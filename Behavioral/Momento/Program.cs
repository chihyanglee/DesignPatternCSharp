using System;

namespace Momento
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Originator();
            o.State = "On";

            // Use Caretaker to store internal state
            var c = new Caretaker();
            c.Memento = o.CreateMemento();

            // change state of o
            o.State = "Off";

            // Restore state of o from c
            o.SetMemento(c.Memento);

        }
    }
    class Originator
    {
        public string State { get; set; }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }

        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
    }
    class Memento
    {
        private string _state;
        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        { 
            get
            {
                return _state;
            }
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

}
