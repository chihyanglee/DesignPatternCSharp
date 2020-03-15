using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            // 這裡有幾種設計的方式，可以將各種state的轉換提供介面設定
            // 或是隱性的在各個state內轉換
            // 此處寫的是隱性的Default state => StateA => StateB
            var context = new Context();
            context.ContextAction1();
            context.StateDependentAction1();
            context.StateTransitionAction1();
            context.StateDependentAction2();
            context.StateTransitionAction2();
        }
    }

    class Context
    {
        private AbstractState state;

        public Context()
        {
            this.state = new DefaultState();
        }
        public Context(AbstractState state)
        {
            this.state = state;
        }

        public void ContextAction1() { }
        public void ContextAction2() { }

        public void StateDependentAction1()
        {
            state.Action1();
        }
        public void StateDependentAction2()
        {
            state.Action2();
        }
        public void StateTransitionAction1()
        {
            this.state = new StateA();
            this.state.SetContext(this);
        }
        public void StateTransitionAction2()
        {
            this.state = new StateB();
            this.state.SetContext(this);
        }
    }
    abstract class AbstractState
    {
        protected Context context;
        public void SetContext(Context context)
        {
            this.context = context;
        }

        public abstract void Action1();

        public abstract void Action2();
    }

    class DefaultState : AbstractState
    {
        public override void Action1()
        {
        }

        public override void Action2()
        {
        }
    }

    class StateA : AbstractState
    {
        public override void Action1()
        {
        }

        public override void Action2()
        {
        }
    }
    class StateB : AbstractState
    {
        public override void Action1()
        {
        }

        public override void Action2()
        {
        }
    }
}
