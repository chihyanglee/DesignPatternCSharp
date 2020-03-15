using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Composite();
            var branch1 = new Composite();
            var branch1Child1 = new Leaf();
            var branch1Child2 = new Leaf();
            branch1.Add(branch1Child1);
            branch1.Add(branch1Child2);
            tree.Add(branch1);
        }
    }
    abstract class Component
    {
        protected abstract void Operation();

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        protected virtual bool IsComposite()
        {
            return true;
        }
    }

    class Leaf : Component
    {
        protected override void Operation()
        {
            throw new NotImplementedException();
        }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        protected override bool IsComposite()
        {
            return true;
        }
    }
    class Composite : Component
    {
        protected List<Component> children = new List<Component>();

        public override void Add(Component component)
        {
            this.children.Add(component);
        }

        public override void Remove(Component component)
        {
            this.children.Remove(component);
        }
        protected override void Operation()
        {
            throw new NotImplementedException();
        }
    }
}
