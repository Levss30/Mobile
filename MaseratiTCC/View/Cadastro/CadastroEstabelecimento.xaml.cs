using MaseratiTCC.View.Perfil;
using MaseratiTCC.ViewModels.Estabelecimentos;

namespace MaseratiTCC.View.Cadastro;

public partial class CadastroEstabelecimento : ContentPage
{
    EstabelecimentoViewModel viewModel;
    public CadastroEstabelecimento()
	{
		InitializeComponent();
        viewModel = new EstabelecimentoViewModel();
        BindingContext = viewModel;
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoCadastro());
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {

    }
}