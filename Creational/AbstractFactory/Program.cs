using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /*
    * Abstract Factory Pattern與Factory Method Pattern
    * 差別僅在於此Pattern著重於Factory可以產生一系列的產品
    * 相對Factory Method Pattern的factory僅產生一種產品
    */
    abstract class AbstractFactory
    {
        public abstract IProduct1 CreateProduct1();
        public abstract IProduct2 CreateProduct2();
    }
    class FactoryA : AbstractFactory
    {
        public override IProduct1 CreateProduct1()
        {
            return new Product1A();
        }
        public override IProduct2 CreateProduct2()
        {
            return new Product2A();
        }
    }
    class FactoryB : AbstractFactory
    {
        public override IProduct1 CreateProduct1()
        {
            return new Product1B();
        }
        public override IProduct2 CreateProduct2()
        {
            return new Product2B();
        }
    }
    interface IProduct1 { }
    interface IProduct2 { }
    class Product1A : IProduct1 { }
    class Product1B : IProduct1 { }
    class Product2A : IProduct2 { }
    class Product2B : IProduct2 { }
}