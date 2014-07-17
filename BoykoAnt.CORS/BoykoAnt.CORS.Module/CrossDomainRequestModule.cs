using System;
using System.Net;
using System.Web;

namespace BoykoAnt.CORS.Module
{
	public class CrossDomainRequestModule : IHttpModule
	{
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += OnBeginRequest;
		}

		private void OnBeginRequest(object sender, EventArgs eventArgs)
		{
			var application = (HttpApplication)sender;
			var request = application.Context.Request;

			var origin = HttpRequestExtensions.GetOrigin(request);

			if (string.IsNullOrEmpty(origin))
			{
				return;
			}

			var response = application.Context.Response;
			var uri = new Uri(origin);

			if (CrossDomainRequestModuleConfiguration.Instance.AllowedHosts.Contains(uri.Host))
			{
				var methods = request.Headers.Get("Access-Control-Request-Method") ?? request.HttpMethod;
				var headers = request.Headers.Get("Access-Control-Request-Headers") ?? string.Empty;

				response.AddHeader("Access-Control-Allow-Origin", origin);
				response.AddHeader("Access-Control-Allow-Methods", methods);
				response.AddHeader("Access-Control-Max-Age", "1000");
				response.AddHeader("Access-Control-Allow-Headers", headers);

				if (request.HttpMethod.ToLowerInvariant() == "options")
				{
					response.End();
				}
			}
			else
			{
				if (CrossDomainRequestModuleConfiguration.Instance.IsDropNotAllowedHosts)
				{
					response.StatusCode = (int) HttpStatusCode.Forbidden;
					response.StatusDescription = string.Format("Host {0} is not allowed.", uri.Host);
					response.End();
				}
			}
		}
	}
}