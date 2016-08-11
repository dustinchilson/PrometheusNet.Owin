using System;
using System.Linq;
using System.Threading.Tasks;
using Owin;
using Prometheus.Advanced;

namespace Prometheus.Owin
{
    public static class PrometheusExtensions
    {
        public static IAppBuilder UsePrometheusServer(this IAppBuilder app, PrometheusOptions options = null)
        {
            if (options == null)
                options = new PrometheusOptions();

            if (options.CollectorRegistry == DefaultCollectorRegistry.Instance)
            {
                // Default to DotNetStatsCollector if none speified
                // For no collectors, pass an empty collection
                if (!options.Collectors.Any())
                    options.Collectors.Add(new DotNetStatsCollector());

                DefaultCollectorRegistry.Instance.RegisterOnDemandCollectors(options.Collectors);
            }

            app.Map(string.Format("/{0}", options.MapPath), coreapp =>
            {
                coreapp.Run(async context =>
                {
                    var req = context.Request;
                    var response = context.Response;

                    var acceptHeader = req.Headers.Get("Accept");
                    var acceptHeaders = acceptHeader == null ? null : acceptHeader.Split(',');
                    var contentType = ScrapeHandler.GetContentType(acceptHeaders);

                    response.ContentType = contentType;

                    using (var outputStream = response.Body)
                    {
                        var collected = options.CollectorRegistry.CollectAll();
                        ScrapeHandler.ProcessScrapeRequest(collected, contentType, outputStream);
                    }

                    await Task.FromResult(0).ConfigureAwait(false);
                });
            });

            return app;
        }
    }
}
