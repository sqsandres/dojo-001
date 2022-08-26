# Introduction 
Stock and Transactions microservices app.

# DataBases
**Server:** dv-east-sql-server.database.windows.net

**User:** superadmin

**Password:** $erver2022

**Databases:** 
 - dv-east-transaction-service-sql
 - dv-east-stock-service-sql
 - dv-east-identity-service-sql

**Connection strings:** 
 - transaction: Server=tcp:dv-east-sql-server.database.windows.net,1433;Initial Catalog=dv-east-transaction-service-sql;Persist Security Info=False;User ID=superadmin;Password=$erver2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
 - inventory: Server=tcp:dv-east-sql-server.database.windows.net,1433;Initial Catalog=dv-east-stock-service-sql;Persist Security Info=False;User ID=superadmin;Password=$erver2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
 - identity: Server=tcp:dv-east-sql-server.database.windows.net,1433;Initial Catalog=dv-east-identity-service-sql;Persist Security Info=False;User ID=superadmin;Password=$erver2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

# Getting Started
## Prerequisites
- Visual Studio
- SQL Server Data Base (2015 or more)
- SQL Management Studio
## Firts steps
- Clone this repo with the command:
```sh
git clone https://carlosandresnino@dev.azure.com/carlosandresnino/dojo_01/_git/dojo_01
```

## Sites
APP DEV:
https://dv-east-ui-app-win.azurewebsites.net/

https://dv-east-security-service-app-win.azurewebsites.net

https://dv-east-inventory-service-app-win.azurewebsites.net

https://dv-east-transaction-service-app-win.azurewebsites.net


## Styling Guide
[style guide](./STYLE-GUIDE.md).

## Unit Test Guide
[test guide](./TEST-GUIDE.md).