using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // use ConcreteClass1 operation to do TemplateMethod
            var concrete1 = new ConcreteClass1();
            concrete1.TemplateMethod();

            // use ConcreteClass2 operation to do TemplateMethod
            var concrete2 = new ConcreteClass2();
            concrete2.TemplateMethod();
        }
    }
    abstract class AbstractTemplate
    {
        public void TemplateMethod()
        {
            this.BaseOperation1();
            this.CustomizedOperation1();
            this.BaseOperation2();
            this.CustomizedOperation2();
        }

        protected void BaseOperation1() { }
        protected abstract void CustomizedOperation1();

        protected void BaseOperation2() { }
        protected abstract void CustomizedOperation2();
    }

    class ConcreteClass1 : AbstractTemplate
    {
        protected override void CustomizedOperation1()
        {
            // Implement CustomizedOperation1
        }

        protected override void CustomizedOperation2()
        {
            // Implement CustomizedOperation2
        }
    }

    class ConcreteClass2 : AbstractTemplate
    {
        protected override void CustomizedOperation1()
        {
            // Implement CustomizedOperation1
        }

        protected override void CustomizedOperation2()
        {
            // Implement CustomizedOperation2
        }
    }
}
