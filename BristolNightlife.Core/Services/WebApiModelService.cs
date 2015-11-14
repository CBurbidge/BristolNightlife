using System;
using System.IO;
using BristolNightlife.Core.Models;
using Newtonsoft.Json;

namespace BristolNightlife.Core.Services
{
	public class WebApiModelService : IWebApiModelService
	{
		private readonly IApiModelCacheService _apiModelCacheService ;
		private readonly IDownloaderService _downloaderService ;

		public WebApiModelService(IDownloaderService downloaderService, IApiModelCacheService apiModelCacheService)
		{
			_downloaderService = downloaderService;
			_apiModelCacheService = apiModelCacheService;
		}

		public void GetDateJson(DateTime date, Action<ApiModel.Rootobject> success, Action<Exception> error)
		{
			string url = "http://www.someEventsWebsite.com"; // Obviously fake...

			Action<string> parseAndAddToDb = text =>
			{
				using (var stringReader = new StringReader(text))
				{
					var converter = new JsonSerializer();
					var jsonReader = new JsonTextReader(stringReader);
					var rootobject = converter.Deserialize<ApiModel.Rootobject>(jsonReader);
					
					_apiModelCacheService.AddDateModel(date, rootobject);
					
					success(rootobject);
					
					jsonReader.Close();
				}
			};

			_downloaderService.Download(url, parseAndAddToDb, error);	
		}
	}

	public interface IWebApiModelService
	{
		void GetDateJson(DateTime date, Action<ApiModel.Rootobject> success, Action<Exception> error);
	}
}