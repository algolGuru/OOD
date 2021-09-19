using observer;
using Xunit;

namespace observers2Tests
{
    public class NotifyObserversTests
    {
        [Fact]
        public void NotifyObservers_ObserverUnsabscribeWhileSubjectNotifyObservers_NoError()
        {
            //Arrange
            WeatherData weatherData = new WeatherData( 0.0, 0.0, 760.0 );

            Display display = new Display();
            weatherData.RegisterObserver( display );

            StatisticDisplay statsDisplay = new StatisticDisplay();
            weatherData.RegisterObserver( statsDisplay );

            //Assert
            var exception = Record.Exception( () => weatherData.SetMeasurements( 3, 0.7, 760 ) );
            Assert.Null( exception );
        }
    }
}
