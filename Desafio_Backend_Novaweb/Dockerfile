# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy the CSPROj file and restore any dependecies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Desafio_Backend_Novaweb.dll" ]
