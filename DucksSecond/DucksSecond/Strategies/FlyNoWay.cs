using Ducks.Behaviors;

namespace Ducks.Strategies
{
    class FlyNoWay : IFlyBehavior
    {
        public int NumbersOfFlgihts { get { return 0; } }
        public void Fly() { }
    }
}
