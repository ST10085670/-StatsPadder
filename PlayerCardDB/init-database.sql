USE master;
GO

-- Create the Conference database only if it does not already exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Player')
BEGIN
    CREATE DATABASE Player;
END
GO

-- Switch to the Player database
USE Player;
GO

-- Create User table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(10) NOT NULL
);
GO
-- Create Product table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    CardType VARCHAR (10) NOT NULL,
    CardName VARCHAR(100) NOT NULL,
    ImageUrl VARCHAR(100) NOT NULL,
    CardPrice decimal(10,2)
);
GO

-- Create Purchase table
CREATE TABLE Purchases (
    PurchaseID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    PurDate DATE NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PurchaseID) REFERENCES Purchases(PurchaseID)
);
GO

-- Insert data into User table
INSERT INTO Users (FirstName, LastName, Email, Password)
VALUES 
('John', 'Doe', 'john.doe@example.com','1234'),
('Jane', 'Smith', 'jane.smith@example.com','2345'),
('Aphiwe', 'Mhotwana', 'ap.mhot@example.com','2345'),
('Hlumelo', 'Ntwanambi', 'h.ntwana@example.com','2345'),
('Emily', 'Jones', 'emily.jones@example.com','3456');
GO

-- Insert data into Product table
INSERT INTO Products (CardType, CardName, ImageUrl,CardPrice)
VALUES 
('Gold', 'Bruno Fernandes', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fx.com%2Fgoal%2Fstatus%2F1440585414075576329&psig=AOvVaw0FhS9k61YEz6V4hQYFZKPi&ust=1744362345392000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCPCkqKGOzYwDFQAAAAAdAAAAABAJ', 150.45 ),
('Silver', 'Mykhailo Mudryk', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.givemesport.com%2Fbest-silver-cards-fifa-23-ultimate-team%2F&psig=AOvVaw0YnUoxv7je0IBOnIY3XwRH&ust=1744362550015000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOj3_YKPzYwDFQAAAAAdAAAAABAE', 56.23),
('Bronze', 'Nusa', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.givemesport.com%2Fbest-bronze-cards-fifa-23-ultimate-team%2F&psig=AOvVaw07HYuLvERS2yGtJksJucwN&ust=1744362603378000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCNjD0JyPzYwDFQAAAAAdAAAAABAE', 16.89),
('Gold', 'Kevin De Bruyne', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ea.com%2Fgames%2Fea-sports-fc%2Fratings%2Fplayer-ratings%2Fkevin-de-bruyne%2F192985&psig=AOvVaw1dtWDfbPw84HzQUFl2vP-l&ust=1744362750397000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIipzOSPzYwDFQAAAAAdAAAAABAK', 180.32),
('Silver', 'Onyeka', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.givemesport.com%2Fbest-silver-cards-fifa-23-ultimate-team%2F&psig=AOvVaw0YnUoxv7je0IBOnIY3XwRH&ust=1744362550015000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOj3_YKPzYwDFQAAAAAdAAAAABAK', 25.00);

GO
-- Insert data into Registrations table
INSERT INTO Purchases (UserID, ProductID, PurDate)
VALUES 
(1, 1, '2025-03-15'),
(2, 2, '2025-03-20'),
(3, 1, '2025-03-20'),
(4, 4, '2025-03-20'),
(3, 2, '2025-03-25');
GO 