using System;
using Xunit;
using TeaDB;
using TeaDB.Entities;
using TeaDB.IMappers;
using TeaDB.Models;
using TeaDB.IRepo;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TeaLib;

namespace TeaTest
{
    public class TeaTests
    {
        private readonly IMapper mapper = new DBMapper();
        private DBRepo repo;

        private readonly CustomerModel testCustomer = new CustomerModel(){
            firstName = "Sahaj",
            lastName = "Kumar",
            email = "skum@yahoo.com"
        };

        private readonly Customers testCustomer2 = new Customers(){
            Customerid = 1,
            Customerfirstname = "Customer",
            Customerlastname = "Test",
            Customeremail = "test@yahoo.com"
        };

        private readonly OrderModel testOrder = new OrderModel(){
            customerId = 2,
            locationId = 1,
            totalPrice = Convert.ToDecimal(4.99),
            complete = false
        };

        private readonly OrderItemModel testOrderItem = new OrderItemModel(){
            orderId = 10,
            productId = 1,
            amount = 1,
            totalPrice = Convert.ToDecimal(5.99)
        };

        private readonly Products testProduct = new Products(){
            Productid = 1,
            Productname = "Test Tea",
            Numberofteabags = 10,
            Price = Convert.ToDecimal(5.99),
            Description = "this is a test"
        };
        private void Seed(TeaContext testcontext)
        {
            testcontext.Products.AddRange(testProduct);
            testcontext.Customers.AddRange(testCustomer2);
            testcontext.SaveChanges();
        }

        [Fact]
        public void NewCustomerShouldAddCustomer()
        {
            
            var options = new DbContextOptionsBuilder<TeaContext>().UseInMemoryDatabase("NewCustomerShouldAddCustomer").Options;
            using var testContext = new TeaContext(options);
            repo = new DBRepo(){
                context = testContext,
                mapper = mapper
            };
            
            //Act
            repo.NewCustomerAsync (testCustomer);

            //Assert
            using var assertContext = new TeaContext(options);
            Assert.NotNull(assertContext.Customers.Single(h => h.Customeremail == testCustomer.email));
        }






        [Fact]
        public void NewOrderShouldCreateNewOrder()
        {
            
            var options = new DbContextOptionsBuilder<TeaContext>().UseInMemoryDatabase("NewOrderShouldCreateNewOrder").Options;
            using var testContext = new TeaContext(options);
            repo = new DBRepo(){
                context = testContext,
                mapper = mapper
            };
            
            //Act
            repo.NewOrder(testOrder);

            //Assert
            using var assertContext = new TeaContext(options);
            Assert.NotNull(assertContext.Orders.Single(h => h.Customerid == testOrder.customerId && h.Locationid == testOrder.locationId ));
        }

        [Fact]
        public void NewOrderItemShouldCreateNewOrderItem()
        {
            
            var options = new DbContextOptionsBuilder<TeaContext>().UseInMemoryDatabase("NewOrderItemShouldCreateNewOrderItem").Options;
            using var testContext = new TeaContext(options);
            repo = new DBRepo(){
                context = testContext,
                mapper = mapper
            };
            
            //Act
            repo.AddProductToOrderItem(testOrderItem);

            //Assert
            using var assertContext = new TeaContext(options);
            Assert.NotNull(assertContext.Orderitems.First(h => h.Orderid == testOrderItem.orderId));
        }


        [Fact]
        public void GetProductShouldGetProduct()
        {
            
            var options = new DbContextOptionsBuilder<TeaContext>().UseInMemoryDatabase("GetProductShouldGetProduct").Options;
            using var testContext = new TeaContext(options);
            repo = new DBRepo(){
                context = testContext,
                mapper = mapper
            };
            Seed(testContext);
            //Act
            var result = repo.GetProduct(1);

            //Assert
            using var assertContext = new TeaContext(options);
            Assert.Equal(result.id, testProduct.Productid);
        }



        [Fact]
        public void GetCustomerShouldGetCustomer()
        {
            
            var options = new DbContextOptionsBuilder<TeaContext>().UseInMemoryDatabase("GetCustomerShouldGetCustomer").Options;
            using var testContext = new TeaContext(options);
            repo = new DBRepo(){
                context = testContext,
                mapper = mapper
            };
            Seed(testContext);
            //Act
            var result = repo.GetCustomerInfo(testCustomer2.Customeremail);

            //Assert
            using var assertContext = new TeaContext(options);
            Assert.Equal(result.email, testCustomer2.Customeremail);
        }
       
        

        
    }
}
