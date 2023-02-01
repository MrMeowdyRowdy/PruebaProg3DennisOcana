using Prueba.ViewModels;

namespace Prueba;

public partial class ImageList : ContentPage
{
	private ImageListModel viewMode;
    public ImageList(ImageListModel viewModel)
	{
		InitializeComponent();
        viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewMode.GetPhotoListCommand.Execute(null);
    }
}