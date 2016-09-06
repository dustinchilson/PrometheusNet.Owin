using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Prometheus.Advanced;
using Prometheus.Owin;

namespace PrometheusNet.Owin.Ninject
{
    public class NinjectCollectorLocator : ICollectorLocator
    {
        private readonly IKernel _kernel;

        public NinjectCollectorLocator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IEnumerable<IOnDemandCollector> Get()
        {
            return _kernel.GetAll<IOnDemandCollector>();
        }
    }
}
