namespace TennisScoreboard.Domain.Models;

public class TennisMatch
{
    public IDictionary<Player, Score> PlayersScore;

    private TennisMatch(Player playerA, Player playerB)
    {
        PlayersScore = new Dictionary<Player, Score>
        {
            { playerA, new Score() },
            { playerB, new Score() },
        };
    }

    public static TennisMatch WithPlayers(Player playerA, Player playerB) => new(playerA, playerB);

    public void ScorePoint(Player player)
    {
        PlayersScore[player].ScorePoint();
    }
}

public class Score
{
    private readonly IReadOnlyList<int> _scoreValues = new[]
    {
        0, 15, 30, 40
    };

    private int _currentScoreIndex = 0;
    public int Value => _scoreValues[_currentScoreIndex];
    public int Game = 0;

    public void ScorePoint()
    {
        if(_currentScoreIndex < 3)
            _currentScoreIndex++;
        else
        {
            _currentScoreIndex = 0;
            Game++;
        }
           
    }
}