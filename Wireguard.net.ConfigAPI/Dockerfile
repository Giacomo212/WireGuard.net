FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Wireguard.net.ConfigAPI/Wireguard.net.ConfigAPI.csproj", "Wireguard.net.ConfigAPI/"]
COPY ["Wireguard.net.ConfigAPI.Common/Wireguard.net.ConfigAPI.Common.csproj", "Wireguard.net.ConfigAPI.Common/"]
COPY ["Wireguard.net.ConfigAPI.DataAccess/Wireguard.net.ConfigAPI.DataAccess.csproj", "Wireguard.net.ConfigAPI.DataAccess/"]
COPY ["WireGuard.net.ConfigAPI.SystemHandles/WireGuard.net.ConfigAPI.SystemHandles.csproj", "WireGuard.net.ConfigAPI.SystemHandles/"]
RUN dotnet restore "Wireguard.net.ConfigAPI/Wireguard.net.ConfigAPI.csproj"
COPY . .
WORKDIR "/src/Wireguard.net.ConfigAPI"
RUN dotnet build "Wireguard.net.ConfigAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wireguard.net.ConfigAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wireguard.net.ConfigAPI.dll"]
