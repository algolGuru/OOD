using Ducks.Strategies;

namespace Ducks
{
    class Program
    {
        static void Main( string[] args )
        {
            MallardDuck mallardDuck = new MallardDuck();
            mallardDuck.Dance();
            mallardDuck.Fly();
            mallardDuck.Fly();
            mallardDuck.Fly();
            mallardDuck.Quack();
            mallardDuck.Swim();
            mallardDuck.Display();
            mallardDuck.SetFlyBehavior( new FlyWithWings() ); 
            mallardDuck.Fly();
            mallardDuck.Fly();

            RedHeadDuck redHeadDuck = new RedHeadDuck();
            redHeadDuck.Dance();
            redHeadDuck.Fly();
            redHeadDuck.Quack();
            redHeadDuck.Swim();
            redHeadDuck.Display();

            RubberDuck rubberDuck = new RubberDuck();
            rubberDuck.Dance();
            rubberDuck.Fly();
            rubberDuck.Quack();
            rubberDuck.Swim();
            rubberDuck.Display();

            DecoyDuck decoyDuck = new DecoyDuck();
            decoyDuck.Dance();
            decoyDuck.Fly();
            decoyDuck.Quack();
            decoyDuck.Swim();
            decoyDuck.Display();
        }
    }
}
