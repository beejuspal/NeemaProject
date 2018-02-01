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
using XLabs.Forms.Controls;

namespace AcademyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public List<string> Alpha { get; set; }
		HttpClient objClint = new HttpClient();
		public SignUpPage()
		{
			InitializeComponent();

			//BackgroundColor = Color.Black;

			rdoGender.ItemsSource = new[]
			{
				"Male",
				"Female"

			};
			
			//PickerCtl.ItemsSource = new[]
			//{
			//	"A",
			//	"B"

			//};
			rdoGender.CheckedChanged += rdoGender_CheckedChanged;
			GetUserRole();

		}
		private void rdoGender_CheckedChanged(object sender, int e)
		{
			var radio = sender as CustomRadioButton;

			if (radio == null || radio.Id == -1)
			{
				return;
			}

			DisplayAlert("Info", radio.Text, "OK");
		}

		private void pkrUserType_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (pkrUserType != null && pkrUserType.SelectedIndex <= pkrUserType.Items.Count)


			{
				var selecteditem = pkrUserType.Items[pkrUserType.SelectedIndex];
				
				DisplayAlert("Picker Control", selecteditem, "OK");
			}
		}
		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			var user = new User()
			{
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text
			};

			// Sign up logic goes here

			var signUpSucceeded = AreDetailsValid(user);
			if (signUpSucceeded)
			{
				var rootPage = Navigation.NavigationStack.FirstOrDefault();
				if (rootPage != null)
				{
					App.IsUserLoggedIn = true;
					Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
					await Navigation.PopToRootAsync();
				}
			}
			else
			{
				messageLabel.Text = "Sign up failed";
			}
		}

		bool AreDetailsValid(User user)
		{
			return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
		}
		public async void GetUserRole()
		{
			UserRole objUserRole = new UserRole();
			 

			string json = "";
			json = Newtonsoft.Json.JsonConvert.SerializeObject(objUserRole);
			
			objClint.BaseAddress = new Uri("http://172.18.11.159:9091/");
			
			System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync("api/UserManager/OtherUserRole/");
			if (respon.IsSuccessStatusCode)
			{
				//ListView result1 = FindViewById<ListView>(Resource.Id.listView1);
				var result = await respon.Content.ReadAsStringAsync();
				var Items1 = JsonConvert.DeserializeObject<List<UserRole>>(result);
				pkrUserType.ItemsSource = Items1;




			}
		}

	}
}