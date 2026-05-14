using CityExplorerAiron.ViewModels;

namespace CityExplorerAiron.Views;

public partial class ExplorePage : ContentPage
{

    public ExplorePage(ExploreViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}