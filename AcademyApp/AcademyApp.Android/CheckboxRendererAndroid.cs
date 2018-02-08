using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcademyApp.CustomControls;
using AcademyApp.Droid;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CheckBoxRenderer), typeof(CheckboxRendererAndroid))]
namespace AcademyApp.Droid
{
	public class CheckboxRendererAndroid : ButtonRenderer
	{
		public CheckboxRendererAndroid(Context context) : base(context)
		{

		}
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			

			if (e.OldElement == null)
			{
				var control = new Android.Widget.CheckBox(this.Context);
				this.SetNativeControl(control);



			}
		}
	}
}