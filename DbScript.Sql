-- Create Database
CREATE DATABASE EcommerceProductCatalog;
GO

USE EcommerceProductCatalog;
GO

-- Create Products Table
CREATE TABLE Products (
    Id INT IDENTITY (1, 1) PRIMARY KEY,
    Name NVARCHAR (200) NOT NULL,
    Description NVARCHAR (500),
    Price DECIMAL(18, 2) NOT NULL,
    Category INT NOT NULL,
    ImageUrl NVARCHAR (500),
    StockQuantity INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    LastUpdatedDate DATETIME2 NOT NULL,
    CreatedBy INT NOT NULL,
    UpdatedBy INT NOT NULL
);
GO

-- Insert Sample Data

INSERT INTO
    Products (
        Name,
        Description,
        Price,
        Category,
        ImageUrl,
        StockQuantity,
        CreatedDate,
        LastUpdatedDate,
        CreatedBy,
        UpdatedBy
    )
VALUES (
        'Dell XPS Laptop',
        'High performance laptop for developers',
        95000,
        1,
        'https://images.unsplash.com/photo-1496181133206-80ce9b88a853',
        10,
        GETDATE (),
        GETDATE (),
        1,
        1
    ),
    (
        'Samsung Refrigerator',
        'Energy efficient double door refrigerator',
        45000,
        1,
        'https://images.unsplash.com/photo-1586201375761-83865001e31c',
        5,
        GETDATE (),
        GETDATE (),
        1,
        1
    ),
    (
        'Women Red Dress',
        'Elegant red dress for special occasions',
        10000,
        2,
        'https://images.unsplash.com/photo-1529139574466-a303027c1d8b',
        20,
        GETDATE (),
        GETDATE (),
        1,
        1
    ),
    (
        'Men T-Shirt',
        'Comfortable cotton t-shirt',
        1200,
        2,
        'https://images.unsplash.com/photo-1521572163474-6864f9cf17ab',
        50,
        GETDATE (),
        GETDATE (),
        1,
        1
    ),
    (
        'Running Shoes',
        'Lightweight sports running shoes',
        3500,
        3,
        'https://images.unsplash.com/photo-1542291026-7eec264c27ff',
        25,
        GETDATE (),
        GETDATE (),
        1,
        1
    );
GO
