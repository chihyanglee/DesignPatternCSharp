using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            // Get a ProductA
            IProductFactory factoryA = new ProductAFactory();
            var productA = factoryA.CreateProduct();

            // Get a ProductB
            IProductFactory factoryB = new ProductBFactory();
            var productB = factoryB.CreateProduct();
        }
    }
    /*
    * 抽象化的ProductFactory亦可使用Abstract class，內可放一些共用的Method
    */
    interface IProductFactory
    {
        IProduct CreateProduct();
    }
    class ProductAFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductA();
        }
    }
    class ProductBFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }
    }
    interface IProduct
    {

    }
    class ProductA : IProduct { }
    class ProductB : IProduct { }

}
