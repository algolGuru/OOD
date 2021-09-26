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

            ObserverStub<WeatherInfo> observerStubSub1 = new ObserverStub<WeatherInfo>();
            ObserverStub<WeatherInfo> observerStubSub2 = new ObserverStub<WeatherInfo>();
            ObserverStubWithUnsubscribe<WeatherInfo> observerStubSub3 = new ObserverStubWithUnsubscribe<WeatherInfo>();
            weatherData.RegisterObserver( observerStubSub1 );
            weatherData.RegisterObserver( observerStubSub2 );
            weatherData.RegisterObserver( observerStubSub3 );

            //Act
            var exception = Record.Exception( () => weatherData.SetMeasurements( 3, 0.7, 760 ) );

            //Assert
            Assert.Null( exception );
            Assert.Equal( 1, ObserverStubWithUnsubscribe<WeatherInfo>.CallCount );
            Assert.Equal( 2, ObserverStub<WeatherInfo>.CallCount );
        }
    }

    public class ObserverStub<T> : IObserver<T>
    {
        public static int CallCount { get; set; }

        public void Update( T data, Observer<T> observer )
        {
            CallCount++;
        }
    }

    public class ObserverStubWithUnsubscribe<T> : IObserver<T>
    {
        public static int CallCount { get; set; }

        public void Update( T data, Observer<T> observer )
        {
            CallCount++;
            observer.RemoveObserver( this );
        }
    }
}
