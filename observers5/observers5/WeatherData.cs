namespace observer
{
    public class WeatherData : Observer<WeatherInfo>
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        private double _windSpeed;
        private double _windDirection;


        public WeatherData( double temperature, double humidity, double pressure, double windSpeed, double windDirection )
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _windDirection = windDirection;
        }

        public double GetTemperature()
        {
            return _temperature;
        }

        public double GetHumidity()
        {
            return _humidity;
        }

        public double GetPressure()
        {
            return _pressure;
        }

        public double GetWindSpeed()
        {
            return _windSpeed;
        }

        public double GetWindDirection()
        {
            return _windDirection;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements( double temp, double humidity, double pressure, double windSpeed, double windDirection )
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _windDirection = windDirection;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info = new WeatherInfo
            {
                Temperature = GetTemperature(),
                Humidity = GetHumidity(),
                Pressure = GetPressure(),
                WindSpeed = GetWindSpeed(),
                WindDirection = GetWindDirection()
            };
            return info;
        }
    }
}
