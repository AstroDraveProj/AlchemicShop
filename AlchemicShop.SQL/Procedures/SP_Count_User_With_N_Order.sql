/*Number of users with N order*/

CREATE PROCEDURE [dbo].[SP_Count_User_With_N_Order]
	@Number INT
	AS
		BEGIN
			SELECT COUNT([u].[Id])
				FROM
				[AlchemicShopDb].[dbo].[Users] [u]
					WHERE 
					[u].[Id] IN
					(SELECT [o].[UserId]
						FROM 
						[AlchemicShopDb].[dbo].[Orders] [o]
							GROUP BY [o].[UserId]
								HAVING COUNT([o].[UserId]) = @Number)
		END

--EXEC [dbo].[SP_Count_User_With_N_Order] 2