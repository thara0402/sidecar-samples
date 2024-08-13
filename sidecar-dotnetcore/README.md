# Sidecar dotnet core

## Build and Push Docker Images
```shell-session
$ docker build -t thara0402/sidecar-dotnetcore:0.3.0 ./
$ docker run --rm -it -p 8000:2000 --name sidecar thara0402/sidecar-dotnetcore:0.3.0
$ docker push thara0402/sidecar-dotnetcore:0.3.0
```
