# portfolio-api

api for my portfolio

## setup

If you are running on visual studio, make sure to launch using `portfolio-api`.

For any IDE, two environment variables are needed:

* DefaultConnection: `[database connection string]`

The variables have been provided.

migrations is used to update the database.
for more info: http://benjii.me/2017/05/enable-entity-framework-core-migrations-visual-studio-2017/
make sure you're in `src` and also make sure envrionment variable `DefaultConnection` is set
Note: I have not been able to get the Package Manager Console to work yet.

## migrations

1. `export DefaultConnection="{ConnectionString}"`
2. `dotnet ef migrations add ProfileIdAdded --project "repo/entity-framework/PortfolioApi.Repository.EntityFramework.csproj" --startup-project "src/PortfolioApi.csproj"`
