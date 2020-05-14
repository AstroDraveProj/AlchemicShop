/*Number of users with at least 1 order*/

CREATE PROCEDURE [dbo].[SP_Count_User_With_Order]
	AS
		BEGIN
			SELECT COUNT([u].[Id])
				FROM
				[AlchemicShopDb].[dbo].[Users] [u]
					WHERE
					[u].[Id] IN 
					(SELECT DISTINCT [o].[UserId]
						FROM
						[AlchemicShopDb].[dbo].[Orders] [o])					
		END

--EXEC [dbo].[SP_Count_User_With_Order] 