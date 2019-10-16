USE [CypadSQM_Android4_4]
GO
/****** Object:  StoredProcedure [dbo].[usp_Staff_Filter]    Script Date: 10/16/2019 6:30:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_Staff_Filter]
	@Page int,
	@SearchText NVARCHAR(50)
AS
BEGIN
	WITH FilterBySearchText_CTE
	AS
	(
		SELECT		[EmployeeNumber], [Name], [DateEmploymentStarted]
		FROM		[dbo].[Staff]
		WHERE		[Name] LIKE @SearchText +'%' OR @SearchText IS NULL
	)
	SELECT		[EmployeeNumber], 
				[Name], 
				FORMAT([DateEmploymentStarted],'dd/MM/yy') AS [DateEmploymentStarted], 
				(SELECT COUNT(*) FROM FilterBySearchText_CTE) AS TotalRows
	FROM		FilterBySearchText_CTE
	ORDER BY	[EmployeeNumber]
				OFFSET (@Page - 1) * 5 ROWS
				FETCH NEXT 5 ROWS ONLY
END
