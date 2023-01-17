
using System.Collections.Generic;

namespace Batshark.DeploymentInfo.Services
{
    public interface IChecksumsService
    {
        IEnumerable<FileEntry> GetChecksums();
    }
}
