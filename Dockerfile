#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["noberto.mealControl.WebAPI/noberto.mealControl.WebAPI.csproj", "noberto.mealControl.WebAPI/"]
COPY ["noberto.mealControl.Infra.IoC/noberto.mealControl.Infra.IoC.csproj", "noberto.mealControl.Infra.IoC/"]
COPY ["noberto.mealControl.Application.Background/noberto.mealControl.Application.Background.csproj", "noberto.mealControl.Application.Background/"]
COPY ["noberto.mealControl.Application/noberto.mealControl.Application.csproj", "noberto.mealControl.Application/"]
COPY ["noberto.mealControl.Core/noberto.mealControl.Core.csproj", "noberto.mealControl.Core/"]
COPY ["noberto.mealControl.Infra.Database/noberto.mealControl.Infra.Database.csproj", "noberto.mealControl.Infra.Database/"]
RUN dotnet restore "./noberto.mealControl.WebAPI/noberto.mealControl.WebAPI.csproj"
COPY . .
WORKDIR "/src/noberto.mealControl.WebAPI"
RUN dotnet build "./noberto.mealControl.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./noberto.mealControl.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "noberto.mealControl.WebAPI.dll"]