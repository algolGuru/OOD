namespace observer
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherData weatherData = new WeatherData( 0.0, 0.0, 760.0 );

            Display display = new Display();
            weatherData.RegisterObserver( display );

            StatisticDisplay statsDisplay = new StatisticDisplay();
            weatherData.RegisterObserver( statsDisplay );

            weatherData.SetMeasurements( 3, 0.7, 760 );
        }
    }
}
