--Section 2. DML

--2. Insert
INSERT INTO Clients (FirstName,	LastName, Phone) VALUES
('Teri', 'Ennaco',	'570-889-5187'),
('Merlyn',	'Lawler',	'201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke',	'631-748-6479'),
('Melodie',	'Knipp', '805-690-1682'),
('Candida',	'Corbley',	'908-275-8357');
GO

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86,	2),
('W10780048', 'Suspension Rod', 42.81,	1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3);
GO

--3. Update
--Assign all Pending jobs to the mechanic Ryan Harnos (look up his ID manually, there is no need to use table joins)
--and change their status to 'In Progress'.
UPDATE Jobs
	SET MechanicId = (SELECT MechanicId FROM Mechanics WHERE FirstName = 'Ryan' AND LastName = 'Harnos'),
		[Status] = 'In Progress'
WHERE [Status] = 'Pending';
GO

SELECT
	*
FROM Jobs
WHERE [Status] = 'Pending';
GO

--4. Delete
--Cancel Order with ID 19 – delete the order from the database and all associated entries from the mapping table.
SELECT
	*
FROM Orders
WHERE OrderId = 19;

DELETE FROM OrderParts
WHERE OrderId = 19;

DELETE FROM Orders
WHERE OrderId = 19;