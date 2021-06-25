--3. There are two groups of items that you must buy for the above users.
--The first are items with id between 251 and 299 including.
--Second group are items with id between 501 and 539 including.
--Take off cash from each user for the bought items.

DECLARE @firstItemId INT = 251;

WHILE (@firstItemId <= 299)
BEGIN
	EXEC usp_BuyItem 26, @firstItemId, 212;
	EXEC usp_BuyItem 115, @firstItemId, 212;
	EXEC usp_BuyItem 146, @firstItemId, 212;
	EXEC usp_BuyItem 177, @firstItemId, 212;
	EXEC usp_BuyItem 296, @firstItemId, 212; 

	SET @firstItemId += 1;
END;

DECLARE @secondItemId INT = 501;

WHILE (@secondItemId <= 539)
BEGIN
	EXEC usp_BuyItem 26, @secondItemId, 212;
	EXEC usp_BuyItem 115, @secondItemId, 212;
	EXEC usp_BuyItem 146, @secondItemId, 212;
	EXEC usp_BuyItem 177, @secondItemId, 212;
	EXEC usp_BuyItem 296, @secondItemId, 212; 
	 
	SET @secondItemId += 1;
END;