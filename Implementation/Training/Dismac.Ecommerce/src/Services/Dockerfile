# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY Shared/Service.Shared.Utils/Service.Shared.Utils.csproj ./Shared/Service.Shared.Utils/
COPY Customer/Customer.Domain/Customer.Domain.csproj ./Customer/Customer.Domain/
COPY Customer/Customer.Persistence.Database/Customer.Persistence.Database.csproj ./Customer/Customer.Persistence.Database/
COPY Customer/Customer.Service.EventHandlers/Customer.Service.EventHandlers.csproj ./Customer/Customer.Service.EventHandlers/
COPY Customer/Customer.Service.Queries/Customer.Service.Queries.csproj ./Customer/Customer.Service.Queries/
COPY Customer/Customer.Api/Customer.Api.csproj ./Customer/Customer.Api/
RUN dotnet restore "Customer/Customer.Api/Customer.Api.csproj"

# copy everything else and build app
COPY Shared/Service.Shared.Utils/. ./Shared/Service.Shared.Utils/
COPY Customer/Customer.Domain/. ./Customer/Customer.Domain/
COPY Customer/Customer.Persistence.Database/. ./Customer/Customer.Persistence.Database/
COPY Customer/Customer.Service.EventHandlers/. ./Customer/Customer.Service.EventHandlers/
COPY Customer/Customer.Service.Queries/. ./Customer/Customer.Service.Queries/
COPY Customer/Customer.Api/. ./Customer/Customer.Api/
WORKDIR /src/Customer/Customer.Api
RUN dotnet publish "Customer.Api.csproj" -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]