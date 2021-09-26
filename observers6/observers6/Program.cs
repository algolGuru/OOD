namespace observer
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherData weatherDataOutside = new WeatherData( ObserverType.Outside, 0, 0, 760, 0, 45 );
            WeatherData weatherDataInside = new WeatherData( ObserverType.Inside, 0, 0, 760 );

            StatisticDisplay statsDisplay = new StatisticDisplay();
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Temperature, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Humidity, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Pressure, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.WindSpeed, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.WindDirection, new WindDirectionDisplayStatisticStrategy() ) );

            Display display = new Display();

            weatherDataOutside.RegisterObserver( statsDisplay );
            weatherDataOutside.RegisterObserver( display );
            weatherDataInside.RegisterObserver( statsDisplay );
            weatherDataInside.RegisterObserver( display );

            weatherDataOutside.SetMeasurements( 3, 0.7, 760, 10, 40 );
            weatherDataInside.SetMeasurements( 3, 0.7, 760 );
            weatherDataOutside.SetMeasurements( 4, 0.8, 761, 10, 360 );
            weatherDataInside.SetMeasurements( 4, 0.8, 761 );
        }
    }
}
