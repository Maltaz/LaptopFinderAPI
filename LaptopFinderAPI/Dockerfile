#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LaptopFinderAPI/LaptopFinderAPI.csproj", "LaptopFinderAPI/"]
COPY ["LaptopFinder.Core/LaptopFinder.Core.csproj", "LaptopFinder.Core/"]
RUN dotnet restore "LaptopFinderAPI/LaptopFinderAPI.csproj"
COPY . .
WORKDIR "/src/LaptopFinderAPI"
RUN dotnet build "LaptopFinderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaptopFinderAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaptopFinderAPI.dll"]