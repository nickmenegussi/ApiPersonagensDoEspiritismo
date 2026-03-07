FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Entra na pasta do projeto
COPY ApiPersonagensDoEspiritismo/*.csproj ./ApiPersonagensDoEspiritismo/
WORKDIR /app/ApiPersonagensDoEspiritismo
RUN dotnet restore

# Copia tudo
COPY ApiPersonagensDoEspiritismo/. .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/ApiPersonagensDoEspiritismo/out .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ApiPersonagensDoEspiritismo.dll"]