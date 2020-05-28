CREATE PROCEDURE [dbo].[SP_UPDATE_STATUS](
	@idOrder INT
	)
	AS
		BEGIN
		DECLARE @Result VARCHAR(50)
			IF @idOrder = null
				BEGIN
				SET @Result = 'wrong parameter'
			END
			ELSE
				BEGIN
				IF EXISTS
					(SELECT * 
						FROM [AlchemicShopDb].[dbo].[Orders] [o]
							WHERE 
							[o].[Id]=@IdOrder
							AND [o].[ClosedDate] IS NULL
							AND CAST(GETDATE() - 7 AS DATE) = CAST([o].[SheduledDate] AS DATE)
							)
					BEGIN
						BEGIN TRANSACTION [OrderStatusDateUpd]
								BEGIN TRY 
									UPDATE [AlchemicShopDb].[dbo].[Orders]
										SET 
										[ClosedDate]=GETDATE(),
										[Status] = 1
											WHERE 
											[AlchemicShopDb].[dbo].[Orders].[Id] = @idOrder;
								SET @Result = 'success'
								COMMIT TRANSACTION [OrderStatusDateUpd]
								END TRY
							BEGIN CATCH
									IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION [OrderStatusDateUpd]
									SET @Result = 'fail'
							END CATCH
						END
						ELSE
						BEGIN
						SET @Result = 'fail'
						END
					END
		SELECT @Result
		END
GO

--DROP PROCEDURE IF EXISTS[dbo].[SP_UPDATE_STATUS] 

--EXEC[dbo].[SP_UPDATE_STATUS] @idOrder = 11
--4