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
