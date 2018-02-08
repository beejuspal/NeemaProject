using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AcademyApp.CustomControls
{
	public class HyperlinkLabel : View
	{
		

		Action<string> action;
		public static readonly BindableProperty UriProperty = BindableProperty.Create(
		  propertyName: "Uri",
		  returnType: typeof(string),
		  declaringType: typeof(HyperlinkLabel),
		  defaultValue: default(string));

		public string Uri
		{
			get { return (string)GetValue(UriProperty); }
			set { SetValue(UriProperty, value); }
		}

		
		public static readonly BindableProperty textProperty = BindableProperty.Create(
		  propertyName: "Text",
		  returnType: typeof(string),
		  declaringType: typeof(HyperlinkLabel),
		  defaultValue: default(string));

		public string Text
		{
			get { return (string)GetValue(textProperty); }
			set { SetValue(textProperty, value); }
		}

	}
}
