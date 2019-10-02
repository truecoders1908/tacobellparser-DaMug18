using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("0, 0, Taco Bell Warrior", 0, 0, "Taco Bell Warrior")]
        [InlineData("32, -85, Taco Bell Auburn", 32, -85, "Taco Bell Auburn")]
        [InlineData("30, -87, Taco Bell Pensacola", 30, -87, "Taco Bell Pensacola")]
        public void ShouldParse(string str, double expectedLat, double expectedLon, string expectedName)
        {
            // TODO: Complete Should Parse
            TacoParser parsed = new TacoParser();

            //Act
            ITrackable actual = parsed.Parse(str);

            //Assert
            Assert.Equal(expectedLat, actual.Location.Latitude);
            Assert.Equal(expectedLon, actual.Location.Longitude);
            Assert.Equal(expectedName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Taco, Bell")]
        [InlineData("-91, 50, Taco Bell Warrior")]
        [InlineData("50, bell, Taco Mama")]
        [InlineData("Are you kidding me, NO, 32")]
        [InlineData("0, 180, Taco Daddy")]
        [InlineData("90, 90 ")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            TacoParser tacoparser = new TacoParser();

            //Act
            ITrackable actual = tacoparser.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}
