using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine( "I'am fly with wings" );
        }
    }
}
