FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 5155
ENV ASPNETCORE_URLS=http://+:5286

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/UniversityBuildingService/UniversityBuildingService.csproj", "src/UniversityBuildingService/"]
RUN dotnet restore "./src/UniversityBuildingService/UniversityBuildingService.csproj"
COPY . .
WORKDIR "/src/src/UniversityBuildingService"
RUN dotnet build "./UniversityBuildingService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UniversityBuildingService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniversityBuildingService.dll"]