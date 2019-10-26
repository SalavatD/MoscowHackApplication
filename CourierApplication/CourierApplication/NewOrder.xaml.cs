using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CourierApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewOrder : ContentPage
	{

        public NewOrder ()
		{
            InitializeComponent ();
        }

        private async void Add_Orders_Clicked(object sender, EventArgs e)
        {
            MainPage.mainPage.currentOrderLabel.Text = ListOrders.CurrentOrder;
            // TODO выбрать заказ вручную
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            string jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("orders", content);
            var result = await response.Content.ReadAsStringAsync();
            await Navigation.PopModalAsync();
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}