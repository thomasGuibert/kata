using System;
using System.Collections.Generic;
using Xunit;

namespace Bowling
{
    public class ScoreResolverTests
    {
        [Fact]
        public void GivenAScoreResolver_ThenExist()
        {
            var resolver = new ScoreResolver();
            Assert.NotNull(resolver);
        }

        [Fact]
        public void GivenANotFinishGame_WhenResolve_ThenThows()
        {
            //Arrange
            var firstThrow = "1";
            var secondThrow = "1";
            var game = new Game();
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            var resolver = new ScoreResolver();

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => resolver.Resolve(game));
            Assert.Contains("contains 2 results but expected 5", exception.Message);
        }

        [Theory]
        [InlineData("1", "1", 10)]
        [InlineData("1", "2", 15)]
        public void GivenAGameOnlyHits_WhenResolve_ThenResolveSumOfHit(
            string firstThrow, 
            string secondThrow, 
            int expectedResult)
        {
            Game game = GenerateDumyGame(firstThrow, secondThrow);

            var resolver = new ScoreResolver();

            var score = resolver.Resolve(game);

            Assert.Equal(expectedResult, score);
        }

        [Fact]
        public void GivenAGameWithASpare_WhenResolve_ThenThrowAfterSpareCountedTwice()
        {
            var game = new Game();
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("/"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            var resolver = new ScoreResolver();

            var score = resolver.Resolve(game);

            Assert.Equal(18+1, score);
        }

        [Fact]
        public void GivenAGameWithAStrike_WhenResolve_ThenThrowAfterSpareCountedTwice()
        {
            var game = new Game();
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("x"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            game.AddFrame(Frame.AddFristThrow("1").AddSecondThrow("1"));
            var resolver = new ScoreResolver();

            var score = resolver.Resolve(game);

            Assert.Equal(18 + 2, score);
        }

        private static Game GenerateDumyGame(string firstThrow, string secondThrow)
        {
            var game = new Game();
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            game.AddFrame(Frame.AddFristThrow(firstThrow).AddSecondThrow(secondThrow));
            return game;
        }
    }
}
