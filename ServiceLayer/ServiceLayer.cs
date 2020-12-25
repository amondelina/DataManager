using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
using Parser;
using System.IO;

namespace ServiceLayer
{
    public class ServiceLayer
    {
        DataAccessLayer.DataAccessLayer DAL;
        DataAccessLayer.DataAccessLayer Log;
        OptionsManager.OptionsManager manager;
        ParserToXML parser;
        bool first = true;
        public ServiceLayer()
        {
            manager = new DMOptionsManager();
            DAL = new DataAccessLayer.DataAccessLayer(manager.GetOptions<ConnectionOptions>() as ConnectionOptions);
            Log = new DataAccessLayer.DataAccessLayer((manager.GetOptions<SendingOptions>() as SendingOptions).LogOptions);
            parser = new ParserToXML();
        }
        public async  Task<Contacts> CreateContacts(int PhoneId, int AddressId, int EmailId)
        {
            Address address;
            EmailAddress email;
            PersonPhone phone;
            try
            {
                address = await DAL.GetAddress(AddressId);
            }
            catch(Exception e)
            {
                address = null;
                await Log.Write(e.Message);
            }
            try
            {
                email = await DAL.GetEmailAddress(EmailId);
            }
            catch (Exception e)
            {
                email = null;
                await Log.Write(e.Message);
            }
            try
            {
                phone = await DAL.GetPersonPhone(PhoneId);
            }
            catch (Exception e)
            {
                phone = null;
                await Log.Write(e.Message);
            }
            return  new Contacts
            {

                Address = address,
                EmailAddress = email,
                PersonPhone = phone
            };
        }
        public async Task<string> CreateXML (Contacts contacts)
        {
            if (first == true)
            {
                await CreateFile("Contacts", parser.GenerateXSDSchema<Contacts>(), ".xsd");
                first = false;
            }
            return parser.GenerateXML(contacts);
        }
        public async Task CreateFile(string name, string content, string ext)
        {
            var dir = (manager.GetOptions<SendingOptions>() as SendingOptions).Directory;
            var path = Path.Combine(dir, name + ext);
            try
            {
                using (var sw = new StreamWriter(path))
                    await sw.WriteAsync(content);
            }
            catch(Exception e)
            {
               await Log.Write(e.Message);
            }
            
        }        

    }
}
