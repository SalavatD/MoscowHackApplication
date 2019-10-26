using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoscowHackApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void New_Order_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NewOrder());
        }

        private void List_Orders_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListOrders());
        }
    }
}
