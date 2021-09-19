namespace observer
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherData weatherData = new WeatherData( 0.0, 0.0, 760.0 );

            Subscriber<WeatherInfo> display = new Subscriber<WeatherInfo>( 1, new Display() );
            weatherData.RegisterObserver( display );

            Subscriber<WeatherInfo> display2 = new Subscriber<WeatherInfo>( 6, new Display() );
            weatherData.RegisterObserver( display2 );

            Subscriber<WeatherInfo> statsDisplay = new Subscriber<WeatherInfo>( 3, new StatisticDisplay() );
            weatherData.RegisterObserver( statsDisplay );

            Subscriber<WeatherInfo> statsDisplay2 = new Subscriber<WeatherInfo>( 2, new StatisticDisplay() );
            weatherData.RegisterObserver( statsDisplay2 );

            weatherData.SetMeasurements( 3, 0.7, 760 );
            weatherData.SetMeasurements( 4, 0.8, 761 );

            weatherData.RemoveObserver( statsDisplay );

            weatherData.SetMeasurements( 10, 0.8, 761 );
            weatherData.SetMeasurements( -10, 0.8, 761 );
        }
    }
}
