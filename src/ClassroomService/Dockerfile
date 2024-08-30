FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 5155
ENV ASPNETCORE_URLS=http://+:5155

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ClassroomService/ClassroomService.csproj", "src/ClassroomService/"]
RUN dotnet restore "./src/ClassroomService/ClassroomService.csproj"
COPY . .
WORKDIR "/src/src/ClassroomService"
RUN dotnet build "./ClassroomService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClassroomService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassroomService.dll"]