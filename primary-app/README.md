# Primary Application

## Build and Push Docker Images
```shell-session
$ docker build -t thara0402/sidecar-primary-app:0.5.0 ./
$ docker run --rm -it -p 8000:8080 --name primary thara0402/sidecar-primary-app:0.5.0
# docker run --rm -it -p 8000:80 -e ASPNETCORE_HTTPS_PORTS=80 --name primary thara0402/sidecar-primary-app:0.5.0
$ docker push thara0402/sidecar-primary-app:0.5.0
```
