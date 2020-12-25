using System;
using System.Data.SqlClient;
using Models;
using OptionsManager;
using System.Transactions;
using System.Threading.Tasks;

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
        public async  Task<Address> GetAddress(int id)
        {
            Address address;
            var command = new SqlCommand("GetAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                await reader.ReadAsync();
                address = new Address
                {
                    
                    AddressID = await reader.GetFieldValueAsync<int>(0),
                    AddressLine1 = await reader.GetFieldValueAsync<string>(1),
                    AddressLine2 = reader.IsDBNull(2) ? null : await reader.GetFieldValueAsync<string>(2),
                    City = await reader.GetFieldValueAsync<string>(3),
                    StateProvinceID = await reader.GetFieldValueAsync<int>(4),
                    PostalCode = await reader.GetFieldValueAsync<string>(5),
                    rowguid = await reader.GetFieldValueAsync<Guid>(7),
                    ModifiedDate = await reader.GetFieldValueAsync<DateTime>(8)
                };
                reader.Close();
                ts.Complete();
            }
            return address;
        }
        public async Task<EmailAddress> GetEmailAddress(int id)
        {
            EmailAddress email;
            var command = new SqlCommand("GetEmailAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                await reader.ReadAsync();
                var businessEntityID = await reader.GetFieldValueAsync<int>(0);
                email = new EmailAddress
                {
                    EmailAddressID = await reader.GetFieldValueAsync<int>(1),
                    EmailAddress1 = await reader.GetFieldValueAsync<string>(2),
                    rowguid = await reader.GetFieldValueAsync<Guid>(3),
                    ModifiedDate = await reader.GetFieldValueAsync<DateTime>(4)
                };
                reader.Close();
                email.BusinessEntity = await GetBusinessEntity(businessEntityID);
                ts.Complete();
            }
            return email;
        }
        public async Task<BusinessEntity> GetBusinessEntity(int id)
        {
            BusinessEntity businessEntity;
            var command = new SqlCommand("GetBusinessEntity", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using(var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                await reader.ReadAsync();
                businessEntity = new BusinessEntity
                {
                    BusinessEntityID = await reader.GetFieldValueAsync<int>(0),
                    rowguid = await reader.GetFieldValueAsync<Guid>(1),
                    ModifiedDate = await reader.GetFieldValueAsync<DateTime>(2)

                };
                reader.Close();
                ts.Complete();
                
            }
            return businessEntity;
        }
        public async Task<PersonPhone> GetPersonPhone(int id)
        {
            PersonPhone phone;
            var command = new SqlCommand("GetPersonPhone", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                await reader.ReadAsync();
                var businessEntityID = reader.GetFieldValueAsync<int>(0);
                var typeId = reader.GetFieldValueAsync<int>(2);
                phone = new PersonPhone
                {
                    PhoneNumber = await reader.GetFieldValueAsync<string>(1),
                    ModifiedDate = await reader.GetFieldValueAsync<DateTime>(3)
                };
                reader.Close();
                phone.BusinessEntity = await GetBusinessEntity(businessEntityID.Result);
                phone.PhoneNumberType = await GetPhoneNumberType(typeId.Result);
                ts.Complete();
            }
            return phone;
        }
        public async Task<PhoneNumberType> GetPhoneNumberType(int id)
        {
            PhoneNumberType phoneNumberType;
            var command = new SqlCommand("GetPhoneNumberType", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (var ts = new TransactionScope())
            {
                var reader = command.ExecuteReader();
                await reader.ReadAsync();
                phoneNumberType = new PhoneNumberType
                {
                    PhoneNumberTypeID = await reader.GetFieldValueAsync<int>(0),
                    Name = await reader.GetFieldValueAsync<string>(1),
                    ModifiedDate = await reader.GetFieldValueAsync<DateTime>(2)
                };
                ts.Complete();
                reader.Close();
            }
            return phoneNumberType;
        }
        public async Task Write(string message)
        {
            var command = new SqlCommand("Write", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@time", DateTime.Now);
            using (var ts = new TransactionScope())
            {
                Task task = new Task(() => command.ExecuteScalar());
                await task;
                ts.Complete();
            }
        }
    }
}
