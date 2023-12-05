#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Store.Service.Product/Store.Service.Product.csproj", "Store.Service.Product/"]
RUN dotnet restore "Store.Service.Product/Store.Service.Product.csproj"
COPY . .
WORKDIR "/src/Store.Service.Product"
RUN dotnet build "Store.Service.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.Service.Product.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.Service.Product.dll"]