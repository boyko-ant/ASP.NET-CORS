using System.Collections.Generic;

namespace BoykoAnt.CORS.Module
{
	public class CrossDomainRequestModuleConfiguration
	{
		#region Singleton

		private CrossDomainRequestModuleConfiguration()
		{
			_allowedHosts = new List<string>();
		}

		static CrossDomainRequestModuleConfiguration()
		{
			_instance = new CrossDomainRequestModuleConfiguration();
		}

		private static readonly CrossDomainRequestModuleConfiguration _instance;

		public static CrossDomainRequestModuleConfiguration Instance
		{
			get { return _instance; }
		}

		#endregion

		private readonly List<string> _allowedHosts;

		public List<string> AllowedHosts
		{
			get { return _allowedHosts; }
		}
	}
}