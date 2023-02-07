FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusinessLogic.Tests/IntegrationTests/IntegrationTests.csproj", "BusinessLogic.Tests/IntegrationTests/"]
RUN dotnet restore "BusinessLogic.Tests/IntegrationTests/IntegrationTests.csproj"
COPY . .
WORKDIR "/src/BusinessLogic.Tests/IntegrationTests"
RUN dotnet build "IntegrationTests.csproj" -c Release -o /app/build

FROM build AS final
WORKDIR /src/BusinessLogic.Tests/IntegrationTests
COPY --from=build /src/BusinessLogic.Tests/IntegrationTests .
ENTRYPOINT ["dotnet", "test"]
