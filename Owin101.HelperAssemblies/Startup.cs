using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.IO;
using Owin.Types;

namespace Owin101.HelperAssemblies
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.UseType<CounterMiddleWare>();
            builder.UseType<LoggingMiddleWare>();
            builder.UseHandler(async (req, res, next) =>
            {
                await res.WriteAsync("Owin.Extensions makes wrapping ....\r\n");
                next();
                await res.WriteAsync(".... super easy.\r\n");
            });
            //builder.UseFunc(_ => async env => await WriteHelloWordMiddleWare(env));
            builder.UseHandlerAsync((req, res) => res.WriteAsync("Hello world gets even easier!\r\n"));
        }
        
        private static async Task WriteHelloWordMiddleWare(IDictionary<string, object> env)
        {
            object responseStream;
            if (!env.TryGetValue(OwinConstants.ResponseBody, out responseStream))
                throw new Exception("Excpecting a valid owin dicitonary");

            using (var s = (Stream) responseStream)
            using (var sr = new StreamWriter(s))
            {
                await sr.WriteLineAsync("Hello world");
            }
        }
    }
}