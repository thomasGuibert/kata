namespace TennisScoreboard.Domain.Models;

public record Player
{ 
    public string Id { get; init; }

    private Player(string id)
    {
        Id = id;
    }

    public static Player FromId(string playerId) 
        => new(playerId);
}