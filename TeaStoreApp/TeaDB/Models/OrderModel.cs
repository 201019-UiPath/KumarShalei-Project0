namespace TeaDB.Models
{
    public class OrderModel
    {
        public int id{get;set;}
        public int customerId{get;set;}
        public int locationId{get;set;}
        public bool complete{get;set;}
    }
}