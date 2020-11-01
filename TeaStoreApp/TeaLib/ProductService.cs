using System.Collections.Generic;
using System;
using TeaDB;
using TeaDB.Models;
using TeaDB.IRepo;

namespace TeaLib
{
    public class ProductService
    {
        
        private DBRepo repo;

        public ProductService(){
            this.repo = new DBRepo();
        }

        public ProductModel GetProductFunFact(int id){
            return repo.GetProductFunFact(id);
        }
    }
}