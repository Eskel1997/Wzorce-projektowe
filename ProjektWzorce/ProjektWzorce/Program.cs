using ProjektWzorce.Abstract;
using ProjektWzorce.Concrete.AbstractFactory;
using ProjektWzorce.Concrete.Facade;
using ProjektWzorce.Enums;
using System;
using System.Collections.Generic;

namespace ProjektWzorce
{
    public class UI
    {
        private void PrintFurnitureTypes()
        {
            foreach (var type in Enum.GetValues(typeof(FurnitureType)))
            {
                Console.WriteLine($"{(int)type}. {Enum.GetName(typeof(FurnitureType), type)} \n");
            }
        }

        private void PrintFurnitureStyles()
        {
            foreach (var type in Enum.GetValues(typeof(FurnitureStyleEnum)))
            {
                Console.WriteLine(($"{(int)type}. {Enum.GetName(typeof(FurnitureStyleEnum), type)} \n"));
            }
        }

        private void PrintDiscountTypes()
        {
            foreach (var type in Enum.GetValues(typeof(DiscountEnum)))
            {
                Console.WriteLine(($"{(int)type}. {Enum.GetName(typeof(DiscountEnum), type)} \n"));
            }
        }

        private void PrintPaymentTypes()
        {
            foreach (var type in Enum.GetValues(typeof(PaymentEnum)))
            {
                Console.WriteLine(($"{(int)type}. {Enum.GetName(typeof(PaymentEnum), type)} \n"));
            }
        }

        public int UserMenu(FactoryFasade facade, int state)
        {
            switch (state)
                {
                    case 0:
                        Console.WriteLine("1. Order Furniture");
                        Console.WriteLine("2. Crate Furniture Set");
                        Console.WriteLine("3. Change Payment Method");
                        Console.WriteLine("4. Change Discount");
                        Console.WriteLine("5. Remove Item");
                        Console.WriteLine("6. Pay");
                        Console.WriteLine("7. Print shopping list");
                        Console.WriteLine("8. Exit");
                        Console.WriteLine("Select one");
                        var newState = Convert.ToInt32(Console.ReadLine());
                        state = newState;
                        break;
                    case 1:
                        Console.WriteLine("Choose style \n");
                        PrintFurnitureStyles();
                        Console.WriteLine("Select value \n");
                        var style = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose type \n");
                        PrintFurnitureTypes();
                        var type = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose color \n");
                        string color = Console.ReadLine();
                        facade.Operation((FurnitureStyleEnum)style, (FurnitureType)type, color);
                        state = 0;
                        break;
                    case 2:
                        Console.WriteLine("Choose style \n");
                        PrintFurnitureStyles();
                        Console.WriteLine("Select value \n");
                        var setStyle = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose color \n");
                        string setColor = Console.ReadLine();
                        facade.CreateFurnitureSet(setColor, (FurnitureStyleEnum)setStyle);
                        state = 0;
                        break;
                    case 3:
                        Console.WriteLine("Select Payment method \n");
                        PrintPaymentTypes();
                        var paymentType = Convert.ToInt32(Console.ReadLine());
                        facade.ChangePayment((PaymentEnum)paymentType);
                        state = 0;
                        break;
                    case 4:
                        Console.WriteLine("Select discount \n");
                        PrintDiscountTypes();
                        var discountType = Convert.ToInt32(Console.ReadLine());
                        facade.MakeDiscount((DiscountEnum)discountType);
                        state = 0;
                        break;
                    case 5:
                        facade.PrintBasketItems();
                        Console.WriteLine("Select item \n");
                        var item = Convert.ToInt32(Console.ReadLine());
                        facade.Remove(item);
                        state = 0;
                        break;
                    case 6:
                        facade.Pay();
                        state = 0;
                        break;
                    case 7:
                        Console.WriteLine("\n");
                        facade.PrintBasketItems();
                        Console.WriteLine("\n");
                        state = 0;
                        break;
                    case 8:
                        break;
                    default:
                        state = 0;
                        break; ;
                }

            return state;
        }
    }
     class Program
    {
        

        static void Main(string[] args)
        {
            var userMenu = new UI();
            var modernFactory = new ModernFactory("Rzeszow", "Warszawska", "23");
            var victorianFactory = new VictorianFactory("Warsaw", "Krakowska", "14");
            var ardDecoFactory = new ArtDecoFactory("Rzeszów", "Lubelska", "26");
            int state = 0;
            var shoppingList = new List<IFurniture>();
            var facade = new FactoryFasade(ardDecoFactory, modernFactory, victorianFactory, shoppingList);

            while (state < 8)
            {
                state = userMenu.UserMenu(facade, state);
            }
        }
    }
}
