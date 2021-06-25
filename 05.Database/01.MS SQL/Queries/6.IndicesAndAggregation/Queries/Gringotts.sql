--Exercises: Indices and Data Aggregation

--Gringotts
USE Gringotts;
GO

--01.Records’ Count
SELECT COUNT(*) [Count] FROM WizzardDeposits;
GO

--02.Longest Magic Wand
SELECT TOP(1)
	MagicWandSize LongestMagicWand
		FROM WizzardDeposits
		GROUP BY MagicWandSize
		ORDER BY MagicWandSize DESC;
GO

--03.Longest Magic Wand Per Deposit Groups
SELECT
	DepositGroup DepositGroup
	,MAX(MagicWandSize) LongestMagicWand
		FROM WizzardDeposits
		GROUP BY DepositGroup;
GO

--04.Smallest Deposit Group Per Magic Wand Size
SELECT TOP (2)
	DepositGroup
		FROM WizzardDeposits
		GROUP BY DepositGroup
		ORDER BY AVG(MagicWandSize) ASC;
GO

--5.Deposits Sum
SELECT
	DepositGroup
	,SUM(DepositAmount) TotalSum
		FROM WizzardDeposits
		GROUP BY DepositGroup;
GO

--06.Deposits Sum for Ollivander Family
SELECT
	DepositGroup
	,SUM(DepositAmount) TotalSum
		FROM WizzardDeposits
		WHERE MagicWandCreator LIKE 'Ollivander%'
		GROUP BY DepositGroup;
GO

--07.Deposits Filter
SELECT
	DepositGroup
	,SUM(DepositAmount) TotalSum
		FROM WizzardDeposits
		WHERE MagicWandCreator LIKE 'Ollivander%'
		GROUP BY DepositGroup
		HAVING SUM(DepositAmount) < 150000
		ORDER BY TotalSum DESC;
GO

--08.Deposit Charge
SELECT
	DepositGroup
	,MagicWandCreator
	,MIN(DepositCharge) MinDepositCharge
		FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandCreator;
GO

--09. Age Groups
SELECT
	CASE 
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]' 
	END AgeGroup
	,COUNT(Id) WizardCount
		FROM WizzardDeposits
		GROUP BY 
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]' 
		END;
GO


--10.First Letter
SELECT
	LEFT(FirstName, 1) FirstLetter
		FROM WizzardDeposits
		WHERE DepositGroup LIKE 'Troll%'
		GROUP BY LEFT(FirstName, 1)
		ORDER BY FirstLetter;
GO

--11.Average Interest
SELECT 
	DepositGroup
	,IsDepositExpired
	,AVG(DepositInterest) AverageInterest
		FROM WizzardDeposits
		WHERE DepositStartDate > '1985-01-01'
		GROUP BY DepositGroup, IsDepositExpired
		ORDER BY DepositGroup DESC, IsDepositExpired ASC;
GO

--12.Rich Wizard, Poor Wizard
SELECT
	SUM([Difference]) SumDifference
		FROM (SELECT
			wd1.DepositAmount - wd2.DepositAmount [Difference]
			FROM WizzardDeposits wd1
			JOIN WizzardDeposits wd2
			ON wd1.id + 1 = wd2.id) diff;
GO

--SELECT 
--		FirstName AS [Host Wizard],
--		DepositAmount AS [Host Wizard Deposit],
--		LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
--		LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit]
--			FROM WizzardDeposits;