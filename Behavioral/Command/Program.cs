using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            // prepared stage
            var invoker = new Invoker();
            var commanderA = new CommanderA();
            var commanderB = new CommanderB();

            // receiver order
            var order1 = new CommandOrderA(commanderA);
            var order2 = new CommandOrderB(commanderB);
            var order3 = new CommandOrderA(commanderA);
            invoker.ReceiveOrder(order1);
            invoker.ReceiveOrder(order2);
            invoker.ReceiveOrder(order3);
            invoker.CancelOrder(order3);
            invoker.NodifyCommander();
        }
    }

    class Invoker
    {
        private List<CommandOrder> orderList = new List<CommandOrder>();
        public void ReceiveOrder(CommandOrder order)
        {
            orderList.Add(order);
        }

        public void CancelOrder(CommandOrder order)
        {
            orderList.Remove(order);
        }

        public void NodifyCommander()
        {
            foreach (var order in orderList)
            {
                order.SendOrder();
            }
            orderList.Clear();
        }
    }
}
