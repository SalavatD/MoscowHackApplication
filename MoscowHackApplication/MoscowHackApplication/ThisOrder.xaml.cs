using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoscowHackApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThisOrder : ContentPage
	{
        public string ThisСloth { get; set; }

        public ThisOrder ()
		{
			InitializeComponent ();
            ThisСloth = ListOrders.ThisСloth;
            this.BindingContext = this;
        }

        static async System.Threading.Tasks.Task ReadAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://fastcatapi.azurewebsites.net/api/");
            HttpResponseMessage response = await client.GetAsync("orders/8");
            var result = await response.Content.ReadAsStringAsync();
        }

        private void Remove_Order_Clicked(object sender, EventArgs e)
        {
            // TODO отменить заказ
            ReadAsync();
            Navigation.PopModalAsync();
        }
    }
}