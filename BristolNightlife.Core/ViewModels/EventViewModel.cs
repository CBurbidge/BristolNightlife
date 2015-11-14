using System;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using BristolNightlife.Core.Models;
using BristolNightlife.Core.Services;

namespace BristolNightlife.Core.ViewModels
{
	public class EventViewModel : MvxViewModel
	{
		private readonly IEventService _eventService = Mvx.Resolve<IEventService>();
		private readonly INavStringService _navStringService = Mvx.Resolve<INavStringService>();

		public void Init(EventItemNavigation info)
		{
			EventModel = new EventModel();

			DateTime date;
			int id;
			EventType eventType;
			_navStringService.Decode(info.NavInfo, out date, out eventType, out id);
			
			_eventType = eventType;

			_eventService.GetEventInfo(date, id, eventType, model =>
			{
				EventModel = model;
				IsLoaded = true;
			}, _ =>
			{
				
			});
		}

		private EventType _eventType;
		public string Colour 
		{
			get {
				switch (_eventType)
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
		}

		private bool _isLoaded;

		public bool IsLoaded
		{
			get
			{
				return _isLoaded;
			}
			set { _isLoaded = value; RaisePropertyChanged(() => IsLoaded); }
		}
		
		private EventModel _eventModel;

		public EventModel EventModel
		{
			get
			{
				return _eventModel;
			}
			set { _eventModel = value; RaisePropertyChanged(() => EventModel); }
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
	}
}