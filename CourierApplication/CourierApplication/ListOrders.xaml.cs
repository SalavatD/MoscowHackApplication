using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CourierApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListOrders : ContentPage
	{
        public string[] Orders { get; set; }
        public static string CurrentOrder { get; set; } = "";

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
            // TODO список доступных для доставки заказов
            ReadAsync();
            Orders = new string[] { "Order 1", "Order 2", "Order 3", "Order 4" };
            ordersList.ItemsSource = Orders;
        }

        private void ordersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                switch (e.Item.ToString())
                {
                    case "Order 1":
                        CurrentOrder = "Order 1";
                        Navigation.PushModalAsync(new NewOrder());
                        break;
                    case "Order 2":
                        CurrentOrder = "Order 2";
                        Navigation.PushModalAsync(new NewOrder());
                        break;
                    case "Order 3":
                        CurrentOrder = "Order 3";
                        Navigation.PushModalAsync(new NewOrder());
                        break;
                    case "Order 4":
                        CurrentOrder = "Order 4";
                        Navigation.PushModalAsync(new NewOrder());
                        break;
                    default:
                        break;
                }
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}