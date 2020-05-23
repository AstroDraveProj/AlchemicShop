CREATE FUNCTION FUNCTION_ORDER_SUM()
    RETURNS TABLE
        AS
            RETURN
                (SELECT 
                [o].[Id],
                SUM([p].[Price]*[op].[Amount]) as ORDERSUM
                    FROM
                    [AlchemicShopDb].[dbo].[OrderProducts] [op],
                    [AlchemicShopDb].[dbo].[Orders] [o],
                    [AlchemicShopDb].[dbo].[Products] [p]
                        WHERE
                        [o].[Id]=[op].[OrderId]
                        and [p].[Id]=[op].[ProductId]
                            GROUP BY
                            [o].[Id]
                           )

--SELECT * FROM [dbo].[FUNCTION_ORDER_SUM]()