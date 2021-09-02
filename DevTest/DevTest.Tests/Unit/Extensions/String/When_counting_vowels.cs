using Xunit;
using DevTest.BL.Extensions;
using FluentAssertions;

namespace DevTest.Tests.Unit.Extensions.String
{
    public class When_counting_vowels
    {
        [Theory]
        [InlineData("John Doe", 3)]
        [InlineData("This is a long sentence", 7)]
        [InlineData("i", 1)]
        [InlineData("p",0)]
        public void It_returns_correct_amount(string sentence, int expectedResult)
        {
            sentence.CountVowels().Should().Be(expectedResult);
        }
    }
}
