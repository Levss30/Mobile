using MaseratiTCC.View.Login;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Cadastro;

public partial class CadastroView : ContentPage
{
    UsuarioViewModel viewModel;
    public CadastroView()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }
    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoCadastro());
    }

    private bool ValidarCPF()
    {
        if (string.IsNullOrWhiteSpace(viewModel.Cpf))
        {
            return false;
        }

        string cpfLimpo = new string(viewModel.Cpf.Where(char.IsDigit).ToArray());

        if (cpfLimpo.Length != 11 || cpfLimpo.Distinct().Count() == 1)
        {
            return false;
        }

        // Verifica se todos os dígitos são iguais
        if (cpfLimpo.All(c => c == cpfLimpo[0]))
        {
            return false;
        }

        // Calcula os dígitos verificadores
        int digitoVerificador1 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 9));
        int digitoVerificador2 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 10));

        return digitoVerificador1 == cpfLimpo[9] - '0' && digitoVerificador2 == cpfLimpo[10] - '0';
    }

    private int CalcularDigitoVerificador(string parteCpf)
    {
        int soma = 0;
        int multiplicador = parteCpf.Length + 1;

        foreach (char c in parteCpf)
        {
            soma += (c - '0') * multiplicador;
            multiplicador--;
        }

        int resto = soma % 11;

        return resto < 2 ? 0 : 11 - resto;
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {

    }
}