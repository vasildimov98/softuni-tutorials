--Section 3. Querying

--5. Products by Price
--Select all products ordered by price (descending) then by name (ascending). 

--Required columns:
--•	Name
--•	Price
--•	Description

SELECT
	[Name]
	,Price
	,[Description]
FROM Products
ORDER BY Price DESC, [Name] ASC;
GO

--6. Negative Feedback
--Select all feedbacks alongside with the customers which gave them.
--Filter only feedbacks which have rate below 5.0.
--Order results by ProductId (descending) then by Rate (ascending).

--Required columns:
--•	ProductId
--•	Rate
--•	Description
--•	CustomerId
--•	Age
--•	Gender

SELECT
	fb.ProductId
	,fb.Rate
	,fb.[Description]
	,ct.Id
	,ct.Age
	,ct.Gender
FROM Feedbacks fb
JOIN Customers ct
	ON fb.CustomerId = ct.Id
WHERE Rate < 5.0
ORDER BY fb.ProductId DESC, fb.Rate ASC;
GO

--7. Customers without Feedback
--Select all customers without feedbacks. Order them by customer id (ascending).
--Required columns:
--•	CustomerName – customer’s first and last name, concatenated with space
--•	PhoneNumber
--•	Gender
--Example:

SELECT 
	CONCAT(FirstName, ' ', LastName) CustomerName
	,PhoneNumber
	,Gender
FROM Customers cu
WHERE NOT EXISTS(SELECT * FROM Feedbacks fb WHERE fb.CustomerId = cu.Id)
ORDER BY Id ASC;
GO

--8. Customers by Criteria
--Select customers that are either
--at least 21 old and contain “an” in their first name
--or their phone number ends with “38” and are not from Greece.
--Order by first name (ascending), then by age(descending).
--Required columns:
--•	FirstName
--•	Age
--•	PhoneNumber

SELECT
	FirstName
	,Age
	,PhoneNumber
FROM Customers
WHERE (Age >= 21 AND CHARINDEX('an', FirstName) > 0)
	OR (CHARINDEX('38', PhoneNumber) = 9 AND CountryId != (SELECT Id FROM Countries WHERE [Name] = 'Greece'))
ORDER BY FirstName ASC, Age DESC;
GO

--9. Middle Range Distributors
--Select all distributors which distribute ingredients used in the making process of all products having average rate between 5 and 8 (inclusive). Order by distributor name, ingredient name and product name all ascending.
--Required columns:
--•	DistributorName
--•	IngredientName
--•	ProductName
--•	AverageRate

SELECT
	d.[Name] DistributorName
	,i.[Name] IngredientName
	,pr.[Name] ProductName
	,AVG(fb.Rate) AverageRate
FROM Distributors d
JOIN Ingredients i
	ON d.Id = i.DistributorId
JOIN ProductsIngredients pri
	ON i.Id = pri.IngredientId
JOIN Products pr
	ON pri.ProductId = pr.Id
JOIN Feedbacks fb
	ON pr.Id = fb.ProductId
GROUP BY d.[Name], i.[Name], pr.[Name]
HAVING AVG(fb.Rate) BETWEEN 5 AND 8
ORDER BY DistributorName ASC, IngredientName ASC, ProductName ASC;
GO

--10. Country Representative
--Select all countries with their most active distributor (the one with the greatest number of ingredients).
--If there are several distributors with most ingredients delivered, list them all.
--Order by country name then by distributor name.

--Required columns:
--•	CountryName
--•	DistributorName
SELECT
	CountryName
	,DistributorName
FROM
(
	SELECT
		c.[Name] CountryName
		,d.[Name] DistributorName
		,DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) DistibutorRank
	FROM Countries c
	JOIN Distributors d
		ON c.Id = d.CountryId
	LEFT JOIN Ingredients i
		ON d.Id = i.DistributorId
	GROUP BY c.[Name], d.[Name]
) i
WHERE DistibutorRank = 1
ORDER BY CountryName ASC, DistributorName ASC;
GO