using System.Collections.Generic;
using learn_dotnet.Models;
using learn_dotnet.Interfaces;
using MongoDB.Driver;

namespace learn_dotnet.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerRepository(ICustomersMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.CollectionName);
        }

        public List<Customer> GetAll()
        {
            return _customers.Find(customer => true).ToList();
        }

         public Customer Get(string id)
         {
              return _customers.Find<Customer>(
                  customer => customer.Id == id
                ).FirstOrDefault();
         }

         public Customer Create(Customer customer)
         {
            _customers.InsertOne(customer);
            return customer;
         }

         public void Update(string id, Customer newCustomer)
         {
             _customers.ReplaceOne(customer => customer.Id == id, newCustomer);
         }

         public void Delete(string id)
         {
            _customers.DeleteOne(customer => customer.Id == id);
         }
    }
}