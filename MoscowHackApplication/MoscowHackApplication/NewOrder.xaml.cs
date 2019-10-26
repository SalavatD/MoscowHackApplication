using System;
using System.Text;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoscowHackApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewOrder : ContentPage
	{
		public NewOrder ()
		{
			InitializeComponent ();
		}

        private async void newClothesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            string jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
            if (e.Item != null)
            {
                switch (e.Item.ToString())
                {
                    case "Jeans":
                        // TODO выбрать заказ
                        jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
                        break;
                    case "Joggers":
                        // TODO выбрать заказ
                        jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
                        break;
                    case "Bomber":
                        // TODO выбрать заказ
                        jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
                        break;
                    case "Shirt":
                        // TODO выбрать заказ
                        jsonData = @"{""1"" : ""1"", ""2"" : ""2"", ""3"" : ""3""}";
                        break;
                    default:
                        break;
                }
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("orders", content);
                var result = await response.Content.ReadAsStringAsync();
            }
            ((ListView)sender).SelectedItem = null;
            await Navigation.PopModalAsync();
            
        }
    }
}