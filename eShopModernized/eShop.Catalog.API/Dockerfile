#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8083
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["eShop.Catalog.API/eShop.Catalog.API.csproj", "eShop.Catalog.API/"]
RUN dotnet restore "eShop.Catalog.API/eShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/eShop.Catalog.API"
RUN dotnet build "eShop.Catalog.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "eShop.Catalog.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "eShop.Catalog.API.dll"]