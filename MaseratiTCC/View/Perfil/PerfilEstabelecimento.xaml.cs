using MaseratiTCC.View.Login;

namespace MaseratiTCC.View.Perfil;

public partial class PerfilEstabelecimento : ContentPage
{
	public PerfilEstabelecimento()
	{
		InitializeComponent();
	}

    private void OnAlterarFotoClicked(object sender, EventArgs e)
    {

    }

    private void btnSair_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new LoginView());
    }

    private void OnDescricaoImageTapped(object sender, TappedEventArgs e)
    {

    }

    private void OnCepImageTapped(object sender, TappedEventArgs e)
    {

    }

    private void OnEnderecoImageTapped(object sender, TappedEventArgs e)
    {

    }
}