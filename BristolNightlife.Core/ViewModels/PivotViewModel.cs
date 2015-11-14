using System;
using System.Collections.ObjectModel;
using System.Linq;
using Cirrious.MvvmCross.ViewModels;
using BristolNightlife.Core.Models;
using BristolNightlife.Core.Services;

namespace BristolNightlife.Core.ViewModels
{
	public class PivotViewModel : MvxViewModel
	{
		public PivotViewModel(IApiService apiService)
		{
			var api = apiService;

			Dates = new ObservableCollection<DateViewModel>
			{
				new DateViewModel(api),
				new DateViewModel(api),
				new DateViewModel(api),
				new DateViewModel(api),
				new DateViewModel(api),
				new DateViewModel(api),
				new DateViewModel(api),
			};

			foreach (var daysFromToday in Enumerable.Range(0, Dates.Count))
			{
				Dates[daysFromToday].Initiate(DateTime.Today.AddDays(daysFromToday));
			}
		}

		public string AppRed { get { return AppColours.Red; } }
		public string AppGreen { get { return AppColours.Green; } }
		public string AppBlue { get { return AppColours.Blue; } }

		public ObservableCollection<DateViewModel> Dates { get; set; }
	}
}