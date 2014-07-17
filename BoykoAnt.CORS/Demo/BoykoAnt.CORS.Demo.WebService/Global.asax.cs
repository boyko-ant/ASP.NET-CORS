using System;
using BoykoAnt.CORS.Module;

namespace BoykoAnt.CORS.Demo.WebService
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			CrossDomainRequestModuleConfiguration.Instance.AllowedHosts.Add("localhost");
			CrossDomainRequestModuleConfiguration.Instance.AllowedHosts.Add("localhost:50101");
			CrossDomainRequestModuleConfiguration.Instance.AllowedHosts.Add("localhost:50102");
		}
	}
}