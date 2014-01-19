using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin101.HelperAssemblies
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class LoggingMiddleWare
    {
        private readonly AppFunc _next;

        public LoggingMiddleWare(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var sw = Stopwatch.StartNew();
            await _next(env);
            sw.Stop();
            var responseStream = env["owin.ResponseBody"];
            using (var s = (Stream)responseStream)
            using (var sr = new StreamWriter(s))
            {
                await sr.WriteLineAsync("Rendered in " + sw.Elapsed);
            }
        }
    }
}
