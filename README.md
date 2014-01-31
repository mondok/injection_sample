# Entity Framework Lifecycle Management Sample Using StructureMap IoC #
This project is a simple sample application that shows how to use StructureMap + controller injection to manage an entity framework lifecycle context.

The basic idea is that you can access the same DataContext through different areas of the application by leveraging the IoC's lifecycle management (in this case, HttpContext scoped).  An example of this is the `PeopleRepositoryHelper` in the Lib directory.  While contrived, notice that it's pulling the context with

`EfSampleContext context = ObjectFactory.GetInstance<EfSampleContext>();`

While this could be a property, for the sake of this demo we're going to get it from a centralized place each time. On a related note, notice in the `PeopleController` that it is injected in via the constructor.  

This is all setup in the DependencyResolution folder with the file `IoC.cs`.  You can see that we use a fluent configuration to initialize the context:

`x.For<EfSampleContext>().HttpContextScoped().Use(z => new EfSampleContext());`

The package that allows this is StructureMap.MVC4 which can be found on NuGet.  It adds all the necessary files for initialization.  

The only other piece of code to note is in the `EfSampleContext.cs` file.  We have a static method called InitializeDatabase that sets up the DB if it doesn't already exist.  This initialize is handled in Global.asax, though that may be better off moved into App_Start and handled in a separate file in a real world scenario.  