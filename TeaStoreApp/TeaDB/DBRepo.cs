using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeaDB.Entities;
using TeaDB.Models;
using TeaDB.IMappers;
using TeaDB.IRepo;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TeaDB
{
    public class DBRepo : ICustomerRepo, IInventoryRepo, ILocationRepo, IOrderListRepo, IOrderRepo, IProductRepo

    {
        private readonly TeaContext context;
        private readonly IMapper mapper; 
        public DBRepo(){
            this.context = new TeaContext();
            this.mapper = new DBMapper();
        }



        public List<OrderModel> GetOrderHistory(int id)
        {
           return mapper.ParseOrder(
                context.Orders
                .Include("orderlist")
                .Where(i => i.Customerid == id && i.Payed == true)
                .ToList()
            );
        }


        public void NewCustomerAsync(CustomerModel customer)
        {
            context.Customers.AddAsync(mapper.ParseCustomer(customer));
            context.SaveChangesAsync();
        }

        public CustomerModel GetCustomer(int id){
            return mapper.ParseCustomer(
                context.Customers
                .SingleOrDefault(i => i.Customerid == id)
            );
        }





        public void ReplenishStock(int locationid, int productid, int amount)
        {
            var stock = 
                context.Inventory
                .First(i => i.Locationid == locationid && i.Product == productid)
            ;           
            stock.Stock += amount;
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








        public void AddProductToOrderList(OrderListModel order)
        {
            
            context.Orderlist.Add(mapper.ParseOrderList(order));
            context.SaveChanges();
        }

        public void DeleteProductFromOrderList(int orderid, int productid)
        {
            var order = mapper.ParseOrderList(context.Orderlist.First(i => i.Orderid == orderid && i.Product == productid));
            context.Orderlist.Remove(mapper.ParseOrderList(order));
            context.SaveChanges();
        }

        
        public List<OrderListModel> GetItemsInBasket(int orderid){
            return mapper.ParseOrderList(
                context.Orderlist
                .Where(i => i.Orderid == orderid)
                .ToList()
            );
        }








        public void NewOrder(int customerid, int locationid)
        {
            Orders order = new Orders{
                Customerid = customerid,
                Locationid = locationid
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int orderid)
        {
            var order = mapper.ParseOrder(context.Orders.First(i=>i.Orderid ==orderid));
            context.Orders.Remove(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public bool OldOrder(int customerId, int locationId)
        {
            var order = context.Orders.First(i => i.Locationid == locationId && i.Customerid == customerId);
            return Convert.ToBoolean(order.Payed);
        }

        public int GetOrderId(int customerid, int locationId){
            var Id =  mapper.ParseOrder(
                context.Orders.Where(i => i.Customerid == customerid).First(i => i.Locationid == locationId && i.Payed == false)
            );
            return Id.id;

        }



        public void PlaceOrder(int orderid){
            var orders = context.Orders.First(i => i.Orderid == orderid);
            orders.Payed = true;
            context.SaveChanges();
        }




       


        




        public ProductModel GetProductFunFact(int id)
        {
            return mapper.ParseProduct(context.Products.First(p => p.Productid == id));
        }
    }
}