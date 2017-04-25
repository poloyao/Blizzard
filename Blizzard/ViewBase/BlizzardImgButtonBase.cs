using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Blizzard.ViewBase
{
	public class BlizzardImgButtonBase:Button
	{
		public static readonly DependencyProperty ImgSourceProperty;//= DependencyProperty.Register("",typeof(ImageSource),typeof(BlizzardImgButtonBase))

		public ImageSource ImgSource
		{
			get { return (ImageSource)GetValue(ImgSourceProperty); }
			set { SetValue(ImgSourceProperty, value); }
		}

		static BlizzardImgButtonBase()
		{
			var metadate = new FrameworkPropertyMetadata((ImageSource)null);
			ImgSourceProperty = DependencyProperty.RegisterAttached("ImgSource", typeof(ImageSource), typeof(BlizzardImgButtonBase), metadate);

		}

		public BlizzardImgButtonBase()
		{
			this.Style = App.Current.Resources["BlizzardButtonStyle"] as Style;
		}
	}
}
