using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Advanced;

namespace Prometheus.Owin
{
    public interface ICollectorLocator
    {
        IEnumerable<IOnDemandCollector> Get();
    }
}