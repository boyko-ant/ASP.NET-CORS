using System.Web;

namespace BoykoAnt.CORS.Module
{
	public class HttpRequestExtensions
	{
		public static string GetOrigin(HttpRequest request)
		{
			var origin = request.Headers.Get("Origin");

			if (string.IsNullOrEmpty(origin))
			{
				origin = string.Format("http{0}://{1}",
					request.IsSecureConnection ? "s" : string.Empty,
					request.Headers.Get("Host"));
			}

			return origin;
		}
	}
}