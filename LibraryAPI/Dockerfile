#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
#WORKDIR /src
#COPY ["LibraryAPI/LibraryAPI.csproj", "LibraryAPI/"]
#RUN dotnet restore "LibraryAPI/LibraryAPI.csproj"
#COPY . .
#WORKDIR "/src/LibraryAPI"
#RUN dotnet build "LibraryAPI.csproj" -c Release -o /app

#FROM build AS publish
#RUN dotnet publish "LibraryAPI.csproj" -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "LibraryAPI.dll"]


FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
CMD dotnet AspNetCoreHerokuDocker.dll