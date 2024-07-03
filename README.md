Download dotnet for linux/windows/mac whatever you machine is

https://dotnet.microsoft.com/en-us/download

Then pull down this repository

then open `appsettings.json` and enter the bearer token and base url (all the way through the /api part)  the `getAccountBatch` will be appended

from the root directory

`dotnet run`

will run the non chunked version and it will output the first page of results

`dotnet run chunked`

will run the chunked / optimized version and will output the first page of results, which under current server configuration will be "SearchCriteraRequired"
