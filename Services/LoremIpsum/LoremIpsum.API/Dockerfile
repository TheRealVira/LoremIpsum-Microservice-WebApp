FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2.100-preview3-sdk AS build
WORKDIR /src
COPY ["Services/LoremIpsum/LoremIpsum.API/LoremIpsum.API.csproj", "Services/LoremIpsum/LoremIpsum.API/"]
RUN dotnet restore "Services/LoremIpsum/LoremIpsum.API/LoremIpsum.API.csproj"
COPY . .
WORKDIR "/src/Services/LoremIpsum/LoremIpsum.API"
RUN dotnet build "LoremIpsum.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoremIpsum.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsum.API.dll"]