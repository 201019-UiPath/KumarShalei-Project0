using System.Threading.Tasks;
using TeaDB.Models;
namespace TeaDB.IRepo
{
    public interface IProductRepo
    {
         ProductModel GetProductFunFact(int id);
    }
}