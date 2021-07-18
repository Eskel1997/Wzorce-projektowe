using System;
using ProjektWzorce.Abstract;
using ProjektWzorce.Enums;

namespace ProjektWzorce.Concrete.FactoryMethod
{
    public class ChairCreator : IFurniture
    {
        public string Color { get; set; }
        public FurnitureType Type { get; set; }
        public FurnitureStyleEnum Style { get; set; }
        public float Price { get; set; }

        public ChairCreator(string color, FurnitureStyleEnum style, float price)
        {
            Type = FurnitureType.Chair;
            Color = color;
            Price = price;
            Style = style;
        }

        public string Describe()
        {
            return $"Type: {Enum.GetName(typeof(FurnitureType),Type)}," +
                              $" Color: {Color}, Style: {Enum.GetName(typeof(FurnitureStyleEnum),Style)}, Price: {Price}";
        }

        public IFurniture CreateFurniture(string color, FurnitureStyleEnum style, float price)
        {
            return new ChairCreator(color, style, price);
        }
    }
}
