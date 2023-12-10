

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build

WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/Company.BookManager.API.dll" ]


