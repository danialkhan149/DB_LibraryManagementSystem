USE LibraryDB;
GO

		-- -----------------------
			-- CREATE QUERIES --
		-- -----------------------

	-- * Static CREATE Queries * --
-- 1. Add a New Member --
  INSERT INTO Member (FirstName, LastName, Email, Phone, MembershipType)
	VALUES ('Danial', 'Ahmed', '241881@students.au.edu.pk', '310-835-5327', 'Premium');

-- 2. Add a New Book --
  INSERT INTO Book (Title, ISBN, YearPublished, PublisherID, GenreID)
	VALUES ('Database Systems', '9780262037682', 2020, 1, 3);

-- 3. Add a New Loan Record --
  INSERT INTO Loan (InventoryID, MemberID, StaffID, LoanDate, DueDate, ReturnDate)
	VALUES (2, 1, 1, '2025-06-01', '2025-06-15', NULL);


	-- * Dynamic CREATE Queries (Stored Procedures) * --
-- 1. Add a New Member --
  CREATE PROCEDURE dbo.AddMember
      @FirstName NVARCHAR(50),
      @LastName NVARCHAR(50),
      @Email NVARCHAR(100),
      @Phone NVARCHAR(20),
      @MembershipType NVARCHAR(30)
  AS
  BEGIN
      INSERT INTO Member (FirstName, LastName, Email, Phone, MembershipType)
      VALUES (@FirstName, @LastName, @Email, @Phone, @MembershipType);
  END;
  GO

  -- To execute `dbo.AddMember` Procedure --
  EXEC dbo.AddMember @FirstName = 'Danial', @LastName = 'Ahmed', @Email = '241881@students.au.edu.pk', @Phone = '310-835-5327', @MembershipType = 'Premium';

-- 2. Add a New Book --
  CREATE PROCEDURE dbo.AddBook
	  @Title NVARCHAR(150),
	  @ISBN NVARCHAR(20),
      @YearPublished INT,
      @PublisherID INT,
      @GenreID INT
  AS
  BEGIN
	  INSERT INTO Book (Title, ISBN, YearPublished, PublisherID, GenreID)
	  VALUES (@Title, @ISBN, @YearPublished, @PublisherID, @GenreID)
  END;
  GO

  -- To execute `dbo.AddBook` Procedure --
  EXEC dbo.AddBook @Title = 'Database Systems', @ISBN = '9780262037682', @YearPublished = 2020, @PublisherID = 1, @GenreID = 3;

-- 3. Add a New Loan Record --
  CREATE PROCEDURE dbo.AddLoan
	  @InventoryID INT,
	  @MemberID INT,
      @StaffID INT,
      @LoanDate DATE,
      @DueDate DATE,
      @ReturnDate DATE
  AS
  BEGIN
	  INSERT INTO Loan (InventoryID, MemberID, StaffID, LoanDate, DueDate, ReturnDate)
	  VALUES (@InventoryID, @MemberID, @StaffID, @LoanDate, @DueDate, @ReturnDate)
  END;
  GO

  -- To execute `dbo.AddLoan` Procedure --
  EXEC dbo.AddLoan @InventoryID = 2, @MemberID = 1, @StaffID = 1, @LoanDate = '2025-06-01', @DueDate = '2025-06-15', @ReturnDate =  NULL;



		-- ---------------------
			-- READ QUERIES --
		-- ---------------------

-- 1. View all books with genre and publisher --
  SELECT b.BookID, b.Title, g.Name AS Genre, p.Name AS Publisher
  FROM Book b
  JOIN Genre g ON b.GenreID = g.GenreID
  JOIN Publisher p ON b.PublisherID = p.PublisherID;

-- 2. List all currently loaned books --
  SELECT l.LoanID, b.Title, m.FirstName + ' ' + m.LastName AS MemberName, l.LoanDate, l.DueDate
  FROM Loan l
  JOIN Inventory i ON l.InventoryID = i.InventoryID
  JOIN Book b ON i.BookID = b.BookID
  JOIN Member m ON l.MemberID = m.PersonID
  WHERE l.ReturnDate IS NULL;

-- 3. List reservations for a specific member --
  SELECT r.ReservationID, b.Title, r.ReservationDate, r.ExpiryDate
  FROM Reservation r
  JOIN Inventory i ON r.InventoryID = i.InventoryID
  JOIN Book b ON i.BookID = b.BookID
  WHERE r.MemberID = 2;


	-- * Encapsulated READ Queries (Stored Procedures) * --
-- 1. View all books with genre and publisher --
  CREATE PROCEDURE dbo.GetBooksWithGenreAndPublisher
  AS
  BEGIN
      SELECT 
          b.BookID, 
          b.Title, 
          g.Name AS Genre, 
          p.Name AS Publisher
      FROM Book b
      JOIN Genre g ON b.GenreID = g.GenreID
      JOIN Publisher p ON b.PublisherID = p.PublisherID;
  END;
  GO

  -- * To Execute `dbo.GetBooksWithGenreAndPublisher` Procedure --
  EXEC dbo.GetBooksWithGenreAndPublisher;

-- 2. List all currently loaned books --
  CREATE PROCEDURE dbo.GetActiveLoanedBooks
  AS
  BEGIN
      SELECT 
          l.LoanID, 
          b.Title, 
          m.FirstName + ' ' + m.LastName AS MemberName, 
          l.LoanDate, 
          l.DueDate
      FROM Loan l
      JOIN Inventory i ON l.InventoryID = i.InventoryID
      JOIN Book b ON i.BookID = b.BookID
      JOIN Member m ON l.MemberID = m.PersonID
      WHERE l.ReturnDate IS NULL;
  END;
  GO

  -- * To Execute `dbo.GetActiveLoanedBooks` Procedure --
  EXEC dbo.GetActiveLoanedBooks;

-- 3. Dynamic Query For showing Reservations for a Specific Member --
  CREATE PROCEDURE dbo.GetReservationsByMember
      @MemberID INT
  AS
  BEGIN
      SELECT 
          r.ReservationID, 
          b.Title, 
          r.ReservationDate, 
          r.ExpiryDate
      FROM Reservation r
      JOIN Inventory i ON r.InventoryID = i.InventoryID
      JOIN Book b ON i.BookID = b.BookID
      WHERE r.MemberID = @MemberID;
  END;
  GO

  -- * To Execute `dbo.GetReservationsByMember` Procedure (Change MemberID to the Member's Reservations you wanna see) --
  EXEC dbo.GetReservationsByMember @MemberID = 2;



		-- -----------------------
			-- UPDATE QUERIES --
		-- ----------------------- 

	-- * Static UPDATE Queries * --
-- 1. Update a member's phone number --
  UPDATE Member
  SET Phone = '999-888-7777'
  WHERE PersonID = 3;

-- 2. Mark a book as returned --
  UPDATE Loan
  SET ReturnDate = '2025-06-14'
  WHERE LoanID = 1;

-- 3. Change a book's status to 'Available' --
  UPDATE Inventory
  SET Status = 'Available'
  WHERE InventoryID = 3;


	-- * Dynamic UPDATE Queries (Stored Procedures) * --
-- 1. Update a member's phone number --
  CREATE PROCEDURE dbo.UpdateMemberPhone
	   @PersonID INT,
	   @Phone NVARCHAR(20)
  AS
  BEGIN
	  UPDATE Member
	  SET Phone = @Phone
	  WHERE PersonID = @PersonID
  END;
  GO

  -- To Execute `dbo.UpdateMemberPhone` Procdure (You can change values of PersonID and Phone according to your needs) --
  EXEC dbo.UpdateMemberPhone @PersonID = 3, @Phone = '999-888-7777';

 -- 2. Mark a book as returned --
 CREATE PROCEDURE dbo.MarkLoanAsReturned
      @LoanID INT,
      @ReturnDate DATE
  AS
  BEGIN
      UPDATE Loan
      SET ReturnDate = @ReturnDate
      WHERE LoanID = @LoanID;
  END;
  GO

  -- To Execute `dbo.MarkLoanAsReturned` Procdure (You can change values of LoanID and returnDate according to your needs) --
  EXEC dbo.MarkLoanAsReturned @LoanID = 1, @ReturnDate = '2025-06-14';

-- 2. Mark a book as returned --
  CREATE PROCEDURE dbo.UpdateInventoryStatus
      @InventoryID INT,
      @Status NVARCHAR(20)
  AS
  BEGIN
      UPDATE Inventory
      SET Status = @Status
      WHERE InventoryID = @InventoryID;
  END;
  GO

  -- To Execute `dbo.UpdateInventoryStatus` Procdure (You can change values of InventoryID and Status ('Available' or 'Loaned') according to your needs) --
  EXEC dbo.UpdateInventoryStatus @InventoryID = 3, @Status = 'Available';



		-- -----------------------
			-- DELETE QUERIES --
		-- -----------------------

	-- * Static DELETE Queries * --
-- 1. Delete a reservation --
  DELETE FROM Reservation
  WHERE ReservationID = 5;

-- 2. Remove a review by a member --
  DELETE FROM Review
  WHERE ReviewID = 2;

-- 3. Remove a book (All Related foreign key rows must be deleted First) --
  DELETE FROM BookAuthor WHERE BookID = 10;
  DELETE FROM Fine WHERE LoanID IN (SELECT LoanID FROM Loan WHERE InventoryID IN (SELECT InventoryID FROM Inventory where BookID = 10));
  DELETE FROM Loan WHERE LoanID IN (SELECT LoanID FROM Loan WHERE InventoryID IN (SELECT InventoryID FROM Inventory where BookID = 10));
  DELETE FROM Reservation WHERE InventoryID IN (SELECT InventoryID FROM Inventory where BookID = 10);
  DELETE FROM Inventory WHERE BookID = 10;
  DELETE FROM Review WHERE BookID = 10;
  DELETE FROM Book WHERE BookID = 10;


	-- * Dynamic DELETE Queries (Stored Procedures) * --
-- 1. Delete a reservation --
  CREATE PROCEDURE dbo.DeleteReservation
	  @ReservationID INT
  AS
  BEGIN
	  DELETE FROM Reservation
	  WHERE ReservationID = @ReservationID
  END;
  GO

  -- To Execute `dbo.DeleteReservation` (Change value of ReservationID according to your needs) --
  EXEC dbo.DeleteReservation @ReservationID = 5;

-- 2. Remove a review by a member --
  CREATE PROCEDURE dbo.DeleteReview
	  @ReviewID INT
  AS
  BEGIN
	  DELETE FROM Review
	  WHERE ReviewID = @ReviewID
  END;
  GO

  -- To Execute `dbo.DeleteReview` (Change value of ReviewID according to your needs) --
  EXEC dbo.DeleteReview @ReviewID = 5;

-- 3. Remove a book (All Related foreign key rows are deleted First) --
  CREATE PROCEDURE dbo.DeleteBookAndDependencies
      @BookID INT
  AS
  BEGIN
      SET NOCOUNT ON;
      BEGIN TRY
          BEGIN TRANSACTION;
        
          DELETE FROM BookAuthor 
          WHERE BookID = @BookID;

		  DELETE FROM Fine WHERE LoanID IN 
			  (SELECT LoanID FROM Loan WHERE InventoryID IN 
				  (SELECT InventoryID FROM Inventory where BookID = @BookID));

		  DELETE FROM Loan WHERE LoanID IN 
			  (SELECT LoanID FROM Loan WHERE InventoryID IN 
				  (SELECT InventoryID FROM Inventory where BookID = @BookID));

		  DELETE FROM Reservation WHERE InventoryID IN 
			  (SELECT InventoryID FROM Inventory where BookID = @BookID);
        
          DELETE FROM Inventory 
          WHERE BookID = @BookID;
        
          DELETE FROM Review 
          WHERE BookID = @BookID;
        
          DELETE FROM Book 
          WHERE BookID = @BookID;
          
          COMMIT TRANSACTION;
		  PRINT 'Book with ID: ' + CAST(@BookID AS NVARCHAR(10)) + ' and all dependencies have been successfully deleted.';

      END TRY

      BEGIN CATCH
          IF (@@TRANCOUNT > 0)
		  BEGIN
              ROLLBACK TRANSACTION;
			  THROW 50000, 'An error occurred during the operation. Please try again.', 1;
		  END
      END CATCH
  END; 
  GO

  -- To Execute `dbo.DeleteBookAndDependencies` (Change value of BookID according to your needs) --
  EXEC dbo.DeleteBookAndDependencies @BookID = 10;