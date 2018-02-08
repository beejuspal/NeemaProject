using AcademyApp.CustomControls;
using AcademyApp.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperLinkRendererUWP))]
namespace AcademyApp.UWP
{
	public class HyperLinkRendererUWP : ViewRenderer<HyperlinkLabel, Windows.UI.Xaml.Controls.HyperlinkButton>
	{

		protected override void OnElementChanged(ElementChangedEventArgs<HyperlinkLabel> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
			{
				HyperlinkButton hlnkBtn = new HyperlinkButton();
				SetNativeControl(hlnkBtn);
				hlnkBtn.Content = "Forget Password";
				//hlnkBtn.Click += HlnkBtn_Click;
				

			}
		}

		private void HlnkBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
		
			
		}
	}
}
