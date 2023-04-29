FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Phrases.Api/Phrases.Api.csproj", "src/Services/Phrases.Api/"]
RUN dotnet restore "src/Services/Phrases.Api/Phrases.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Phrases.Api"
RUN dotnet build "Phrases.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Phrases.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Phrases.Api.dll"]
