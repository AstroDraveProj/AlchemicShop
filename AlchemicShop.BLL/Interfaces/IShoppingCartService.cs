namespace AlchemicShop.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        int GetMax();

        int GetOrderId(string s);
    }
}
