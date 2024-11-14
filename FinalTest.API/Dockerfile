# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FinalTest.API/FinalTest.API.csproj", "FinalTest.API/"]
COPY ["FinalTest.Infrastructure/FinalTest.Infrastructure.csproj", "FinalTest.Infrastructure/"]
COPY ["FinalTest.App/FinalTest.App.csproj", "FinalTest.App/"]
COPY ["FinalTest.Domain/FinalTest.Domain.csproj", "FinalTest.Domain/"]
RUN dotnet restore "./FinalTest.API/FinalTest.API.csproj"
COPY . .
WORKDIR "/src/FinalTest.API"
RUN dotnet build "./FinalTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FinalTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalTest.API.dll"]