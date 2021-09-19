namespace observer
{
    public class WeatherData : Observer<WeatherInfo>
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;

        public WeatherData( double temperature, double humidity, double pressure )
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
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

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements( double temp, double humidity, double pressure )
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info = new WeatherInfo
            {
                Temperature = GetTemperature(),
                Humidity = GetHumidity(),
                Pressure = GetPressure()
            };
            return info;
        }
    }
}
