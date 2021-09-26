namespace observer
{
    public struct WeatherInfo
    {
        public double Temperature;
        public double Humidity;
        public double Pressure;
        public double WindSpeed;
        public double WindDirection;

        public double GetByMeasure( WeatherType measure )
        {
            switch ( measure )
            {
                //Сделать вместо строк enum
                case WeatherType.Temperature:
                    return Temperature;
                case WeatherType.Humidity:
                    return Humidity;
                case WeatherType.Pressure:
                    return Pressure;
                case WeatherType.WindSpeed:
                    return WindSpeed;
                case WeatherType.WindDirection:
                    return WindDirection;
                default:
                    throw new System.ArgumentException( "Invalid Measure" );
            }
        }
    }
}
