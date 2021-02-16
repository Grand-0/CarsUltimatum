USE CarsUltimatumdb;

INSERT INTO CarClasses(Name) VALUES 
	(N'Sedan'),
	(N'Hatchback'),
	(N'Universal'),
	(N'Liftback'),
	(N'Coupe'),
	(N'Convertible'),
	(N'Roadster'),
	(N'Targa'),
	(N'SUV'),
	(N'Crossover'),
	(N'Pickup'),
	(N'Van'),
	(N'Minivan'),
	(N'Minibus');

INSERT INTO Companies(Name, YearFoundation) VALUES
	(N'Ford', 1903),
	(N'Audi', 1932),
	(N'Mercedes', 1926),
	(N'Nissan', 1933),
	(N'Infiniti', 1989),
	(N'Chevrolet', 1911),
	(N'Fiat', 1899),
	(N'Volkswagen', 1937);

INSERT INTO Cars(Name, Price, YearCreate, Count, FuelType, VolumeEngene,
CountHourseForce, FullWeight, FuelVolume, Color, CountPlaces, Transmission,
CompanyName, CarClassName)
VALUES
	(N'Tiguan Status', 84803, 2015, 5, N'Petrol', 1984, 180, 2320, 60, 
	N'Red', 7, N'Automatic', N'Volkswagen', N'Crossover'),
	(N'Polo', 42751, 2017, 12, N'Petrol', 1598, 110, 1680, 55, N'Black',
	5, N'Automatic', N'Volkswagen', N'Liftback'),
	(N'Transit Kombi', 88940, 2013, 3, N'Diesel', 2198, 125, 6000, 150, N'Gray',
	20, N'Mechanical', N'Ford', N'Minibus');

	
INSERT INTO Images(Name, Path, CarID) VALUES
	(N'001', N'D:\Programming\Ñ#\Progects\CarsUltimatum\Images\Companies\Ford\Cars\Transit Kombi\001.png', 3),
	(N'001', N'D:\Programming\Ñ#\Progects\CarsUltimatum\Images\Companies\Volkswagen\Cars\Polo\001.png', 2),
	(N'001', N'D:\Programming\Ñ#\Progects\CarsUltimatum\Images\Companies\Volkswagen\Cars\Tiguan Status\001.png', 1);