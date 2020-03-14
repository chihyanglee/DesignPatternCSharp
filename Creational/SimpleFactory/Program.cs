using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a ProductA
            var productA = SimpleFactory.CreateProduct("A");

            // Get a ProductB
            var productB = SimpleFactory.CreateProduct("B");
        }
    }
    interface IProduct
    {

    }
    class ProductA : IProduct
    {

    }
    class ProductB : IProduct
    {

    }
    static class SimpleFactory
    {
        public static IProduct CreateProduct(string type)
        {
            switch (type)
            {
                case "A":
                    return new ProductA();
                case "B":
                    return new ProductB();
                default:
                    return null;
            }
        }
    }
}
