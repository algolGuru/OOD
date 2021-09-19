using observer;
using System.Collections.Generic;
using Xunit;

namespace subscribers3Tests
{
    public class ObserverTests
    {
        [Fact]
        public void GetSubscribers_SubscribersSortedByPriority()
        {
            //Arrange
            WeatherData weatherData = new WeatherData( 0.0, 0.0, 760.0 );

            Subscriber<WeatherInfo> display = new Subscriber<WeatherInfo>( 1, new Display() );
            weatherData.RegisterObserver( display );

            Subscriber<WeatherInfo> display2 = new Subscriber<WeatherInfo>( 6, new Display() );
            weatherData.RegisterObserver( display2 );

            Subscriber<WeatherInfo> statsDisplay = new Subscriber<WeatherInfo>( 3, new StatisticDisplay() );
            weatherData.RegisterObserver( statsDisplay );

            Subscriber<WeatherInfo> statsDisplay2 = new Subscriber<WeatherInfo>( 2, new StatisticDisplay() );
            weatherData.RegisterObserver( statsDisplay2 );

            //Act
            List<Subscriber<WeatherInfo>> subscribers = weatherData.GetSubscribers();

            //Assert
            Assert.True( subscribers[ 3 ].Priority <= subscribers[ 2 ].Priority );
            Assert.True( subscribers[ 2 ].Priority <= subscribers[ 1 ].Priority );
            Assert.True( subscribers[ 1 ].Priority <= subscribers[ 0 ].Priority );
        }
    }
}
