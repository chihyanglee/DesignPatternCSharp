using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var componentA1 = new ComponentA("a1");
            var componentA2 = new ComponentA("a2");
            var componentB1 = new ComponentB("b1");
            var componentB2 = new ComponentB("b2");
            mediator.AddComponent(componentA1);
            mediator.AddComponent(componentA2);
            mediator.AddComponent(componentB1);
            mediator.AddComponent(componentB2);

            componentA2.Notify("hello world", "b2");
            componentB1.Broadcast("hello world all");
        }
    }

    interface IMediator
    {
        void NotifyAll(string message);
        void NotifyTo(string message, AbstractComponent from, string to);
    }
    class ConcreteMediator : IMediator
    {
        private List<AbstractComponent> list = new List<AbstractComponent>();
        public void AddComponent(AbstractComponent component)
        {
            component.SetMediator(this);
            list.Add(component);
        }

        public void NotifyAll(string message)
        {
            foreach (var component in list)
            {
                // System.Console.WriteLine($"Notify {component}");
                component.GotNotify(message);
            }
        }

        public void NotifyTo(string message, AbstractComponent from, string to)
        {
            // System.Console.WriteLine($"{from} send a message: {message} to {to}");
            var target = list.FirstOrDefault(c => c.Name.Equals(to));
            target?.GotNotify(message);
        }
    }

    abstract class AbstractComponent
    {
        public string Name { get; set; }
        public AbstractComponent(string name)
        {
            this.Name = name;
        }
        protected IMediator mediator;
        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void GotNotify(string message)
        {
            System.Console.WriteLine($"{this.Name} just got a message: {message}");
        }
    }
    class ComponentA : AbstractComponent
    {
        public ComponentA(string name)
            : base(name)
        {

        }

        public void Notify(string message, string target)
        {
            this.mediator.NotifyTo(message, this, target);
        }
    }
    class ComponentB : AbstractComponent
    {
        public ComponentB(string name)
            : base(name)
        {

        }

        public void Broadcast(string message)
        {
            this.mediator.NotifyAll(message);
        }
    }
}
