using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    public class WaltzBehavior : IDanceBehavior
    {
        public void Dance()
        {
            Console.WriteLine("I'am dance waltz!");
        }
    }
}
