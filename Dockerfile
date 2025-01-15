#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

#COPY ["NuGet.Config", "."]
COPY ["EFSoft.BFF.Api/EFSoft.BFF.Api.csproj", "EFSoft.BFF.Api/"]

#ARG NUGET_PASSWORD
#RUN apk add --update sed 
#RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"emilfilip3\" /><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\" /></emilfilip3></packageSourceCredentials></configuration>|" NuGet.Config

RUN dotnet restore "EFSoft.BFF.Api/EFSoft.BFF.Api.csproj" #--configfile NuGet.Config

COPY . .
WORKDIR "/src/EFSoft.BFF.Api"
RUN dotnet build "EFSoft.BFF.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.BFF.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.BFF.Api.dll"]