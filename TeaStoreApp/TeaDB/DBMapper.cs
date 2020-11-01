using System.Collections.Generic;
using TeaDB.Entities;
using TeaDB.Models;
using TeaDB.IMappers;

namespace TeaDB
{
    public class DBMapper : IMapper
    {
        public Customers ParseCustomer(CustomerModel customer)
        {
            return new Customers(){
                Customername = customer.name
            };
        }

        // public ICollection<Customers> ParseCustomer(List<CustomerModel> customer)
        // {
        //     ICollection<Customers> customers = new List<Customers>();
        //     foreach (var c in customer){

        //         customers.Add(ParseCustomer(c));
        //     }
        //     return customers;
        // }

        public CustomerModel ParseCustomer(Customers customer)
        {
            return new CustomerModel(){
                id = customer.Customerid,
                name = customer.Customername
            };
        }

        // public List<CustomerModel> ParseCustomer(ICollection<Customers> customer)
        // {
        //     List<CustomerModel> customers = new List<CustomerModel>();
        //     foreach (var c in customer){
        //         customers.Add(ParseCustomer(c));
        //     }
        //     return customers;
        // }

        public Inventory ParseInventory(InventoryModel inventory)
        {
            return new Inventory(){
                Product = inventory.productId,
                Stock = inventory.stock,
                Locationid = inventory.locationId
            };
        }

        public ICollection<Inventory> ParseInventory(List<InventoryModel> inventory)
        {
            ICollection<Inventory> inventories = new List<Inventory>();
            foreach (var i in inventory){

                inventories.Add(ParseInventory(i));
            }
            return inventories;
        }

        public InventoryModel ParseInventory(Inventory inventorys)
        {
            return new InventoryModel(){
                productId = System.Convert.ToInt32(inventorys.Product),
                stock = System.Convert.ToInt32(inventorys.Stock),
                locationId = System.Convert.ToInt32(inventorys.Locationid)
            };
        }

        public List<InventoryModel> ParseInventory(ICollection<Inventory> inventorys)
        {
            List<InventoryModel> inventory = new List<InventoryModel>();
            foreach (var i in inventorys){
                inventory.Add(ParseInventory(i));
            }
            return inventory;
        }

        public Locations ParseLocation(LocationModel location)
        {
            return new Locations(){
                City = location.city
            };
        }

        public ICollection<Locations> ParseLocation(List<LocationModel> location)
        {
            ICollection<Locations> locations = new List<Locations>();
            foreach (var l in location){

                locations.Add(ParseLocation(l));
            }
            return locations;
        }

        public LocationModel ParseLocation(Locations locations)
        {
            return new LocationModel(){
                id = locations.Locationid,
                city = locations.City
            };
        }

        public List<LocationModel> ParseLocation(ICollection<Locations> locations)
        {
            List<LocationModel> location = new List<LocationModel>();
            foreach (var l in locations){
                location.Add(ParseLocation(l));
            }
            return location;
        }








        public Orders ParseOrder(OrderModel order)
        {
            return new Orders(){
                Customerid = order.customerId,
                Locationid = order.locationId,
                Payed = order.complete
            };
        }

        

        public ICollection<Orders> ParseOrder(List<OrderModel> order)
        {
            ICollection<Orders> orders = new List<Orders>();
            foreach (var o in order){

                orders.Add(ParseOrder(o));
            }
            return orders;
        }

        public OrderModel ParseOrder(Orders orders)
        {
            return new OrderModel(){
                id = orders.Orderid,
                customerId = System.Convert.ToInt32(orders.Customerid),
                locationId = System.Convert.ToInt32(orders.Locationid),
                complete = System.Convert.ToBoolean(orders.Payed)
            };
        }

        public List<OrderModel> ParseOrder(ICollection<Orders> orders)
        {
            List<OrderModel> order = new List<OrderModel>();
            foreach (var o in orders){
                order.Add(ParseOrder(o));
            }
            return order;
        }










        public Orderlist ParseOrderList(OrderListModel orderList)
        {
            return new Orderlist(){
                Orderid = orderList.orderId,
                Product = orderList.productId,
                Amount = orderList.amount
            };
        }

        public ICollection<Orderlist> ParseOrderList(List<OrderListModel> orderList)
        {
            ICollection<Orderlist> orderlists = new List<Orderlist>();
            foreach (var o in orderList){

                orderlists.Add(ParseOrderList(o));
            }
            return orderlists;
        }

        public OrderListModel ParseOrderList(Orderlist orderlist)
        {
            return new OrderListModel(){
                orderId = System.Convert.ToInt32(orderlist.Orderid),
                productId = System.Convert.ToInt32(orderlist.Product),
                amount = System.Convert.ToInt32(orderlist.Amount)
            };
        }

        public List<OrderListModel> ParseOrderList(ICollection<Orderlist> orderlist)
        {
            List<OrderListModel> orderlists = new List<OrderListModel>();
            foreach (var o in orderlist){
                orderlists.Add(ParseOrderList(o));
            }
            return orderlists;
        }

        public Products ParseProduct(ProductModel product)
        {
            return new Products(){
                Productname = product.name,
                Price = product.price,
                Funfact = product.funfact
            };
        }

        public ICollection<Products> ParseProduct(List<ProductModel> product)
        {
            ICollection<Products> products = new List<Products>();
            foreach (var p in product){

                products.Add(ParseProduct(p));
            }
            return products;
        }

        public ProductModel ParseProduct(Products products)
        {
            return new ProductModel(){
                id = products.Productid,
                name = products.Productname,
                price = System.Convert.ToDecimal(products.Price),
                funfact = products.Funfact
            };
        }

        public List<ProductModel> ParseProduct(ICollection<Products> products)
        {
            List<ProductModel> product = new List<ProductModel>();
            foreach (var p in products){
                product.Add(ParseProduct(p));
            }
            return product;
        }
    }
}
