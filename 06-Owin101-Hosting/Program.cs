﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Owin101.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {

            using (WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.ReadLine();
            }

        }
    }
}
