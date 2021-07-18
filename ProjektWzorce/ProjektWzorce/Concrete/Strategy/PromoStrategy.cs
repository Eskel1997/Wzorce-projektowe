using ProjektWzorce.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektWzorce.Concrete.Strategy
{
    public class FurnitureSetPromoStrategy : IPromoStrategy
    {
        public float Discount(float bill, List<IFurniture> shoppingList)
        {
            if (shoppingList.Count() >= 3)
            {
                return bill - (0.15f* bill);
            }
            Console.WriteLine("Minimum 3 items");
            return bill;
        }
    }

    public class BigShopping : IPromoStrategy
    {
        public float Discount(float bill, List<IFurniture> shoppingList)
        {
            if (shoppingList.Count() >= 5)
            {
                return bill - (0.15f* bill);
            }
            Console.WriteLine("Minimum 5 items");
            return bill;
        }
    }

    public class NormalShopping : IPromoStrategy
    {
        public float Discount(float bill, List<IFurniture> shoppingList)
        {
            return bill;
        }
    }
}
