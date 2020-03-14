namespace Command
{
    interface ICommander
    {
        void ExecuteCommand();
    }
    class CommanderA : ICommander
    {
        public void ExecuteCommand()
        {

        }
    }
    class CommanderB : ICommander
    {
        public void ExecuteCommand()
        {

        }
    }
    abstract class CommandOrder
    {
        protected ICommander commander;
        public string OrderName { get; set; }
        public CommandOrder(ICommander commander)
        {
            this.commander = commander;
        }

        public void SendOrder()

        {
            commander.ExecuteCommand();
        }
    }

    class CommandOrderA : CommandOrder
    {
        public CommandOrderA(ICommander commander)
        : base(commander)
        {
            this.OrderName = "CommandOrderA";
        }
    }
    class CommandOrderB : CommandOrder
    {
        public CommandOrderB(ICommander commander)
        : base(commander)
        {
            this.OrderName = "CommandOrderB";
        }
    }
}