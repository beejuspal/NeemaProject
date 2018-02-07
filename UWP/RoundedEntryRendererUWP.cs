using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererUWP))]
namespace UWP
{
	public class RoundedEntryRendererUWP : EntryRenderer
	{
		public RoundedEntryRendererUWP(Context context) : base(context)
		{

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Background = new SolidColorBrush(Colors.Cyan);
			}
		}
	}
}
