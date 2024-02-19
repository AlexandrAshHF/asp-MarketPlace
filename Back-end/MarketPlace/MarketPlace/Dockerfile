#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MarketPlace/MarketPlace.API.csproj", "MarketPlace/"]
COPY ["MarketPlace.Application/MarketPlace.Application.csproj", "MarketPlace.Application/"]
COPY ["MarketPlace.Core/MarketPlace.Core.csproj", "MarketPlace.Core/"]
COPY ["MarketPlace.DAL/MarketPlace.DAL.csproj", "MarketPlace.DAL/"]
COPY ["MarketPlace.Infrastructure/MarketPlace.Infrastructure.csproj", "MarketPlace.Infrastructure/"]
RUN dotnet restore "./MarketPlace/./MarketPlace.API.csproj"
COPY . .
WORKDIR "/src/MarketPlace"
RUN dotnet build "./MarketPlace.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MarketPlace.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketPlace.API.dll"]