namespace BristolNightlife.Core.Models
{
	public class EventModel
	{
		public int EventId { get; set; }
		public string MaxImgSize { get; set; }
		public string ImgStem { get; set; }
		public string NameOfNight { get; set; }
		public string VenId { get; set; }
		public string Venue { get; set; }
		public string Headliners { get; set; }
		public string Date { get; set; }
		public string DateText { get; set; }
		public string Price { get; set; }
		public string EventImgAdded { get; set; }
		public string Details { get; set; }
		public string GigClub { get; set; }
		public string ArtId { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public string ArtImgAdded { get; set; }

		public string MaxImageUrl
		{
			get
			{
				return ImgStem + MaxImgSize.ToString() + ".jpg";
			}
		}
	}
}