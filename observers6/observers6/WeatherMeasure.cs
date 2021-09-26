namespace observer
{
    public enum WeatherType
    {
        Temperature,
        Humidity,
        Pressure,
        WindSpeed,
        WindDirection
    }

    public class WeatherMeasure
    {
        public WeatherType Measure { get; }
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public double AccValue { get; private set; }

        public void UpdateValues( double currentValue )
        {
            if( MinValue > currentValue )
            {
                MinValue = currentValue;
            }
            if( MaxValue < currentValue )
            {
                MaxValue = currentValue;
            }
            AccValue += currentValue;
        }

        public void DisplayStatistic( uint countAcc )
        {
            _displayStatisticBehavior.DisplayStatistic( Measure, MinValue, MaxValue, AccValue, countAcc );
        }

        private readonly IDisplayStatisticBehavior _displayStatisticBehavior;

        public WeatherMeasure( WeatherType measure, IDisplayStatisticBehavior displayStatisticBehavior )
        {
            Measure = measure;
            MinValue = double.PositiveInfinity;
            MaxValue = double.NegativeInfinity;
            AccValue = 0;
            _displayStatisticBehavior = displayStatisticBehavior;
        }
    }
}