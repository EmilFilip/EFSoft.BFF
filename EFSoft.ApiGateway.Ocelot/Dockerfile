#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EFSoft.ApiGateway.Ocelot/EFSoft.ApiGateway.Ocelot.csproj", "EFSoft.ApiGateway.Ocelot/"]
RUN dotnet restore "EFSoft.ApiGateway.Ocelot/EFSoft.ApiGateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/EFSoft.ApiGateway.Ocelot"
RUN dotnet build "EFSoft.ApiGateway.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.ApiGateway.Ocelot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.ApiGateway.Ocelot.dll"]