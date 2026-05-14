using CityExplorerAiron.ViewModels;

namespace CityExplorerAiron.Views;

public partial class FavoritesPage : ContentPage
{
    // Kasutame readonly m‰rksına, et tagada andmete turvalisus
    private readonly FavoritesViewModel _viewModel;

    public FavoritesPage(FavoritesViewModel viewModel)
    {
        InitializeComponent();

        // M‰‰rame ViewModeli nii muutujasse kui ka BindingContextiks
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // K‰ivitame laadimise k‰su
        // On hea tava kontrollida, kas k‰sku saab t‰ita, kuigi antud juhul on see alati tıene
        if (_viewModel.LoadFavoritesCommand.CanExecute(null))
        {
            _viewModel.LoadFavoritesCommand.Execute(null);
        }
    }

}