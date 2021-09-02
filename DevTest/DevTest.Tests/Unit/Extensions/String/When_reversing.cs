using Xunit;
using DevTest.BL.Extensions;
using FluentAssertions;

namespace DevTest.Tests.Unit.Extensions.String
{
    public class When_reversing
    {
        [Theory]
        [InlineData("yes", "sey")]
        [InlineData("John Doe", "eoD nhoJ")]
        [InlineData("This is a long sentence", "ecnetnes gnol a si sihT")]
        public void It_returns_reversed_string(string sentence, string expectedResult)
        {
            sentence.Reverse().Should().Be(expectedResult);
        }
    }
}
