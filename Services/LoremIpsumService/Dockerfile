FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59021
EXPOSE 44354

FROM microsoft/dotnet:2.2.100-preview3-sdk AS build
WORKDIR /src
COPY ["Services/LoremIpsumService/LoremIpsumService.csproj", "Services/LoremIpsumService/"]
RUN dotnet restore "Services/LoremIpsumService/LoremIpsumService.csproj"
COPY . .
WORKDIR "/src/Services/LoremIpsumService"
RUN dotnet build "LoremIpsumService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoremIpsumService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsumService.dll"]