CREATE TRIGGER [Products.TR_Product_AfterInsert_Discount]
	ON [AlchemicShopDb].[dbo].[Products]
	AFTER INSERT
	AS
	IF EXISTS (SELECT * 
				FROM [AlchemicShopDb].[dbo].[Products]
					WHERE
					[AlchemicShopDb].[dbo].[Products].[Amount]>100)
	BEGIN
	UPDATE [AlchemicShopDb].[dbo].[Products]
		SET [Price]=[inserted].[Price] *0.8
			FROM [inserted]
				WHERE [AlchemicShopDb].[dbo].[Products].[Id]=[inserted].[Id]
	END
GO