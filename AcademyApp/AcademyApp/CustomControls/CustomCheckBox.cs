using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AcademyApp.CustomControls
{
	public class CustomCheckBox : View
	{
		public static readonly BindableProperty CheckedProperty =
		BindableProperty.Create("Checked", typeof(bool), typeof(CustomCheckBox), default(bool));

		public bool Checked
		{
			get { return (bool)GetValue(CheckedProperty); }
			set { SetValue(CheckedProperty, value); }
		}

	}
}
