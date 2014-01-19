using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.IO;

namespace Owin101.Hosting
{
    
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {

            builder.UseErrorPage();
            builder.MapPath("/favicon.ico", b => b.UseHandler((req, res) => res.StatusCode = 500));

            builder.MapPath("/error", b => b.UseFilter(req =>
            {
                var up = new Exception("BARF!");
                throw up;
            }));

            builder.MapPath("/hello-world", b =>
            {
                b.Use(typeof (CounterMiddleWare));
                b.Use(typeof (LoggingMiddleWare));
                b.UseHandlerAsync((req, res) => res.WriteAsync("Hello world!\r\n"));
            });
            builder.UseWelcomePage();
        }
    }
}