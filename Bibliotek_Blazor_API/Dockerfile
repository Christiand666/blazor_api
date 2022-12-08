#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
WORKDIR /app
COPY --from=build-env /app/out .
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Bibliotek_Blazor_API/Bibliotek_Blazor_API.csproj", "Bibliotek_Blazor_API/"]
#RUN dotnet restore "Bibliotek_Blazor_API/Bibliotek_Blazor_API.csproj"
#COPY . .
#WORKDIR "/src/Bibliotek_Blazor_API"
#RUN dotnet build "Bibliotek_Blazor_API.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Bibliotek_Blazor_API.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bibliotek_Blazor_API.dll", "--urls", "http://localhost:80"]