namespace observer
{
    public struct WeatherInfo
    {
        public double Temperature;
        public double Humidity;
        public double Pressure;
        public double? WindSpeed;
        public double? WindDirection;

        public double? GetByMeasure( WeatherType measure )
        {
            return measure switch
            {
                WeatherType.Temperature => Temperature,
                WeatherType.Humidity => Humidity,
                WeatherType.Pressure => Pressure,
                WeatherType.WindSpeed => WindSpeed,
                WeatherType.WindDirection => WindDirection,
                _ => throw new System.ArgumentException( "Invalid Measure" ),
            };
        }
    }
}
