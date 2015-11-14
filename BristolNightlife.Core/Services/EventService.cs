using System;
using System.Net;
using BristolNightlife.Core.Models;

namespace BristolNightlife.Core.Services
{
	public interface IEventService
	{
		void GetEventInfo(DateTime date, int eventId, EventType eventType, Action<EventModel> success,
			Action<Exception> error);
	}

	public class EventService : IEventService
	{
		private readonly IApiModelCacheService _apiModelCacheService;
		private readonly IWebApiModelService _webApiModelService;
		private readonly IEventMapperService _eventMapperService;

		public EventService(IEventMapperService eventMapperService, IWebApiModelService webApiModelService,
			IApiModelCacheService apiModelCacheService)
		{
			_eventMapperService = eventMapperService;
			_webApiModelService = webApiModelService;
			_apiModelCacheService = apiModelCacheService;
		}

		public void GetEventInfo(DateTime date, int eventId, EventType eventType, Action<EventModel> success,
			Action<Exception> error)
		{
			if (_apiModelCacheService.ContainsDate(date))
			{
				success(
					_eventMapperService.Map(
						_apiModelCacheService.GetDateModel(date),
						eventId,
						eventType));
			}
			else
			{
				Action<ApiModel.Rootobject> successTwo = rootobject =>
				{
					success(
						_eventMapperService.Map(
							rootobject,
							eventId,
							eventType));
				};
				_webApiModelService.GetDateJson(date, successTwo, error);
			}
		}
	}

	public class EventMapperService : IEventMapperService
	{
		public EventModel Map(ApiModel.Rootobject rootObject, int eventId, EventType eventType)
		{
			switch (eventType)
			{
				case EventType.Club:
					return _GetEvent(rootObject.events_by_type[ApiModel.ClubEvents], eventId);
				case EventType.Gig:
					return _GetEvent(rootObject.events_by_type[ApiModel.Gigs], eventId);
				case EventType.Other:
					return _GetEvent(rootObject.events_by_type[ApiModel.OtherEvents], eventId);
			}
			return null;
		}

		private EventModel _GetEvent(ApiModel.EventCollection eventCollection, int eventId)
		{
			var e = eventCollection.events[eventId];
			var eventModel = new EventModel
			{
				EventId = eventId,
				MaxImgSize = e.max_img_size,
				ImgStem = _DeHtml(e.img_stem),
				NameOfNight = _DeHtml(e.nameofnight),
				VenId = e.ven_id,
				Venue = _DeHtml(e.venue),
				Headliners = _DeHtml(e.headliners),
				Date = e.date,
				DateText = e.date_text,
				Price = _DeHtml(e.price),
				EventImgAdded = e.event_img_added,
				Details = _DeHtml(e.details),
				GigClub = e.gig_club,
				ArtId = e.art_id,
				Name = _DeHtml(e.name),
				Bio = _DeHtml(e.bio),
				ArtImgAdded = e.art_img_added
			};

			return eventModel;
		}

		private string _DeHtml(string s)
		{
			return WebUtility.HtmlDecode(s);
		}
	}

	public interface IEventMapperService
	{
		EventModel Map(ApiModel.Rootobject rootObject, int eventId, EventType eventType);
	}
}