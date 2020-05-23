CREATE TRIGGER [Products.TR_Product_AFTER_UPDATE_Discount]
  ON [AlchemicShopDb].[dbo].[Products]
    FOR UPDATE
  AS
  UPDATE [AlchemicShopDb].[dbo].[Products]
    SET [Price]=[inserted].[Price] *0.8
      FROM [inserted]
        WHERE [AlchemicShopDb].[dbo].[Products].[Id]=[inserted].[Id]
GO