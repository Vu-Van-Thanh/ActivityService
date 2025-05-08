FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ActivityService.API/ActivityService.API.csproj", "ActivityService.API/"]
RUN dotnet restore "ActivityService.API/ActivityService.API.csproj"
COPY . .
WORKDIR "/src/ActivityService.API"
RUN dotnet build "ActivityService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActivityService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActivityService.API.dll"] 