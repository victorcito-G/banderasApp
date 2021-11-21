using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace banderasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaBanderasPage : ContentPage
    {
        public ListaBanderasPage()
        {
            InitializeComponent();
        }

        // mostras lista de personas 

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                List<Models.Countries.CountriesRest> listapaises = new List<Models.Countries.CountriesRest>();
                listapaises = await Controller.CountriesController.getCountries();

                lstPaises.ItemsSource = listapaises;
            }
            else
            {
                await DisplayAlert("Error de Conexion", "Sin Conexion a Internet", "OK");
            }

        }

       

        private async void lstPaises_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            List<Models.Countries.CountriesRest> listapaises = new List<Models.Countries.CountriesRest>();
            //listapaises = await Controller.CountriesController.getCountries();
            //await DisplayAlert("Elemento Tocado ", "correo: " + listapaises, "Ok");
            //await DisplayAlert("Elemento Tocado ", "correo: ", "Ok");
            var mensaje = await DisplayAlert("Mensaje", "Desea ir a la ubicacion seleccionada en el Mapa", "Yes", "No");
            if (mensaje)
            {
                var page = new Views.MapPage();
                page.BindingContext = listapaises;
                await Navigation.PushAsync(page);
            }

            

        }

        private void btncountries_Clicked(object sender, EventArgs e)
        {

        }

        private void CountriesSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Models.Countries.CountriesRest> listapaises = new List<Models.Countries.CountriesRest>();

            //var countriesSearched = listapaises.where(c => c.Contains(CountriesSearchBar.Text));
            //lstPaises.ItemsSource = countriesSearched;

            //SearchBar searchBar = (SearchBar)sender;
            //lstPaises.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }
    }
}