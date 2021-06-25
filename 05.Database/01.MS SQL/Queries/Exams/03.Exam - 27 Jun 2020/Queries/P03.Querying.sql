--Section 3. Querying 

--5.	Mechanic Assignments
--Select all mechanics with their jobs.
--Include job status and issue date.
--Order by mechanic Id, issue date, job Id (all ascending).

--Required columns:
--•	Mechanic Full Name
--•	Job Status
--•	Job Issue Date

SELECT
	CONCAT(m.FirstName, ' ', m.LastName) FullName
	,j.[Status]
	,j.IssueDate
FROM Mechanics m
LEFT JOIN Jobs j
	ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId ASC, j.IssueDate ASC, j.JobId ASC;
GO

--6. Current Clients
--Select the names of all clients with active jobs (not Finished).
--Include the status of the job and how many days it’s been since it was submitted.
--Assume the current date is 24 April 2017.
--Order results by time length (descending) and by client ID (ascending).

--Required columns:
--•	Client Full Name
--•	Days going – how many days have passed since the issuing
--•	Status

SELECT
	(SELECT CONCAT(cl.FirstName, ' ', cl.LastName) FROM Clients cl WHERE cl.ClientId = j.ClientId) Client
	,DATEDIFF(DAY, IssueDate, '2017-04-24') [Days going]
	,[Status]
FROM Jobs j
WHERE [Status] != 'Finished'
ORDER BY [Days going] DESC, ClientId ASC; 
GO

--7. Mechanic Performance
--Select all mechanics and the average time they take to finish their assigned jobs.
--Calculate the average as an integer.
--Order results by mechanic ID (ascending).
--Required columns:
--•	Mechanic Full Name
--•	Average Days – average number of days the machanic took to finish the job

SELECT 
	(SELECT CONCAT(m2.FirstName, ' ', m2.LastName) FROM Mechanics m2 WHERE m2.MechanicId = m1.MechanicId) Mechanic
	,AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) [Average Days]
FROM Mechanics m1
LEFT JOIN Jobs j
	ON m1.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished'
GROUP BY m1.MechanicId
ORDER BY m1.MechanicId;
GO

--8. Available Mechanics
--Select all mechanics without active jobs
--(include mechanics which don’t have any job assigned or all of their jobs are finished).
--Order by ID (ascending).

--Required columns:
--•	Mechanic Full Name
SELECT 
	CONCAT(mc.FirstName, ' ', mc.LastName) Available
FROM Mechanics mc
WHERE (SELECT COUNT(*) FROM Jobs j WHERE j.MechanicId = mc.MechanicId)
	= (SELECT COUNT(*) FROM Jobs j WHERE j.MechanicId = mc.MechanicId AND j.Status = 'Finished')
	OR (SELECT COUNT(*) FROM Jobs j WHERE j.MechanicId = mc.MechanicId) = 0;

--9. Past Expenses
--Select all finished jobs and the total cost of all parts that were ordered for them.
--Sort by total cost of parts ordered (descending) and by job ID (ascending).
--Required columns:
--•	Job ID
--•	Total Parts Cost

SELECT
	j.JobId
	,ISNULL(SUM(p.Price * op.Quantity), 0) Total
FROM Jobs j
LEFT JOIN Orders o
	ON j.JobId = o.JobId
LEFT JOIN OrderParts op
	ON o.OrderId = op.OrderId
LEFT JOIN Parts p
	ON op.PartId = p.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC;
GO

--10. Missing Parts
--List all parts that are needed for active jobs (not Finished)
--without sufficient quantity in stock
--and in pending orders
--(the sum of parts in stock and parts ordered is less than the required quantity).
--Order them by part ID (ascending).

--Required columns:
--•	Part ID
--•	Description
--•	Required – number of parts required for active jobs
--•	In Stock – how many of the part are currently in stock
--•	Ordered – how many of the parts are expected to be delivered (associated with order that is not Delivered)

SELECT
	p.PartId
	,p.[Description]
	,pn.Quantity [Required]
	,p.StockQty [In Stock]
	,IIF(o.Delivered IS NULL, 0, op.Quantity) Ordered
FROM Parts p
LEFT JOIN PartsNeeded pn
	ON p.PartId = pn.PartId	
LEFT JOIN Jobs j
	ON pn.JobId = j.JobId
LEFT JOIN Orders o
	ON j.JobId = o.JobId
LEFT JOIN OrderParts op
	ON op.PartId = p.PartId
WHERE j.FinishDate IS NULL
	AND (p.StockQty + IIF(o.Delivered IS NULL, 0, op.Quantity)) < pn.Quantity
ORDER BY p.PartId ASC;
GO