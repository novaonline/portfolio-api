
FROM microsoft/dotnet

# Inits
LABEL Name=portfolio-api Version=0.0.1 
ARG source=.
WORKDIR /portfolio-api

# Things are the container... publish
COPY . .
RUN dotnet restore src/portfolio-api.csproj
RUN dotnet restore test/test.csproj
RUN dotnet publish src/portfolio-api.csproj -c Release -o out
WORKDIR /portfolio-api/src

ENTRYPOINT ["dotnet", "portfolio-api.dll"]
