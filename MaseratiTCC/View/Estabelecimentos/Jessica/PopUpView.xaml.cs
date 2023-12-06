using CommunityToolkit.Maui.Views;
using MaseratiTCC;
using MaseratiTCC.View.Estabelecimentos.Jessica;
using Microsoft.Maui.Controls;
using System;

namespace MauiToolkitPopupSample
{
    public partial class PopUpView : Popup
    {
        private readonly Page _mainPage;
        public PopUpView()
        {
            InitializeComponent();
            _mainPage = _mainPage;
        }


        private async void ConfirmarHorario_Clicked(object sender, EventArgs e)
        {
            var selectedTime = timePicker.Time;

            Close();

            var currentPage = this.Parent as Page;

            if (selectedTime != TimeSpan.Zero) 
            {
                await currentPage.DisplayAlert("Agendado!!", $"Horário marcado para: {selectedTime}", "OK");

                await currentPage.Navigation.PopToRootAsync();
                await currentPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await currentPage.DisplayAlert("Aviso", "Por favor, selecione um horário antes de continuar.", "OK");
            }
        }




    }
}
