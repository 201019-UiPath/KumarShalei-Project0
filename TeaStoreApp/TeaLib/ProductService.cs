using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class ProductService
    {
        
        private IProductRepo repo;

        public ProductService(IProductRepo repo){
            this.repo = repo;
        }

        public ProductModel GetProductFunFact(int id){
            return repo.GetProductFunFact(id);
        }
    }
}