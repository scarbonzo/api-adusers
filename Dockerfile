FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["api-adusers/api-adusers.csproj", "api-adusers/"]
RUN dotnet restore "api-adusers/api-adusers.csproj"
COPY . .
WORKDIR "/src/api-adusers"
RUN dotnet build "api-adusers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-adusers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-adusers.dll"]