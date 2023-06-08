#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Titan.WebApi/Titan.WebApi.csproj", "Titan.WebApi/"]
COPY ["Titan.Application/Titan.Application.csproj", "Titan.Application/"]
COPY ["Titan.Domain/Titan.Domain.csproj", "Titan.Domain/"]
COPY ["Titan.Persistance/Titan.Persistance.csproj", "Titan.Persistance/"]
RUN dotnet restore "Titan.WebApi/Titan.WebApi.csproj"
COPY . .
WORKDIR "/src/Titan.WebApi"
RUN dotnet build "Titan.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Titan.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Titan.WebApi.dll"]