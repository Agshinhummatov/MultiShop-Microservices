# MultiShop Catalog Service

## Overview
The MultiShop Catalog Service is a microservice designed to manage product categories, product details, and product images within a multi-shop application. It provides CRUD operations to facilitate easy management of catalog items.

## Features
- **Category Management**: Create, read, update, and delete product categories.
- **Product Detail Management**: Manage product details with CRUD operations.
- **Product Image Management**: Handle product images with ease.

## Technologies
- **Framework**: .NET Core
- **Database**: MongoDB
- **ORM**: AutoMapper for object mapping

## API Endpoints
### Categories
- `POST /categories`: Create a new category
- `GET /categories`: Retrieve all categories
- `GET /categories/{id}`: Get a category by ID
- `PUT /categories/{id}`: Update an existing category
- `DELETE /categories/{id}`: Delete a category

- ### Products
- `POST /products`: Create a new product
- `GET /products`: Retrieve all products
- `GET /products/{id}`: Get a product by ID
- `PUT /products/{id}`: Update an existing product
- `DELETE /products/{id}`: Delete a product

### Product Details
- `POST /productdetails`: Create a new product detail
- `GET /productdetails`: Retrieve all product details
- `GET /productdetails/{id}`: Get a product detail by ID
- `PUT /productdetails/{id}`: Update an existing product detail
- `DELETE /productdetails/{id}`: Delete a product detail

### Product Images
- `POST /productimages`: Create a new product image
- `GET /productimages`: Retrieve all product images
- `GET /productimages/{id}`: Get a product image by ID
- `PUT /productimages/{id}`: Update an existing product image
- `DELETE /productimages/{id}`: Delete a product image
- 
![Catalog Service](https://i.imgur.com/JBbnYCt.png)
![Catalog Service](https://i.imgur.com/Gou03pv.png)


# MultiShop Discount Service

## Overview
The MultiShop Discount Service is a microservice designed to manage coupon codes for a multi-shop application. It provides CRUD operations to facilitate the management of discount coupons, allowing shops to offer promotions to their customers.

## Features
- **Coupon Management**: Create, read, update, and delete discount coupons.
- **Integration**: Utilizes Dapper for efficient database access with SQL Server.

## Technologies
- **Framework**: .NET Core
- **Database**: SQL Server
- **ORM**: Dapper for data access



## API Endpoints
- `POST /coupons`: Create a new coupon
- `GET /coupons`: Retrieve all coupons
- `GET /coupons/{id}`: Get a coupon by ID
- `PUT /coupons/{id}`: Update an existing coupon
- `DELETE /coupons/{id}`: Delete a coupon
- 
![Discount Service](https://i.imgur.com/7JuKTM7.png)


# **MultiShop Order Service**

## **Overview**
The **MultiShop Order Service** is a microservice within the MultiShop ecosystem designed to manage orders, order details, customer addresses, and order operations. It supports **CQRS** (Command and Query Responsibility Segregation) using **MediatR** and is protected by **JWT-based authentication**.

## **Architecture**

The **Order Service** follows the **Onion Architecture** pattern, which separates concerns into distinct layers:

- **Core**: Contains business logic and domain entities.
- **Infrastructure**: Handles data access and repository implementations.
- **Presentation**: The API layer, exposing endpoints to clients.

### **Core Layer**
- **MultiShop.Order.Application**: Application logic, services, commands, and queries.
- **MultiShop.Order.Domain**: Domain entities and repository interfaces.

### **Infrastructure Layer**
- **MultiShop.Order.Persistence**: Data access using **Entity Framework Core** for CRUD operations.

### **Presentation Layer**
- **MultiShop.Order.WebApi**: ASP.NET Core Web API, exposing endpoints for orders, order details, addresses, and operations.

## **Features**
- **Order Management**: CRUD operations for customer orders.
- **Order Detail Management**: Manage product, quantity, and price details for orders.
- **Address Management**: Manage delivery and billing addresses.
- **Order Operations**: Handle order processing, shipping, cancellation, etc.
- **CQRS Integration**: Separation of commands and queries using **MediatR**.
- **Secure Access**: JWT-based authentication for all API endpoints.

## **Technologies**
- **Framework**: .NET Core
- **Authentication**: JSON Web Tokens (JWT)
- **CQRS**: MediatR for Command and Query Responsibility Segregation
- **Database**: SQL Server (or other relational databases)
- **ORM**: Entity Framework Core

## **API Endpoints**

### **Orders**
- `GET /orders`: Retrieve all orders.
- `GET /orders/{id}`: Retrieve an order by ID.
- `POST /orders`: Create a new order.
- `PUT /orders`: Update an order.
- `DELETE /orders/{id}`: Remove an order by ID.

### **Order Details**
- `GET /orderdetails`: Retrieve all order details.
- `GET /orderdetails/{id}`: Retrieve an order detail by ID.
- `POST /orderdetails`: Create a new order detail.
- `PUT /orderdetails`: Update an order detail.
- `DELETE /orderdetails/{id}`: Remove an order detail by ID.

### **Addresses**
- `GET /addresses`: Retrieve all addresses.
- `GET /addresses/{id}`: Retrieve an address by ID.
- `POST /addresses`: Create a new address.
- `PUT /addresses`: Update an address.
- `DELETE /addresses/{id}`: Remove an address by ID.

### **Order Operations**
- `GET /orderoperations`: Retrieve all order operations.
- `GET /orderoperations/{id}`: Retrieve an order operation by ID.
- `POST /orderoperations`: Create a new order operation.
- `PUT /orderoperations`: Update an order operation.
- `DELETE /orderoperations/{id}`: Remove an order operation by ID.

## **Onion Architecture Explained**

The **Onion Architecture** ensures a clean separation of concerns:

1. **Core Layer**: Contains business logic and domain models, independent of external dependencies.
2. **Infrastructure Layer**: Implements data access and external integrations, like repositories and database contexts.
3. **Presentation Layer**: Handles API requests and responses.

### **Repository Pattern**

The **Repository Pattern** is used to manage data access. It isolates the business logic from the data layer and makes the application easier to maintain and test.


![Image 1](https://i.imgur.com/7WZqsH4.png)
![Image 2](https://i.imgur.com/AFW4mUW.png)

---





# MultiShop Cargo Service

## Overview  
The **MultiShop Cargo Service** is a microservice designed to manage cargo operations, cargo details, cargo companies, and cargo customers within the **MultiShop** ecosystem. This service offers a complete suite of features to create, read, update, and delete cargo-related entities and track the movement of shipments. It provides secure API endpoints that can only be accessed by authenticated users.

The **Cargo Service** follows a **Layered Architecture** (also known as **N-Tier Architecture**), ensuring a separation of concerns between the different parts of the application. This architecture includes:
- **Business Logic Layer**: Handles the core business logic.
- **Data Access Layer**: Responsible for interacting with the database.
- **Entity Layer**: Contains domain models/entities.
- **API Layer**: Provides API endpoints.

The architecture uses the **Repository Pattern** and **Service Layer Pattern** to ensure the codebase is clean, maintainable, and testable.

## Architecture

The **Cargo Service** follows the **Layered Architecture** pattern, where each layer is responsible for a specific concern in the application.

### Business Layer  
- **(MultiShop.Cargo.BusinessLayer)**: This layer contains the business logic and service interfaces for managing cargo entities such as cargo companies, cargo customers, cargo details, and cargo operations.  
- **Example**: `CargoCompanyManager` implements the `ICargoCompanyService` interface, which interacts with the data access layer to perform business operations on `CargoCompany` entities.

### Data Access Layer  
- **(MultiShop.Cargo.DataAccessLayer)**: Responsible for interacting with the database using repositories. This layer implements the **Repository Pattern** to abstract CRUD operations.  
- **Example**: `EfCargoCompanyDal` is a concrete repository implementation for handling CRUD operations on `CargoCompany` entities.

### Entity Layer  
- **(MultiShop.Cargo.EntityLayer)**: Contains the domain models/entities that represent cargo-related data. These entities are used throughout the business and data access layers.  
- **Example**: `CargoCompany`, `CargoCustomer`, `CargoDetail`, `CargoOperation`.

### API Layer  
- **(MultiShop.Cargo.WebApi)**: This layer exposes the endpoints for cargo operations to clients using ASP.NET Core Web API.  
- **Security**: All API endpoints are protected using **JWT-based authentication**, ensuring that only authenticated users can perform operations.

## Features  
- **Cargo Company Management**: Manage cargo companies with CRUD operations.  
- **Cargo Customer Management**: Create, update, and delete cargo customer information.  
- **Cargo Detail Management**: Handle cargo details such as sender, receiver, barcode, and cargo company.  
- **Cargo Operation Management**: Perform CRUD operations on cargo operations, including tracking barcodes, descriptions, and operation dates.  
- **Secure Access**: All API endpoints are protected using JWT-based authentication, ensuring only authorized users can perform operations.

## Technologies  
- **Framework**: .NET Core  
- **Authentication**: JSON Web Tokens (JWT) using IdentityServer for secure access.  
- **Database**: SQL Server or other relational databases.  
- **ORM**: Entity Framework Core for ORM and database operations.

## Design Patterns Used  
- **Layered Architecture (N-Tier Architecture)**: Ensures a separation of concerns and a clean structure for business logic, data access, and API layers.  
- **Repository Pattern**: Provides an abstraction layer between the business logic and data access logic, allowing the business layer to focus on operations without worrying about how data is retrieved or stored.  
- **Service Layer Pattern**: Encapsulates the business logic into services, making it easier to test and manage.  
- **Dependency Injection**: Facilitates loose coupling and improves testability by allowing dependencies to be injected into services and controllers.

## API Endpoints  

### Cargo Companies  
- `POST /cargoCompanies`: Create a new cargo company.  
- `GET /cargoCompanies`: Retrieve all cargo companies.  
- `GET /cargoCompanies/{id}`: Get a cargo company by ID.  
- `PUT /cargoCompanies`: Update an existing cargo company.  
- `DELETE /cargoCompanies/{id}`: Delete a cargo company.  

### Cargo Customers  
- `POST /cargoCustomers`: Create a new cargo customer.  
- `GET /cargoCustomers`: Retrieve all cargo customers.  
- `GET /cargoCustomers/{id}`: Get a cargo customer by ID.  
- `PUT /cargoCustomers`: Update an existing cargo customer.  
- `DELETE /cargoCustomers/{id}`: Delete a cargo customer.  

### Cargo Details  
- `POST /cargoDetails`: Create a new cargo detail.  
- `GET /cargoDetails`: Retrieve all cargo details.  
- `GET /cargoDetails/{id}`: Get a cargo detail by ID.  
- `PUT /cargoDetails`: Update an existing cargo detail.  
- `DELETE /cargoDetails/{id}`: Delete a cargo detail.  

### Cargo Operations  
- `POST /cargoOperations`: Create a new cargo operation.  
- `GET /cargoOperations`: Retrieve all cargo operations.  
- `GET /cargoOperations/{id}`: Get a cargo operation by ID.  
- `PUT /cargoOperations`: Update an existing cargo operation.  
- `DELETE /cargoOperations/{id}`: Delete a cargo operation.

## Images  

![Cargo Service Image 1](https://i.imgur.com/rUVLRKk.png)  
![Cargo Service Image 2](https://i.imgur.com/8Hsynuw.png)  
![Cargo Service Image 3](https://i.imgur.com/xYo3vsO.png)










# MultiShop IdentityServer

## Overview
**MultiShop IdentityServer** is a central authentication and authorization server that is responsible for managing user identities and providing secure access to various services in the MultiShop ecosystem. It uses **IdentityServer4** to implement the **OAuth 2.0** and **OpenID Connect** protocols. This allows secure authentication and token-based authorization between services and clients.

The server issues **JSON Web Tokens (JWTs)**, which are then used by other services, such as the Catalog, Discount,Order and Cargo services, to authorize and authenticate API requests. These tokens ensure that only authorized users and clients can access the respective resources.

## Features
- **OAuth 2.0 and OpenID Connect**: Provides industry-standard protocols for secure authentication and authorization.
- **Scoped Access**: Define fine-grained permissions (scopes) for services like Catalog, Discount, Cargo, etc.
- **Client Credentials Grant**: Used for client-to-client authentication, enabling backend services to communicate securely.
- **Centralized Identity Management**: Handles user identity and service access in a centralized manner, streamlining security across the system.

## Components
### API Resources
The API resources define the access levels for different services. These resources are protected and can only be accessed by clients with the necessary scopes.

### Identity Resources
Identity resources are used to retrieve user-specific data such as email, profile, and OpenID information. These resources are part of the authentication process.

### API Scopes
Scopes define the permissions that clients need to request access to specific APIs. For instance, scopes like "CatalogFullPermission" and "CargoFullPermission" are required to interact with those specific resources.

### Clients
Clients are the applications that request tokens from the IdentityServer to authenticate and authorize their users or services. Each client has predefined scopes and permissions based on their roles (e.g., Visitor, Manager, Admin).

## Authentication in Services
All services in the MultiShop ecosystem, such as the Catalog Service, Discount Service, and Cargo Service, are secured by **JWT tokens** issued by the IdentityServer. These tokens are included in the `Authorization` header of API requests, allowing the services to validate the token and determine the level of access a user or service has.

