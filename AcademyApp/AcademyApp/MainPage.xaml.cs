using AcademyApp.ModelClass.UserManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AcademyApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
           
        }
        HttpClient objClint = new HttpClient();
        
        public async void GetAllData()
        {
            User objUser = new User();
            //p.Id = 2;


            //Uri requestUri = new Uri("http://localhost:2070/api/Students"); //replace your Url  

            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(objUser);
         
            objClint.BaseAddress = new Uri("http://172.18.11.159:9091/");
            //System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync("api/todos/" + p.Id);
            System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync("api/Students/");
            if (respon.IsSuccessStatusCode)
            {
                //ListView result1 = FindViewById<ListView>(Resource.Id.listView1);
                var result = await respon.Content.ReadAsStringAsync();

                //				var Items = JsonConvert.DeserializeObject<String[]>(result);

                //				var data = new string[] {
                //   "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                //};
                //result1.Adapter = new ArrayAdapter(
                //	this, Resource.Layout.listViewTemplate, Items);

                var Items1 = JsonConvert.DeserializeObject<List<User>>(result);
                ListView1.ItemsSource = Items1;




            }
        }
    }
}
