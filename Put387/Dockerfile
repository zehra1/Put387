#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Put387/Put387.csproj", "Put387/"]
RUN dotnet restore "Put387/Put387.csproj"
COPY . .
WORKDIR "/src/Put387"
RUN dotnet build "Put387.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Put387.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Put387.dll"]