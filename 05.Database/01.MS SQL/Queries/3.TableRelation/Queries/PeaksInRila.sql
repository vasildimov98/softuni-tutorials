--09. Peaks in Rila
USE [Geography];
GO

SELECT 
	m.MountainRange,
	p.PeakName,
	p.Elevation
		FROM Peaks AS p
		JOIN Mountains AS m ON p.MountainId = m.Id
		WHERE MountainRange = 'Rila'
		ORDER BY p.Elevation DESC;
GO