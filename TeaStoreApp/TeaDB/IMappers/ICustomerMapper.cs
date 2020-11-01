using TeaDB.Entities;
using TeaDB.Models;
using System.Collections.Generic;

namespace TeaDB.IMappers
{
    public interface ICustomerMapper
    {
        Customers ParseCustomer(CustomerModel customer);
        ICollection<Customers> ParseCustomer(List<CustomerModel> customer);
        CustomerModel ParseCustomer(Customers customer);
        List<CustomerModel> ParseCustomer(ICollection<Customers> customer);
    }
}
