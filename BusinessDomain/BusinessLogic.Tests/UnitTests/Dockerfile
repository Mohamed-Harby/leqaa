FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusinessDomain/BusinessLogic.Tests/UnitTests/UnitTests.csproj", "BusinessDomain/BusinessLogic.Tests/UnitTests/"]
RUN dotnet restore "BusinessDomain/BusinessLogic.Tests/UnitTests/UnitTests.csproj"
COPY . .
WORKDIR "/src/BusinessDomain/BusinessLogic.Tests/UnitTests"
RUN dotnet build "UnitTests.csproj" -c Release -o /app/build

FROM build AS final
WORKDIR /src/BusinessDomain/BusinessLogic.Tests/UnitTests
COPY --from=build /src/BusinessDomain/BusinessLogic.Tests/UnitTests .
ENTRYPOINT ["dotnet", "test"]
