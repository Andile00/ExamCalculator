#Starts from the .NET 8 SDK image as the base img
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#Sets up the working directory
WORKDIR /app
#Copies ONLY the .csproj file first to the container
COPY ExamCalculator/*.csproj ./ExamCalculator/
WORKDIR /app/ExamCalculator
RUN dotnet restore

COPY ExamCalculator/. ./
RUN dotnet publish -c Release -o /app/publish
#Uses runtime img to execute the application 
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .
#Runs the compiled application
ENTRYPOINT ["dotnet", "ExamCalculator.dll"]