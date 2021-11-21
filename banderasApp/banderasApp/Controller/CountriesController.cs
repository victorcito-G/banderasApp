using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace banderasApp.Controller
{
    public class CountriesController
    {

        public async static Task<List<Models.Countries.CountriesRest>> getCountries()
        {
            List<Models.Countries.CountriesRest> listapaises = new List<Models.Countries.CountriesRest>();

            using (System.Net.Http.HttpClient client = new HttpClient())
            {
                // var response = await client.GetAsync("XXttps://restcountries.com/v3.1/region/Americas");
                var response = await client.GetAsync("https://restcountries.com/v3.1/all"); 
                if (response.IsSuccessStatusCode)
                {

                    var contenido = response.Content.ReadAsStringAsync().Result;

                    listapaises = JsonConvert.DeserializeObject<List<Models.Countries.CountriesRest>>(contenido);

                    //sitioscerca = lugares.response.venues as List<Models.ApiFourSquare1.Venue>;

                }

                return listapaises;
            }

        }

    }
}
