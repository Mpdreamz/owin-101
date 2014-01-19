# Introducing IAppBuilder

In the previous example we manually wrap middleware inside eachother this gets rather old pretty quickly if you have a chain of say 8 middleware handlers:

`new A(new B(new C(new D(new E())))` ad infinitum much?

One of tactics to combat this that was introduced in the pre Owin days is an interface call `IAppBuilder`. 
The katana project took this and implemented this in the owin.dll, this is a common source of confusion since the spec never mentions IAppBuilder. 

Most examples on the internet that have anything to do with Owin will however have IAppBuilder in the examples which could have people believe IAppBuilder is part of the spec or 
perhaps even worse that owin.dll is a requirement to run owin. The first sample project in this repos clearly shows that this is not the case!

Make sure you read https://github.com/owin/owin/issues/19 on this matter, it's a great read. I tend to agree that middleware standardizing around IAppBuilder is not an issue
as long as the middleware itself can be chained without it.

Most middleware/application frameworks integrations already come extension methods on IAppBuilder that make it even easier to hook them in the pipeline and configuring them.

### RUN

run 03.bat in the root after a debug build to run the application inside this assembly.