using System;
using System.Collections.Generic;
using ProjektWzorce.Concrete.FactoryMethod;

namespace ProjektWzorce.Abstract
{
    public interface IAbstractFactory
    {

        public abstract List<IFurniture> CreateFurnitureSet(string color, float chairPrice, float coffeTablePrice, float sofaPrice);
        public abstract ChairCreator CreateChair(string color, float price);
        public abstract CoffeTableCreator CreateCoffeTable(string color, float price);
        public abstract SofaCreator CreateSofa(string color, float price);

    }
}
