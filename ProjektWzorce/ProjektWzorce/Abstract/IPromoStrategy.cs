using System.Collections.Generic;

namespace ProjektWzorce.Abstract
{
    public interface IPromoStrategy
    {
        float Discount(float bill, List<IFurniture> shoppingList);
    }
}
