FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app


COPY src/BuildingBlocks/BuildingBlocks.Common ./BuildingBlocks/BuildingBlocks.Common
COPY src/BuildingBlocks/BuildingBlocks.CustomExceptions ./BuildingBlocks/BuildingBlocks.CustomExceptions
COPY src/BuildingBlocks/BuildingBlocks.EventBus ./BuildingBlocks/BuildingBlocks.EventBus
COPY src/BuildingBlocks/BuildingBlocks.EventBusServiceBus ./BuildingBlocks/BuildingBlocks.EventBusServiceBus
COPY src/BuildingBlocks/BuildingBlocks.WebCommon ./BuildingBlocks/BuildingBlocks.WebCommon


COPY src/TransactionService.Common ./TransactionService.Common
COPY src/TransactionService.Domain ./TransactionService.Domain
COPY src/TransactionService.Domain.Tests ./TransactionService.Domain.Tests
COPY src/TransactionService.DomainTests ./TransactionService.DomainTests
COPY src/TransactionService.Persistence ./TransactionService.Persistence
COPY src/TransactionService.Persistence.Contracts ./TransactionService.Persistence.Contracts
COPY src/TransactionService.Persistence.Database ./TransactionService.Persistence.Database
COPY src/TransactionService.Persistence.Tests ./TransactionService.Persistence.Tests

COPY src/TransactionService.WebAPI ./TransactionService.WebAPI


RUN dotnet restore TransactionService.WebAPI

RUN dotnet publish TransactionService.WebAPI -c Release -o out




# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
EXPOSE 443
EXPOSE 1433
EXPOSE 1431
EXPOSE 5454


ENTRYPOINT ["dotnet", "TransactionService.WebAPI.dll"]