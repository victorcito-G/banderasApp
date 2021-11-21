using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace banderasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            //var latitud = Convert.ToDouble(lblatitud.Text);
            //var longitud = Convert.ToDouble(lblongitud.Text);

            //posicion del mapa 
            myMapa.MoveToRegion(
               //MapSpan.FromCenterAndRadius(new Position(latitud, longitud),
               MapSpan.FromCenterAndRadius(new Position(15.5198897, -88.05553),
                Distance.FromKilometers(30))
                );

            List<Models.Countries.CountriesRest> listapaises = new List<Models.Countries.CountriesRest>();

           

            Pin pin = new Pin
            {
                Label = "San Pedro Sula",
                Address = "Mall Galeria",
                Type = PinType.Place,
                Position = new Position(15.5198897, -88.05553)
            };

            myMapa.Pins.Add(pin);

        }
    }
}