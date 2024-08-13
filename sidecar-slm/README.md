# Sidecar SLM using Ollama

## Build and Push Docker Images
```shell-session
$ docker build -t thara0402/sidecar-slm:0.1.0 ./
$ docker run --rm -it -p 11434:11434 --name sidecar-slm thara0402/sidecar-slm:0.1.0
$ docker push thara0402/sidecar-slm:0.1.0
```
