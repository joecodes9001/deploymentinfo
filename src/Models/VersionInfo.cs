
namespace Batshark.DeploymentInfo
{
    public class VersionInfo
    {
        /// <summary>
        /// Version, from the AssemblyInformationalVersionAttribute of the build. The version it was built as.
        /// </summary>
        /// <value></value>
        public string Version { get; set; }
        /// <summary>
        /// .Net version runtime
        /// </summary>
        /// <value></value>
        public string NetVersion { get; set; }
        /// <summary>
        /// COMMIT_BRANCH loaded from environment variable (great for docker images.)
        /// </summary>
        /// <value></value>
        public string Branch { get; set; }
        /// <summary>
        /// COMMIT_SHA loaded from environment variable (great for docker images.)
        /// </summary>
        /// <value></value>
        public string Commit { get; set; }
        /// <summary>
        /// yyyyMMddHHmmss build date.
        /// </summary>
        /// <value></value>
        public string BuildDate { get; set; }
    }
}

