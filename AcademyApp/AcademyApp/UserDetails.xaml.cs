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
           
            objClint.BaseAddress = new Uri("http://172.18.11.159:9093/");
          
            HttpResponseMessage respon = await objClint.GetAsync("api/Usermanager/AllUser/");
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
	}
}