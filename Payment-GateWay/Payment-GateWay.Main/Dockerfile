FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5006
EXPOSE 5007

ENV ASPNETCORE_URLS=http://+:5006
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Payment-GateWay/Payment-GateWay.Main/Payment-Gateway.main.csproj", "Payment-GateWay/Payment-GateWay.Main/"]
RUN dotnet restore "Payment-GateWay/Payment-GateWay.Main/Payment-Gateway.main.csproj"
COPY . .
WORKDIR "/src/Payment-GateWay/Payment-GateWay.Main"
RUN dotnet build "Payment-Gateway.main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment-Gateway.main.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /src/Payment-GateWay/
COPY --from=build /src/Payment-GateWay/ .
WORKDIR /src/Payment-GateWay/Payment-GateWay.Main
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "run"]
