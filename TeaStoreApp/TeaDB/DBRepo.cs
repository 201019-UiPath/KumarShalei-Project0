using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeaDB.Entities;
using TeaDB.Models;
using TeaDB.IMappers;
using TeaDB.IRepo;
using System.Threading.Tasks;
using System.Linq;

namespace TeaDB
{
    public class DBRepo : ICustomerRepo, IInventoryRepo, ILocationRepo, IOrderListRepo, IOrderRepo, IProductRepo

    {
        private readonly TeaContext context;
        private readonly IMapper mapper; 
        public DBRepo(TeaContext context, IMapper mapper){
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProductToOrderList(OrderListModel order)
        {
            context.Orderlist.Add(mapper.ParseOrderList(order));
            context.SaveChanges();
        }

        public void DeleteProductFromOrderList(OrderListModel order)
        {
            context.Orderlist.Remove(mapper.ParseOrderList(order));
            context.SaveChanges();
        }

        public ProductModel GetProductFunFact(int id)
        {
            return mapper.ParseProduct(context.Products.First(p => p.Productid == id));
        }

        public void NewOrder(OrderModel order)
        {
            context.Orders.Add(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public void DeleteOrder(OrderModel order)
        {
            context.Orders.Remove(mapper.ParseOrder(order));
            context.SaveChanges();
        }


        public List<InventoryModel> GetLocationInventory(int x)
        {
            return mapper.ParseInventory(
                context.Inventory
                .Where(i => i.Locationid == x)
                .ToList()
            );
        }

        public List<OrderModel> GetLocationOrderHistory(int x)
        {
            return mapper.ParseOrder(
                context.Orders
                .Include("OrderList")
                .Where(i => i.Locationid == x)
                .ToList()
            );
        }

        public List<OrderModel> GetOrderHistory(int id)
        {
           return mapper.ParseOrder(
                context.Orders
                .Include("OrderList")
                .Where(i => i.Customerid == id)
                .ToList()
            );
        }


        public void NewCustomerAsync(CustomerModel customer)
        {
            context.Customers.AddAsync(mapper.ParseCustomer(customer));
            context.SaveChangesAsync();
        }


        public void OldOrder(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public void ReplenishStock(int locationid, int productid, int amount)
        {
            var stock = 
                context.Inventory
                .Where(i => i.Locationid == locationid)
                .First(i => i.Product == productid)
            ;
            stock.Stock += amount;
            context.SaveChanges();
            
        }
    }
}