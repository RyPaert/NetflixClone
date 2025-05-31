using NetflixCloneMAUI.ViewModels;

namespace NetflixCloneMAUI.Pages;

public partial class DetailsPage : ContentPage
{
    private readonly DetailsViewModel _viewModel;

    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();

    }

    private void TrailersTab_Tapped(object sender, TappedEventArgs e)
    {
        similarTabIndicaror.Color = Colors.Black;
        similarTabContent.IsVisible = false;

        trailersTabIndicaror.Color = Colors.Red;
        trailersTabContent.IsVisible = true;
    }

    private void SimilarTab_Tapped(object sender, TappedEventArgs e)
    {
        trailersTabIndicaror.Color = Colors.Black;
        trailersTabContent.IsVisible = false;

        similarTabIndicaror.Color = Colors.Red;
        similarTabContent.IsVisible = true;
    }
}