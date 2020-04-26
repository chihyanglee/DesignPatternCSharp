using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConcreteBuilder();
            var director = new Director(builder);
            var product = director.BuildProduct();
        }
    }

    class Director
    {
        private IBuilder builder;
        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public abstractProduct BuildProduct()
        {
            // here we can decide the order of builder inside director
            var product = new Product();
            product.SetPartA(builder.BuildPartA());
            product.SetPartB(builder.BuildPartB());
            product.SetPartC(builder.BuildPartC());
            return product;
        }
    }

    #region builder
    class ConcreteBuilder : IBuilder
    {
        public PartA BuildPartA()
        {
            return new PartA();
        }
        public PartB BuildPartB()
        {
            return new PartB();
        }
        public PartC BuildPartC()
        {
            return new PartC();
        }
    }
    interface IBuilder
    {
        PartA BuildPartA();
        PartB BuildPartB();
        PartC BuildPartC();
    }
    class PartA
    {

    }
    class PartB
    {

    }
    class PartC
    {

    }
    #endregion

    #region product
    abstract class abstractProduct
    {
        PartA partA;
        PartB partB;
        PartC partC;
        public void SetPartA(PartA partA)
        {
            this.partA = partA;
        }

        public void SetPartB(PartB partB)
        {
            this.partB = partB;
        }

        public void SetPartC(PartC partC)
        {
            this.partC = partC;
        }
    }

    class Product : abstractProduct
    {

    }
    #endregion
}
