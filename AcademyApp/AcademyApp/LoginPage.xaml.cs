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
		public LoginPage()
		{
			InitializeComponent();
	
			
			//HyperLinkedFP.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));
			//chkbox.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnChecked()));


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
			var respon = await objClint.PostAsync("api/Users/authenticate", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

			if (respon.IsSuccessStatusCode)
			{
				var result = respon.Content.ReadAsStringAsync().Result;
				var name = JsonConvert.DeserializeObject<ReponseTokenMode>(result);
				Application.Current.Properties["token"] = name.Token;
				await Application.Current.SavePropertiesAsync();
				await DisplayAlert("Alert", "User Log In Successfully", "ok");

				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore(new UserDetails(), this);
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
		public void OnLabelClicked()
		{
			//await Navigation.PushAsync(new SignUpPage());

			HyperLinkedFP.Navigation.PushAsync(new SignUpPage());
		}

		public void OnChecked()
		{

			//if (chkbox.Checked == true)
			//{
			//	messageLabel.Text = "User Login Failed";
			//}

		}
	}
}