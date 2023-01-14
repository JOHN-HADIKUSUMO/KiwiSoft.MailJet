# KiwiSoft.Bitly
#### This nuget package is meant to be used to shrink long Url into shorter one with the helps of Bitly Rest API. You need to create your own subscription with https://bitly.com before you can use this nuget package.

#### Once you have a subscription, you need to get a group guid id and generate a token. Those informations will be used by the package while communicating with the Bitly Rest API.

#### There are two way to pass in GroupId and Token to the instant object
#### A) By adding new section on appsettings.json as see below :
##### appsettings.json
```JSON
{
  "KiwiSoft.Bitly": {
    "GroupGuidId": "GKcgnMiNain",
    "Token": "563e96dfffd3d5e744dca8172719b01aed23eb09"
  }
}
```
And on the C# code, you just need to call new Shortener() to create a new instant.
```C#
  Shortener shortener = new Shortener();
  ReturnURL result = await shortener.CreateAsync("https://edi.wang/post/2019/4/24/how-to-pack-a-net-core-class-library-and-upload-to-nuget");
  string url = result.Status?result.Url:string.Empty;
```

#### B) By instantiating Configuration class and pass it to the constructor :

```C#
  Configuration configuration = new Configuration();
  configuration.GroupGuid = "GKcgnMiNain";
  configuration.Token = "563e96dfffd3d5e744dca8172719b01aed23eb09";

  Shortener shortener = new Shortener(configuration);
  ReturnURL result = await shortener.CreateAsync("https://edi.wang/post/2019/4/24/how-to-pack-a-net-core-class-library-and-upload-to-nuget");
  string url = result.Status?result.Url:string.Empty;
```

You can find out whether the operation is successful or not by looking at the value of **Status** property on ReturnUrl. And the shortened url can be 
retrieved from **Url** property.
