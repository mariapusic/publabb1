#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/publabb1.Server.csproj", "publabb1/Server/"]
COPY ["Client/publabb1.Client.csproj", "publabb1/Client/"]
COPY ["Shared/publabb1.Shared.csproj", "publabb1/Shared/"]
RUN dotnet restore "publabb1/Server/publabb1.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "publabb1.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "publabb1.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "publabb1.Server.dll"]