# DEPRECATED
This repository is no longer maintained, I recommend switching over to https://github.com/PrometheusClientNet/Prometheus.Client

# PrometheusNet.Owin #
An Owin handler for the prometheus-net metrics tracking library

Using the awesome library [prometheus-net](https://github.com/andrasm/prometheus-net) from [andrasm](https://github.com/andrasm) serve the metrics endpoints using the Owin middleware.

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/dustinchilson/PrometheusNet.Owin/master/LICENSE)
[![No Maintenance Intended](http://unmaintained.tech/badge.svg)](http://unmaintained.tech/)

## PrometheusNet.Owin ##

[![NuGet](https://img.shields.io/nuget/v/PrometheusNet.Owin.svg)](https://www.nuget.org/packages/PrometheusNet.Owin/)

### Installation ###
This library is packaged as a nuget package available [here](https://www.nuget.org/packages/PrometheusNet.Owin/)

```
Install-Package PrometheusNet.Owin
```

### Basic Usage ###
Once running you should see all of the stats running from your server (ex http://localhost:1234/metrics)
```CSharp
public void Configuration(IAppBuilder app)
{
    app.UsePrometheusServer();
}
```

### Advanced Usage ###
Once running you should see all of the stats running from your server (ex http://localhost:1234/prometheus)

```CSharp
public void Configuration(IAppBuilder app)
{
    var options = new PrometheusOptions();
    options.MapPath = "prometheus";
    options.Collectors.Add(new DotNetStatsCollector());
    options.Collectors.Add(new PerfCounterCollector());

    app.UsePrometheusServer(options);
}
```

## PrometheusNet.Owin.Ninject ##

[![NuGet](https://img.shields.io/nuget/v/PrometheusNet.Owin.Ninject.svg)](https://www.nuget.org/packages/PrometheusNet.Owin.Ninject/)

### Installation ###
This library is packaged as a nuget package available [here](https://www.nuget.org/packages/PrometheusNet.Owin.Ninject/)

```
Install-Package PrometheusNet.Owin.Ninject
```

### Usage ###
Once running you should see all of the stats running from your server (ex http://localhost:1234/prometheus)

```CSharp
public void Configuration(IAppBuilder app)
{
    var options = new PrometheusOptions();
    options.CollectorLocator = new NinjectCollectorLocator(kernel);

    app.UsePrometheusServer(options);
}
```

## License ##

[LICENSE](https://raw.githubusercontent.com/dustinchilson/PrometheusNet.Owin/master/LICENSE)

MIT License

Copyright (c) 2016 Dustin Chilson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
