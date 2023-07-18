# WebsiteStatusApp
worker service, log messages, deploying service app

Has been installing services lists:
1) serilog.aspnetcore
2) serilog.sinks.file
3) microsoft.extensions.hosting.windowsservices

Right click the project name on visual studio and pick the PUBLISH.
I prefered local file for this works.

Deployment powershell code:
sc.exe create WebsiteStatus binpath= c:\temp\workerservice\WebsiteStatus.exe start= auto

you look for it the services.msc, it has been registered as WebsiteStatus

You must be sure that the service is stoping and then you type the "sc delete WebsiteStatus". Thats all.
