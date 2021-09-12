using Ducks.Behaviors;

namespace Ducks.Strategies
{
    class FlyNoWay : IFlyBehavior
    {
        private int _numbersOfFlights = 0;
        public int NumbersOfFlgihts { get { return _numbersOfFlights; } }
        public void Fly() { }
    }
}
