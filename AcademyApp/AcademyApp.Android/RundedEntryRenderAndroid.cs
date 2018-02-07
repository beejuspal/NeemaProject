using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcademyApp;
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
[assembly: ExportRenderer(typeof(RoundedEntry),typeof(RundedEntryRenderAndroid))]
namespace AcademyApp.Droid
{
	public class RundedEntryRenderAndroid :EntryRenderer
	{
		public RundedEntryRenderAndroid(Context context) : base(context)
		{

		}
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if(e.OldElement==null)
			{
				var gradientDrwable = new GradientDrawable();
				gradientDrwable.SetCornerRadius(60f);
				gradientDrwable.SetStroke(5, Android.Graphics.Color.DarkBlue);
				gradientDrwable.SetColor(Android.Graphics.Color.DarkGreen);
				Control.SetBackground(gradientDrwable);
				Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
				
				
			}
		}
	}
}