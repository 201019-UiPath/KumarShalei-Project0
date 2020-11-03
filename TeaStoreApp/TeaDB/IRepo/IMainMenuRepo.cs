using TeaDB.Models;
using System.Collections.Generic;
namespace TeaDB.IRepo
{
    public interface IMainMenuRepo
    {
        void NewCustomerAsync(CustomerModel customer);
        CustomerModel GetCustomerInfo(string email);
        List<OrderModel> GetOrderHistory(CustomerModel customer);

        List<OrderModel> GetOrderHistoryByLeastExpensive(CustomerModel customer);
        List<OrderModel> GetOrderHistoryByMostExpensive(CustomerModel customer);
        
    }
}