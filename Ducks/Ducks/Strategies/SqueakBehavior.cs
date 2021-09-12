using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    class SqueakBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine( "Squeak!" );
        }
    }
}
