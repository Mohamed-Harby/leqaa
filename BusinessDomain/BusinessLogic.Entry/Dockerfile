FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE  5001

ENV ASPNETCORE_URLS=https://+:5001
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusinessDomain/BusinessLogic.Entry/BusinessLogic.Entry.csproj", "BusinessDomain/BusinessLogic.Entry/"]
RUN dotnet restore "BusinessDomain/BusinessLogic.Entry/BusinessLogic.Entry.csproj"
COPY . .
WORKDIR "/src/BusinessDomain/BusinessLogic.Entry"
RUN dotnet build "BusinessLogic.Entry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusinessLogic.Entry.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /src/BusinessDomain/BusinessLogic.Entry
COPY --from=build /src/BusinessDomain/BusinessLogic.Entry .
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "run"]
