Create Database Product_DB

CREATE TABLE Product_Mst(
	ProductId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ProductName [nvarchar](50) NOT NULL,
	ProductDescription [nvarchar](100) NOT NULL,
	ProductPrice [nvarchar](50) NOT NULL,
	OpeningStock  [nvarchar](50) NOT NULL,
	BuyStock [nvarchar](50) NOT NULL,
	SellStock [nvarchar](50) NOT NULL,
	ClosingStock [nvarchar](50) NOT NULL,
);

select *from Product_Mst

ALTER TABLE Product_Mst
 ALTER COLUMN OpeningStock int NOT NULL;

 ALTER TABLE Product_Mst
 ALTER COLUMN BuyStock int NOT NULL;

  ALTER TABLE Product_Mst
 ALTER COLUMN SellStock int NOT NULL;

   ALTER TABLE Product_Mst
 ALTER COLUMN ClosingStock int NOT NULL;

 ALTER TABLE Product_Mst
 ALTER COLUMN ProductPrice float NOT NULL;

ALTER TABLE Product_Mst
 ALTER COLUMN OpeningStock float NOT NULL;

 ALTER TABLE Product_Mst
 ALTER COLUMN BuyStock float NOT NULL;

  ALTER TABLE Product_Mst
 ALTER COLUMN SellStock float NOT NULL;

   ALTER TABLE Product_Mst
 ALTER COLUMN ClosingStock float NOT NULL;
