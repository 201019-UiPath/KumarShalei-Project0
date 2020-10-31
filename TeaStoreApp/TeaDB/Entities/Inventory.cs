using System;
using System.Collections.Generic;

namespace TeaDB.Entities
{
    public partial class Inventory
    {
        public int? Product { get; set; }
        public int? Stock { get; set; }
        public int? Locationid { get; set; }

        public virtual Locations Location { get; set; }
        public virtual Products ProductNavigation { get; set; }
    }
}
