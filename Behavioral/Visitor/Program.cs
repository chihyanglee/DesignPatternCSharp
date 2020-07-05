using System;
using System.Collections.Generic;
namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

namespace Visitor.Structural
{
    class AppMain
    {
        static void ExecuteMain()
        {
            // setup structure
            var o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            // create visitor objects
            var v1 = new ConcreteVisitor1();
            var v2 = new ConcreteVisitor2();

            // Structure accepting visitors
            o.Accept(v1);
            o.Accept(v2);

            // wait for user
            Console.ReadKey();
        }
    }

    abstract class Visitor
    {
        public abstract void VisitConcreteElementA(
            ConcreteElementA concreteElementA
        );
        public abstract void VisitConcreteElementB(
            ConcreteElementB concreteElementB
        );
    }

    class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Console.WriteLine($"{concreteElementA.GetType().Name} visited by {this.GetType().Name}");
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Console.WriteLine($"{concreteElementB.GetType().Name} visited by {this.GetType().Name}");
        }
    }
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Console.WriteLine($"{concreteElementA.GetType().Name} visited by {this.GetType().Name}");
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Console.WriteLine($"{concreteElementB.GetType().Name} visited by {this.GetType().Name}");
        }
    }
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    class ConcreteElementA: Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {

        }
    }
    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
        public void OperationB()
        {

        }
    }

    class ObjectStructure
    {
        private List<Element> _elements = new List<Element>();

        public void Attach(Element element)
        {
            _elements.Add(element);
        }

        public void Detach(Element element)
        {
            _elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach(var element in _elements)
            {
                element.Accept(visitor);
            }
        }

    }
}
