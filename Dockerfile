# ---------- ESTÁGIO 1: build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia só o .csproj primeiro e restaura (aproveita cache do Docker)
COPY RentabilidadeCarteira/RentabilidadeCarteira.csproj RentabilidadeCarteira/
RUN dotnet restore RentabilidadeCarteira/RentabilidadeCarteira.csproj

# Agora copia o resto do código e publica
COPY . .
RUN dotnet publish RentabilidadeCarteira/RentabilidadeCarteira.csproj -c Release -o /app

# ---------- ESTÁGIO 2: runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "RentabilidadeCarteira.dll"]
