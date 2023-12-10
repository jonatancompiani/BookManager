# Company Book Manager #

This is a technical test for Company, implementing an ASP.NET Book management API, connecting to SQL Server using Entity Framework, with S3 Storage and Docker Support.

## How to set up? ##

### Using GNU Make (Recommended)

1. Install [GNU Make](https://www.gnu.org/software/make/manual/make.html)
2. On the root folder run the command `make init` 
3. Done! The application and database will be initialized in docker,and the migrations will be applied

### Using Docker
1. On the Docker folder, run the command `docker compose up` 
2. On the Company.BookManager.Infrastructure folder run the command `dotnet ef database update`
3. Done!

### Using Visual Studio
1. On the Docker folder run the command `docker compose up msssql`
2. On the Company.BookManager.Infrastructure folder run the command `dotnet ef database update`
3. Open the .sln file in Visual Studio
4. Set the Company.BookManager.API as the Startup Projet
5. Press F5 to start debugging

## How to use?

You can check the endpoints on [Swagger](http://localhost:5276/swagger/index.html) and interact with them.


## Final notes:
- The update book was not implemented (I was going to use Json Patch)
- The S3 Bucket implementation was not completed in time