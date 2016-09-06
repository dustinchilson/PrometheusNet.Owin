using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Advanced;

namespace Prometheus.Owin
{
    public class PrometheusOptions
    {
        private string _mapPath = "metrics";
        private ICollectorRegistry _collectorRegistry = DefaultCollectorRegistry.Instance;
        private List<IOnDemandCollector> _collectors = new List<IOnDemandCollector>();
        private ICollectorLocator _collectorLocator = new DefaultCollectorLocator();

        public string MapPath
        {
            get
            {
                return _mapPath;
            }
            set
            {
                _mapPath = value;
            }
        }

        public ICollectorRegistry CollectorRegistry
        {
            get
            {
                return _collectorRegistry;
            }
            set
            {
                _collectorRegistry = value;
            }
        }
        
        public List<IOnDemandCollector> Collectors
        {
            get
            {
                return _collectors;
            }
            set
            {
                _collectors = value;
            }
        }
        
        public ICollectorLocator CollectorLocator
        {
            get
            {
                return _collectorLocator;
            }
            set
            {
                _collectorLocator = value;
            }
        }
    }
}