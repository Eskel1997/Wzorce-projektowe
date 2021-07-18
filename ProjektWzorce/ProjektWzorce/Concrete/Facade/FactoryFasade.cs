using ProjektWzorce.Abstract;
using ProjektWzorce.Concrete.AbstractFactory;
using ProjektWzorce.Concrete.Strategy;
using ProjektWzorce.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektWzorce.Concrete.Facade
{
    public class FactoryFasade
    {
        protected ArtDecoFactory ArtDecoFactory;
        protected ModernFactory ModernFactory;
        protected VictorianFactory VictorianFactory;
        protected IPaymentStrategy PaymentStrategy = new CashStrategy();
        protected IPromoStrategy PromoStrategy = new NormalShopping();
        public List<IFurniture> ShoppingList;

        public FactoryFasade(
            ArtDecoFactory artDecoFactory,
            ModernFactory modernFactory,
            VictorianFactory victorianFactory,
            List<IFurniture> shoppingList)
        {
            ArtDecoFactory = artDecoFactory;
            ModernFactory = modernFactory;
            VictorianFactory = victorianFactory;
            ShoppingList = shoppingList;
        }

        public void Operation(FurnitureStyleEnum style, FurnitureType type, string color)
        {
            switch (style)
            {
                case FurnitureStyleEnum.ArtDeco:
                    if (type == FurnitureType.Chair)
                    {
                        ShoppingList.Add(ArtDecoFactory.CreateChair(color, 15));
                    }

                    if (type == FurnitureType.CoffeTable)
                    {
                        ShoppingList.Add(ArtDecoFactory.CreateCoffeTable(color, 50));
                    }

                    if (type == FurnitureType.Sofa)
                    {
                        ShoppingList.Add(ArtDecoFactory.CreateSofa(color, 100));
                    }
                    break;
                case FurnitureStyleEnum.Modern:
                    if (type == FurnitureType.Chair)
                    {
                        ShoppingList.Add(ModernFactory.CreateChair(color, 20));
                    }

                    if (type == FurnitureType.CoffeTable)
                    {
                        ShoppingList.Add(ModernFactory.CreateCoffeTable(color, 70));
                    }

                    if (type == FurnitureType.Sofa)
                    {
                        ShoppingList.Add(ModernFactory.CreateSofa(color, 250));
                    }
                    break;
                case FurnitureStyleEnum.Victorian:
                    if (type == FurnitureType.Chair)
                    {
                        ShoppingList.Add(VictorianFactory.CreateChair(color, 60));
                    }

                    if (type == FurnitureType.CoffeTable)
                    {
                        ShoppingList.Add(VictorianFactory.CreateCoffeTable(color, 180));
                    }

                    if (type == FurnitureType.Sofa)
                    {
                        ShoppingList.Add(VictorianFactory.CreateSofa(color, 450));
                    }
                    break;
            }
        }

        public void CreateFurnitureSet(string color, FurnitureStyleEnum style)
        {
            switch (style)
            {
                case FurnitureStyleEnum.ArtDeco:
                    ShoppingList.AddRange(ArtDecoFactory.CreateFurnitureSet(color, 15,50,100));
                    break;
                case FurnitureStyleEnum.Modern:
                    ShoppingList.AddRange(ModernFactory.CreateFurnitureSet(color, 20,70,250));
                    break;
                case FurnitureStyleEnum.Victorian:
                    ShoppingList.AddRange(VictorianFactory.CreateFurnitureSet(color,60,180,450));
                    break;
            }
        }

        public void ChangePayment(PaymentEnum type)
        {
            switch (type)
            {
                case PaymentEnum.Blik:
                    this.PaymentStrategy = new BlikStrategy();
                    break;
                case PaymentEnum.Card:
                    this.PaymentStrategy = new CardStrategy();
                    break;
                case PaymentEnum.Cash:
                    this.PaymentStrategy = new CashStrategy();
                    break;
                default:
                    this.PaymentStrategy = new CashStrategy();
                    break;
            }
        }

        public void MakeDiscount(DiscountEnum type)
        {
            switch (type)
            {
                case DiscountEnum.BigSale:
                    this.PromoStrategy = new BigShopping();
                    break;
                case DiscountEnum.MiniSale:
                    this.PromoStrategy = new FurnitureSetPromoStrategy();
                    break;
                default:
                    this.PromoStrategy = new NormalShopping();
                    break;
                    
            }

            var bill = this.ShoppingList.Sum(p => p.Price);
            Console.WriteLine($"Chosen strategy: {Enum.GetName(typeof(DiscountEnum), type)}");
            Console.WriteLine($"Before discount: {bill}");
            Console.WriteLine($"After discount: {this.PromoStrategy.Discount(bill, this.ShoppingList)}");
        }

        public void Pay()
        {
            var bill = this.ShoppingList.Sum(p => p.Price);
            var endBill = this.PromoStrategy.Discount(bill, ShoppingList);
            Console.WriteLine(this.PaymentStrategy.Pay(endBill));
            this.ShoppingList.Clear();
        }

        public void PrintBasketItems()
        {
            int i = 0;
            this.ShoppingList.ForEach(p =>
            {
                i++;
                Console.WriteLine($"{i}. {p.Describe()}");
            });
        }
        public void Remove(int itemNumber)
        {
            if (itemNumber > 0 && itemNumber <= ShoppingList.Count)
            {
                ShoppingList.RemoveAt(itemNumber - 1);
            }
            else
            {
                Console.WriteLine("Item not exist \n");
            }
        }
    }
}
