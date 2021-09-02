using Xunit;
using DevTest.BL.Extensions;
using FluentAssertions;

namespace DevTest.Tests.Unit.Extensions.String
{
    public class When_counting_consonants
    {
        [Theory]
        [InlineData("John Doe", 4)]
        [InlineData("This is a long sentence", 12)]
        [InlineData("i", 0)]
        [InlineData("p", 1)]
        public void It_returns_correct_amount(string sentence, int expectedResult)
        {
            sentence.CountConsonants().Should().Be(expectedResult);
        }
    }
}
