FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
LABEL maintainer="elvia@elvia.no"

WORKDIR /app
COPY src/ .
RUN dotnet publish \
        ./adms-extensions-saf-to-ifs-workordertask/SafToIfsWorkOrderTask.csproj \
        --configuration Release \
        --output ./out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
LABEL maintainer="elvia@elvia.no"

# Workaround
# crit: Microsoft.AspNetCore.Server.Kestrel[0]
#       Unable to start Kestrel.
# System.Net.Sockets.SocketException (13): Permission denied
# https://github.com/dotnet/aspnetcore/issues/4699
ENV ASPNETCORE_URLS=http://*:8080

RUN addgroup application-group --gid 1001 \
    && adduser application-user --uid 1001 \
        --ingroup application-group \
        --disabled-password

WORKDIR /app
COPY --from=build /app/out .
RUN chown --recursive application-user .
USER application-user
EXPOSE 8080
ENTRYPOINT ["dotnet", "SafToIfsWorkOrderTask.dll"]
