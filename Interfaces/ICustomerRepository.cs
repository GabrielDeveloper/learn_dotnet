using System.Collections.Generic;
using learn_dotnet.Models;


namespace learn_dotnet.Interfaces
{
    public interface ICustomerRepository
    {
         public List<Customer> GetAll();

         public Customer Get(string id);

         public Customer Create(Customer customer);

         public void Update(string id, Customer customer);

         public void Delete(string id);
    }
}