#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventTicket.Services.Ordering/EventTicket.Services.Ordering.csproj", "EventTicket.Services.Ordering/"]
RUN dotnet restore "./EventTicket.Services.Ordering/./EventTicket.Services.Ordering.csproj"
COPY . .
WORKDIR "/src/EventTicket.Services.Ordering"
RUN dotnet build "./EventTicket.Services.Ordering.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventTicket.Services.Ordering.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventTicket.Services.Ordering.dll"]