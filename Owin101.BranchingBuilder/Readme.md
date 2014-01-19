# Branching using Microsoft.Owin.Mapping

Now we're getting into the realm of the experimental:

https://www.nuget.org/packages/Microsoft.Owin.Mapping/

> Install-Package Microsoft.Owin.Mapping -Version 0.21.0-pre -Pre

In many cases you hand of the pipeline to your favorite application framework (asp.net/webapi/nancyfx/simpleweb etc) and then you use their routing and the likes.

But what if you want to have endpoint /nancyfx handled by nancy and the others by simpleweb? Sure you can write your own middleware that dispatches into the proper middleware
based on owin.RequestPath but this gets tedious rather fast. 

Thats where Microsoft.Owin.Mapping comes into play think of it as applicationless routing.

### RUN

run 05.bat in the root after a debug build to run the application inside this assembly.