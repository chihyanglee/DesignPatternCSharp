using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeAPort typeACharger = new TypeACharger();

            var adapterAtoC = new AdapterTypeAtoTypeC(typeACharger);
            adapterAtoC.TypeCCharge();
        }
    }

    class AdapterTypeAtoTypeC : ITypeCPort
    {
        private ITypeAPort typeACharger;

        public AdapterTypeAtoTypeC(ITypeAPort typeACharger)
        {
            this.typeACharger = typeACharger;
        }

        public void TypeCCharge()
        {
            this.typeACharger.TypeACharge();
        }
    }

    class AdapterTypeCtoTypeA : ITypeAPort
    {
        private ITypeCPort typeCCharger;

        public AdapterTypeCtoTypeA(ITypeCPort typeCCharger)
        {
            this.typeCCharger = typeCCharger;
        }

        public void TypeACharge()
        {
            this.typeCCharger.TypeCCharge();
        }
    }


    interface ITypeAPort
    {
        void TypeACharge();
    }

    class TypeACharger : ITypeAPort
    {
        public void TypeACharge()
        {

        }
    }

    interface ITypeCPort
    {
        void TypeCCharge();
    }

    class TypeCCharger : ITypeCPort
    {
        public void TypeCCharge()
        {

        }
    }
}
