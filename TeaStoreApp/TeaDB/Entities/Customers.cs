using System;
using System.Collections.Generic;

namespace TeaDB.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Customerid { get; set; }
        public string Customername { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
