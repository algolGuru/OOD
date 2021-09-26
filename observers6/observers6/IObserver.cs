using observers6;
using System;
using System.Collections.Generic;

namespace observer
{
    public interface IObserver<T>
    {
        public void Update( T data, Observer<T> observer );
    }

    public class Display : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data, Observer<WeatherInfo> observer )
        {
            Console.WriteLine( $"Current Temp: {data.Temperature}" );
            Console.WriteLine( $"Current Hum: {data.Humidity}" );
            Console.WriteLine( $"Current Pressure: {data.Pressure}" );
            if( observer.ObserverType == ObserverType.Outside )
            {
                string windDirection = WindDirectionDetector.DetectWindDirection( data.WindDirection.Value );
                Console.WriteLine( $"Current Wind Speed: {data.WindSpeed.Value}" );
                Console.WriteLine( $"Current Wind Direction: {windDirection}" );
            }
        }
    }

    public class StatisticDisplay : IObserver<WeatherInfo>
    {
        private List<WeatherMeasure> _sensors = new List<WeatherMeasure>();

        public void AddSensor( WeatherMeasure sensor )
        {
            _sensors.Add( sensor );
        }

        public void Update( WeatherInfo data, Observer<WeatherInfo> observer )
        {
            _countAcc++;
            foreach( var sensor in _sensors )
            {
                if( !( observer.ObserverType == ObserverType.Inside && IsWindSensor( sensor ) ) )
                {
                    double? value = data.GetByMeasure( sensor.Measure );
                    sensor.UpdateValues( value.Value );

                    sensor.DisplayStatistic( _countAcc );
                }
            }

        }

        private bool IsWindSensor( WeatherMeasure sensor )
        {
            return sensor.Measure == WeatherType.WindDirection || sensor.Measure == WeatherType.WindSpeed;
        }

        private uint _countAcc = 0;
    }
}