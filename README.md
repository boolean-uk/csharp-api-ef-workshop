# C# API with Injected Service and Entity Framework

## Setup

- Remove or rename the *appsettings.Example.json* so that you have an *appsettings.json, appsettings.Development.json* file in the root of the workshop.wwwapi project which contains your NEON credentials:
```json
{

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=URL; Database=neondb; Username=neondb_owner; Password=PASSWORD;"

  }
}

```

- Note the .gitignore file in the root of the project which prevents the build directories being uploaded:
```
*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
```


## Dependencies Installed

You'll need all of these which have already been installed in this project:

- ```Install-Package Scalar.AspNetCore``` provides a /scalar endpoint 
- ```Install-Package Swashbuckle.AspNetCore ``` provides a /swagger endpoint
- ```Install-Package Microsoft.EntityFrameworkCore``` 
- ```Install-Package Microsoft.EntityFrameworkCore.Tools```
- ```Install-Package Microsoft.EntityFrameworkCore.Design```
- ```Install-Package NpgSql.EntityFrameworkCore.PostgreSql```

## Change the ```Program.cs```

```cs
builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.LogTo(message => Debug.WriteLine(message));

});

```

## Run a Migration

In the Package Manager Console you can run:

- ```add-migration First``` to create a migration
- ```update-database``` to apply to a db