using System;
using BristolNightlife.Core.Models;

namespace BristolNightlife.Core.Services
{
	public interface IApiService
	{
		void GetEventsForDate(DateTime date, Action<ApiModel.Rootobject> success, Action<Exception> error);
	}

	public class ApiService : IApiService
	{
		private readonly IApiModelCacheService _apiModelCacheService;
		private readonly IWebApiModelService _webApiModelService;

		public ApiService(IWebApiModelService webApiModelService, IApiModelCacheService apiModelCacheService)
		{
			_webApiModelService = webApiModelService;
			_apiModelCacheService = apiModelCacheService;
		}

		public void GetEventsForDate(DateTime date, Action<ApiModel.Rootobject> success, Action<Exception> error)
		{
			if (_apiModelCacheService.ContainsDate(date))
				success(_apiModelCacheService.GetDateModel(date));
			else
				_webApiModelService.GetDateJson(date, success, error);
		}
	}
}