using System;

namespace observer
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherData weatherData = new WeatherData(
                temperature: 0.0,
                humidity: 0.0,
                pressure: 760.0,
                objectNumber: 1 );

            WeatherData weatherDataOutside = new WeatherData(
                temperature: 0.0,
                humidity: 0.0,
                pressure: 760.0,
                objectNumber: 2 );

            Display display = new Display();
            weatherData.RegisterObserver( display );
            weatherDataOutside.RegisterObserver( display );

            Console.WriteLine( weatherData.SetMeasurements( 3, 0.7, 760 ) );
        }
    }
}
