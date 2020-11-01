using System;
using Xunit;
using TeaDB;
using TeaDB.Entities;
using TeaDB.IMappers;
using TeaDB.Models;
using TeaDB.IRepo;
using TeaDB;
using TeaLib;

namespace TeaTest
{
    public class TeaTests
    {
        [Fact]
        public void GetCustomerShouldGetCustomer()
        {
            
            CustomerService repo= new CustomerService();
            
            int x = 1;
            CustomerModel test1 = new CustomerModel(){
                id = 1,
                name = "Laramie"
            };
            var customer = repo.GetCustomer(x);

            Assert.Equal(customer, test1);
        }
    }
}
