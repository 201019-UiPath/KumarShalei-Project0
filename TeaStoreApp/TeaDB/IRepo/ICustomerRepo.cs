using TeaDB.Models;
using System.Collections.Generic;
namespace TeaDB.IRepo
{
    public interface ICustomerRepo
    {
        void NewCustomerAsync(CustomerModel customer);
        List<OrderModel> GetOrderHistory(int id);
        
    }
}