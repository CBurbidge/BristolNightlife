using System.Collections.Generic;

namespace BristolNightlife.Core.Models
{
	public enum EventType
	{
		Other,
		Gig,
		Club
	}
	
	public class ApiModel
	{
		public const string OtherEvents = "Other events";
		public const string ClubEvents = "Club events";
		public const string Gigs = "Gigs";

		public class Rootobject
		{
			public Dictionary<string, EventCollection> events_by_type { get; set; }
			public string next_day { get; set; }
			public string current_day { get; set; }
			public string current_day_text { get; set; }
			public string prev_day { get; set; }
			public bool? today { get; set; }
			public Img_Preloads[] img_preloads { get; set; }
		}

		public class EventCollection
		{
			public EventType type_num { get; set; }
			public string type { get; set; }
			public Dictionary<int, Event> events { get; set; }
		}

		public class Event
		{
			public string event_id { get; set; }
			public string max_img_size { get; set; }
			public string img_stem { get; set; }
			public string nameofnight { get; set; }
			public string ven_id { get; set; }
			public string venue { get; set; }
			public string headliners { get; set; }
			public string date { get; set; }
			public string date_text { get; set; }
			public string price { get; set; }
			public string event_img_added { get; set; }
			public string details { get; set; }
			public string gig_club { get; set; }
			public string art_id { get; set; }
			public string name { get; set; }
			public string bio { get; set; }
			public string art_img_added { get; set; }
		}

		public class Img_Preloads
		{
			public string max_img_size { get; set; }
			public string img_stem { get; set; }
		}
	}
}