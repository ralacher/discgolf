#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["disc-golf/Server/discgolf.Server.csproj", "disc-golf/Server/"]
COPY ["disc-golf/Client/discgolf.Client.csproj", "disc-golf/Client/"]
COPY ["disc-golf/Shared/discgolf.Shared.csproj", "disc-golf/Shared/"]
RUN dotnet restore "disc-golf/Server/discgolf.Server.csproj"
COPY . .
WORKDIR "/src/disc-golf/Server"
RUN dotnet build "discgolf.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "discgolf.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "discgolf.Server.dll"]