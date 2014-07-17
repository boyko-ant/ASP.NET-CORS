ASP.NET-CORS
============

## How to use:

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

### Wiki
You can find more information about current project on [wiki](https://github.com/boyko-ant/ASP.NET-CORS/wiki).

### Demo
You can clone this repository and checkout my demo projects if you want to understand how it works in more details. 
