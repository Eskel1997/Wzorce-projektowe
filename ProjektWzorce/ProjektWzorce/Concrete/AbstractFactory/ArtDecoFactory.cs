using ProjektWzorce.Abstract;
using ProjektWzorce.Concrete.FactoryMethod;
using ProjektWzorce.Enums;
using System;
using System.Collections.Generic;

namespace ProjektWzorce.Concrete.AbstractFactory
{
    public class ArtDecoFactory : IAbstractFactory
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public ArtDecoFactory(string city, string street, string number)
        {
            City = city;
            Street = street;
            Number = number;
        }

        public void Describe()
        {
            Console.WriteLine($"City: {City}, Street: {Street}, Number: {Number}");
        }

        public List<IFurniture> CreateFurnitureSet(string color,float chairPrice, float coffeTablePrice, float sofaPrice)
        {
            var list = new List<IFurniture>();
            list.Add(new ChairCreator(color, FurnitureStyleEnum.ArtDeco, chairPrice));
            list.Add(new CoffeTableCreator(color, FurnitureStyleEnum.ArtDeco, coffeTablePrice));
            list.Add(new SofaCreator(color, FurnitureStyleEnum.ArtDeco, sofaPrice));

            return list;
        }

        public ChairCreator CreateChair(string color, float price)
        {
            return new ChairCreator(color, FurnitureStyleEnum.ArtDeco, price);
        }

        public CoffeTableCreator CreateCoffeTable(string color, float price)
        {
            return new CoffeTableCreator(color, FurnitureStyleEnum.ArtDeco, price);
        }

        public SofaCreator CreateSofa(string color, float price)
        {
            return new SofaCreator(color, FurnitureStyleEnum.ArtDeco, price);
        }
    }
}
