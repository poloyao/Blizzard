using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blizzard.ViewBase
{
	public class BlizzardWindowBase : Window
	{
		private Button CloseButton;
		private Button MinButton;
		private TextBlock WindowTitle;
		private Button TitleButton;
		public BlizzardWindowBase()
		{
			//style需要放置在loaded前执行,有待研究
			//不能在loaded事件中处理style，估计是绘制顺序相关。
			this.Style = App.Current.Resources["BlizzardWindowStyle"] as Style;
			this.Loaded += BlizzardWindowBase_Loaded;
		}
		

		private void BlizzardWindowBase_Loaded(object sender, RoutedEventArgs e)
		{
			//this.Style = (Style)App.Current.Resources["BlizzardWindowStyle"];
			ControlTemplate blizzardTemp = App.Current.Resources["BlizzardWindowTemplate"] as ControlTemplate;			

			if (blizzardTemp != null)
			{
				CloseButton = blizzardTemp.FindName("CloseWinButton", this) as Button;
				MinButton = blizzardTemp.FindName("MinWinButton", this) as Button;
				WindowTitle = blizzardTemp.FindName("WindowTitleTbl", this) as TextBlock;
				TitleButton = blizzardTemp.FindName("TitleButton", this) as Button;

				CloseButton.Click += CloseButton_Click;
				MinButton.Click += MinButton_Click;

				TitleButton.MouseLeftButtonDown += TitleButton_MouseLeftButtonDown;

				this.Deactivated += (s, re) =>
				{
					TitleButton.Background = App.Current.Resources["DeactivatedColor"] as System.Windows.Media.SolidColorBrush;
				};
				this.Activated += (s, re) =>
				{
					TitleButton.Background = App.Current.Resources["ActivatedColor"] as System.Windows.Media.SolidColorBrush;
				};
			}

		}

		private void TitleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void MinButton_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
			base.OnMouseLeftButtonDown(e);
		}

	}
}
