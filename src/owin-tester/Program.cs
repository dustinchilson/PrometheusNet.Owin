using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using Prometheus.Advanced;
using Prometheus.Owin;

namespace owin_tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:1234/";
            
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new PrometheusOptions();
            options.Collectors.Add(new DotNetStatsCollector());
            options.Collectors.Add(new PerfCounterCollector());

            app.UsePrometheusServer(options);
        }
    }
}
