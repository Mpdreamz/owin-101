# Owin Hosting

Up until now we've relied on OwinHost.exe to actually host and run our small little websites. But what if you want to self host say in a console application or service? 
This is where the Microsoft.Owing.Hosting and Microsoft.Owin.Host.* assemblies come into play.

You can run this like you would any other console application, F5 this sucker.

## Microsoft.Owin

We have not actually seen this package up untill now, this dll contains an actual implementation for IAppBuilder.
It also proves implementations for OwinRequest, OwinResponse, FormCollection, RequestCookieCollection etcetera all of the 
basics building blocks for dealing with http requests and responses really.
This is also the home of the OwinStartup attribute you often see in online examples.

## Microsoft.Owin.Diagnostics

This contains the .ErrorPage() and .WelcomePage extensions on IAppBuilder.

## Microsoft.Owin.Hosting

Defines the basic pipelining for hosting implementations and introduces some concepts

Builder, Loader, Engine, ServerFactory, Starter none of which I fully understand however the `ServerFactory` bit is important since its what actual hosting implementations have to implement.

See also http://katanaproject.codeplex.com/SourceControl/latest#src/Microsoft.Owin.Host.HttpListener/OwinServerFactory.cs

and

https://groups.google.com/forum/#!msg/net-http-abstractions/s5A1SlRp3n4/jCiCfE3_VSoJ

## Microsoft.Owin.Hosting.HttpListener

An implementation of OwinServerFactory that allows owin middleware to run inside an HttpListener (http.sys)


## Microsoft.Owin.Hosting.SystemWeb

An implementation of OwinServerFactory that allows owin middleware to run inside System.Web's request pipeline (ASP.NET). Up untill very recently the only way to run owin inside IIS.

## Microsoft.Owin.Hosting.IIS

An implementation of OwinServerFactory that does not run inside the ASP.NET pipeline but inside what i assume to a special HttpModule.
Codenamed Helios this is still in beta but I've had no issues already running a production site on azure with it.

# Important note

None of this is really needed to run owin inside a webserver or to self host, this is just project katana's implementations of conventions agreed upon on the owin mailing lists. 
An alternative approach would be to include `Nowin` which is a single dll that includes a pure C# webserver that I've found to be a lot more stable when trying to self host on mono. 
With Microsoft.Owin.Host.HttpListener i would often get random errors on my mac when trying to bind to a port. 

There are some discussions going on right now on the .NET http abstractions working group about OWIN governance

https://groups.google.com/forum/#!forum/net-http-abstractions

This is great because whilst the katana project is steamrolling the owin movement further along it's probably a good idea to have two owin stacks building and agreeing 
on the conventions on top of OWIN. 