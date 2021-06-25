SELECT
	it.[Name] AS Item,
	it.Price,
	it.MinLevel,
	gt.[Name] AS [Forbidden Game Type]
FROM Items AS it
	LEFT JOIN GameTypeForbiddenItems AS gtfit ON gtfit.ItemId = it.Id
	LEFT JOIN GameTypes AS gt ON gt.Id = gtfit.GameTypeId
ORDER BY [Forbidden Game Type] DESC, Item ASC;