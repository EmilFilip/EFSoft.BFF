#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.11-alpine3.18-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0.11-alpine3.18-amd64 AS build
WORKDIR /src
COPY ["EFSoft.BFF.Api/EFSoft.BFF.Api.csproj", "EFSoft.BFF.Api/"]
RUN dotnet restore "EFSoft.BFF/EFSoft.BFF.Api.csproj"
COPY . .
WORKDIR "/src/EFSoft.BFF.Api"
RUN dotnet build "EFSoft.BFF.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.BFF.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.BFF.Api.dll"]