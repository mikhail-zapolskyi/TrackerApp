#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project777.API/Project777.API.csproj", "Project777.API/"]
RUN ls Project777.API/
COPY ["Project777.API/Dockerfile", "./"]
RUN dotnet restore "Project777.API/Project777.API.csproj"
RUN ls -al
COPY . .
RUN pwd
RUN ls -al
WORKDIR "/src/Project777.API"
RUN dotnet build "Project777.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project777.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project777.API.dll"]