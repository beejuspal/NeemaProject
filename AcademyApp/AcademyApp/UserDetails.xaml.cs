using AcademyApp.ModelClass.UserManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetails : ContentPage
	{
		public UserDetails ()
		{
			InitializeComponent ();
            GetAllUsers();

        }
        public async void GetAllUsers()
        {
            HttpClient objClint = new HttpClient();
          
            objClint.BaseAddress = new Uri("http://172.18.11.159:9091/");
            string get_token = jwt();
            objClint.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", get_token);
            HttpResponseMessage respon = await objClint.GetAsync("api/Users/allusers");
            if (respon.IsSuccessStatusCode)
            {
                var result = await respon.Content.ReadAsStringAsync();
                var Items1 = JsonConvert.DeserializeObject<List<UserDetail>>(result);
                lvUsers.ItemsSource = Items1;


            }
		}
		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPage());
		}
        private string jwt()
        {
            // create authorization header with jwt token
            string token = (Application.Current.Properties["token"].ToString());
            return token;
        }
    }

}