# Sidecar dotnet core

## Build and Push Docker Images
```shell-session
$ docker build -t thara0402/sidecar-dotnetcore:0.1.0 ./
$ docker run --rm -it -p 8000:8080 --name primary thara0402/sidecar-dotnetcore:0.1.0
# docker run --rm -it -p 8000:80 -e ASPNETCORE_HTTPS_PORTS=80 --name primary thara0402/sidecar-dotnetcore:0.1.0
$ docker push thara0402/sidecar-dotnetcore:0.1.0
```

## Azure App Service Settings
```shell-session
$ az webapp config appsettings set --resource-group <group-name> --name <app-name> --settings WEBSITES_PORT=8080
```

