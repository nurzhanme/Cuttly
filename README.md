# Cuttly
Cuttly is a c# library for interacting with the Cuttly URL shortening service. It provides an easy-to-use interface for shortening URLs.

If you like this project please give a star and a cup of coffee =)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/nurzhanme)

## Installation

[![NuGet Badge](https://buildstats.info/nuget/Cuttly)](https://www.nuget.org/packages/Cuttly/)

To install Cuttly, you can use the NuGet package manager in Visual Studio. Simply search for "Cuttly" and click "Install".

Alternatively, you can install Cuttly using the command line:

```
Install-Package Cuttly
```

## Getting Started

Firstly obtain valid Cuttly API key from the https://cutt.ly/.

### Sample

https://github.com/nurzhanme/CuttSharp

### Without using dependency injection:

```c#
var CuttlyClient = new CuttlyClient(new CuttlyOptions()
{
    ApiKey = Environment.GetEnvironmentVariable("MY_CUTTLY_API_KEY")
});
```

### Using dependency injection:

In your secrets.json or other settings.json

```json
"CuttlyOptions": {
  //"ApiKey": "Your api key goes here",
  //"ApiBaseAddress": "If api base has been changed (optional. by default: https://cutt.ly/api/api.php)"
},
```

#### Program.cs

```c#
serviceCollection.AddCuttlyClient();
```

or using Environment Variable

```c#
serviceCollection.AddCuttlyClient(settings => { settings.ApiKey = Environment.GetEnvironmentVariable("MY_CUTTLY_API_KEY"); });
```

NOTE: do NOT put your API key directly to your source code.

After injecting your service you will be able to get it from service provider

```c#
var CuttlyClient = serviceProvider.GetRequiredService<CuttlyClient>();
```

or injecting in the constructor of your class

```c#
public class MyService
{
    private readonly CuttlyClient _CuttlyClient;
    
    public MyService(CuttlyClient CuttlyClient)
    {
        _CuttlyClient = CuttlyClient;
    }
}
```

### Shorten request

```c#
//string urlToShorten - may be input parameter

var respone = await CuttlyClient.Shorten(urlToShorten});

if (response.Url.Status == (int)ShortStatus.OK)
{
    Console.WriteLine(response);
}
```

more details about requests https://cutt.ly/api-documentation/regular-api
