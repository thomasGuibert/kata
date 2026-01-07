using Shouldly;
using TennisScoreboard.Domain.Models;

namespace TennisScoreboardTests.Scenarios;

internal class TennisScoreboardScenario
{
    private Competition _competition;
    private TennisMatch _currentMatch;

    internal TennisScoreboardScenario ThenTheScoreBoardShouldBe(Scoreboard expectedScoreBoard)
    {
        _competition.Scoreboard.ShouldBe(expectedScoreBoard);
        return this;
    }

    internal TennisScoreboardScenario WhenAMatchIsPlayedBy(Player playerA, Player playerB)
    {
        _currentMatch = TennisMatch.WithPlayers(playerA, playerB);
        _competition.AddMatch(_currentMatch);
        return this;
    }

    internal TennisScoreboardScenario GivenACompetition()
    {
        _competition = new Competition();
        return this;
    }
    internal static TennisScoreboardScenario New() => new ();

    public TennisScoreboardScenario AndScoredOnceBy(Player player)
    {
        _currentMatch.ScorePoint(player);
        return this;
    }
}