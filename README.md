ASP.NET-CORS
============

How to use:

### Install nuget package

```
PM> Install-Package BoykoAnt.CORS
```

### Add http module to web.config

```xml
<system.webServer>
	<modules runAllManagedModulesForAllRequests="true">
		<add
		  name="CrossDomainRequestModule"
		  type="BoykoAnt.CORS.Module.CrossDomainRequestModule" />
	</modules>
</system.webServer>
```

### Initialize allowed CORS hosts in Global.asax

```csharp
public class Global : System.Web.HttpApplication
{
	protected void Application_Start(object sender, EventArgs e)
	{
		CrossDomainRequestModuleConfiguration.Instance.AllowedHosts.Add("localhost");
	}
}
```