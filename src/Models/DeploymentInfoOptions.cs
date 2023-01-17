
namespace Batshark.DeploymentInfo
{
    public class DeploymentInfoOptions
    {
        /// <summary>
        /// String used in the "contains" check, allow you to limit the files included with checksums.
        /// Example. limiting it to your org name space could be done with "MyOrg."
        /// </summary>
        /// <value></value>
        public string ChecksumModuleContains { get; set; } = null;
        /// <summary>
        /// Override the whoami, should be passed in config, from env variable etc. great for container deployments etc.
        /// </summary>
        /// <value></value>
        public string WhoamiOverride { get; set; } = null;
        /// <summary>
        /// the route to access whoami, default /whoami
        /// </summary>
        /// <value></value>
        public string WhoamiRoute { get; set; } = "whoami";
        /// <summary>
        /// the route to access checksums default /checksums
        /// </summary>
        /// <value></value>
        public string ChecksumsRoute { get; set; } = "checksums";
        /// <summary>
        /// the route to access version info default /version
        /// </summary>
        /// <value></value>
        public string VersionRoute { get; set; } = "version";

        public UseHash UseHash { get; set; } = UseHash.MD5;



    }
}
