using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new ComponentA();
            foo.Operation();
            // decorate foo with decorator1
            var fooWithDecorator1 = new Decorator1(foo);
            fooWithDecorator1.Operation();
            // decorate fooWithDecorator1 with decorator2
            var fooWithDecorator1AndDecorator2 = new Decorator2(fooWithDecorator1);
            fooWithDecorator1AndDecorator2.Operation();
        }
    }
    abstract class AbstractComponent
    {
        public abstract void Operation();
    }
    class ComponentA : AbstractComponent
    {
        public override void Operation()
        {
            // ComponentA Operation
        }
    }
    class ComponentB : AbstractComponent
    {
        public override void Operation()
        {
            // ComponentB Operation
        }
    }

    abstract class AbstractDecorator : AbstractComponent
    {
        protected AbstractComponent component;
        public AbstractDecorator(AbstractComponent component)
        {
            this.component = component;
        }
    }
    class Decorator1 : AbstractDecorator
    {
        public Decorator1(AbstractComponent component)
            : base(component)
        {
        }

        public override void Operation()
        {
            // Decorator1 Operation
        }
    }
    class Decorator2 : AbstractDecorator
    {
        public Decorator2(AbstractComponent component)
            : base(component)
        {
        }

        public override void Operation()
        {
            // Decorator2 Operation
        }
    }
    class Decorator3 : AbstractDecorator
    {
        public Decorator3(AbstractComponent component)
            : base(component)
        {
        }

        public override void Operation()
        {
            // Decorator3 Operation
        }
    }
}
