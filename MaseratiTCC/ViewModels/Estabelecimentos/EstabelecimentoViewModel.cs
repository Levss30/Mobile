using MaseratiTCC.Models;
using MaseratiTCC.Models.Enuns;
using MaseratiTCC.Services.Estabelecimentos;
using MaseratiTCC.Services.Usuarios;
using MaseratiTCC.View.Cadastro;
using MaseratiTCC.View.Login;
using MauiApp1.View.Senhas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaseratiTCC.Services.Estabelecimentos;
using MaseratiTCC.View.Perfil;

namespace MaseratiTCC.ViewModels.Estabelecimentos
{
    public class EstabelecimentoViewModel : BaseViewModel
    {
        private EstabelecimentosServices eService;

        public EstabelecimentoViewModel()
        {
            eService = new EstabelecimentosServices();
            InicializarCommands();
        }

        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarEstabelecimento());
            AutenticarCommand = new Command(async () => await AutenticarEstabelecimento());
        }

        private string cnpj = string.Empty;
        public string Cnpj
        {
            get { return cnpj; }
            set
            {
                cnpj = value;
                OnPropertyChanged();
            }
        }


        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string endereco = string.Empty;
        public string Endereco
        {
            get { return endereco; }
            set
            {
                endereco = value;
                OnPropertyChanged();
            }
        }

        private int cep = 0;
        public int Cep
        {
            get { return cep; }
            set
            {
                cep = value;
                OnPropertyChanged();
            }
        }

        private int complemento = 0;
        public int Complemento
        {
            get { return complemento; }
            set
            {
                complemento = value;
                OnPropertyChanged();
            }
        }

        private int numero_est = 0;
        public int Numero_est
        {
            get { return numero_est; }
            set
            {
                numero_est = value;
                OnPropertyChanged();
            }
        }

        private int telefone = 0;
        public int Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                OnPropertyChanged();
            }
        }


        private string nome_est = string.Empty;
        public string Nome_est
        {
            get { return nome_est; }
            set
            {
                nome_est = value;
                OnPropertyChanged();
            }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        public async Task RegistrarEstabelecimento()
        {
            try
            {
                Estabelecimento e = new Estabelecimento();
                e.Email = Email;
                e.Nome_est = Nome_est;
                e.Endereco = Endereco;
                e.CEP = Cep;
                e.Numero_est = Numero_est;
                e.Telefone = Telefone;
                e.Complemento = Complemento;
                e.UsuarioId = 1;
                e.Senha = Senha;
                e.Cnpj = Cnpj;

                Estabelecimento eRegistrado = await eService.PostResgistrarEstabelecimentoAsync(e);

                if (eRegistrado.Id != 0)
                {
                    string mensagem = $"O estabelecimento {eRegistrado.Nome_est} foi registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.
                        Navigation.PushAsync(new LoginView());
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarEstabelecimento()
        {
            try
            {
                Estabelecimento e = new Estabelecimento();
                e.Email = Email;
                e.Senha = Senha;

                Estabelecimento eAutenticado = await eService.PostAutenticarEstabelecimentoAsync(e);

                if (!string.IsNullOrEmpty(eAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {eAutenticado.Nome_est}.";
                    Preferences.Set("EstabelecimentoId", eAutenticado.Id);
                    Preferences.Set("EstabelecimentoCNPJ", eAutenticado.Cnpj);
                    Preferences.Set("EstabelecimentoEmail", eAutenticado.Email);
                    Preferences.Set("EstabelecimentoEndereco", eAutenticado.Endereco);
                    Preferences.Set("EstabelecimentoCEP", eAutenticado.CEP);
                    Preferences.Set("EstabelecimentoNumeroest", eAutenticado.Numero_est);
                    Preferences.Set("EstabelecimentoTelefone", eAutenticado.Telefone);
                    Preferences.Set("EstabelecimentoSenha", eAutenticado.Senha);
                    Preferences.Set("EstabelecimentoNome", eAutenticado.Nome_est);
                    Preferences.Set("EstabelecimentoToken", eAutenticado.Token);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.
                        Navigation.PushAsync(new PerfilEstabelecimento());
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :C", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
