CREATE TABLE "User" (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(30) NOT NULL,
	weekly float NOT NULL CHECK (weekly BETWEEN 0 AND 112),
	username nvarchar(20) NOT NULL,
	email nvarchar(30) NOT NULL,
	password char(60),
	isActive bit NOT NULL,
	isAdmin bit NOT NULL,
	isDeleted bit NOT NULL DEFAULT 0
);

CREATE TABLE Country (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(40) NOT NULL,
	short nvarchar(3) NOT NULL,
	isActive bit NOT NULL DEFAULT 1,
);

CREATE TABLE Category (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(30) NOT NULL
);

CREATE TABLE Client (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(30) NOT NULL,
	address nvarchar(50) NOT NULL,
	city nvarchar(20) NOT NULL,
	zip nvarchar(15) NOT NULL,
	isDeleted bit NOT NULL DEFAULT 0,
	countryID int NOT NULL FOREIGN KEY REFERENCES Country(id)
);

CREATE TABLE Project (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(30) NOT NULL,
	description nvarchar(60),
	status varchar(10) NOT NULL CHECK (status IN('active', 'inactive', 'archived')) DEFAULT 'active',
	isDeleted bit NOT NULL DEFAULT 0,
	clientID int NOT NULL FOREIGN KEY REFERENCES Client(id),
	leadID int NOT NULL FOREIGN KEY REFERENCES "User"(id)
);

CREATE TABLE Worktime (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	description nvarchar(60),
	hours float NOT NULL CHECK (hours BETWEEN 0 AND 16),
	overtime float CHECK (overtime BETWEEN 0 AND 8),
	date date NOT NULL,
	clientID int NOT NULL FOREIGN KEY REFERENCES Client(id),
	projectID int NOT NULL FOREIGN KEY REFERENCES Project(id),
	userID int NOT NULL FOREIGN KEY REFERENCES "User"(id),
	categoryID int NOT NULL FOREIGN KEY REFERENCES Category(id)
);