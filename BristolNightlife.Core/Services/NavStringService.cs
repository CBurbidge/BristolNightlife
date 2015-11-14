using System;
using System.Globalization;
using BristolNightlife.Core.Models;

namespace BristolNightlife.Core.Services
{
	public interface INavStringService
	{
		string Encode(DateTime date, EventType eventType, int eventId);
		void Decode(string navString, out DateTime date, out EventType eventType, out int eventId);
	}

	public class NavStringService : INavStringService
	{
		private const string DateFormat = "yyyy-MM-dd";

		public string Encode(DateTime date, EventType eventType, int eventId)
		{
			return date.ToString(DateFormat) + "_" + eventType + "_" + eventId;
		}

		public void Decode(string navString, out DateTime date, out EventType eventType, out int eventId)
		{
			var split = navString.Split('_');
			date = DateTime.ParseExact(split[0], DateFormat, CultureInfo.InvariantCulture);
			EventType.TryParse(split[1] , out eventType);
			eventId = int.Parse(split[2]);
		}
	}
}