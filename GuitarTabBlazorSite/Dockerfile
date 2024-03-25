#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GuitarTabBlazorSite/GuitarTabBlazorSite.csproj", "GuitarTabBlazorSite/"]
COPY ["TabTranslator/GuitarTabConverter.csproj", "TabTranslator/"]
RUN dotnet restore "GuitarTabBlazorSite/GuitarTabBlazorSite.csproj"
COPY . .
WORKDIR "/src/GuitarTabBlazorSite"
RUN dotnet build "GuitarTabBlazorSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuitarTabBlazorSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuitarTabBlazorSite.dll"]