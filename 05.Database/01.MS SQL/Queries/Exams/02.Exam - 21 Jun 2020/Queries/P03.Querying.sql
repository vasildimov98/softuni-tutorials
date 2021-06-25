--Section 3. Querying (40 pts)

--5. EEE-Mails
--Select accounts whose emails start with the letter “e”. Select their first and last name, their birthdate in the format "MM-dd-yyyy", their city name, and their Email.
--Order them by city name (ascending)


SELECT 
	FirstName
	,LastName
	,FORMAT(BirthDate, 'MM-dd-yyyy') BirthDate
	,(SELECT [Name] FROM Cities c WHERE c.id = a.CityId) Hometown
	,Email
FROM Accounts a
WHERE Email LIKE 'e%'
ORDER BY Hometown;
GO

--6. City Statistics
--Select all cities with the count of hotels in them. Order them by the hotel count (descending), then by city name. Do not include cities, which have no hotels in them.
SELECT 
	[Name] City
	,(SELECT COUNT(*) FROM Hotels WHERE c.Id = CityId) Hotels
FROM Cities c
WHERE (SELECT COUNT(*) FROM Hotels WHERE c.Id = CityId) != 0
ORDER BY Hotels DESC, City ASC;
GO

--7. Longest and Shortest Trips
/*
	Find the longest and shortest trip for each account, in days.
	Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null).
	Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).
*/

SELECT 
	atr.AccountId
	,(SELECT CONCAT(ac1.FirstName, ' ', ac1.LastName) FROM Accounts ac1 WHERE ac1.Id = atr.AccountId) FullName
	,MAX(DATEDIFF(DAY, tr.ArrivalDate, tr.ReturnDate)) LongestTrip
	,MIN(DATEDIFF(DAY, tr.ArrivalDate, tr.ReturnDate)) ShortestTrip
FROM AccountsTrips atr
JOIN Accounts ac
	ON atr.AccountId = ac.Id
JOIN Trips tr
	ON atr.TripId = tr.Id
WHERE ac.MiddleName IS NULL AND tr.CancelDate IS NULL
GROUP BY atr.AccountId
ORDER BY LongestTrip DESC, ShortestTrip ASC;
GO

--8. Metropolis
--Find the top 10 cities, which have the most registered accounts in them. Order them by the count of accounts (descending).
SELECT TOP (10)
	c.Id
	,c.[Name] City
	,c.CountryCode Country
	,COUNT(ac.Id) Accounts
FROM Cities c
JOIN Accounts ac
	ON c.Id = ac.CityId
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC;
GO

--76
--Tyumen
--RU
--5

--12
--Haskovo
--BG
--4

--33
--Belfast
--UK
--4

--38
--Wolverhampton
--UK
--4

--39
--New York
--US
--4

--46
--San Diego
--US
--3

--14
--Pazardzhik
--BG
--3

--16
--Veliko Tarnovo
--BG
--3

--1
--Sofia
--BG
--3

--36
--Derby
--UK
--3

--9. Romantic Getaways
--Find all accounts, which have had one or more trips to a hotel in their hometown.
--Order them by the trips count (descending), then by Account ID.

SELECT
	ac.Id
	,ac.Email
	,(SELECT [Name] FROM Cities c WHERE ac.CityId = c.Id) City
	,COUNT(tr.Id) Trips
FROM AccountsTrips actr
JOIN Accounts ac
	ON actr.AccountId = ac.Id
JOIN Trips tr
	ON actr.TripId = tr.Id
JOIN Rooms r
	ON tr.RoomId = r.Id
JOIN Hotels h
	ON r.HotelId = h.Id
WHERE h.CityId = ac.CityId
GROUP BY ac.Id, ac.Email, ac.CityId
ORDER BY Trips DESC, Id ASC;
GO

--Retrieve the following information about each trip:
--•	Trip ID
--•	Account Full Name
--•	From – Account hometown
--•	To – Hotel city
--•	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
--Order the results by full name, then by Trip ID.

SELECT
	actr.TripId Id
	,CONCAT(ac.FirstName, ' ', ISNULL(ac.MiddleName + ' ', ''), ac.LastName) FullName
	,(SELECT [Name] FROM Cities c WHERE c.Id = ac.CityId) [From]
	,(SELECT [Name] FROM Cities c WHERE c.Id = h.CityId) [To]
	,CASE 
		WHEN tr.CancelDate IS NULL THEN CONVERT(VARCHAR, DATEDIFF(DAY, tr.ArrivalDate, tr.ReturnDate)) + ' days'
		ELSE 'Canceled'
	END Duration
FROM AccountsTrips actr
JOIN Accounts ac
	ON actr.AccountId = ac.Id
JOIN Trips tr
	ON actr.TripId = tr.Id
JOIN Rooms r
	ON tr.RoomId = r.Id
JOIN Hotels h
	ON r.HotelId = h.Id
ORDER BY FullName ASC, tr.Id ASC;
GO