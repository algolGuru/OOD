using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    class QuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine( "Quack quack!" );
        }
    }
}
