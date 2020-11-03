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
    public class DBRepo : ICustomerRepo, IManagerRepo, ILocationRepo, IOrderRepo

    {
        private readonly TeaContext context;
        private readonly IMapper mapper; 
        public DBRepo(){
            this.context = new TeaContext();
            this.mapper = new DBMapper();
        }




        public void NewCustomerAsync(CustomerModel customer)
        {
            context.Customers.AddAsync(mapper.ParseCustomer(customer));
            context.SaveChangesAsync();
        }

        public CustomerModel GetCustomerInfo(string email)
        {
            return mapper.ParseCustomer(
                context.Customers
                .First(c => c.Customeremail == email)
            );
        }

        public List<OrderModel> GetOrderHistory(CustomerModel customer)
        {
            return mapper.ParseOrder(
                context.Orders
                .Include("OrderItems")
                .Where(c => c.Customerid == customer.id && c.Payed == true)
                .ToList()
            );
        }



       
            

        public void ReplenishStock(InventoryModel inventory, int amount)
        {
            var stock = 
                context.Inventory
                .First(i => i == mapper.ParseInventory(inventory))
            ;           
            stock.Stock += amount;
            context.SaveChanges();           
        }







        public List<OrderModel> GetLocationOrderHistory(int x)
        {
            return mapper.ParseOrder(
                context.Orders
                .Include("OrderItems")
                .Where(i => i.Locationid == x)
                .ToList()
            );
        }


        public List<InventoryModel> GetLocationInventory(int x)
        {
            return mapper.ParseInventory(
                context.Inventory
                .Include("Products")
                .Where(i => i.Locationid == x)
                .ToList()
            );
        }







        public void NewOrder(OrderModel order)
        {
            
            context.Orders.Add(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public OrderModel GetCurrentOrder(int customerid, int locationid){
            return mapper.ParseOrder(
                context.Orders
                .First(o => o.Customerid == customerid && o.Locationid == locationid)
            );
        }

        public void AddProductToOrderItem(OrderItemModel order)
        {
            context.Orderitems.Add(mapper.ParseOrderItem(order));
            context.SaveChanges();
        }

        public void DeleteProductFromOrderItem(OrderItemModel order)
        {
            context.Orderitems.Remove(mapper.ParseOrderItem(order));
            context.SaveChanges();
        }

        
        public List<OrderItemModel> GetItemsInBasket(int orderid){
            return mapper.ParseOrderItem(
                context.Orderitems
                .Where(i => i.Orderid == orderid)
                .ToList()
            );
        }

        

        public void DeleteOrder(OrderModel order)
        {
            context.Orders.Remove(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        

        public int GetOrderId(CustomerModel customer, int locationId){
            var order =  mapper.ParseOrder(
                context.Orders
                .Where(o => o.Customerid == customer.id)
                .First(o => o.Locationid == locationId && o.Payed == false)
            );
            if(order != null){
                return order.id;
            } else {return -1;}

        }

        



        public void PlaceOrder(OrderModel order){
            var orders = context.Orders.First(i => i.Orderid == order.id);
            orders.Payed = true;
            context.SaveChanges();
        }




       
        

        public void ChangeOrderTotalPrice(OrderModel order, decimal amount)
        {
            var orders = context.Orders.First(i => i == mapper.ParseOrder(order));
            orders.Totalprice += amount;
            context.SaveChanges();
        }






        // public ProductModel GetProductFunFact(int id)
        // {
        //     return mapper.ParseProduct(context.Products.First(p => p.Productid == id));
        // }


    }
}