# LogAggregator
Simple .NET based log aggregation tool. Store all your logs in one place. 
The tool contains Web API part and Simple MVC Web Site

The idea of the tool is centalized log repository for projects having multiple environemnts and \ or installations. 
For example you have Test, Staging and Prod environments. And 10 installations of the same product for diferent customers.
When you face an error in one environment, you can easily query if other environments have the same issue and when it started. You have all your logs in one place and do not have to go to every system and check logs.

**API.** Store log entries and search logs with paging.
**Site.** MVC site for log searching.
**Storage.** Can be anything, you just need to implement interface, register implementation in IOC and select it in Web.config. Currently Mongo DB storage is implemented, as well as dummy storage for testing purposes.
Example: 
```cs
    builder.RegisterType<MongoDbStorage>().Named<IStorage>("MongoDbStorage").SingleInstance();
    builder.RegisterType<FileStrorage>().Named<IStorage>("FileSystemStorage").InstancePerRequest();
    builder.RegisterType<NoStorage>().Named<IStorage>("NoStorage").InstancePerRequest();
```
Web.config
```
 <add key="StorageName" value="MongoDbStorage" />
```
**Sample Project.** Contains simple console app to demo API - Post Logs and Search logs.

**By default tool is configured to use Mongo DB on localhost:27017. See web.config for other options.**
