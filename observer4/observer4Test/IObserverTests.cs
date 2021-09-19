using observer;
using Xunit;

namespace observer4Test
{
    public class IObserverTests
    {
        [Fact]
        public void Update_MethodGetNumberOfSubject_OutputContainsValidNumberOfStation()
        {
            //Arrange
            WeatherData weatherData = new WeatherData(
                temperature: 0.0,
                humidity: 0.0,
                pressure: 760.0,
                objectNumber: 1 );

            WeatherData weatherDataOutside = new WeatherData(
                temperature: 0.0,
                humidity: 0.0,
                pressure: 760.0,
                objectNumber: 2 );

            Display display = new Display();
            weatherData.RegisterObserver( display );
            weatherDataOutside.RegisterObserver( display );

            //Act
            var result = weatherData.SetMeasurements( 3, 0.7, 760 );
            var outsideResult = weatherDataOutside.SetMeasurements( 4, 0.8, 761 );

            //Assert
            Assert.Equal( "Current Temp: 3\nCurrent Hum: 0,7\nCurrent Pressure: 760\n1\n" , result);
            Assert.Equal( "Current Temp: 4\nCurrent Hum: 0,8\nCurrent Pressure: 761\n2\n" , outsideResult );
        }
    }
}