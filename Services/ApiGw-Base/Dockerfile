FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Services/ApiGw-Base/ApiGw-Base.csproj", "Services/ApiGw-Base/"]
RUN dotnet restore "Services/ApiGw-Base/ApiGw-Base.csproj"
COPY . .
WORKDIR "/src/Services/ApiGw-Base"
RUN dotnet build "ApiGw-Base.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiGw-Base.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiGw-Base.dll"]