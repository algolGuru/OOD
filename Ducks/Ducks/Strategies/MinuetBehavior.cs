using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    class MinuetBehavior : IDanceBehavior
    {
        public void Dance()
        {
            Console.WriteLine( "I'am dance minuet!" );
        }
    }
}
