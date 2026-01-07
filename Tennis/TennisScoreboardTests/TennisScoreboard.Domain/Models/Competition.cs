namespace TennisScoreboard.Domain.Models;

public class Competition
{
    private IList<TennisMatch> _matches = new List<TennisMatch>();
    public Scoreboard Scoreboard =>
        new()
        {
            PlayerAScore = _matches.FirstOrDefault().PlayersScore.First().Value.Value,
            PlayerBScore = _matches.FirstOrDefault().PlayersScore.Last().Value.Value,
            PlayerAGame = _matches.FirstOrDefault().PlayersScore.First().Value.Game,
            PlayerBGame = _matches.FirstOrDefault().PlayersScore.Last().Value.Game
        };

    public void AddMatch(TennisMatch match)
    {
        _matches.Add(match);
    }
}