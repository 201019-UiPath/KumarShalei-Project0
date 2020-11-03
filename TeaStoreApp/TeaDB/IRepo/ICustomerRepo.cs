using TeaDB.Models;
using System.Collections.Generic;
namespace TeaDB.IRepo
{
    public interface ICustomerRepo
    {
        void NewCustomerAsync(CustomerModel customer);
        CustomerModel GetCustomerInfo(string email);
        List<OrderModel> GetOrderHistory(CustomerModel customer);
        
    }
}