using AcademyApp.ModelClass.UserManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };
            string json = "";
            json = JsonConvert.SerializeObject(user);
            HttpClient objClint = new HttpClient();
            objClint.BaseAddress = new Uri("http://172.18.11.159:9091/");
            HttpResponseMessage respon = await objClint.PostAsync("api/Users/authenticate", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            if (respon.IsSuccessStatusCode)
            {
                await DisplayAlert("Alert", "User Log In Successfully", "ok");
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "User Login Failed";
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Email == Constants.Username && user.Password == Constants.Password;
        }
    }
}