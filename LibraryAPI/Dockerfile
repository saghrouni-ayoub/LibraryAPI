#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
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
CMD dotnet LibraryAPI.dll