using System;
using System.Collections.Generic;
namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject1 = new Subject1();
            var observerA = new ObserverA();
            var observerB = new ObserverB();
            subject1.AddObserver(observerA);
            subject1.AddObserver(observerB);
            subject1.Notify("notify message from subject1");

            subject1.RemoveObserver(observerA);
            subject1.Notify("notify message from subject1");

        }
    }
    abstract class AbstractSubject
    {
        protected List<AbstractObserver> observerList = new List<AbstractObserver>();
        public void AddObserver(AbstractObserver observer)
        {
            observerList.Add(observer);
        }

        public void RemoveObserver(AbstractObserver observer)
        {
            observerList.Remove(observer);
        }

        public abstract void Notify(string message);
    }

    class Subject1 : AbstractSubject
    {
        public override void Notify(string message)
        {
            foreach (var observer in observerList)
            {
                observer.Notified(message);
            }
        }
    }
    class Subject2 : AbstractSubject
    {
        public override void Notify(string message)
        {
            foreach (var observer in observerList)
            {
                observer.Notified(message);
            }
        }
    }
    abstract class AbstractObserver
    {
        public abstract void Notified(string message);
    }
    class ObserverA : AbstractObserver
    {
        public override void Notified(string message)
        {

        }
    }
    class ObserverB : AbstractObserver
    {
        public override void Notified(string message)
        {

        }

    }
}
