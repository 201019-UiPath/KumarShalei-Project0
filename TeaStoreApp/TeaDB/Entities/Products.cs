using System;
using System.Collections.Generic;

namespace TeaDB.Entities
{
    public partial class Products
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public decimal? Price { get; set; }
        public string Funfact { get; set; }
    }
}
