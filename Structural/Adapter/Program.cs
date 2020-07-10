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

namespace Adapter.Peg
{
    class ClientCode
    {
        static void ClientCodeMain()
        {
            var roundPeg = new RoundPeg(4);
            var squarePeg = new SquarePeg(3);

            // 欲例用IsHoleFit測量squarePeg是否放得進去

            // first test
            // compiler error => isholefit cannot accept type squarePeg
            // var isSquareFit = IsHoleFit(squarePeg);

            // => make a adapter to fix this problen
            var squarePegAdapter = new SquarePegAdapter(squarePeg);
            var isSquareFit = IsHoleFit(squarePegAdapter);
        }

        static bool IsHoleFit(IRoundPeg roundPeg)
        {
            int holeRadius = 4;
            return roundPeg.GetRadius() <= holeRadius;
        }
    }

    class SquarePegAdapter: IRoundPeg
    {
        private SquarePeg squarePeg;

        public SquarePegAdapter(SquarePeg squarePeg)
        {
            this.squarePeg = squarePeg;
        }

        public int GetRadius()
        {
            return (int)(this.squarePeg.GetWidth() * Math.Sqrt(2) / 2);
        }
    }



    interface IRoundPeg
    {
        int GetRadius();
    }

    class RoundPeg: IRoundPeg
    {
        private int radius;
        public RoundPeg(int radius)
        {
            this.radius = radius;
        }

        public int GetRadius()
        {
            return radius;
        }
    }

    interface ISquarePeg
    {
        int GetWidth();
    }

    class SquarePeg: ISquarePeg
    {
        private int width;
        public SquarePeg(int width)
        {
            this.width = width;
        }

        public int GetWidth()
        {
            return width;
        }
    }

}
