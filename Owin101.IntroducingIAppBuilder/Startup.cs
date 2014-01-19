using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.IO;

namespace Owin101.IntroducingIAppBuilder
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            //outermost middleware
            builder.Use(typeof(CounterMiddleWare));
            builder.Use(typeof(LoggingMiddleWare));
            //innermost middleware
            builder.Use(new Func<AppFunc, AppFunc>(next => (AppFunc) WriteHelloWordMiddleWare));
            //The previous does not call 'next' so any handler after the previous will be ignored.

        }
        
        private static async Task WriteHelloWordMiddleWare(IDictionary<string, object> env)
        {
            object responseStream;
            if (!env.TryGetValue("owin.ResponseBody", out responseStream))
                throw new Exception("Excpecting a valid owin dicitonary");

            using (var s = (Stream) responseStream)
            using (var sr = new StreamWriter(s))
            {
                await sr.WriteLineAsync("Hello world");
            }
        }
    }
}