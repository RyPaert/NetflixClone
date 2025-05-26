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

    private void SimilarTab_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TrailersTab_Tapped(object sender, TappedEventArgs e)
    {

    }
}