FROM microsoft/dotnet:1.1.0-sdk-projectjson

RUN mkdir -p /dotnetapp

COPY src /dotnetapp
WORKDIR /dotnetapp

RUN dotnet restore

EXPOSE 5002

WORKDIR /dotnetapp/Email
ENTRYPOINT ["dotnet", "run", "-p", "project.json"]