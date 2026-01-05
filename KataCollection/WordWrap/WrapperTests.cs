using Xunit;

namespace WordWrap
{
    public class WrapperTests
    {
        [Fact]
        public void WhenWrapperCalled_ShouldReturnValue()
        {
            var wrappedValue = Wrapper.Wrap("", 1);
            Assert.NotNull(wrappedValue);
        }

        [Fact]
        public void GivenStaticWrapper_WhenCalledWithNull_ShouldReturnEmptyValue()
        {
            var wrappedValue = Wrapper.Wrap("", 1);
            Assert.Equal("", wrappedValue);
        }

        [Fact]
        public void GivenStaticWrapper_WhenCalledWithSentence_ShouldReturnSentence()
        {
            var wrappedValue = Wrapper.Wrap("A dumy sentence.", 100);
            Assert.Equal("A dumy sentence.", wrappedValue);
        }

        [Fact]
        public void GivenStaticWrapper_WhenCalledWith15CharactersSentence_ShouldReturn2Rows()
        {
            var wrappedValue = Wrapper.Wrap("A dumy sentence.", 8);
            Assert.Equal("A dumy\nsentence.", wrappedValue);
        }
    }
}
