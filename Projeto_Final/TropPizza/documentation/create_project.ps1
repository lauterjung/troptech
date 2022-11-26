dotnet new sln
dotnet new classlib -n TropPizza.Domain -f net5.0 
dotnet new classlib -n TropPizza.Infra.Data -f net5.0
dotnet new webapi -n TropPizza.WebApi -f net5.0
dotnet new nunit -n TropPizza.Tests -f net5.0

dotnet sln add .\TropPizza.Domain\ 
dotnet sln add .\TropPizza.Infra.Data\ 
dotnet sln add .\TropPizza.WebApi\
dotnet sln add .\TropPizza.Tests\
dotnet add .\TropPizza.Tests\ reference .\TropPizza.Domain\ 
dotnet add .\TropPizza.Infra.Data\ reference .\TropPizza.Domain\ 
dotnet add .\TropPizza.WebApi\ reference .\TropPizza.Domain\ 
dotnet add .\TropPizza.WebApi\ reference .\TropPizza.Infra.Data\ 

cd .\TropPizza.Infra.Data\
dotnet add package System.Data.SqlClient