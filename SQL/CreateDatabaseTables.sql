USE CarsUltimatumdb;

CREATE TABLE Classes(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(30) NOT NULL,

	CONSTRAINT PK_Classes_ID PRIMARY KEY (ID),
	CONSTRAINT QU_Classes_Name UNIQUE (Name),
);

CREATE TABLE Companies(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	YearFoundation int NOT NULL,

	CONSTRAINT PK_Companies_ID PRIMARY KEY (ID),
	CONSTRAINT QU_Companies_Name UNIQUE (Name)
);

CREATE TABLE Cars(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Price money NOT NULL,
	YearCreate int NOT NULL,
	Count int NOT NULL,

	/*Engene Specifications*/
	FuelType nvarchar(20) NOT NULL DEFAULT('Unknown'),
	VolumeEngene int NOT NULL DEFAULT(0),
	CountHourseForce int NOT NULL DEFAULT(0),
	
	/*Weight and volume*/
	FullWeight int NOT NULL,
	FuelVolume int NOT NULL,

	/*Corpus*/
	Color nvarchar(20) NOT NULL,
	CountPlaces int NOT NULL,
	Transmission nvarchar(20) NOT NULL,

	/*Foreigns keys*/
	CompanyName nvarchar(50) NOT NULL,
	ClassName nvarchar(30) NOT NULL,

	/*Constraints*/
	CONSTRAINT PK_Cars_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Cars_To_Companies FOREIGN KEY (CompanyName) REFERENCES Companies(Name)
	ON DELETE CASCADE,
	CONSTRAINT FK_Cars_To_Classes FOREIGN KEY (ClassName) REFERENCES Classes(Name)
	ON DELETE CASCADE
);

CREATE TABLE Images(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(10) NOT NULL,
	Path nvarchar(50) NOT NULL,
	CarID int NOT NULL

	CONSTRAINT PK_Images_ID PRIMARY KEY(ID),
	CONSTRAINT QU_Images_Path UNIQUE (Path),
	CONSTRAINT FK_Images_To_Cars FOREIGN KEY (CarID) REFERENCES Cars(ID)
);

CREATE TABLE Customers(
	ID int IDENTITY(1,1) NOT NULL,
	Login nvarchar(30) NOT NULL,
	Password nvarchar(10) NOT NULL,
	Address nvarchar(30) NOT NULL,
	Email nvarchar(30) NOT NULL,
	Purse money NOT NULL,
	Role nvarchar(30) NOT NULL DEFAULT('Customer'),

	CONSTRAINT PK_Customers_ID PRIMARY KEY(ID),
	CONSTRAINT QU_Customers_Email UNIQUE (Email),
	CONSTRAINT QU_Customers_Login UNIQUE (Login)
);

CREATE TABLE Orders(
	ID int IDENTITY(1,1) NOT NULL,
	TotalPrice money DEFAULT(0),
	CustomerID int NOT NULL,

	CONSTRAINT PK_Orders_ID PRIMARY KEY(ID),
	CONSTRAINT FK_Orders_To_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(ID)
);

CREATE TABLE OrdersCars(
	ID int IDENTITY(1,1) NOT NULL,
	OrderID int NOT NULL,
	CarID int NOT NULL,

	CONSTRAINT PK_OrdersCars_ID PRIMARY KEY (ID),
	CONSTRAINT FK_OrderCars_To_Cars FOREIGN KEY (CarID) REFERENCES Cars(ID),
	CONSTRAINT FK_OrderCars_To_Orders FOREIGN KEY (OrderID) REFERENCES Orders(ID) 
	ON DELETE CASCADE
);