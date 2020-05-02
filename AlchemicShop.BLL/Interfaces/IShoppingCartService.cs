using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        int GetMax();

        int GetOrderId(string s);
    }
}
