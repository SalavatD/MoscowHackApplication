using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CourierApplication
{
    public partial class MainPage : ContentPage
    {
        public static string currentOrder = "Empty";
        public static MainPage mainPage;

        public MainPage()
        {
            InitializeComponent();
            mainPage = this;
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            currentOrderLabel.GestureRecognizers.Add(tapGesture);
            tapGesture.Tapped += (s, e) =>
            {
                Navigation.PushModalAsync(new CurrentOrderPage());
            };
        }

        static async System.Threading.Tasks.Task ReadAsyncCoordinates()
        {
            var coordinates = new HttpClient();
            string Address = "Москва, пл. академика Курчатова, 1, стр. 73";
            coordinates.BaseAddress = new Uri("https://geocoder.api.here.com/6.2/geocode.json");
            HttpResponseMessage response = await coordinates.GetAsync($"?app_id=tMxrsHS0dLtlEoHJyyFi&app_code=mbSwaOQm7uM7_EwGqYPI1A&searchtext={Address}");
            var json = await response.Content.ReadAsStringAsync();
            int position = json.IndexOf("DisplayPosition");
            string result = "";
            for (int i = position + 18; json[i] != '}'; i++)
                if (char.IsNumber(json[i]) || json[i] ==',' || json[i] == '.')
                    result += json[i];
            Console.WriteLine(result);
            //var result = (JContainer)JObject.Parse(json)["Response"];
            //result = (JContainer)JObject.Parse(result.ToString())["View"];
            //dynamic final = result.Descendants()
            //.OfType<JObject>()
            //.Where(x => x["Result"] != null).FirstOrDefault();
            //final = (JContainer)JObject.Parse(final.ToString())["Result"];
            //final = result.Descendants()
            //.OfType<JObject>()
            //.Where(x => x["Location"] != null).FirstOrDefault();
            //final = (JContainer)JObject.Parse(final.ToString())["Location"];
            //final = (JContainer)JObject.Parse(final.ToString())["DisplayPosition"];
            //final = final.ToString();
            //Coordinate finalResult = JsonConvert.DeserializeObject<Coordinate>(final);
            //Console.WriteLine(finalResult);
        }

        public async void New_Order_Clicked(object sender, EventArgs e)
        {
            // TODO получить подобранный заказ
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            string jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("orders", content);
            var result = await response.Content.ReadAsStringAsync();
            await Navigation.PopModalAsync();
            currentOrderLabel.Text = "Order 1";
        }

        private void List_Orders_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListOrders());
        }
    }

    internal class Coordinate
    {
        public Double Latitude{ get; set; }
        public Double Longitude { get; set; }
        public override string ToString()
        {
            return Latitude + " " + Longitude;
        }
    }
}
