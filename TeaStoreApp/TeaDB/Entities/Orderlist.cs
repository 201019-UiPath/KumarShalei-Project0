using System;
using System.Collections.Generic;

namespace TeaDB.Entities
{
    public partial class Orderlist
    {
        public int? Orderid { get; set; }
        public int? Product { get; set; }
        public int? Amount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products ProductNavigation { get; set; }
    }
}
