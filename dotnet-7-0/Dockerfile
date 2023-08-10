# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
# copy csproj and restore as distinct layers
#COPY *.sln .
COPY /*.csproj ./aspnetapp/
RUN cd aspnetapp && dotnet restore

# copy everything else and build app
COPY ./. ./aspnetapp/
WORKDIR /aspnetapp
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
# dll has the same name as the project being built
ENTRYPOINT ["dotnet", "dotnet.dll"]