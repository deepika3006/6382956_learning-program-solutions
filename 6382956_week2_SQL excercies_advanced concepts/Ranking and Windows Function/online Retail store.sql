use [advanced sql]
go
CREATE TABLE RetailProducts (
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Brand VARCHAR(50),
    Stock INT,
    Price DECIMAL(10, 2)
);
INSERT INTO RetailProducts (ProductID, ProductName, Category, Brand, Stock, Price) VALUES
(1, 'Gaming Laptop', 'Computers', 'XtremeGear', 12, 17000.00),
(2, 'Business Laptop', 'Computers', 'OfficeMax', 20, 14500.00),
(3, 'Convertible Laptop', 'Computers', 'FlexTech', 10, 14500.00),
(4, 'Mechanical Keyboard', 'Accessories', 'KeyStorm', 50, 1200.00),
(5, 'Wireless Mouse', 'Accessories', 'ClickPro', 70, 600.00),
(6, 'Ergonomic Chair', 'Furniture', 'ComfySit', 15, 3000.00),
(7, 'Standing Desk', 'Furniture', 'WorkFlow', 10, 4200.00),
(8, 'Bookshelf', 'Furniture', 'HomeLine', 25, 1800.00),
(9, 'Noise Cancelling Headset', 'Accessories', 'AudioZen', 30, 1200.00),
(10, 'Gaming Monitor', 'Computers', 'XtremeGear', 8, 15000.00),
(11, 'Desk Organizer', 'Accessories', 'Neatify', 60, 400.00),
(12, 'Laptop Backpack', 'Accessories', 'GearPack', 40, 1200.00);

SELECT 
    ProductID,
    ProductName,
    Category,
    Brand,
    Stock,
    Price,
    RANK() OVER (
        PARTITION BY Category 
        ORDER BY Price DESC
    ) AS RankPos
FROM RetailProducts;
SELECT 
    ProductID,
    ProductName,
    Category,
    Brand,
    Stock,
    Price,
    DENSE_RANK() OVER (
        PARTITION BY Category 
        ORDER BY Price DESC
    ) AS DenseRankPos
FROM RetailProducts;

WITH RankedProducts AS (
    SELECT 
        *,
        ROW_NUMBER() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS RowNum
    FROM RetailProducts
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Brand,
    Stock,
    Price
FROM RankedProducts
WHERE RowNum <= 3;