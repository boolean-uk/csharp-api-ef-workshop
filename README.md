# C# API with Injected Service and Entity Framework

This application is a Calculator service injected into our API
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


## Repository Layer

So this isn't ideal at the moment.  I'm creating a Repository Layer for every Entity in my Database.  



## PersonSubjects Table

The join between the Person and Subjects is done via the PersonSubjects table.  Note as I haven't written and endpoint for this, I used sql to insert some records:
```sql

INSERT INTO "Subjects" ("Name") VALUES
  ('Mathematics'),
  ('Nautical Studies'),
  ('Science'),
  ('Spanish'),
  ('German'),
  ('French'),
  ('Dutch'),
  ('Norwegian');



INSERT INTO "PersonSubjects" ("PersonId", "SubjectId", "CreationDate") VALUES (1, 3, CURRENT_TIMESTAMP);
INSERT INTO "PersonSubjects" ("PersonId", "SubjectId", "CreationDate") VALUES (1, 1, CURRENT_TIMESTAMP);
INSERT INTO "PersonSubjects" ("PersonId", "SubjectId", "CreationDate") VALUES (1, 6, CURRENT_TIMESTAMP);
INSERT INTO "PersonSubjects" ("PersonId", "SubjectId", "CreationDate") VALUES (1, 7, CURRENT_TIMESTAMP);

```


## Validation
```
Install-Package FluentValidation
Install-Package FluentValidation.DependencyInjectionExtensions
```