using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();
            var proxy = new Proxy(subject);
            proxy.Request();
        }
    }
    interface ISubject
    {
        void Request();
    }
    class Subject : ISubject
    {
        public void Request()
        {

        }
    }

    class Proxy : ISubject
    {
        private Subject subject;

        public Proxy(Subject subject)
        {
            this.subject = subject;
        }

        public void Request()
        {
            if (Validate())
            {
                this.subject.Request();
            }
        }

        public bool Validate()
        {
            // some rule
            return true;
        }
    }
}
