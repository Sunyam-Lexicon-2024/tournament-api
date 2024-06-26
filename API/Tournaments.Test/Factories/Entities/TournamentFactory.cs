namespace Tournaments.Test.Factories.Entities;

public class TournamentFactory()
{
    public static List<Tournament> Generate(int count)
    {
        List<Tournament> tournaments = [];

        for (int i = 0; i < count; i++)
        {
            Tournament game = new($"Tournament-{i + 1}")
            {
                Id = i + 1,
                StartDate = new DateOnly(2024, 1, 1)
            };
            tournaments.Add(game);
        }
        return tournaments;
    }

    public static List<Tournament> GenerateWithChildren(int count)
    {
        List<Tournament> tournaments = [];

        for (int i = 0; i < count; i++)
        {
            Tournament tournament = new($"Tournament-{i + 1}")
            {
                Id = i + 1,
                StartDate = new DateOnly(2024, 1, 1),
            };

            foreach (Game g in GameFactory.Generate(5))
            {
                tournament.Games.Add(g);
            }

            tournaments.Add(tournament);
        }
        return tournaments;
    }

    public static Tournament GenerateSingle()
    {
        return new Tournament("Tournament-1")
        {
            Id = 1,
            StartDate = new DateOnly(2024, 1, 1)
        };
    }
}