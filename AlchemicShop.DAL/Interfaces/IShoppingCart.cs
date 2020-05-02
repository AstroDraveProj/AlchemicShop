namespace AlchemicShop.DAL.Interfaces
{
    public interface IShoppingCart<T> where T:class
    {
        int GetMax();
    }
}
