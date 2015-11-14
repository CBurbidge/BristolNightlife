using System;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using BristolNightlife.Core.Models;
using BristolNightlife.Core.Services;

namespace BristolNightlife.Core.ViewModels
{
	public class EventSummaryViewModel : MvxViewModel
	{
		private readonly INavStringService _navStringService;// = Mvx.Resolve<INavStringService>();

		public EventSummaryViewModel(INavStringService navStringService)
		{
			_navStringService = navStringService;
		}

		private string _nameOfNight;

		public string NameOfNight
		{
			get { return _nameOfNight; }
			set
			{
				_nameOfNight = value;
				RaisePropertyChanged(() => NameOfNight);
			}
		}

		private string _dummy;
		public string Colour
		{
			get
			{
				switch (TypeNum)
				{
					case EventType.Club:
						return AppColours.Blue;
					case EventType.Gig:
						return AppColours.Green;
					case EventType.Other:
						return AppColours.Red;
				}
				return null;
			}
			set { _dummy = value; RaisePropertyChanged(() => Colour); }
		}

		private string _venue;

		public string Venue
		{
			get { return _venue; }
			set
			{
				_venue = value;
				RaisePropertyChanged(() => Venue);
			}
		}
		
		private DateTime _date;

		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				RaisePropertyChanged(() => Date);
			}
		}

		private EventType _typeNum;

		public EventType TypeNum
		{
			get { return _typeNum; }
			set
			{
				_typeNum = value;
				RaisePropertyChanged(() => TypeNum);
			}
		}

		private int _eventId;

		public int EventId
		{
			get { return _eventId; }
			set
			{
				_eventId = value;
				RaisePropertyChanged(() => EventId);
			}
		}

		public ICommand GoToEventCommand
		{
			get
			{
				var navString = _navStringService.Encode(Date, TypeNum, EventId);

				return new MvxCommand(() => ShowViewModel<EventViewModel>(
					new EventItemNavigation()
					{
						NavInfo = navString
					}));
			}
		}
	}
}