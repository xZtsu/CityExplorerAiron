using System.Collections.ObjectModel;
using System.Windows.Input;
using CityExplorerAiron.Models;
using CityExplorerAiron.Services;
using CityExplorerAiron.Resources.Strings; // Vajalik tõlgete jaoks

namespace CityExplorerAiron.ViewModels;

public class FavoritesViewModel : BaseViewModel
{
    private readonly DatabaseService _dbService;

    public ObservableCollection<Landmark> FavoriteLandmarks { get; set; } = new();


    public string FavoritesHeaderText => AppResources.FavoriteTitle;

    public ICommand LoadFavoritesCommand { get; }
    public ICommand DeleteFavoriteCommand { get; }

    public FavoritesViewModel(DatabaseService dbService)
    {
        _dbService = dbService;

        DeleteFavoriteCommand = new Command<Landmark>(async (landmark) => await DeleteFavorite(landmark));
        LoadFavoritesCommand = new Command(async () => await LoadFavorites());

        LanguageService.LanguageChanged += () =>
        {
            OnPropertyChanged(nameof(FavoritesHeaderText));
        };
    }

    private async Task LoadFavorites()
    {
        var favorites = await _dbService.GetFavoritesAsync();
        FavoriteLandmarks.Clear();
        foreach (var item in favorites)
        {
            FavoriteLandmarks.Add(item);
        }
    }

    private async Task DeleteFavorite(Landmark landmark)
    {
        if (landmark == null) return;

        bool confirm = await App.Current.MainPage.DisplayAlert(
            AppResources.FavoriteTitle,
            $"{landmark.Name}?",
            "OK", "Cancel");

        if (confirm)
        {
            await _dbService.DeleteFavoriteAsync(landmark);
            FavoriteLandmarks.Remove(landmark);
        }
    }
}