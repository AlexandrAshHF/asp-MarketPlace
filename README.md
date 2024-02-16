 #  <center>MyMarketPlace</center>

MyMarketPlace is an educational project that simulates the operation of a marketplace where users can buy and sell products. The project was implemented using multi-layer architecture and SOLID principles. The project is monolithic, that is, it consists of one application, which includes both front-end and back-end parts. This project is my first (**more or less large**) project aimed at gaining experience and expanding knowledge.  
  
***The project is under development***

## Navigation
 - [Functionality](#functionality)
 - [Screenshots](#screenshots)
 - [How to run in Debug mode](#how-to-run-in-debug-mode)
 - [Technology stack](#technology-stack)
 - [Useful links](#useful-links)

## Functionality
- **General:**
     - Authorization/registration actions.
- **Buyer:**
     - Catalog browsing, searching and filtering.
     - Rating and commenting on products.
     - Subscription to the mailing list.
     - Adding and removing products from the cart.
     - Placing an order, saving pickup locations.
- **Seller:**
     - View, add, edit, remove products from the list.
     - Obtaining information about academic performance, obtaining an Excel report.
- **Admin:**
     - Obtaining information about users, products, reviews, etc.
     - Statistics of interest in the site.

## Screenshots

## How to run in Debug mode
To start the project you need:

- Install Visual Studio 2019 or higher
- Install SQL Server 2019 or higher
- Clone the project repository using the git clone command https://github.com/your_username/marketplace.git
- Open the MarketPlace.sln file in Visual Studio
- Restore NuGet packages using dotnet restore command
- Create a database using the dotnet ef database update command
- Run the project using the dotnet run command or press F5 in Visual Studio

## Technology stack
- **SDK:** `.NET 8`
- **Frameworks:** `ASP.NET Core`, `React`
- **Persistence:**
    - Database: `MS SQL Server 2022`
    - ORM: `Entity Framework Core`
- **Authorization:** `JWT Token`
- **Presentation:**
    - API Documentation: `OpenAPI (Swagger)`
    - Frontend Development: `React`
- **Unit Testing:** `XUnit`
- **Containerization:** `Docker`
- **Programming languages**: `C#`, `JavaScript`, `SQL`
- **Tools & IDE:**: `Visual Studio`, `VS Code`, `SMSS`, `Postman`

## Useful links
- Video: [link]()