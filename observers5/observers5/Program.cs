namespace observer
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherData weatherData = new WeatherData( 0, 0, 760, 0, 45 );

            StatisticDisplay statsDisplay = new StatisticDisplay();

            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Temperature, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Humidity, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.Pressure, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.WindSpeed, new StdWeatherMeasureDisplayStatisticStrategy() ) );
            statsDisplay.AddSensor( new WeatherMeasure( WeatherType.WindDirection, new WindDirectionDisplayStatisticStrategy() ) );

            weatherData.RegisterObserver( statsDisplay );

            weatherData.SetMeasurements( 3, 0.7, 760, 10, 40 );
            weatherData.SetMeasurements( 4, 0.8, 761, 10, 360 );
        }
    }
}
