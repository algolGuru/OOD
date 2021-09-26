namespace observer
{
    public class WeatherData : Observer<WeatherInfo>
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        private double? _windSpeed;
        private double? _windDirection;

        public WeatherData(
            ObserverType observerType,
            double temperature,
            double humidity,
            double pressure ) : base( observerType )
        {
            if (observerType == ObserverType.Outside )
            {
                throw new System.Exception( "Wind indicators should be indicated outside" );
            }

            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            _windSpeed = null;
            _windDirection = null;
        }

        public WeatherData(
            ObserverType observerType,
            double temperature,
            double humidity,
            double pressure,
            double windSpeed,
            double windDirection ) : base( observerType )
        {
            if( observerType == ObserverType.Inside )
            {
                throw new System.Exception( "There can be no wind inside" );
            }

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
            if( ObserverType == ObserverType.Inside )
            {
                throw new System.Exception( "There is no wind inside station" );
            }

            return _windSpeed.Value;
        }

        public double GetWindDirection()
        {
            if( ObserverType == ObserverType.Inside )
            {
                throw new System.Exception( "There is no wind inside station" );
            }

            return _windDirection.Value;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements( double temp, double humidity, double pressure, double windSpeed, double windDirection )
        {
            if( ObserverType == ObserverType.Inside )
            {
                throw new System.Exception( "there is no wind inside" );
            }

            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _windDirection = windDirection;

            MeasurementsChanged();
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

            double? windSpeed = null;
            double? windDirection = null;
            if( ObserverType == ObserverType.Outside )
            {
                windSpeed = GetWindSpeed();
                windDirection = GetWindDirection();
            }

            WeatherInfo info = new WeatherInfo
            {
                Temperature = GetTemperature(),
                Humidity = GetHumidity(),
                Pressure = GetPressure(),
                WindSpeed = windSpeed,
                WindDirection = windDirection
            };
            return info;
        }
    }
}
