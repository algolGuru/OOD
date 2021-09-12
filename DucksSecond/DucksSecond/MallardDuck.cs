using Ducks.Strategies;
using System;

namespace Ducks
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
            : base( new FlyWithWings(), new QuackBehavior(), new WaltzBehavior() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'am mallard duck" );
        }
    }
}
