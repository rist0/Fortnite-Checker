using System.Collections.Generic;
using System.IO;
using System.Net;
using FortniteChecker.Models;

namespace FortniteChecker.Classes
{
    internal static class ProxyHelper
    {
        public static IWebProxy GetWebProxy(Proxy proxy)
        {
            var webProxy = new WebProxy($"{proxy.IpAddress}:{proxy.Port}");

            if (string.IsNullOrEmpty(proxy.Username) || string.IsNullOrEmpty(proxy.Password))
            {
                return webProxy;
            }

            var webProxyCredentials = new NetworkCredential(proxy.Username, proxy.Password);

            webProxy.UseDefaultCredentials = false;
            webProxy.Credentials = webProxyCredentials;

            return webProxy;
        }

        public static List<Proxy> ValidateAndLoadProxies(IEnumerable<string> files)
        {
            var proxies = new List<Proxy>();

            foreach (var file in files)
            {
                var lines = File.ReadAllLines(file);

                // NOTE: These are the most common separators
                var proxyDelimiters = new[]
                {
                    ':',
                    ';',
                    '|'
                };

                foreach (var line in lines)
                {
                    var separatedProxy = line.Split(proxyDelimiters);

                    var proxy = new Proxy();

                    if (separatedProxy.Length != 2 && separatedProxy.Length != 4)
                    {
                        continue;
                    }

                    var validateIpAddress = IPAddress.TryParse(separatedProxy[0], out var ipAddress);

                    var validatePort = ushort.TryParse(separatedProxy[1], out var port);

                    if (!validateIpAddress || !validatePort)
                    {
                        continue;
                    }

                    proxy.IpAddress = separatedProxy[0];
                    proxy.Port = port;

                    if (separatedProxy.Length == 4)
                    {
                        proxy.Username = separatedProxy[2];
                        proxy.Password = separatedProxy[3];
                    }

                    proxies.Add(proxy);
                }
            }

            return proxies;
        }
    }
}
