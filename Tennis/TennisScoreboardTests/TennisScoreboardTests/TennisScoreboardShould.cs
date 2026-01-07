using TennisScoreboard.Domain.Models;
using TennisScoreboardTests.Scenarios;

namespace TennisScoreboardTests;

public class TennisScoreboardShould
{
    [Fact]
    public void ComputeTennisScoreBoardWhenGameStarted()
    {
        TennisScoreboardScenario.New()
            .GivenACompetition()
            .WhenAMatchIsPlayedBy(Player.FromId("player_A"), Player.FromId("player_B"))
            .ThenTheScoreBoardShouldBe(new Scoreboard
            {
                PlayerAScore = 0,
                PlayerBScore = 0
            });
    }

    [Fact]
    public void ComputeTennisScoreBoardWhenPlayerWinOnce()
    {
        TennisScoreboardScenario.New()
            .GivenACompetition()
            .WhenAMatchIsPlayedBy(Player.FromId("player_A"), Player.FromId("player_B"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .ThenTheScoreBoardShouldBe(new Scoreboard
            {
                PlayerAScore = 15,
                PlayerBScore = 0
            });
    }

    [Fact]
    public void ComputeTennisScoreBoardWhenPlayerWinTwice()
    {
        TennisScoreboardScenario.New()
            .GivenACompetition()
            .WhenAMatchIsPlayedBy(Player.FromId("player_A"), Player.FromId("player_B"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .ThenTheScoreBoardShouldBe(new Scoreboard
            {
                PlayerAScore = 30,
                PlayerBScore = 0
            });
    }

    [Fact]
    public void ComputeTennisScoreBoardWhenPlayerWinThreeTimes()
    {
        TennisScoreboardScenario.New()
            .GivenACompetition()
            .WhenAMatchIsPlayedBy(Player.FromId("player_A"), Player.FromId("player_B"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .ThenTheScoreBoardShouldBe(new Scoreboard
            {
                PlayerAScore = 40,
                PlayerBScore = 0
            });
    }

    [Fact]
    public void ComputeTennisScoreBoardWhenPlayerWinFourTimes()
    {
        TennisScoreboardScenario.New()
            .GivenACompetition()
            .WhenAMatchIsPlayedBy(Player.FromId("player_A"), Player.FromId("player_B"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .AndScoredOnceBy(Player.FromId("player_A"))
            .ThenTheScoreBoardShouldBe(new Scoreboard
            {
                PlayerAScore = 0,
                PlayerBScore = 0,
                PlayerAGame = 1,
                PlayerBGame = 0
            });
    }
}