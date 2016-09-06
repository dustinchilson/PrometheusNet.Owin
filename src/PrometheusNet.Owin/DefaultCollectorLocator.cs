using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Advanced;

namespace Prometheus.Owin
{
    public class DefaultCollectorLocator : ICollectorLocator
    {
        public IEnumerable<IOnDemandCollector> Get()
        {
            yield return new DotNetStatsCollector();
        }
    }
}