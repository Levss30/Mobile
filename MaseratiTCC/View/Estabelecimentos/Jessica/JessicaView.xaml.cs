using MauiApp1.View.Senhas;
using MaseratiTCC.View.Estabelecimentos.Jessica;

namespace MaseratiTCC.View.Estabelecimentos;

public partial class JessicaView : ContentPage
{
	public JessicaView()
	{
		InitializeComponent();
    }

    private void Label_SizeChanged(object sender, EventArgs e)
    {

    }

    private void btnServicos_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ServicosView());
    }
}