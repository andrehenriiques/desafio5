#Nhelper Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

#COPY *.csproj
COPY ["Desafio5.Data.Postgres/Desafio5.Data.Postgres.csproj", "Desafio5.Data.Postgres/"]
COPY ["Desafio5.IoC/Desafio5.IoC.csproj", "Desafio5.IoC/"]
COPY ["Desafio5.Api/Desafio5.Api.csproj", "Desafio5.Api/"]
COPY ["Desafio5.Domain/Desafio5.Domain.csproj", "Desafio5.Domain/"]
COPY ["Desafio5.Tests/Desafio5.Tests.csproj", "Desafio5.Tests/"]
COPY ["Desafio5.Application/Desafio5.Application.csproj", "Desafio5.Application/"]
COPY ["Desafio5.Data/Desafio5.Data.csproj", "Desafio5.Data/"]

RUN dotnet restore "./Desafio5.Api/Desafio5.Api.csproj"

COPY . .
WORKDIR "/src/Desafio5.Api"
RUN dotnet publish "./Desafio5.Api.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled AS final
WORKDIR /app
EXPOSE 8080

ENV TZ=America/Sao_Paulo \
    ASPNETCORE_URLS=http://*:8080

COPY --from=build /app/publish .

USER app

ENTRYPOINT ["dotnet", "Desafio5.Api.dll"]
