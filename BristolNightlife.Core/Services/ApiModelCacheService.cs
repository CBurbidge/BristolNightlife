using System;
using BristolNightlife.Core.Models;

namespace BristolNightlife.Core.Services
{
	public class ApiModelCacheService : IApiModelCacheService
	{
		public bool ContainsDate(DateTime date)
		{
			return ApiCache.Cache.ContainsKey(date);
		}

		public ApiModel.Rootobject GetDateModel(DateTime date)
		{
			return ApiCache.Cache.ContainsKey(date) 
				? ApiCache.Cache[date]
				: null;
		}

		public void AddDateModel(DateTime date, ApiModel.Rootobject model)
		{
			if (model == null)
				return;

			if(ApiCache.Cache.ContainsKey(date) == false)
				ApiCache.Cache.Add(date, model);
		}
	}

	public interface IApiModelCacheService
	{
		bool ContainsDate(DateTime date);
		ApiModel.Rootobject GetDateModel(DateTime date);
		void AddDateModel(DateTime date, ApiModel.Rootobject model);
	}
}