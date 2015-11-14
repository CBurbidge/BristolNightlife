using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using BristolNightlife.Core.Models;
using BristolNightlife.Core.Services;

namespace BristolNightlife.Core.ViewModels
{
	public class DateViewModel : MvxViewModel
	{
		private readonly IApiService _apiService;

		public DateViewModel(IApiService apiService)
		{
			_apiService = apiService;
		}
		
		public void Initiate(DateTime date)
		{
			Date = date;
			if (date == DateTime.Today)
				_pivotItemHeader = "today";
			else
			{
				var pivotItemHeader = _GetHeader();
				_pivotItemHeader = pivotItemHeader;
			}

			_Refresh();
		}

		private string _GetHeader()
		{
			var dateAndNumber = Date.ToString("dddd d").ToLower();
			var dayNum = Date.Day;

			if (dayNum == 1)
				return dateAndNumber + "st";
			if (dayNum == 2)
				return dateAndNumber + "nd";
			if (dayNum == 3)
				return dateAndNumber + "rd";

			return dateAndNumber + "th";
		}

		private PageState _pageState;

		public PageState PageState
		{
			get { return _pageState; }
			set
			{
				_pageState = value;
				RaisePropertyChanged(() => PageState);
				RaisePropertyChanged(() => IsLoaded);
				RaisePropertyChanged(() => IsLoading);
				RaisePropertyChanged(() => IsFailed);
			}
		}

		public bool IsLoaded
		{
			get { return _pageState == PageState.Loaded; }
		}

		public bool IsFailed
		{
			get { return _pageState == PageState.Failed; }
		}

		public bool IsLoading
		{
			get { return _pageState == PageState.Loading; }
		}

		private void _Refresh()
		{
			PageState = PageState.Loading;
			_apiService.GetEventsForDate(Date, _Success, _Error);
		}

		private void _GenerateViewModels()
		{
			if (_rootModel == null)
				return;

			var eventSummaries = new List<EventSummaryViewModel>();

			ApiModel.EventCollection clubNights;
			if (_rootModel.events_by_type.TryGetValue(ApiModel.ClubEvents, out clubNights))
				_GetEventTypeViewModels(clubNights.events, EventType.Club, eventSummaries);

			ApiModel.EventCollection Gigs;
			if (_rootModel.events_by_type.TryGetValue(ApiModel.Gigs, out Gigs))
				_GetEventTypeViewModels(Gigs.events, EventType.Gig, eventSummaries);

			ApiModel.EventCollection otherEventCollection;
			if (_rootModel.events_by_type.TryGetValue(ApiModel.OtherEvents, out otherEventCollection))
				_GetEventTypeViewModels(otherEventCollection.events, EventType.Other, eventSummaries);

			if (eventSummaries.Count > 0)
				EventSummaries = eventSummaries;
		}

		private void _GetEventTypeViewModels(Dictionary<int, ApiModel.Event> apiEvents, EventType clubEventType,
			List<EventSummaryViewModel> eventSummaries)
		{
			foreach (var apiEvent in apiEvents)
			{
				var eventId = (int) apiEvent.Key;
				var eventInfo = apiEvent.Value;
				var eventSummaryViewModel = new EventSummaryViewModel(Mvx.Resolve<INavStringService>())
				{
					Date = Date,
					EventId = eventId,
					NameOfNight = _DeHtml(eventInfo.nameofnight),
					Venue = _DeHtml(eventInfo.venue),
					TypeNum = clubEventType
				};
				eventSummaries.Add(eventSummaryViewModel);
			}
		}

		private string _DeHtml(string s)
		{
			return WebUtility.HtmlDecode(s);
		}

		private void _Error(Exception obj)
		{
			if (obj is WebException)
			{
				PageState = PageState.Failed;
				return;
			}

			throw obj;
		}

		private void _Success(ApiModel.Rootobject obj)
		{
			if (obj == null)
			{
				PageState = PageState.Failed;
				return;
			}
				
			_rootModel = obj;
			_GenerateViewModels();
			PageState = PageState.Loaded;
		}

		private ApiModel.Rootobject _rootModel = null;

		public DateTime Date { get; set; }

		private string _pivotItemHeader;

		public string PivotItemHeader
		{
			get { return _pivotItemHeader; }
			set { _pivotItemHeader = value; RaisePropertyChanged(() => PivotItemHeader); }
		}

		private List<EventSummaryViewModel> _eventSummaries;

		public List<EventSummaryViewModel> EventSummaries
		{
			get { return _eventSummaries; }
			set { _eventSummaries = value; RaisePropertyChanged(() => EventSummaries); }
		}

		public ICommand RetryCommand
		{
			get { return new MvxCommand(_Refresh); }
		}
	}
}