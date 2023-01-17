

using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Batshark.DeploymentInfo.Services
{
    public class WhoamiService : IWhoamiService
    {
        private readonly ILogger<WhoamiService> _logger;
        private readonly IOptions<DeploymentInfoOptions> _options;

        public WhoamiService(ILogger<WhoamiService> logger, IConfiguration configuration, IOptions<DeploymentInfoOptions> options)
        {
            _logger = logger;
            _options = options;

        }

        public string Get()
        {
            return _options.Value.WhoamiOverride != null ? _options.Value.WhoamiOverride : Dns.GetHostName();
        }
    }
}

