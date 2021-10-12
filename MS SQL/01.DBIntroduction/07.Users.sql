CREATE TABLE Users
(
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARCHAR(MAX),
[LastLoginTime] DATETIME,
[IsDeleted] BIT
)

INSERT INTO Users ([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted]) VALUES
('Pesho','sasa123','https://www.pixsy.com/wp-content/uploads/2021/04/ben-sweet-2LowviVHZ-E-unsplash-1.jpeg','5-12-2021',0),
('Gosho','saassa123','https://www.pixsy.com/wp-content/uploads/2021/04/ben-sweet-2LowviVHZ-E-unsplash-1.jpeg','6-23-2021',0),
('Alq','sgagag','https://www.pixsy.com/wp-content/uploads/2021/04/ben-sweet-2LowviVHZ-E-unsplash-1.jpeg','10-21-2021',0),
('Dami','sasrwete3','https://www.pixsy.com/wp-content/uploads/2021/04/ben-sweet-2LowviVHZ-E-unsplash-1.jpeg','01-5-2021',0),
('Reni','234tsaw','https://www.pixsy.com/wp-content/uploads/2021/04/ben-sweet-2LowviVHZ-E-unsplash-1.jpeg','02-6-2021',0)

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id,Username);

ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN([Password]) >= 5);

ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime];






