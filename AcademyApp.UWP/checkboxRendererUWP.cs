using AcademyApp.CustomControls;
using AcademyApp.UWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
//[assembly: ExportRenderer(typeof(CheckBoxRenderer), typeof(checkboxRendererUWP))]

[assembly: ExportRenderer(typeof(CustomCheckBox), typeof(checkboxRendererUWP))]
namespace AcademyApp.UWP
{
	public class checkboxRendererUWP : ViewRenderer<CustomCheckBox, Windows.UI.Xaml.Controls.CheckBox>
	{
		

		protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckBox> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
			{
				CheckBox chkBox = new CheckBox();
				SetNativeControl(chkBox);
				//SetNativeControl(new Windows.UI.Xaml.Controls.CheckBox());
				chkBox.Background = new SolidColorBrush(Colors.Cyan);
				//chkBox.Content = "Remember me";
				//chkBox.Checked += ChkBox_Checked1;
				//chkBox.Unchecked += ChkBox_Unchecked;
				
			}
			if (Control != null)
			{
				Control.IsChecked = Element.Checked;
			}
		}

		private void ChkBox_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			Control.Content = "I am Unchecked";
		}

		private void ChkBox_Checked1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			UpdateStatus();
		}

		private void ChkBox_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			Control.IsChecked = true;

		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == nameof(Element.Checked))
			{
				UpdateStatus();
			}
		}
		private void UpdateStatus()
		{

			Control.IsChecked = Element.Checked;

		}
	}
}


