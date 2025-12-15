CREATE DATABASE AddressBookDB;
GO
USE AddressBookDB;
CREATE TABLE AddressBook (
    AddressBookId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) UNIQUE NOT NULL
);
CREATE TABLE Contacts (
    ContactId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Address NVARCHAR(200),
    City NVARCHAR(50),
    State NVARCHAR(50),
    Zip INT,
    Phone BIGINT,
    Email NVARCHAR(100),
    AddressBookId INT FOREIGN KEY REFERENCES AddressBook(AddressBookId)
);
