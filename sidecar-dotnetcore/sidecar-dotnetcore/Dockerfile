FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /code
COPY . .
RUN dotnet restore
RUN dotnet publish --output /output --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 2000
COPY --from=build /output /app
WORKDIR /app
ENTRYPOINT ["dotnet", "sidecar-dotnetcore.dll"]