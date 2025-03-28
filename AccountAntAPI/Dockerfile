# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore any dependencies
COPY *.csproj ./AccountAntAPI/
RUN dotnet restore "AccountAntAPI/AccountAntAPI.csproj"

# Copy the remaining source code and build the application
COPY . ./AccountAntAPI/
WORKDIR "/src/AccountAntAPI"
RUN dotnet build "AccountAntAPI.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "AccountAntAPI.csproj" -c Release -o /app/publish

# Use the official .NET 8 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
COPY AccountAnt.sqlite /app/AccountAnt.sqlite
ENTRYPOINT ["dotnet", "AccountAntAPI.dll"]
