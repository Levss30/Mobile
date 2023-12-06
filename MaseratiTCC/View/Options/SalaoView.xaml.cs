using MaseratiTCC.Models;
using MaseratiTCC.View.Estabelecimentos;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Options
{
    public partial class SalaoView : ContentPage
    {
        UsuarioViewModel viewModel;
        public List<CarouselItem> CarouselItems { get; set; }
        private StackLayout ratingStackLayout;

        public SalaoView()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            BindingContext = viewModel;
            CarouselItems = new List<CarouselItem>
{
                new CarouselItem { ImagePath = "jessica.png", Description = "Jessica Brune", Avaliacao = 5 , DestinationPage = typeof(JessicaView)},
                new CarouselItem { ImagePath = "embreve.png", Description = "Outra Descrição", Avaliacao = 4 },
                new CarouselItem { ImagePath = "embreve.png", Description = "Alguma Descrição", Avaliacao = 2 }
            };

            carouselView.ItemsSource = CarouselItems;

            ratingStackLayout = new StackLayout();

            for (int i = 0; i < 5; i++)
            {
                Image starImage = new Image();
                ratingStackLayout.Children.Add(starImage);
            }

            carouselView.PositionChanged += CarouselView_PositionChanged;
        }



        private void UpdateRatingStars(List<bool> estrelas)
        {
            for (int i = 0; i < ratingStackLayout.Children.Count; i++)
            {
                if (ratingStackLayout.Children[i] is Image starImage)
                {
                    starImage.IsVisible = estrelas[i];
                }
            }
        }

        private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (carouselView.Position >= 0 && carouselView.Position < CarouselItems.Count)
            {
                var selectedItem = CarouselItems[carouselView.Position];
                UpdateRatingStars(selectedItem.Estrelas);
            }
        }

        private async void OnImageTapped4(object sender, EventArgs e)
        {
            try
            {
                var clickedImage = sender as ImageButton;
                if (clickedImage != null)
                {
                    var clickedItem = clickedImage.BindingContext as CarouselItem;
                    if (clickedItem != null && clickedItem.DestinationPage != null)
                    {
                        var destinationPage = (Page)Activator.CreateInstance(clickedItem.DestinationPage);
                        await Navigation.PushAsync(destinationPage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao manipular evento OnImageTapped4: {ex.Message}");
            }
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            carouselView.Position = (carouselView.Position - 1 + CarouselItems.Count) % CarouselItems.Count;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            carouselView.Position = (carouselView.Position + 1) % CarouselItems.Count;
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
        }
    }




}
