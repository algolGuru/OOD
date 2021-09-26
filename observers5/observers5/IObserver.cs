using System;
using System.Collections.Generic;

namespace observer
{
    public enum WeatherType
    {
        Temperature,
        Humidity,
        Pressure,
        WindSpeed,
        WindDirection
    }

    public class WeatherMeasure
    {
        public WeatherType Measure { get; }
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public double AccValue { get; private set; }

        public void UpdateValues( double currentValue )
        {
            if( MinValue > currentValue )
            {
                MinValue = currentValue;
            }
            if( MaxValue < currentValue )
            {
                MaxValue = currentValue;
            }
            AccValue += currentValue;
        }

        public void DisplayStatistic( uint countAcc )
        {
            _displayStatisticBehavior.DisplayStatistic( Measure, MinValue, MaxValue, AccValue, countAcc );
        }

        private readonly IDisplayStatisticBehavior _displayStatisticBehavior;

        public WeatherMeasure( WeatherType measure, IDisplayStatisticBehavior displayStatisticBehavior )
        {
            Measure = measure;
            MinValue = double.PositiveInfinity;
            MaxValue = double.NegativeInfinity;
            AccValue = 0;
            _displayStatisticBehavior = displayStatisticBehavior;
        }
    }

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
            double avgWindDirection = accValue / countAcc;
            if( avgWindDirection > 315 || avgWindDirection <= 45 )
            {
                Console.WriteLine( $"Average {measure}: North" );
                return;
            }
            if( avgWindDirection > 45 && avgWindDirection <= 135 )
            {
                Console.WriteLine( $"Average {measure}: East" );
                return;
            }
            if( avgWindDirection > 135 && avgWindDirection <= 225 )
            {
                Console.WriteLine( $"Average {measure}: South" );
                return;
            }
            if( avgWindDirection > 225 && avgWindDirection <= 315 )
            {
                Console.WriteLine( $"Average {measure}: West" );
                return;
            }
        }
    }

    public interface IObserver<T>
    {
        public void Update( T data );
    }

    public class Display : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data )
        {
            Console.WriteLine( $"Current Temp: {data.Temperature}" );
            Console.WriteLine( $"Current Hum: {data.Humidity}" );
            Console.WriteLine( $"Current Pressure: {data.Pressure}" );
            Console.WriteLine( $"Current Wind Speed: {data.WindSpeed}" );
            Console.WriteLine( $"Current Wind Direction: {data.WindDirection}" );
        }
    }

    public class StatisticDisplay : IObserver<WeatherInfo>
    {
        private List<WeatherMeasure> _sensors = new List<WeatherMeasure>();

        public void AddSensor( WeatherMeasure sensor )
        {
            _sensors.Add( sensor );
        }

        public void Update( WeatherInfo data )
        {
            foreach( var sensor in _sensors )
            {
                double value = data.GetByMeasure( sensor.Measure );
                sensor.UpdateValues( value );

                _countAcc++;

                sensor.DisplayStatistic( _countAcc );
            }
        }

        private uint _countAcc = 0;
    }
}