using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin101.BareBonesMiddleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public AppFunc Configuration()
        {
            return new LoggingMiddleWare(WriteHelloWordMiddleWare).Invoke;
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
