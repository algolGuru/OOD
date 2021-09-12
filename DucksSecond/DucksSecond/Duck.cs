using Ducks.Behaviors;
using System;

namespace Ducks
{
    public abstract class Duck
    {
        private IFlyBehavior _flyBehavior;
        private readonly IQuackBehavior _quackBehavior;
        private readonly IDanceBehavior _danceBehavior;

        public Duck( IFlyBehavior flyBehavior, IQuackBehavior quackBehavior, IDanceBehavior danceBehavior )
        {
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
            _danceBehavior = danceBehavior;
        }

        public void Quack()
        {
            _quackBehavior.Quack();
        }

        public void Fly()
        {
            _flyBehavior.Fly();
        }

        public void Dance()
        {
            _danceBehavior.Dance();
        }

        public void Swim()
        {
            Console.WriteLine( "I'am swimming" );
        }

        public void SetFlyBehavior( IFlyBehavior flyBehavior )
        {
            _flyBehavior = flyBehavior;
        }

        public abstract void Display();
    }
}
