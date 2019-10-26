using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoscowHackApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListOrders : ContentPage
	{
        public string[] Сlothes { get; set; }
        public static string ThisСloth { get; set; } = "";

        static async System.Threading.Tasks.Task ReadAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            HttpResponseMessage response = await client.GetAsync("orders/8");
            var result = await response.Content.ReadAsStringAsync();
        }

        public ListOrders ()
		{
			InitializeComponent ();
            // TODO получить список  моих аказов
            ReadAsync();
            Сlothes = new string[] { "Jeans", "Joggers", "Bomber", "Shirt" };
            clothesList.ItemsSource = Сlothes;
        }

        private void clothesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                switch (e.Item.ToString())
                {
                    case "Jeans":
                        ThisСloth = "Jeans";
                        Navigation.PushModalAsync(new ThisOrder());
                        break;
                    case "Joggers":
                        ThisСloth = "Joggers";
                        Navigation.PushModalAsync(new ThisOrder());
                        break;
                    case "Bomber":
                        ThisСloth = "Bomber";
                        Navigation.PushModalAsync(new ThisOrder());
                        break;
                    case "Shirt":
                        ThisСloth = "Shirt";
                        Navigation.PushModalAsync(new ThisOrder());
                        break;
                    default:
                        break;
                }
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}