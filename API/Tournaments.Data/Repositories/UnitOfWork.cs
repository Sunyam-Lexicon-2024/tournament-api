namespace Tournaments.Data.Repositories;

public class UnitOfWork(
    TournamentsContext tournamentsContext,
    IRepository<Tournament> tournamentRepository,
    IRepository<Game> gameRepository
) : IUnitOfWork
{
    private readonly TournamentsContext _tournamentsContext = tournamentsContext;
    private readonly IRepository<Tournament> _tournamentRepository = tournamentRepository;
    private readonly IRepository<Game> _gameRepository = gameRepository;

    private bool _disposed = false;

    public IRepository<Tournament> TournamentRepository => _tournamentRepository;

    public IRepository<Game> GameRepository => _gameRepository;

    public async Task CompleteAsync()
    {
        await _tournamentsContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _tournamentsContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}