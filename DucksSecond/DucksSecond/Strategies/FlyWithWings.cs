using Ducks.Behaviors;
using System;

namespace Ducks.Strategies
{
    public class FlyWithWings : IFlyBehavior
    {
        private int _numbersOfFlights = 0;
        public int NumbersOfFlgihts { get { return _numbersOfFlights; } }

        public void Fly()
        {
            _numbersOfFlights++;
            Console.WriteLine( $"I'am fly with wings {_numbersOfFlights} times" );
        }
    }
}
