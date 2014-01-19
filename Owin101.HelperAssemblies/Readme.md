# Helper Assemblies

## Owin.Types

This strongly types some of the types defined in the owin spec. For instance, up untill now i've been getting to the response stream using `env["owin.ResponseBody"]`. 
This works fine but nobody really likes to stringly type in a static language right? Owin.Types allows us to write `env[OwinConstants.ResponseBody]`. 

This only strongly types the owin variables defined in the spec. Individual servers may place additional variables in the environment dictionary.

## Owin.Extensions

Contains several handy extension methods on `IAppBuilder` that ease the registration of middleware i.e

    builder.UseFunc(_ => async env => await WriteHelloWordMiddleWare(env));

compared to: 

    builder.Use(new Func<AppFunc, AppFunc>(next => (AppFunc) WriteHelloWordMiddleWare));

We can even do better and by just doing:

    builder.UseHandlerAsync((req, res) => res.WriteAsync("Hello world gets even easier!\r\n"));


But we can also use UseHandler as a full blown middleware wrapper.

    builder.UseHandler(async (req, res, next) =>
    {
        await res.WriteAsync("Owin.Extensions makes wrapping ....");
        next();
        await res.WriteAsync("super easy");
    });

and instead of passing our "classified" owin middleware with 

     builder.Use(typeof(MyMiddleWare))

we can write 

     builder.UseType<MyMiddleWare>();

### RUN

run 04.bat in the root after a debug build to run the application inside this assembly.

