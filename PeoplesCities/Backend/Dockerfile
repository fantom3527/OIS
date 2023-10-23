#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PeoplesCities.WebApi/PeoplesCities.WebApi.csproj", "PeoplesCities.WebApi/"]
COPY ["PeoplesCities.Application/PeoplesCities.Application.csproj", "PeoplesCities.Application/"]
COPY ["PeoplesCities.Domain/PeoplesCities.Domain.csproj", "PeoplesCities.Domain/"]
COPY ["PeoplesCities.Persistence/PeoplesCities.Persistence.csproj", "PeoplesCities.Persistence/"]
RUN dotnet restore "PeoplesCities.WebApi/PeoplesCities.WebApi.csproj"
COPY . .
WORKDIR "/src/PeoplesCities.WebApi"
RUN dotnet build "PeoplesCities.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PeoplesCities.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PeoplesCities.WebApi.dll"]