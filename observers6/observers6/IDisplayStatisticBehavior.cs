using observers6;
using System;

namespace observer
{
    public interface IDisplayStatisticBehavior
    {
        public void DisplayStatistic( WeatherType measure, double minValue, double maxValue, double accValue, uint countAcc );
    }


    public class StdWeatherMeasureDisplayStatisticStrategy : IDisplayStatisticBehavior
    {
        public void DisplayStatistic( WeatherType measure, double minValue, double maxValue, double accValue, uint countAcc )
        {
            Console.WriteLine( $"Max {measure}: {maxValue}" );
            Console.WriteLine( $"Min {measure}: {minValue}" );
            Console.WriteLine( $"Average {measure}: {accValue / countAcc}" );
        }
    }

    public class WindDirectionDisplayStatisticStrategy : IDisplayStatisticBehavior
    {
        public void DisplayStatistic( WeatherType measure, double minValue, double maxValue, double accValue, uint countAcc )
        {
            Console.WriteLine( $"Max {measure}: {maxValue}" );
            Console.WriteLine( $"Min {measure}: {minValue}" );

            string windDirection = WindDirectionDetector.DetectWindDirection( accValue / countAcc );
            Console.WriteLine( $"Average {measure}: {windDirection}" );
        }
    }
}