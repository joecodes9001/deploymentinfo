# AspNetCore Deployment Info

Libraries that provide endpoints and services for various deployment info that can be useful when deploying your projects. Collection of stuff we have found great use of in our own products.

Work in progress will be creating a nuget package later; in the mean time just take what you need. Currently, only work with net6 or later versions.

## Checksums

Generate checksums of all modules/dll's or limit them to your naming scheme. Great for integrity and deployment verification. Supports md5 or sha256

## Whoami

Endpoint to provide a name of the node you hitting, great for cluster deployment debugging where you have a load balancer in front to identify wich node you hitting.

## Version

Endpoint to provide version info of the app deployed. Supports both build timestamps and version numbers.

For the version build timestamp to work, you need to add the following to your csproj file.
```
  <PropertyGroup>
    ....
    <!-- Important for the build timestamp -->
    <SourceRevisionId>build$([System.DateTime]::UtcNow.ToString("yyyyMMddHHmmss"))</SourceRevisionId>
  </PropertyGroup>

```
