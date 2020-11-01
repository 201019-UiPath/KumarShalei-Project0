namespace TeaDB.IRepo
{
    public interface IInventoryRepo
    {
         void ReplenishStock(int locationid, int productid, int amount);
    }
}