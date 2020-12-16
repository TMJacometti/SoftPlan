#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SoftPlan.API/SoftPlan.API.csproj", "SoftPlan.API/"]
COPY ["SoftPlan.Service/SoftPlan.Service.csproj", "SoftPlan.Service/"]
COPY ["SoftPlan.Infra.Data/SoftPlan.Infra.Data.csproj", "SoftPlan.Infra.Data/"]
COPY ["SoftPlan.Domain/SoftPlan.Domain.csproj", "SoftPlan.Domain/"]
COPY ["SoftPlan.Infra.CrossCutting/SoftPlan.Infra.CrossCutting.csproj", "SoftPlan.Infra.CrossCutting/"]
RUN dotnet restore "SoftPlan.API/SoftPlan.API.csproj"
COPY . .
WORKDIR "/src/SoftPlan.API"
RUN dotnet build "SoftPlan.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftPlan.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftPlan.API.dll"]