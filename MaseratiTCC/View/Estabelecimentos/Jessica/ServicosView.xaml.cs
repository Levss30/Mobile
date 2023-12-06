using CommunityToolkit.Maui.Views;
using MaseratiTCC.View.Options;
using MaseratiTCC.ViewModels.Usuarios;
using MauiToolkitPopupSample;
using System.Globalization;


namespace MaseratiTCC.View.Estabelecimentos.Jessica;

public partial class ServicosView : ContentPage
{
    UsuarioViewModel viewModel;
    public ServicosView()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjkzNjY1NEAzMjMzMmUzMDJlMzBJbkpzNWlGZWZ0TmdzTlFOTmhuQWQyVnVkYmwwMVZ2MXNCVi9hc3ZkeDVZPQ==\r\n");
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;

    }
    private void btnAgendar_Clicked(object sender, EventArgs e)
    {


        var selectedItem = picker1.SelectedItem;
        if (selectedItem == null)
        {
            DisplayAlert("Aviso", "Por favor, selecione um serviço antes de continuar.", "OK");
        }
        else
        {
            // Continue com a lógica, pois um item foi selecionado
            this.ShowPopup(new PopUpView());
        }

    }
}