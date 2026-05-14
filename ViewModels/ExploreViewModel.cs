using System.Collections.ObjectModel;
using System.Windows.Input;
using CityExplorerAiron.Models;
using CityExplorerAiron.Services;

namespace CityExplorerAiron.ViewModels;

public class ExploreViewModel : BaseViewModel
{
    private readonly DatabaseService _dbService;
    private List<Landmark> _allLandmarks;

    public ObservableCollection<Landmark> VisibleLandmarks { get; set; } = new();
    public ObservableCollection<Category> Categories { get; set; } = new();

    public ICommand FilterCommand { get; }
    public ICommand AddToFavoritesCommand { get; }

    public ExploreViewModel(DatabaseService dbService)
    {
        _dbService = dbService;

        _allLandmarks = new List<Landmark>
        {
            new Landmark { Name = "Tallinna Raekoda", CategoryEmoji = "🏰", Description = "Põhja-Euroopa vanim raekoda.", ImageUrl = "raekoda.jpg" },
            new Landmark { Name = "Kadrioru Park", CategoryEmoji = "🌳", Description = "Lossipark ja muuseumid.", ImageUrl = "kadriorg.jpg" },
            new Landmark { Name = "Rataskaevu 16", CategoryEmoji = "🍽️", Description = "Legendaarne restoran vanalinnas.", ImageUrl = "restoran.jpg" },
            new Landmark { Name = "Vanalinn", CategoryEmoji = "🏰", Description = "Vanalinn", ImageUrl = "vanalinn.jpg" }
        };

        Categories.Add(new Category { Emoji = "🏰", Name = "Ajalugu" });
        Categories.Add(new Category { Emoji = "🌳", Name = "Pargid" });
        Categories.Add(new Category { Emoji = "🍽️", Name = "Toit" });

        FilterCommand = new Command<string>(Filter);
        AddToFavoritesCommand = new Command<Landmark>(async (l) => await _dbService.AddFavoriteAsync(l));

        Filter("🏰"); // Vaikimisi laadimine
    }

    private void Filter(string emoji)
    {
        var filtered = _allLandmarks.Where(x => x.CategoryEmoji == emoji).ToList();
        VisibleLandmarks.Clear();
        foreach (var item in filtered) VisibleLandmarks.Add(item);
    }
}