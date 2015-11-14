using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using BristolNightlife.Core.ViewModels;
using Microsoft.Phone.Controls;

namespace BristolNightlife.Phone.Views
{
	public partial class EventView : MvxPhonePage
	{
		private EventViewModel _vm;
		public EventView()
		{
			InitializeComponent();
		}

		private void Browser_OnLoaded(object sender, RoutedEventArgs e)
		{
			if (DataContext != null)
			{
				SlideInAnimation.Begin();
				
				_vm = (EventViewModel)DataContext;
				
				// Data caching makes this super fast, therefore want to try and update web browser 
				// if data exists and set up an event if data is not ready.
				TryUpdateWebBrowser();
				_vm.PropertyChanged += StuffChanged;
			}
		}

		protected override void OnBackKeyPress(CancelEventArgs e)
		{
			SlideOutAnimation.Begin();
			base.OnBackKeyPress(e);
		}

		private void StuffChanged(object sender, PropertyChangedEventArgs e)
		{
			TryUpdateWebBrowser();
		}

		private void TryUpdateWebBrowser()
		{
			if (_vm.IsLoaded && _vm.EventModel.Details != null)
			{
				SetHtml(_vm.EventModel.Details, Browser);
			}
		}

		private string FetchBackgroundColor()
		{
			return IsBackgroundBlack() ? "#000;" : "#fff";
		}

		private string FetchFontColor()
		{
			return IsBackgroundBlack() ? "#fff;" : "#000";
		}

		private static bool IsBackgroundBlack()
		{
			return FetchBackGroundColor() == "#FF000000";
		}

		private static string FetchBackGroundColor()
		{
			Color mc = (Color)Application.Current.Resources["PhoneBackgroundColor"];
			return mc.ToString();
		}

		private void SetHtml(string html, WebBrowser browser)
		{
			string fontColor = FetchFontColor();
			string backgroundColor = FetchBackgroundColor();

			SetBackground(browser);

			var htmlScript = "<script>function getDocHeight() { " +
			  "return document.getElementById('pageWrapper').offsetHeight;" +
			  "}" +
			  "function SendDataToPhoneApp() {" +
			  "window.external.Notify('' + getDocHeight());" +
			  "}</script>";

			var htmlConcat = string.Format("<html><head>{0}</head>" +
			  "<body style=\"margin:0px;padding:0px;background-color:{3};\" " +
			  "onLoad=\"SendDataToPhoneApp()\">" +
			  "<div id=\"pageWrapper\" style=\"width:100%; color:{2}; " +
			  "background-color:{3}\">{1}</div></body></html>",
			  htmlScript,
			  html,
			  fontColor,
			  backgroundColor);
			browser.NavigateToString(htmlConcat);
			browser.IsScriptEnabled = true;
			//Browser.ScriptNotify +=
			//  new EventHandler<NotifyEventArgs>(wb1_ScriptNotify);
		}

		private void SetBackground(WebBrowser browser)
		{
			Color mc =
			  (Color)Application.Current.Resources["PhoneBackgroundColor"];
			browser.Background = new SolidColorBrush(mc);
		}

		private void Browser_OnNavigated(object sender, NavigationEventArgs e)
		{
			Browser.Visibility = Visibility.Visible;
		}
	}
}