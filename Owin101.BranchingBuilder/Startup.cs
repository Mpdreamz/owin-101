using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.IO;

namespace Owin101.BranchingBuilder
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            //a browser also send a request to favicon.ico everytime this breaks our counter middle
            //lets explicitly handler the favicon separately.
            builder.MapPath("/favicon.ico", b => b.Use(new Func<AppFunc, AppFunc>(next => (AppFunc)HandleFavicon)));

            builder.MapPath("/no-count", b =>
            {
                b.Use(typeof(LoggingMiddleWare));
                b.Use(new Func<AppFunc, AppFunc>(next => (AppFunc)WriteHelloWordMiddleWare));
            });

            builder.Use(typeof(CounterMiddleWare));
            builder.Use(typeof(LoggingMiddleWare));
            builder.Use(new Func<AppFunc, AppFunc>(next => (AppFunc)WriteHelloWordMiddleWare));
        }

        private static Task HandleFavicon(IDictionary<string, object> env)
        {
            env["owin.ResponseStatusCode"] = 500;
            return Task.FromResult(500); //could be anything really
        }


        private static async Task WriteHelloWordMiddleWare(IDictionary<string, object> env)
        {
            object responseStream;
            if (!env.TryGetValue("owin.ResponseBody", out responseStream))
                throw new Exception("Excpecting a valid owin dicitonary");

            using (var s = (Stream)responseStream)
            using (var sr = new StreamWriter(s))
            {
                await sr.WriteLineAsync("Hello world");
            }
        }
    }
}