FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Logon.API/Logon.API.csproj", "Logon.API/"]
RUN dotnet restore "Logon.API/Logon.API.csproj"
COPY . .
WORKDIR "/src/Logon.API"
RUN dotnet build "Logon.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Logon.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Logon.API.dll"]