using System;

namespace observer
{
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
        }
    }

    public class StatisticDisplay : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data )
        {
            UpdateValues( ref _minTemperature, ref _maxTemperature, ref _accTemperature, data.Temperature );
            UpdateValues( ref _minHumidity, ref _maxHumidity, ref _accHumidity, data.Humidity );
            UpdateValues( ref _minPressure, ref _maxPressure, ref _accPressure, data.Pressure );
            _countAcc++;

            DisplayStatistic("Temp", _minTemperature, _maxTemperature, _accTemperature);
            DisplayStatistic("Hum", _minHumidity, _maxHumidity, _accHumidity );
            DisplayStatistic( "Pressure ", _minPressure, _maxPressure, _accPressure );
        }

        private double _minTemperature = double.PositiveInfinity;
        private double _maxTemperature = double.NegativeInfinity;
        private double _accTemperature = 0;

        private double _minHumidity = double.PositiveInfinity;
        private double _maxHumidity = double.NegativeInfinity;
        private double _accHumidity = 0;

        private double _minPressure = double.PositiveInfinity;
        private double _maxPressure = double.NegativeInfinity;
        private double _accPressure = 0;

        private uint _countAcc = 0;

        private void DisplayStatistic( string measure, double minValue, double maxValue, double accValue )
        {
            Console.WriteLine( $"Max {measure}: {maxValue}" );
            Console.WriteLine( $"Min {measure}: {minValue}" );
            Console.WriteLine( $"Average {measure}: {accValue / _countAcc}" );
        }

        private void UpdateValues( ref double minValue, ref double maxValue, ref double accValue, double currentValue )
        {
            if( minValue > currentValue )
            {
                minValue = currentValue;
            }
            if( maxValue < currentValue )
            {
                maxValue = currentValue;
            }
            accValue += currentValue;
        }
    }
}
