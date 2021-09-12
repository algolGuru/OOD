using Ducks.Strategies;
using System;

namespace Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck()
             : base( new FlyNoWay(), new MuteQuackBehavior(), new DanceNoWay() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'am decoy duck!" );
        }
    }
}
