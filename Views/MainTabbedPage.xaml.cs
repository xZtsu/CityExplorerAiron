using CityExplorerAiron.Services;
using CityExplorerAiron.Resources.Strings;

namespace CityExplorerAiron.Views;

public partial class MainTabbedPage : TabbedPage
{
    private readonly ExplorePage _explorePage;
    private readonly FavoritesPage _favoritesPage;
    private readonly SettingsPage _settingsPage;

    public MainTabbedPage(ExplorePage explorePage, FavoritesPage favoritesPage, SettingsPage settingsPage)
    {
        InitializeComponent();

        _explorePage = explorePage;
        _favoritesPage = favoritesPage;
        _settingsPage = settingsPage;

        Children.Add(_explorePage);
        Children.Add(_favoritesPage);
        Children.Add(_settingsPage);

        UpdateLabels();


        LanguageService.LanguageChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            UpdateLabels();


            var current = CurrentPage;
            var children = Children.ToList();
            Children.Clear();
            foreach (var child in children) Children.Add(child);
            CurrentPage = current;
        });
    }

    private void UpdateLabels()
    {
        _explorePage.Title = AppResources.ExploreTitle;
        _favoritesPage.Title = AppResources.FavoriteTitle;
        _settingsPage.Title = AppResources.SettingTitle;
    }
}