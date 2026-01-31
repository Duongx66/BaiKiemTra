FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore first for better caching
COPY ["PCM.csproj", "./"]
RUN dotnet restore "PCM.csproj"

# copy everything and publish
COPY . .
WORKDIR /src
RUN dotnet publish "PCM.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
COPY wait-for-db.sh ./
RUN chmod +x ./wait-for-db.sh
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["./wait-for-db.sh"]