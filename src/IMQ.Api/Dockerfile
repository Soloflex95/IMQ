# Multi-stage Dockerfile for IMQ.Api (Web API)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/IMQ.Api/IMQ.Api.csproj", "IMQ.Api/"]
COPY ["src/IMQ.Core/IMQ.Core.csproj", "IMQ.Core/"]
COPY ["src/IMQ.Data/IMQ.Data.csproj", "IMQ.Data/"]
RUN dotnet restore "IMQ.Api/IMQ.Api.csproj"
COPY src/ .
WORKDIR "/src/IMQ.Api"
RUN dotnet build "IMQ.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMQ.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMQ.Api.dll"]
