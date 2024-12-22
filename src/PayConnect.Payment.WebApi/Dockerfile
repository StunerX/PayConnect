#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PayConnect.Payment.WebApi/PayConnect.Payment.WebApi.csproj", "src/PayConnect.Payment.WebApi/"]
COPY ["src/PayConnect.Application/PayConnect.Application.csproj", "src/PayConnect.Application/"]
COPY ["src/PayConnect.Domain/PayConnect.Domain.csproj", "src/PayConnect.Domain/"]
COPY ["src/PayConnect.Infrastructure.EntityFramework/PayConnect.Infrastructure.EntityFramework.csproj", "src/PayConnect.Infrastructure.EntityFramework/"]
RUN dotnet restore "./src/PayConnect.Payment.WebApi/./PayConnect.Payment.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PayConnect.Payment.WebApi"
RUN dotnet build "./PayConnect.Payment.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PayConnect.Payment.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PayConnect.Payment.WebApi.dll"]