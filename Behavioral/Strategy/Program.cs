using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            // use strategyA to do something
            context.SetStrategy(new StrategyA());
            context.DoSomethingWithStrategy();

            // use strategyB to do something;
            context.SetStrategy(new StrategyB());
            context.DoSomethingWithStrategy();
        }
    }
    interface IStrategy
    {
        void ExecuteStrategy();
    }
    class StrategyA : IStrategy
    {
        public void ExecuteStrategy()
        {
            // StrategyA
        }
    }
    class StrategyB : IStrategy
    {
        public void ExecuteStrategy()
        {
            // StrategyB
        }
    }
    class Context
    {
        IStrategy strategy;
        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomethingWithStrategy()
        {
            strategy.ExecuteStrategy();
        }
    }
}
