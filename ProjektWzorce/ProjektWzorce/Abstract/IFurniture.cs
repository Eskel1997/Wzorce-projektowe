using System;
using ProjektWzorce.Enums;

namespace ProjektWzorce.Abstract
{
    public interface IFurniture
    {
        public string Color { get; set; }
        public  FurnitureType Type { get; set; }
        public  FurnitureStyleEnum Style { get; set; }
        public float Price { get; set; }
        public abstract string Describe(); 
        public abstract IFurniture CreateFurniture(string color, FurnitureStyleEnum style, float price);

    }
}
