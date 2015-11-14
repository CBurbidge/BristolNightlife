using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BristolNightlife.Core.ViewModels;

namespace BristolNightlife.Phone
{
	public class MyMockClass //: ResourceDictionary
	{
		public MyMockClass()
		{
			EventSummaries = new ObservableCollection<EventSummaryViewModel>
			{
				new MockEventSummaryViewModel
				{
					Venue = "Venue one",
					NameOfNight = "Name of a night",
					EventId = 1,
				},
				new  MockEventSummaryViewModel
				{
					Venue = "Venue two",
					NameOfNight = "Name of a night two",
					EventId = 2,
				},
				new MockEventSummaryViewModel
				{
					Venue = "Venue three",
					NameOfNight = "Name of a night three",
					EventId = 3,
				}
			};
		}

		public ObservableCollection<EventSummaryViewModel> EventSummaries { get; set; }
	}
}