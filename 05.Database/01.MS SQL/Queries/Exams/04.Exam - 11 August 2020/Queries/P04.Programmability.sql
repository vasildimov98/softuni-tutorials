--Section 4. Programmability 

--11. Customers with Countries

--Create a view named v_UserWithCountries which selects all customers with their countries.
--Required columns:
--•	CustomerName – first name plus last name, with space between them
--•	Age
--•	Gender
--•	CountryName

CREATE VIEW v_UserWithCountries
AS
	SELECT
		CONCAT(FirstName, ' ', LastName) CustomerName
		,Age
		,Gender
		,(SELECT [Name] FROM Countries c WHERE c.Id = cu.CountryId) CountryName
	FROM Customers cu;
GO

SELECT TOP 5 *
FROM v_UserWithCountries
ORDER BY Age
GO

--12.	Delete Products
--Create a trigger that deletes all of the relations of a product upon its deletion. 
CREATE TRIGGER tr_CascadeDelete 
ON Products INSTEAD OF DELETE
AS
BEGIN
	DECLARE @ProductId INT = (SELECT Id FROM deleted);

	DELETE FROM Feedbacks
	WHERE ProductId = @ProductId;

	DELETE ProductsIngredients
	WHERE ProductId = @ProductId;

	DELETE FROM Products
	WHERE Id = @ProductId;
END 
GO

DELETE FROM Products WHERE Id = 7