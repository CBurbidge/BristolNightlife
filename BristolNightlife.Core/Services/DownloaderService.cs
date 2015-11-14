using System;
using System.IO;
using System.Net;

namespace BristolNightlife.Core.Services
{
	public interface IDownloaderService
	{
		void Download(string url, Action<string> success, Action<Exception> error);
	}

	public class DownloaderService : IDownloaderService
	{
		public void Download(string url, Action<string> success, Action<Exception> error)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			try
			{
				request.BeginGetResponse(result => ProcessResponse(success, error, request, result), null);
			}
			catch (Exception exception)
			{
				error(exception);
			}	
		}

		private void ProcessResponse(Action<string> success, Action<Exception> error, HttpWebRequest request, IAsyncResult result)
		{
			try
			{
				var response = request.EndGetResponse(result);
				using (var stream = response.GetResponseStream())
				using (var reader = new StreamReader(stream))
				{
					var text = reader.ReadToEnd();
					success(text);
				}
			}
			catch (Exception exception)
			{
				error(exception);
			}
		}
	}
}