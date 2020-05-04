namespace AlchemicShop.DAL.Interfaces
{
    public interface IShoppingCart<T> where T:class
    {
        int GetMax();

        int GetMaxId(string s);
    }
}
