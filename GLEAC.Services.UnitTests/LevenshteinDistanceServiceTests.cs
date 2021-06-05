using System;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;
using GLEAC.Services.LevenshteinDistance;
using Xunit;

namespace GLEAC.Services.UnitTests
{
    public class LevenshteinDistanceServiceTests
    {

        LevenshteinDistanceService _levenshteinDistanceService;

        public LevenshteinDistanceServiceTests()
        {
            _levenshteinDistanceService = new LevenshteinDistanceService();
        }


        [Theory]
        [InlineData("", "", 0)]
        [InlineData(" ", " ", 0)]
        [InlineData("v", "v", 0)]
        [InlineData("1", "2", 1)]
        [InlineData("123", "12", 1)]
        [InlineData("1234", "1", 3)]
        [InlineData("vinay", "vinay", 0)]
        [InlineData("vinak", "vinay", 1)]
        [InlineData("HONDA", "HYUNDAI", 3)]
        public void CalculateLevenshteinDistance_ShouldReturnLevenshteinDistance(string string1, string string2, int ExpectedDistence)
        {
            var result = _levenshteinDistanceService.CalculateLevenshteinDistance(
                new LevenshteinDistanceRequest(string1, string2));

            Assert.Equal(ExpectedDistence, result.Distance);
        }


        [Theory]
        [InlineData(null, "")]
        [InlineData("", null)]

        public void CalculateLevenshteinDistance_ShouldThrowExceptionIfAnyArgumentIsNull(string string1, string string2)
        {
            Assert.Throws<ArgumentNullException>(() => _levenshteinDistanceService.CalculateLevenshteinDistance(new LevenshteinDistanceRequest(string1, string2)));
        }
    }
}
