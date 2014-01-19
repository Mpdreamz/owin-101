using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Owin101.BareBones
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public AppFunc Configuration()
        {
            return async env =>
            {
                object responseStream;
                if (!env.TryGetValue("owin.ResponseBody", out responseStream))
                    throw new Exception("Excpecting a valid owin dicitonary");

                using (var s = (Stream) responseStream)
                using (var sr = new StreamWriter(s))
                {
                   await sr.WriteAsync("Hello world");
                }
            };
        }
    }
}
