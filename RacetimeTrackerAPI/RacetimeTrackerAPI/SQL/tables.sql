CREATE DATABASE DB_RaceTimes;

USE DB_RaceTimes;

CREATE TABLE [user]
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [name] VARCHAR(50) NOT NULL,
    passwordHash NVARCHAR(255) NOT NULL,
   
    CONSTRAINT UNQ_Name UNIQUE(name),
    
    CONSTRAINT CHK_NameLen CHECK (LEN(name) > 3)
)



CREATE TABLE [group]
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [name] VARCHAR(50) NOT NULL
    )

CREATE TABLE [usergroup]
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [name] VARCHAR(50) NOT NULL,
    [role] VARCHAR(30) NOT NULL
    )
CREATE TABLE trackvariant
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [name] VARCHAR(50) NOT NULL
    )
CREATE TABLE track
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [name] VARCHAR(50) NOT NULL,
    variantId int NOT NULL

	CONSTRAINT FK_TrackVariant FOREIGN KEY (variantId)
	REFERENCES trackvariant(id)
)


CREATE TABLE racetime
(
    id INT PRIMARY KEY IDENTITY(1,1),
    [date] DATETIME NOT NULL,
    userId INT NOT NULL,
    groupId INT NOT NULL,
    trackId INT NOT NULL,
    carClass CHAR NOT NULL,

	CONSTRAINT FK_UserId FOREIGN KEY (userId)
	REFERENCES [user](id),

	CONSTRAINT FK_GroupId FOREIGN KEY (groupId)
	REFERENCES [group](id),

	CONSTRAINT FK_TrackId FOREIGN KEY (trackId)
	REFERENCES [track](id)
)