using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CourierApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentOrderPage : ContentPage
	{

        public CurrentOrderPage()
		{
            InitializeComponent ();
        }

        static async System.Threading.Tasks.Task ReadAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            HttpResponseMessage response = await client.GetAsync("orders/8");
            var result = await response.Content.ReadAsStringAsync();
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

        private void Complete_Orders_Clicked(object sender, EventArgs e)
        {
            MainPage.mainPage.currentOrderLabel.Text = "Empty";
            // TODO заказ доставлен
            ReadAsync();
            Navigation.PopModalAsync();
        }
    }
}