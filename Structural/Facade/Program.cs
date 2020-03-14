using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            // type1
            var subsystem1 = new Subsystem1();
            var subsystem2 = new Subsystem2();
            var subsystem3 = new Subsystem3();
            var subsystem4 = new Subsystem4();
            Facade.Type1.Facade facadeType1 = new Facade.Type1.Facade(subsystem1, subsystem2, subsystem3, subsystem4);
            facadeType1.FacadeOperation1();
            facadeType1.FacadeOperation2();

            // type2
            Facade.Type2.Facade facadeType2 = new Facade.Type2.Facade();
            facadeType2.FacadeOperation1();
            facadeType2.FacadeOperation2();
        }
    }
    class Subsystem1
    {
        public void Operation1()
        {

        }
        public void Operation2()
        {

        }
    }
    class Subsystem2
    {
        public void Operation3()
        {

        }
        public void Operation4()
        {

        }
    }

    class Subsystem3
    {
        public void Operation5()
        {

        }
        public void Operation6()
        {

        }
        public void Operation7()
        {

        }
        public void Operation8()
        {

        }
    }
    class Subsystem4
    {
        public void Operation9()
        {

        }
    }
}
namespace Facade.Type1
{
    class Facade
    {
        private Subsystem1 subsystem1;
        private Subsystem2 subsystem2;
        private Subsystem3 subsystem3;
        private Subsystem4 subsystem4;
        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2, Subsystem3 subsystem3, Subsystem4 subsystem4)
        {
            this.subsystem1 = subsystem1;
            this.subsystem2 = subsystem2;
            this.subsystem3 = subsystem3;
            this.subsystem4 = subsystem4;
        }

        public void FacadeOperation1()
        {
            subsystem2.Operation3();
            subsystem1.Operation2();
            subsystem3.Operation7();
            subsystem3.Operation5();
            subsystem4.Operation9();
        }

        public void FacadeOperation2()
        {
            subsystem2.Operation3();
            subsystem3.Operation5();
            subsystem4.Operation9();
            subsystem1.Operation1();
            subsystem3.Operation6();
            subsystem3.Operation8();
        }
    }
}
namespace Facade.Type2
{
    class Facade
    {
        private Subsystem1 subsystem1 = new Subsystem1();
        private Subsystem2 subsystem2 = new Subsystem2();
        private Subsystem3 subsystem3 = new Subsystem3();
        private Subsystem4 subsystem4 = new Subsystem4();
        public Facade()
        {

        }

        public void FacadeOperation1()
        {
            subsystem2.Operation3();
            subsystem1.Operation2();
            subsystem3.Operation7();
            subsystem3.Operation5();
            subsystem4.Operation9();
        }

        public void FacadeOperation2()
        {
            subsystem2.Operation3();
            subsystem3.Operation5();
            subsystem4.Operation9();
            subsystem1.Operation1();
            subsystem3.Operation6();
            subsystem3.Operation8();
        }
    }
}
