using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRDroidSms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SmsButton_Clicked(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "OK");
            }

        }
    }
}
