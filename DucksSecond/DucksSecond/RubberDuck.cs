using Ducks.Strategies;
using System;

namespace Ducks
{
    class RubberDuck : Duck
    {
        public RubberDuck()
             : base( new FlyNoWay(), new SqueakBehavior(), new DanceNoWay() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'am rubber duck" );
        }
    }
}
