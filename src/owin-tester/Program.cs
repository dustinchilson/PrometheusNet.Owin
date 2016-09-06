using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Ninject;
using Ninject.Modules;
using Owin;
using Prometheus.Advanced;
using Prometheus.Owin;
using PrometheusNet.Owin.Ninject;

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

    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IOnDemandCollector>().To<DotNetStatsCollector>();
            this.Bind<IOnDemandCollector>().To<PerfCounterCollector>();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = new StandardKernel();
            kernel.Load<DImodule>();

            var options = new PrometheusOptions();
            options.CollectorLocator = new NinjectCollectorLocator(kernel);

            app.UsePrometheusServer(options);
        }
    }
}
