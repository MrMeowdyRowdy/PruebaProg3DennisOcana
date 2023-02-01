

namespace Prueba;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ImageList), typeof(ImageList));

    }
}
