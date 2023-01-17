# AspNetCore Deployment Info

Libraries that provides endpoints and services for various deployment info that can be usefull when deploying your projects. Collection of stuff we have found great use of in our own products

## Checksums

Generate checksums of all modules/dll's or limit it to your naming scheme. Great for integrety and deployment verfication. Supports md5 or sha256

## Whoami

endpoint to provide a name of the node your hitting, great for cluster deployment debugging where you have a loadbalancer in front to identiy wich node your hitting.

## Version

endpoint to provide version info of the app deployed. Supports both build timestamps and version numbers.
