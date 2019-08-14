AGL Code Test

HOW TO RUN
1. Clone repository to local
2. Open AGLCodeTest.sln in Visual Studio 2017 
3. Hit F5
4. Enjoy

NLog is configured to write to C:\temp, so this folder will need to be accessible to the logged in account

1. Project descriptions
1.1	CatListMVCUI
	ASP.NET CORE 2.1 MVC web application which provides the front end to fulfil the requirements of the task.
1.2	PetOwnerModels
	POCO classes
1.3	PetOwnerService
	.Net Core 2.1 library project which provides classes and interfaces to read from the provided endpoint and perform the transformation required by the task.
1.4	PetOwnerServiceTests
	Unit tests for the PetOwnerService classes.
	1.4.1 EqualityComparers
		Used by the unit tests to determine equality between the Dictionary<string,List<string>> instances used as DTO. Only used by the unit tests.

2. Configuration

	2.1 CatListMVCUI
		2.1.1 appsettings.json
			Standard appsettings file with a CatListMVCConfig section			
			2.1.1.1	CatListMCVConfig section
				2.1.1.1.1	ApiEndpoint
								The URL which will be requested for Pet Owner data. Works for the provided file url, should also work for an api which returns json

3. Logging
Logging is provided by NLog.
Configuration is contained in .\NLogConfig.xml
Currently only file logging is configured with target files:

C:\temp\nlog-allyyyy-mm-dd.log - stores all logs
C:\temp\nlog-AGLCodeTest-yyyy-mm-dd.log	- ignores Microsoft logs, will only contain logs created by the AGLCodeTest application.
		
	
	


