using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var handlerA = new HandlerA();
            var handlerB = new HandlerB();
            var handlerC = new HandlerC();
            handlerA.SetNext(handlerB)
                    .SetNext(handlerC);
            var request = new object();
            handlerA.Handle(request);
        }
    }

    interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
    abstract class AbstratctHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            return null;
        }
    }

    class HandlerA : AbstratctHandler
    {
        public override object Handle(object request)
        {
            // condition that HandlerA responsible for
            var condition = true;
            if (condition)
            {
                // do something
                System.Console.WriteLine("Handle by A");

            }
            return base.Handle(request);
        }
    }

    class HandlerB : AbstratctHandler
    {
        public override object Handle(object request)
        {
            // condition that HandlerB responsible for
            var condition = true;
            if (condition)
            {
                // do something
                System.Console.WriteLine("Handle by B");

            }
            return base.Handle(request);
        }
    }
    class HandlerC : AbstratctHandler
    {
        public override object Handle(object request)
        {
            // condition that HandlerC responsible for
            var condition = true;
            if (condition)
            {
                // do something
                System.Console.WriteLine("Handle by C");

            }
            return base.Handle(request);
        }
    }
}
