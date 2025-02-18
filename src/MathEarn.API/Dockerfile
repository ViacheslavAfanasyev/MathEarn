# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

#ENTRYPOINT, tells Docker to configure the container to run as an executable. When the container starts, the ENTRYPOINT command runs. When this command ends, the container automatically stops.
#ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]

# Expose the port your application will run on
EXPOSE 80

CMD ["dotnet", "MathEarn.API.dll"]