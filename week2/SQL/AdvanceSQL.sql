create database DotNetFse;
use DotNetFse;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products VALUES
(1, 'iPhone 15', 'Electronics', 1200.00), (2, 'Samsung Galaxy', 'Electronics', 1150.00), (3, 'MacBook Pro', 'Electronics', 2500.00),
(4, 'HP Laptop', 'Electronics', 1200.00), (5, 'Dell Monitor', 'Electronics', 400.00), (6, 'Running Shoes', 'Footwear', 120.00),
(7, 'Formal Shoes', 'Footwear', 150.00), (8, 'Sneakers', 'Footwear', 120.00), (9, 'Heels', 'Footwear', 170.00),
(10, 'Sandals', 'Footwear', 80.00), (11, 'Luxury Sofa', 'Home Furniture', 1200.00), (12, 'Dining Table Set', 'Home Furniture', 900.00);

SELECT * FROM Products;

--Using ROW_NUMBER() 

SELECT Category, ProductName, Price, ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum FROM Products;

--Using RANK()

SELECT Category, ProductName, Price, RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum FROM Products;

--Using DENSE_RANK()

SELECT Category, ProductName, Price, DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRank FROM Products;

--Using ROW_NUMBER() to get the top 3 unique most expensive products per category

WITH RankedProducts AS ( SELECT *, ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum FROM Products) 
SELECT * FROM RankedProducts WHERE RowNum <= 3;

--Using RANK() to get the top 3 unique most expensive products per category

WITH RankedProducts AS ( SELECT *, RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum FROM Products) 
SELECT * FROM RankedProducts WHERE RowNum <= 3;

--Using DENSE_RANK() to get the top 3 unique most expensive products per category

WITH RankedProducts AS ( SELECT *, DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum FROM Products) 
SELECT * FROM RankedProducts WHERE RowNum <= 3;






drop table Products;