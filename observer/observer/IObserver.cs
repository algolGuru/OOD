using System;

namespace observer
{
    public interface IObserver<T>
    {
        public void Update( T data );
    }

    public enum WeatherMeasure
    {
        Temperature,
        Humidity,
        Pressure
    }

    public struct MeasureContainer
    {
        public WeatherMeasure WeatherMeasure { get; private set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public double AccValue { get; set; }

        public MeasureContainer( WeatherMeasure weatherMeasure )
        {
            WeatherMeasure = weatherMeasure;
            MaxValue = 0;
            MinValue = 0;
            AccValue = 0;
        }
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

    //STRUCT
    public class StatisticDisplay : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data )
        {
            UpdateValues( ref _temperature, data.Temperature );
            UpdateValues( ref _humidity, data.Humidity );
            UpdateValues( ref _pressure, data.Pressure );
            _countAcc++;

            DisplayStatistic( _temperature );
            DisplayStatistic( _humidity );
            DisplayStatistic( _pressure );
        }

        private MeasureContainer _temperature = new MeasureContainer( WeatherMeasure.Temperature );
        private MeasureContainer _humidity = new MeasureContainer( WeatherMeasure.Humidity );
        private MeasureContainer _pressure = new MeasureContainer( WeatherMeasure.Pressure );
        private uint _countAcc = 0;

        private void DisplayStatistic( MeasureContainer measureContainer )
        {
            Console.WriteLine( $"Max {measureContainer.WeatherMeasure}: {measureContainer.MaxValue}" );
            Console.WriteLine( $"Min {measureContainer.WeatherMeasure}: {measureContainer.MinValue}" );
            Console.WriteLine( $"Average {measureContainer.WeatherMeasure}: {measureContainer.AccValue / _countAcc}" );
        }

        private void UpdateValues( ref MeasureContainer measureContainer, double currentValue )
        {
            if( measureContainer.MinValue > currentValue )
            {
                measureContainer.MinValue = currentValue;
            }
            if( measureContainer.MaxValue < currentValue )
            {
                measureContainer.MaxValue = currentValue;
            }
            measureContainer.AccValue += currentValue;
        }
    }
}
