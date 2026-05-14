using SQLite;
using CityExplorerAiron.Models;

namespace CityExplorerAiron.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _db;

    async Task Init()
    {
        if (_db is not null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "CityExplorer.db3");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Landmark>();
    }

    public async Task<List<Landmark>> GetFavoritesAsync()
    {
        await Init();
        return await _db.Table<Landmark>().ToListAsync();
    }

    public async Task AddFavoriteAsync(Landmark landmark)
    {
        await Init();
        await _db.InsertAsync(landmark);
    }

    public async Task DeleteFavoriteAsync(Landmark landmark)
    {
        await Init();
        await _db.DeleteAsync(landmark);
    }
}