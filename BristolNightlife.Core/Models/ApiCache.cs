using System;
using System.Collections.Generic;

namespace BristolNightlife.Core.Models
{
	public class ApiCache
	{
		public static Dictionary<DateTime, ApiModel.Rootobject> Cache = new Dictionary<DateTime, ApiModel.Rootobject>();
	}
}