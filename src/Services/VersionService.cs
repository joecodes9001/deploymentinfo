
using System;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Batshark.DeploymentInfo.Services
{
    public class VersionService : IVersionService
    {
        private readonly ILogger<VersionService> _logger;
        public VersionService(ILogger<VersionService> logger)
        {
            _logger = logger;
        }

        public VersionInfo GetVersionData()
        {
            var versionInfo = new VersionInfo()
            {
                Version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion,
                NetVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                Branch = Environment.GetEnvironmentVariable("COMMIT_BRANCH"),
                Commit = Environment.GetEnvironmentVariable("COMMIT_SHA"),
                BuildDate = GetBuildDate(Assembly.GetEntryAssembly()).ToString("yyyyMMddHHmmss")

            };

            return versionInfo;
        }


        private static DateTime GetBuildDate(Assembly assembly)
        {
            const string BuildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion == null) return default;
            var value = attribute.InformationalVersion;
            var index = value.IndexOf(BuildVersionMetadataPrefix);
            if (index <= 0) return default;
            value = value.Substring(index + BuildVersionMetadataPrefix.Length);
            if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var result))
            {
                return result;
            }

            return default;
        }
    }
}

