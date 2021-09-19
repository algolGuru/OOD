namespace observer
{
    public interface IObserver<T>
    {
        public string Update( T data, Observer<T> observer );
    }

    public class Display : IObserver<WeatherInfo>
    {
        public string Update( WeatherInfo data, Observer<WeatherInfo> observer )
        {
            return $"Current Temp: {data.Temperature}\n" +
                $"Current Hum: {data.Humidity}\n" +
                $"Current Pressure: {data.Pressure}\n" +
                $"{observer.ObserverNumber}\n";

        }
    }

    public class StatisticDisplay : IObserver<WeatherInfo>
    {
        public string Update( WeatherInfo data, Observer<WeatherInfo> observer )
        {
            var result = "";
            UpdateValues( ref _minTemperature, ref _maxTemperature, ref _accTemperature, data.Temperature );
            UpdateValues( ref _minHumidity, ref _maxHumidity, ref _accHumidity, data.Humidity );
            UpdateValues( ref _minPressure, ref _maxPressure, ref _accPressure, data.Pressure );
            _countAcc++;

            result += DisplayStatistic( "Temp", _minTemperature, _maxTemperature, _accTemperature );
            result += DisplayStatistic( "Hum", _minHumidity, _maxHumidity, _accHumidity );
            result += DisplayStatistic( "Pressure ", _minPressure, _maxPressure, _accPressure );

            result += observer.ObserverNumber;
            return result;
        }

        private double _minTemperature = double.PositiveInfinity;
        private double _maxTemperature = double.NegativeInfinity;
        private double _accTemperature = 0;

        private double _minHumidity = double.PositiveInfinity;
        private double _maxHumidity = double.NegativeInfinity;
        private double _accHumidity = 0;

        private double _minPressure = double.PositiveInfinity;
        private double _maxPressure = double.NegativeInfinity;
        private double _accPressure = 0;

        private uint _countAcc = 0;

        private string DisplayStatistic( string measure, double minValue, double maxValue, double accValue )
        {
            return $"Max {measure}: {maxValue}\n" +
            $"Min {measure}: {minValue}\n" +
            $"Average {measure}: {accValue / _countAcc}\n";
        }

        private void UpdateValues( ref double minValue, ref double maxValue, ref double accValue, double currentValue )
        {
            if( minValue > currentValue )
            {
                minValue = currentValue;
            }
            if( maxValue < currentValue )
            {
                maxValue = currentValue;
            }
            accValue += currentValue;
        }
    }
}
