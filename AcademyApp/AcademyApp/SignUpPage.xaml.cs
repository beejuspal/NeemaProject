using AcademyApp.ModelClass.UserManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AcademyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
      
		


        public List<string> Alpha { get; set; }
		

		public SignUpPage()
		{
			InitializeComponent();
            fxLoadGender();
            
            GetUserRole();

		}
        private void fxLoadGender()
        {
            //pkrGender.ItemsSource = new[]
            //{
            //    "Male",
            //    "Female"

            //};
        }
        //private void rdoGender_CheckedChanged(object sender, int e)
        //{
        //	//var radio = sender as CustomRadioButton;

        //	//if (radio == null || radio.Id == -1)
        //	//{
        //	//	return;
        //	//}

        //	//DisplayAlert("Info", radio.Text, "OK");
        //}

        private void pkrUserType_OnSelectedIndexChanged(object sender, EventArgs e)
		{
            //if (pkrUserType != null && pkrUserType.SelectedIndex <= pkrUserType.Items.Count)


            //{
            //    var selecteditem = pkrUserType.Items[pkrUserType.SelectedIndex];
            //    int SelectedCode;
            //    var aa = pkrUserType.SelectedItem as UserRole; //Here CountryModels is user define data.
            //    SelectedCode = aa.Id;
            //    DisplayAlert("Picker Control", SelectedCode.ToString(), "OK");
            //}
        }
		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
            //var radio = sender as CustomRadioButton;

            int _roleId;
            var aa = pkrUserType.SelectedItem as UserRole; //Here CountryModels is user define data.
            _roleId = aa.Id;
            //roleId = int.Parse(pkrUserType.SelectedItem.ToString());

            User objuser = new User();

			objuser.FirstName = frstnameEntry.Text;
			objuser.LastName = lastnameEntry.Text;
            objuser.Username = usernameEntry.Text;
            objuser.Password = passwordEntry.Text;
            objuser.Email = emailEntry.Text;
            //objuser.Gender = pkrGender.Items[pkrGender.SelectedIndex];
            objuser.RoleId = _roleId;
            objuser.IsActive = 1;
            string json = "";
            json = JsonConvert.SerializeObject(objuser);
            HttpClient objClint = new HttpClient();
            objClint.BaseAddress = new Uri("http://172.18.11.159:9091/");

            //HttpResponseMessage respon = await objClint.PostAsync("api/UserManager/AddUser", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
			HttpResponseMessage respon = await objClint.PostAsync("api/Users/Register", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
			string msg = "";
            if (respon.IsSuccessStatusCode)
            {
				
				await DisplayAlert("Alert", "User Registered Successfully", "ok");

				await Navigation.PushAsync(new LoginPage());
				//messageLabel.Text  = "User Created Successfully";
              

            }
            else
            {
                messageLabel.Text = "User Creatation Failed";
            }

            // Sign up logic goes here

            //var signUpSucceeded = AreDetailsValid(user);
            //if (signUpSucceeded)
            //{
            //InsertUser( user);

				//var rootPage = Navigation.NavigationStack.FirstOrDefault();
				//if (rootPage != null)
				//{
				//	App.IsUserLoggedIn = true;
				//	Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
				//	await Navigation.PopToRootAsync();
				//	messageLabel.Text = "User Created";
				//}
			//}
			//else
			//{
			//	messageLabel.Text = "Sign up failed";
			//}
		}

		bool AreDetailsValid(User user)
		{
			return (!string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
		}
		public async void GetUserRole()
        {
          
          
            HttpClient objClint = new HttpClient();
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
		public async void InsertUser( User user)
		{



			string json = "";
			json = JsonConvert.SerializeObject(user);
            HttpClient objClint = new HttpClient();
            objClint.BaseAddress = new Uri(BaseAddress.strBaseAddress);

			HttpResponseMessage respon = await objClint.PostAsync("api/UserManager/AddUser", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
			if (respon.IsSuccessStatusCode)
			{


				messageLabel.Text = "User  Created";


			}
			else
			{
				messageLabel.Text = "User Creatation Failed";
			}
		}

	}
}