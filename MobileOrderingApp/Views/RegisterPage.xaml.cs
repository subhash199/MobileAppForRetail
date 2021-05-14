using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterClicked(object sender, EventArgs e)
        {
            ServerRequest request = new ServerRequest();
            if (UserName_Box.Text != null && passwordBox.Text != null && Day_Box.Text != null && Mon_Box.Text != null && Year_Box.Text != null && addressLine1.Text != null && town.Text != null && postCode != null && mobile != null)
            {
                DateTime dob = Convert.ToDateTime(Day_Box.Text + "/" + Mon_Box.Text + "/" + Year_Box.Text);
                DateTime now = DateTime.Today;
              
                if (now.Year-dob.Year>= 18)
                {
                   
                    if (Day_Box.Text.All(char.IsDigit) && Mon_Box.Text.All(char.IsDigit) && Year_Box.Text.All(char.IsDigit) && mobile.Text.All(char.IsDigit))
                    {
                        request.Register(UserName_Box.Text + "|" + passwordBox.Text + "|" + Day_Box.Text + "/" + Mon_Box.Text + "/" + Year_Box.Text + "|" + addressLine1.Text + "|" + AddressLine2.Text + "|" + town.Text + "|" + postCode.Text + "|" + mobile.Text);
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Please Enter Vaild Details", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "This app can only be used if you are aged 18 or above!", "OK");
                }

            }
            else
            {
                await DisplayAlert("Alert", "Please fill in all the details to register!", "OK");
            }
        }
    }
}