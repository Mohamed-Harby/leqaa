FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Authentication/Authentication.Entry/Authentication.Entry.csproj", "Authentication/Authentication.Entry/"]
RUN dotnet restore "Authentication/Authentication.Entry/Authentication.Entry.csproj"
COPY . .
WORKDIR "/src/Authentication/Authentication.Entry"

FROM build AS publish
WORKDIR "/src/Authentication/Authentication.Entry"

RUN dotnet publish "Authentication.Entry.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /src/Authentication/Authentication.Entry
COPY --from=build /src/Authentication/Authentication.Entry .
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "run"]
