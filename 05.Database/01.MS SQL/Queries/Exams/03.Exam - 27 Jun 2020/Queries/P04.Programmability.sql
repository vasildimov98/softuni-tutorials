--Section 4. Programmability

--11. Place Order

/*
	-Your task is to create a user defined procedure (usp_PlaceOrder) which
	-accepts job ID, part serial number and   quantity and creates an order with the specified parameters.
	-If an order already exists for the given job that and the order is not issued (order’s issue date is NULL), add the new product to it.
	-If the part is already listed in the order, add the quantity to the existing one.
	-When a new order is created, set it’s IssueDate to NULL.
	Limitations:
	•	An order cannot be placed for a job that is Finished; error message ID 50011 "This job is not active!"
	•	The quantity cannot be zero or negative; error message ID 50012 "Part quantity must be more than zero!"
	•	The job with given ID must exist in the database; error message ID 50013 "Job not found!"
	•	The part with given serial number must exist in the database ID 50014 "Part not found!"
	If any of the requirements aren’t met, rollback any changes to the database you’ve made and throw an exception with the appropriate message and state	1. 
	Parameters:
	•	JobId
	•	Part Serial Number
	•	Quantity
*/

CREATE PROC usp_PlaceOrder @JobId INT, @PartSerialNumber VARCHAR(50), @Quantity INT
AS
BEGIN
	
	BEGIN TRANSACTION;
		
		IF (@Quantity <= 0)
		BEGIN
			ROLLBACK;
			THROW 50012, 'Part quantity must be more than zero!', 1;
		END

		IF NOT EXISTS(SELECT * FROM Jobs WHERE JobId = @JobId)
		BEGIN
			ROLLBACK;
			THROW 50013, 'Job not found!', 1
		END

		IF EXISTS(SELECT * FROM Jobs WHERE JobId = @JobId AND [Status] = 'Finished')
		BEGIN 
			ROLLBACK;
			THROW 50011, 'This job is not active!', 1;
		END

		IF NOT EXISTS(SELECT * FROM Parts WHERE SerialNumber = @PartSerialNumber)
		BEGIN
			ROLLBACK;
			THROW 50014, 'Part not found!', 1;
		END

		DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL);
		DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber);

		IF EXISTS(SELECT * FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)
		BEGIN
			IF EXISTS(SELECT * FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)
			BEGIN
				UPDATE OrderParts
					SET Quantity += @Quantity
				WHERE OrderId = @OrderId AND PartId = @PartId;
			END
			ELSE
			BEGIN
				INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
				(@OrderId, @PartId, @Quantity);
			END
		END
		ELSE
		BEGIN
			INSERT INTO Orders (JobId, Delivered) VALUES (@JobId, 0);

			SET @OrderId = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL);

			INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
			(@OrderId, @PartId, @Quantity);
		END

	COMMIT;

END
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 23213213, 'JobNotFound', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 2, 'JobNotActive', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 45, 'PartNotFound', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

GO

--12. Cost Of Order
--Create a user defined function (udf_GetCost) that receives a job’s ID and returns the total cost of all parts that were ordered for it. Return 0 if there are no orders.
--Parameters:
--•	JobId

CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL (18, 2)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Jobs WHERE JobId = @JobId)
		RETURN 0;

	RETURN
	(
		SELECT
			ISNULL(SUM(p.Price), 0)
		FROM Jobs j
		LEFT JOIN Orders o
			ON j.JobId = o.JobId
		LEFT JOIN OrderParts op
			ON o.OrderId = op.OrderId
		LEFT JOIN Parts p
			ON op.PartId = p.PartId
		WHERE j.JobId = @JobId
		GROUP BY j.JobId
	);
END
GO

SELECT dbo.udf_GetCost(31231)