# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el archivo de proyecto y restaurar dependencias
COPY APIFarmacia.csproj .
RUN dotnet restore

# Copiar todo el c�digo fuente y compilar la aplicaci�n
COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de compilaci�n
COPY --from=build /app .

# Exponer el puerto que la aplicaci�n escucha
EXPOSE 8080
EXPOSE 8081

# Punto de entrada para la aplicaci�n
ENTRYPOINT ["dotnet", "APIFarmacia.dll"]
