-- Creating DataBase --
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

-- CREATION OF REQUIRED TABLES --
CREATE TABLE Genre (
    GenreID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE Publisher (
    PublisherID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(20)
);

CREATE TABLE Book (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    ISBN NVARCHAR(20) UNIQUE NOT NULL,
    YearPublished INT,
    PublisherID INT,
    GenreID INT,
	CONSTRAINT fk_Book_Publisher
    FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID),
	CONSTRAINT fk_Book_Genre
    FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)
);

CREATE TABLE Author (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Bio TEXT
);

CREATE TABLE BookAuthor (
    BookID INT,
    AuthorID INT,
    PRIMARY KEY (BookID, AuthorID),
	CONSTRAINT fk_BookAuthor_Book
    FOREIGN KEY (BookID) REFERENCES Book(BookID),
	CONSTRAINT fk_BookAuthor_Author
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID)
);

CREATE TABLE Branch (
    BranchID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Location NVARCHAR(255)
);

CREATE TABLE Inventory (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT,
    BranchID INT,
    CopyNumber INT,
    AcquisitionDate DATE,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Available', 'Loaned')),
	CONSTRAINT fk_Inventory_Book
    FOREIGN KEY (BookID) REFERENCES Book(BookID),
	CONSTRAINT fk_Inventory_Branch
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID)
);

CREATE TABLE Member (
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    MembershipType NVARCHAR(30) NOT NULL CHECK (MembershipType IN ('Premium', 'Regular'))
);

CREATE TABLE Staff (
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    HireDate DATE,
    Role NVARCHAR(50)
);

CREATE TABLE Loan (
    LoanID INT IDENTITY(1,1) PRIMARY KEY,
    InventoryID INT,
    MemberID INT,
    StaffID INT,
    LoanDate DATE,
    DueDate DATE,
    ReturnDate DATE,
	CONSTRAINT fk_Loan_Inventory
    FOREIGN KEY (InventoryID) REFERENCES Inventory(InventoryID),
	CONSTRAINT fk_Loan_Member
    FOREIGN KEY (MemberID) REFERENCES Member(PersonID),
	CONSTRAINT fk_Loan_Staff
    FOREIGN KEY (StaffID) REFERENCES Staff(PersonID)
);

CREATE TABLE Fine (
    FineID INT IDENTITY(1,1) PRIMARY KEY,
    LoanID INT UNIQUE,
    Amount DECIMAL(8,2),
    PaidDate DATE,
	CONSTRAINT fk_Fine_Loan
    FOREIGN KEY (LoanID) REFERENCES Loan(LoanID)
);

CREATE TABLE Reservation (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    InventoryID INT UNIQUE,
    MemberID INT,
    ReservationDate DATE,
    ExpiryDate DATE,
	CONSTRAINT fk_Reservation_Inventory
    FOREIGN KEY (InventoryID) REFERENCES Inventory(InventoryID),
	CONSTRAINT fk_Reservation_Member
    FOREIGN KEY (MemberID) REFERENCES Member(PersonID)
);

CREATE TABLE Review (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT,
    MemberID INT,
    Rating DECIMAL(2,1) CHECK (Rating >= 1.0 AND Rating <= 5.0),
    Comment TEXT,
    ReviewDate DATE,
	CONSTRAINT fk_Review_Book
    FOREIGN KEY (BookID) REFERENCES Book(BookID),
	CONSTRAINT fk_Review_Member
    FOREIGN KEY (MemberID) REFERENCES Member(PersonID)
);


-- INSERTION OF SAMPLE DATA --
INSERT INTO Genre (Name, Description) VALUES 
	('Fiction', 'Fictional Stories'),
	('Science', 'Scientific Topics'),
	('Technology', 'Computing and Technical Topics'),
	('History', 'Historical Records'),
	('Biography', 'Biographical Works'),
	('Fantasy', 'Fantasy Fiction'),
	('Romance', 'Romantic Literature'),
	('Horror', 'Horror Fiction'),
	('Adventure', 'Action and Adventure'),
	('Mystery', 'Detective and Mystery Fiction');


INSERT INTO Publisher (Name, Address, Phone) VALUES 
    ('Pearson', '123 Pearson Lane', '123-456-7890'),
    ('O Reilly Media', '100 Tech Blvd', '987-654-3210'),
    ('Penguin Books', '45 Park Ave', '321-654-9870'),
    ('HarperCollins', '67 Harper Rd', '456-789-1234'),
    ('Random House', '89 House St', '654-321-7890'),
    ('Macmillan', '32 Macmillan Dr', '789-123-4567'),
    ('Oxford Press', '10 Oxford Ln', '147-258-3690'),
    ('Cambridge Press', '18 Cambridge Way', '258-369-1470'),
    ('Springer', '5 Science Park', '963-852-7410'),
    ('MIT Press', '1 Technology Sq', '741-852-9630');


INSERT INTO Book (Title, ISBN, YearPublished, PublisherID, GenreID) VALUES 
    ('Intro to SQL', '9781234567897', 2020, 1, 3),
    ('Learning Python', '9781449355739', 2019, 2, 3),
    ('Modern Physics', '9780199560917', 2021, 3, 2),
    ('Digital Fortress', '9780552159739', 2005, 4, 10),
    ('Biology Basics', '9780321123456', 2018, 5, 2),
    ('The Great Gatsby', '9780743273565', 1925, 6, 1),
    ('Clean Code', '9780132350884', 2008, 7, 3),
    ('The Hobbit', '9780345339683', 1937, 8, 6),
    ('Sherlock Holmes', '9780451524935', 1892, 9, 10),
    ('Romantic Tales', '9789999999999', 2015, 10, 7);


INSERT INTO Author (FirstName, LastName, Bio) VALUES
    ('John', 'Smith', 'Expert in databases...'),
    ('Mark', 'Lutz', 'Author of Python books...'),
    ('David', 'Griffiths', 'Physics researcher...'),
    ('Dan', 'Brown', 'Thriller novelist...'),
    ('Charles', 'Darwin', 'Naturalist and biologist...'),
    ('F. Scott', 'Fitzgerald', 'Fiction writer...'),
    ('Robert', 'Martin', 'Software engineer...'),
    ('J.R.R.', 'Tolkien', 'Fantasy author...'),
    ('Arthur', 'Conan Doyle', 'Detective fiction author...'),
    ('Jane', 'Austen', 'Romantic fiction author...');


INSERT INTO BookAuthor (BookID, AuthorID) VALUES 
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);


INSERT INTO Branch (Name, Location) VALUES 
    ('Central Library', 'Downtown'),
    ('West Branch', 'Westside Plaza'),
    ('East Branch', 'Eastside Mall'),
    ('North Branch', 'North Avenue'),
    ('South Branch', 'South Park'),
    ('Uptown Branch', 'Uptown Street'),
    ('City Center Branch', 'Main City Square'),
    ('Riverside Branch', 'Riverside Blvd'),
    ('Campus Branch', 'University Campus'),
    ('Airport Branch', 'Airport Road');


INSERT INTO Inventory (BookID, BranchID, CopyNumber, AcquisitionDate, Status) VALUES 
    (1, 1, 1, '2023-01-01', 'Available'),
    (2, 1, 1, '2023-01-10', 'Available'),
    (3, 2, 1, '2023-01-20', 'Loaned'),
    (4, 2, 1, '2023-02-01', 'Available'),
    (5, 3, 1, '2023-02-10', 'Loaned'),
    (6, 3, 1, '2023-02-15', 'Available'),
    (7, 4, 1, '2023-02-20', 'Available'),
    (8, 4, 1, '2023-03-01', 'Available'),
    (9, 5, 1, '2023-03-05', 'Loaned'),
    (10, 5, 1, '2023-03-10', 'Available');


INSERT INTO Member (FirstName, LastName, Email, Phone, MembershipType) VALUES 
    ('Alice', 'Johnson', 'alice@example.com', '111-222-3333', 'Regular'),
    ('Bob', 'Williams', 'bob@example.com', '222-333-4444', 'Premium'),
    ('Cathy', 'Smith', 'cathy@example.com', '333-444-5555', 'Regular'),
    ('Daniel', 'Lee', 'daniel@example.com', '444-555-6666', 'Premium'),
    ('Eve', 'Taylor', 'eve@example.com', '555-666-7777', 'Regular'),
    ('Frank', 'Martin', 'frank@example.com', '666-777-8888', 'Premium'),
    ('Grace', 'Young', 'grace@example.com', '777-888-9999', 'Regular'),
    ('Henry', 'Scott', 'henry@example.com', '888-999-0000', 'Premium'),
    ('Irene', 'King', 'irene@example.com', '999-000-1111', 'Regular'),
    ('Jack', 'White', 'jack@example.com', '000-111-2222', 'Premium');


INSERT INTO Staff (FirstName, LastName, Email, Phone, HireDate, Role) VALUES 
    ('Emma', 'Brown', 'emma@library.com', '333-444-5555', '2022-06-01', 'Librarian'),
    ('David', 'Clark', 'david@library.com', '444-555-6666', '2021-04-12', 'Assistant'),
    ('Fiona', 'Green', 'fiona@library.com', '555-666-7777', '2023-01-01', 'Manager'),
    ('George', 'Moore', 'george@library.com', '666-777-8888', '2022-07-01', 'Clerk'),
    ('Hannah', 'Price', 'hannah@library.com', '777-888-9999', '2022-08-01', 'Assistant'),
    ('Ian', 'Reed', 'ian@library.com', '888-999-0000', '2023-02-01', 'Security'),
    ('Julia', 'Hall', 'julia@library.com', '999-000-1111', '2023-03-01', 'Librarian'),
    ('Kevin', 'Turner', 'kevin@library.com', '000-111-2222', '2023-04-01', 'Assistant'),
    ('Laura', 'Wright', 'laura@library.com', '111-222-3333', '2023-05-01', 'Clerk'),
    ('Mike', 'Adams', 'mike@library.com', '222-333-4444', '2023-06-01', 'Librarian');


INSERT INTO Loan (InventoryID, MemberID, StaffID, LoanDate, DueDate, ReturnDate) VALUES
    (1, 1, 1, '2024-06-01', '2024-06-15', NULL),
    (2, 2, 2, '2024-05-10', '2024-05-24', '2024-05-23'),
    (3, 3, 3, '2024-05-11', '2024-05-25', '2024-05-26'),
    (4, 4, 4, '2024-06-02', '2024-06-16', NULL),
    (5, 5, 5, '2024-06-03', '2024-06-17', NULL),
    (6, 6, 6, '2024-06-04', '2024-06-18', NULL),
    (7, 7, 7, '2024-06-05', '2024-06-19', NULL),
    (8, 8, 8, '2024-06-06', '2024-06-20', NULL),
    (9, 9, 9, '2024-06-07', '2024-06-21', NULL),
    (10, 10, 10, '2024-06-08', '2024-06-22', NULL);


INSERT INTO Fine (LoanID, Amount, PaidDate) VALUES
    (2, 5.00, '2024-05-25'),
    (3, 3.50, '2024-05-27'),
    (4, 7.00, '2024-06-18'),
    (5, 2.50, NULL),
    (6, 1.00, NULL),
    (7, 4.25, NULL),
    (8, 6.00, NULL),
    (9, 3.75, NULL),
    (10, 2.00, NULL),
    (1, 8.00, '2024-06-10');


INSERT INTO Reservation (InventoryID, MemberID, ReservationDate, ExpiryDate) VALUES
    (1, 2, '2024-06-07', '2024-06-14'),
    (2, 1, '2024-06-05', '2024-06-12'),
    (3, 4, '2024-06-06', '2024-06-13'),
    (4, 5, '2024-06-07', '2024-06-14'),
    (5, 6, '2024-06-08', '2024-06-15'),
    (6, 7, '2024-06-09', '2024-06-16'),
    (7, 8, '2024-06-10', '2024-06-17'),
    (8, 9, '2024-06-11', '2024-06-18'),
    (9, 10, '2024-06-12', '2024-06-19'),
    (10, 3, '2024-06-13', '2024-06-20');


INSERT INTO Review (BookID, MemberID, Rating, Comment, ReviewDate) VALUES
    (1, 1, 4.5, 'Great book for beginners.', '2024-06-01'),
    (2, 2, 5.0, 'Excellent Python reference.', '2024-06-02'),
    (3, 3, 3.2, 'A bit complex, but good.', '2024-06-03'),
    (4, 4, 4.1, 'Exciting thriller!', '2024-06-04'),
    (5, 5, 4.3, 'Very informative.', '2024-06-05'),
    (6, 6, 5.0, 'A classic.', '2024-06-06'),
    (7, 7, 5.0, 'Very helpful for coders.', '2024-06-07'),
    (8, 8, 5.0, 'Beautifully written.', '2024-06-08'),
    (9, 9, 4.0, 'Classic detective tale.', '2024-06-09'),
    (10, 10, 3.9, 'Nice romantic stories.', '2024-06-10');
