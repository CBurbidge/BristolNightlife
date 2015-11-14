using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BristolNightlife.Core.Services;
using BristolNightlife.Core.Models;
using BristolNightlife.Core.ViewModels;

namespace BristolNightlife.Phone
{
	public class MyMockDatesClass
	{
		public MyMockDatesClass()
		{
			var dateViewModel = new DateViewModel(null)
			{
				EventSummaries = new List<EventSummaryViewModel>()
				{
					new MockEventSummaryViewModel
					{
						Venue = "Venue one",
						NameOfNight = "Name of a night",
						EventId = 1,
						TypeNum = EventType.Club
					},
					new MockEventSummaryViewModel
					{
						Venue = "Venue two",
						NameOfNight = "Name of a night two",
						EventId = 2,
						TypeNum = EventType.Gig
					},
					new MockEventSummaryViewModel
					{
						Venue = "Venue three",
						NameOfNight = "Name of a night three",
						EventId = 3,
						TypeNum = EventType.Other
					}
				}
			};
			
			dateViewModel.PageState = PageState.Loaded;
			dateViewModel.PivotItemHeader = "today";

			Dates = new ObservableCollection<DateViewModel>
			{
				dateViewModel, 
			};
		}
		public string AppRed { get { return AppColours.Red; } }
		public string AppGreen { get { return AppColours.Green; } }
		public string AppBlue { get { return AppColours.Blue; } }

		public ObservableCollection<DateViewModel> Dates { get; set; }
	}

	public class MockEventSummaryViewModel : EventSummaryViewModel
	{
		public MockEventSummaryViewModel() : base(null)
		{
		}
	}
}