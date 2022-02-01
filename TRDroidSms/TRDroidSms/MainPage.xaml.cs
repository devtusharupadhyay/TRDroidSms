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
                if (string.IsNullOrWhiteSpace(PhoneNumber.Text))
                {
                    await DisplayAlert("Validation error", "phone number can not be empty", "OK");
                    return;
                }

                var smsService = DependencyService.Get<IStartSmsService>();
                smsService.ChangeNumberAndStartService(PhoneNumber.Text);

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "OK");
            }

        }
    }
}
