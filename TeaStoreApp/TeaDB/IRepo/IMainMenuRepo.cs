using TeaDB.Models;
namespace TeaDB.IRepo
{
    public interface IMainMenuRepo
    {
        void NewCustomerAsync(CustomerModel customer);
        CustomerModel GetCustomerInfo(string email);        
    }
}