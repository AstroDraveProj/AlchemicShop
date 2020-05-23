CREATE TRIGGER [Products.TR_Product_AFTER_INSERT_Discount]
  ON [AlchemicShopDb].[dbo].[Products]
  AFTER INSERT
  AS
  IF EXISTS (SELECT * 
        FROM [AlchemicShopDb].[dbo].[Products]
          WHERE
          [AlchemicShopDb].[dbo].[Products].[Amount]>100
          and [AlchemicShopDb].[dbo].[Products].[Id]=(SELECT [id] FROM [inserted]))
  BEGIN
  UPDATE [AlchemicShopDb].[dbo].[Products]
    SET [Price]=[inserted].[Price] *0.8
      FROM [inserted]
        WHERE [AlchemicShopDb].[dbo].[Products].[Id]=[inserted].[Id]
  END
GO