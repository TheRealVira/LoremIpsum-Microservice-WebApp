# Setup base image and configure node.js
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /app
EXPOSE 58747
EXPOSE 44316

# Install building tools for our application
FROM microsoft/dotnet:2.2.100-preview3-sdk AS build
WORKDIR /src
COPY ["LoremIpsum/LoremIpsum.csproj", "LoremIpsum/"]
RUN dotnet restore "LoremIpsum/LoremIpsum.csproj"
COPY . .
WORKDIR "/src/LoremIpsum"
RUN dotnet build "LoremIpsum.csproj" -c Release -o /app

FROM build AS publish
RUN wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs
RUN dotnet publish "LoremIpsum.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsum.dll"]

