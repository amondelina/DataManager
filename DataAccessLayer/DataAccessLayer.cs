using System;
using System.Data.SqlClient;
using Models;
using OptionsManager;
using System.Transactions;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        SqlConnection connection;
        public DataAccessLayer(ConnectionOptions options)
        {
            using(var ts = new TransactionScope())
            {
                connection = new SqlConnection($"Data Source={options.DataSource}; Database={options.Database}; User ID ={options.User}; Password={options.Password}; Integrated Security={options.IntegratedSecurity}");
                connection.Open();
                ts.Complete();
            }
        }
        public Address GetAddress(int id)
        {
            Address address;
            var command = new SqlCommand("GetAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                reader.Read();
                address = new Address
                {
                    AddressID = reader.GetInt32(0),
                    AddressLine1 = reader.GetString(1),
                    AddressLine2 = reader.IsDBNull(2) ? null : reader.GetString(2),
                    City = reader.GetString(3),
                    StateProvinceID = reader.GetInt32(4),
                    PostalCode = reader.GetString(5),
                    rowguid = reader.GetGuid(7),
                    ModifiedDate = reader.GetDateTime(8)
                };
                reader.Close();
                ts.Complete();
            }
            return address;
        }
        public EmailAddress GetEmailAddress(int id)
        {
            EmailAddress email;
            var command = new SqlCommand("GetEmailAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var businessEntityID = reader.GetInt32(0);
                email = new EmailAddress
                {
                    EmailAddressID = reader.GetInt32(1),
                    EmailAddress1 = reader.GetString(2),
                    rowguid = reader.GetGuid(3),
                    ModifiedDate = reader.GetDateTime(4)
                };
                reader.Close();
                email.BusinessEntity = GetBusinessEntity(businessEntityID);
                ts.Complete();
            }
            return email;
        }
        public BusinessEntity GetBusinessEntity(int id)
        {
            BusinessEntity businessEntity;
            var command = new SqlCommand("GetBusinessEntity", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using(var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                reader.Read();
                businessEntity = new BusinessEntity
                {
                    BusinessEntityID = reader.GetInt32(0),
                    rowguid = reader.GetGuid(1),
                    ModifiedDate = reader.GetDateTime(2)

                };
                reader.Close();
                ts.Complete();
                
            }
            return businessEntity;
        }
        public PersonPhone GetPersonPhone(int id)
        {
            PersonPhone phone;
            var command = new SqlCommand("GetPersonPhone", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var businessEntityID = reader.GetInt32(0);
                var typeId = reader.GetInt32(2);
                phone = new PersonPhone
                {
                    PhoneNumber = reader.GetString(1),
                    ModifiedDate = reader.GetDateTime(3)
                };
                reader.Close();
                phone.BusinessEntity = GetBusinessEntity(businessEntityID);
                phone.PhoneNumberType = GetPhoneNumberType(typeId);
                ts.Complete();
            }
            return phone;
        }
        public PhoneNumberType GetPhoneNumberType(int id)
        {
            PhoneNumberType phoneNumberType;
            var command = new SqlCommand("GetPhoneNumberType", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                reader.Read();
                phoneNumberType = new PhoneNumberType
                {
                    PhoneNumberTypeID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ModifiedDate = reader.GetDateTime(2)
                };
                ts.Complete();
                reader.Close();
            }
            return phoneNumberType;
        }
        public void Write(string message)
        {
            var command = new SqlCommand("Write", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@time", DateTime.Now);
            using (var ts = new TransactionScope())
            {
                command.ExecuteScalar();
                ts.Complete();
            }
        }
    }
}
