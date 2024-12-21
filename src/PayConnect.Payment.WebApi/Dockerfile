FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PayConnect.Payment.WebApi/PayConnect.Payment.WebApi.csproj", "src/PayConnect.Payment.WebApi/"]
RUN dotnet restore "src/PayConnect.Payment.WebApi/PayConnect.Payment.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PayConnect.Payment.WebApi"
RUN dotnet build "PayConnect.Payment.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PayConnect.Payment.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PayConnect.Payment.WebApi.dll"]
