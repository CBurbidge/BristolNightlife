using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BristolNightlife.Phone
{
	public partial class MainPage : PhoneApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e) { this.NavigationService.GoBack(); }
	}
}