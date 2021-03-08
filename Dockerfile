#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 84
ENV ASPNETCORE_URLS=http://+:84

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Gateway_API/Gateway_API.csproj", "Gateway_API/"]
COPY ["Gateway_Services/Gateway_Services.csproj", "Gateway_Services/"]
RUN dotnet restore "Gateway_API/Gateway_API.csproj"
COPY . .
WORKDIR "/src/Gateway_API"
RUN dotnet build "Gateway_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway_API.dll"]
