FROM microsoft/dotnet:2.2-sdk

LABEL author="Shawn Gwin"

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
EXPOSE 5432
# ENV ASPNETCORE_URLS="http://*:5432"

WORKDIR /app

CMD ["/bin/bash", "-c", "dotnet restore && dotnet watch run"]

