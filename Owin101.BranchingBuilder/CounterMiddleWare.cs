using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Owin101.BranchingBuilder
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class CounterMiddleWare
    {
        private readonly AppFunc _next;
        private int _count = 0;

        public CounterMiddleWare(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;

        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            Interlocked.Increment(ref _count);
            this._next(env);
            var responseStream = env["owin.ResponseBody"];
            using (var s = (Stream)responseStream)
            using (var sr = new StreamWriter(s))
            {
                await sr.WriteLineAsync("Called this page" + this._count + " times");
            }
        }
    }
}
