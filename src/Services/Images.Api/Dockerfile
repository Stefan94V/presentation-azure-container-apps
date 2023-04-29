FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Images.Api/Images.Api.csproj", "src/Services/Images.Api/"]
RUN dotnet restore "src/Services/Images.Api/Images.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Images.Api"
RUN dotnet build "Images.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Images.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Images.Api.dll"]
