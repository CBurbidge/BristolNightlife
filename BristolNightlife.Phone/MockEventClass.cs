using System.Net;
using BristolNightlife.Core.ViewModels;
using BristolNightlife.Core.Models;

namespace BristolNightlife.Phone
{
	public class MockEventClass 
	{
		public EventModel EventModel { get; set; }

		public string Colour { get { return "Red"; }  }

		public MockEventClass()
		{
			EventModel = new EventModel
			{
				EventId = 26724,
				MaxImgSize = "4",
				ImgStem = _DeHtml(@"Thing"),
				NameOfNight = "The Crawlin Kingsnakes",
				VenId = "48",
				Venue = "Mr Wolfs",
				Headliners = "+ Big Joe Bone + Rat-a-tat-tat",
				Date = "2015-08-22",
				DateText = "Saturday 22 August",
				Price = _DeHtml(@"&pound;3 \/ &pound;4"),
				EventImgAdded = "4",
				Details =
					@"It&#039;s time for a Rock&#039;n&#039; Roll night, Wolfies style xxx<br \/>\n<br \/>\n<br \/>\n<br \/>\n<br \/>\n<br \/>\n<br \/>\n****<br \/>\n<br \/>\nThe Crawlin&#039; Kingsnakes <br \/>\n<br \/>\nAre a Rockabilly and Rock &amp; Roll band - need you know more? Ok, so they play all the best rockin songs from the 50s onwards that everyone knows, and also some others people may not (but they&#039;re still great tunes). They try to keep their sound as authentic as possible using era equipment and techniques.<br \/>\n<br \/>\n<a href=""http:\/\/www.thecrawlinkingsnakes.com"" target=""_blank"" >thecrawlinkingsnakes.com<\/a>\/<br \/>\n<br \/>\n****<br \/>\n<br \/>\nBig Joe Bone<br \/>\n<br \/>\n&quot;Big Joe Bone&quot; (A.K.A. Danny Wilson) plays what he calls&quot;Blues-Grass&quot; music.....a mix of Delta Blues, Bluegrass, Oldtime, Gospel and Hillbilly music utilizing his raspy vocals, hard driving harmonica rhythms, sublime bottleneck slide guitar playing (on steel bodied resonator guitars) and lightning finger-picking skills on 5 string banjos.....all held together by a very heavy stomping boot!<br \/>\n<br \/>\nOriginally from London and now living on the Mid-Wales coast, Danny started playing guitar as a schoolboy and has now been travelling all around the UK playing his fast, furious Roots music to eager audiences since 2012.<br \/>\nAs well as playing songs from great Roots musicians like Son House, Dock Boggs, Bukka White, Flatt and Scruggs, Mississippi Fred McDowell, Charlie Parr, Blind Willie Johnson, Skip James, Robert Johnson .....the list goes on and on!, Danny also plays his own songs, which fit right in to his eclectic set.....which shows that when it comes to roots music, he really&quot;gets it&quot;.<br \/>\n<br \/>\nAlthough&quot;Big Joe Bone&quot; is a relatively young act compared to some, Danny has a lifetime of music behind him and has thrown himself into what has become a very busy schedule of gigs since he hit the road in 2012.<br \/>\n&quot;Big Joe Bone&quot; is an act not to be missed!<br \/>\n<br \/>\n<a href=""http:\/\/www.facebook.com\/BigJoeBone"" target=""_blank"" >facebook.com\/BigJoeBone<\/a><br \/>\n<br \/>\n****<br \/>\n<br \/>\nPlus Rat-a-tat-tat taking you into the early hours of tomorrow <br \/>\n<br \/>\nDoors from 9pm<br \/>\nTickets &pound;3\/&pound;4 xxx<br \/><br \/>----------------------<br \/>THE CRAWLIN KINGSNAKES<br \/>Hey there! We play all the best Rockabilly and Rock &amp; Roll from the 50s onwards - Elvis, Eddie Cochran, Bill Haley, Chuck Berry, Carl Perkins, Billy Riley, Jerry Lee Lewis plus loads more, so we&#039;ll see you there - we&#039;re sure to have a Rockin good time!!<br \/>\n<br \/>\nBased in Bristol and covering the whole of the South West and beyond, we&#039;re also available for hire for anything - Birthday Parties, Weddings, Gigs, Events, Private Shows - you name it, we&#039;ll do it! <br \/>\nCome see us at any of our shows or drop us a line through our website<br \/>\n<br \/>\n<a href=""http:\/\/www.thecrawlinkingsnakes.com"" target=""_blank"" >thecrawlinkingsnakes.com<\/a>",
				GigClub = "1",
				ArtId = "1016",
				Name = null,
				Bio = null,
				ArtImgAdded = "2"
			};
		}

		private string _DeHtml(string s)
		{
			var deHtml = HttpUtility.HtmlDecode(s);
			return System.Text.RegularExpressions.Regex.Unescape(deHtml);

		}
	}
}