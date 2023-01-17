
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Batshark.DeploymentInfo.Services
{
    public class ChecksumsService : IChecksumsService
    {
        private readonly ILogger<ChecksumsService> _logger;
        private readonly IOptions<DeploymentInfoOptions> _options;


        public ChecksumsService(ILogger<ChecksumsService> logger, IOptions<DeploymentInfoOptions> options)
        {
            _logger = logger;
            _options = options;

        }
        public IEnumerable<FileEntry> GetChecksums()
        {
            // We get all modules and test the Module name
            var result = AppDomain
                            .CurrentDomain
                            .GetAssemblies()
                            .Where(p => !p.IsDynamic)
                            .SelectMany(asm => asm.GetModules())
                            .Where(m => _options.Value.ChecksumModuleContains != null ? m.Name.Contains(_options.Value.ChecksumModuleContains) : true)
                            .Select(module =>
                            {
                                if (_options.Value.UseHash == UseHash.SHA256)
                                    using (SHA256 SHA256 = SHA256.Create())
                                    {
                                        {
                                            using (var stream = System.IO.File.OpenRead(module.Assembly.Location))
                                            {
                                                var hash = SHA256.ComputeHash(stream);

                                                return new FileEntry()
                                                {
                                                    Name = module.Name,
                                                    Version = module.Assembly.GetName().Version.ToString(),
                                                    Checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
                                                };
                                            }
                                        }

                                    }
                                else
                                    using (var md5 = MD5.Create())
                                    {
                                        using (var stream = System.IO.File.OpenRead(module.Assembly.Location))
                                        {
                                            var hash = md5.ComputeHash(stream);

                                            return new FileEntry()
                                            {
                                                Name = module.Name,
                                                Version = module.Assembly.GetName().Version.ToString(),
                                                Checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
                                            };
                                        }
                                    }
                            });

            return result;
        }

    }
}

