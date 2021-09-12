using Ducks.Strategies;
using System;

namespace Ducks
{
    class RedHeadDuck : Duck
    {
        public RedHeadDuck()
             : base( new FlyWithWings(), new QuackBehavior(), new MinuetBehavior() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'am red head duck" );
        }
    }
}
