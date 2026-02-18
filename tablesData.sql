USE [Project0583255125]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'חופשות')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'מוצרים')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'אוכל')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1002, N'קורסים')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1003, N'עוד')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Donor] ON 
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1, N'gili', N'gili@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (2, N'malki', N'malki@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1002, N'yael', N'yael@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1003, N'esty', N'esty@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1004, N'rivka', N'rivka@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1005, N'noa', N'noa@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1006, N'efrat', N'efrat@gmail.com')
GO
INSERT [dbo].[Donor] ([Id], [Name], [EMail]) VALUES (1007, N'michal', N'michal@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Donor] OFF
GO
SET IDENTITY_INSERT [dbo].[Gift] ON 
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1018, N'vvccccfgg', N'wwww', 56, N'images/fish.JPG', 2, 2, N' ', NULL, 2)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1020, N'גכבענמי', N'עימה', 70, N'', 1, 1, N' ', NULL, 1)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1021, N'מארז מוצרי ספא', N'מארז מפנק הכולל קרמים, נרות ריחניים ומוצרי טיפוח איכותיים.', 40, N'images/81wYM37+cbL.jpg', 1003, 1007, N' ', NULL, 1007)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1022, N'סט כלי בית איכותיים', N'סט סירים או כלי מטבח איכותיים לשדרוג חוויית הבישול', 40, N'images/71BZfmB5yQL.jpg', 2, 1005, N' ', NULL, 1005)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1023, N'קורס מחשבים והייטק', N'לימוד יישומי מחשב, כלים דיגיטליים או יסודות תכנות – לשדרוג מקצועי משמעותי', 60, N'images/c52e5cf1-a6dd-4b80-9b44-eb56212189d9-cover.png', 1002, 2, N' ', NULL, 2)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1024, N'חצובה מקצועית', N'חצובה יציבה לצילום תמונות וסרטונים בצורה מדויקת.', 30, N'images/depositphotos_332406396-stock-photo-camera-tripod-isolated-white-background.jpg', 2, 1002, N' ', NULL, 1002)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1025, N'סט מזוודות איכותי', N'סט מזוודות חזקות וקלות לנשיאה בגדלים שונים, מושלם לנסיעות', 40, N'images/71F9uDPWbdL._AC_UY1000_.jpg', 1003, 1, N' ', NULL, 1)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1026, N'מארז קינוחים פרימיום', N'קופסה מהודרת הכוללת מבחר קינוחים אישיים איכותיים.', 23, N'images/large_luxe_chocolate_truffles_gift_box__83165.webp', 3, 1003, N' ', NULL, 1003)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1027, N'ארוחת בוקר מפנקת', N'שובר לארוחת בוקר עשירה הכוללת מגוון מאפים, סלטים ושתייה חמה', 10, N'images/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__images__2012__07__20120718-breakfast-israel-f0dd2bec26b448fb94238ebd942e0159.jpg', 3, 1004, N' ', NULL, 1004)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1028, N'שובר לאטרקציה תיירותית', N'כניסה לאתר תיירות, פארק או מוזיאון לבחירה, לבילוי חווייתי ומהנההכוללת מגוון מאפים, סלטים ושתייה חמה', 45, N'images/photo-1547899879-28997f206c4e.jfif', 1, 1006, N' ', NULL, 1006)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1029, N'מדפסת תמונות ניידת', N'מדפסת קומפקטית להדפסת תמונות ', 70, N'images/61UbPXnc-dL.jpg', 2, 2, N' ', NULL, 2)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1030, N'רחפן צילום', N'רחפן מתקדם עם מצלמה מובנית לצילומי אוויר מרהיבים', 70, N'images/378-R02-Autel-EVO-primary.jpg', 2, 1002, N' ', NULL, 1002)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1031, N'שובר למסעדה יוקרתית', N'שובר כספי למימוש במסעדה איכותית עם תפריט עשיר ומוקפד', 40, N'images/premium_photo-1661954531673-440d23a6eb79.webp', 3, 1003, N' ', NULL, 1003)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1032, N'מכונת קפה מקצועית', N'מכונת אספרסו ביתית להכנת קפה איכותי בלחיצת כפתור', 60, N'images/71L6WE9p2eL._AC_UF894,1000_QL80_.jpg', 2, 1003, N' ', NULL, 1003)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1033, N'טיסה פנים־ארצית', N'כרטיס טיסה ליעד מקומי לבחירה, לחיסכון בזמן ונוחות מירבית', 70, N'images/1920_dsc098172.jpg', 1, 1005, N' ', NULL, 1005)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1034, N'מדיח כלים', N'מדיח שקט וחסכוני עם מספר תוכניות הדחה מתקדמות', 80, N'images/20663017_Bosch_PDC_Built-in-Dishwashers_Meta-image_1200x630.jpg', 2, 1007, N' ', NULL, 1007)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1035, N'שואב אבק רובוטי', N' שואב חכם לניקוי אוטומטי של הרצפה, נטען באופן עצמאי.', 90, N'images/narwalZ10.webp', 2, 1007, N' ', NULL, 1007)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1036, N'כרטיסי כניסה לאתר תיירות מוביל', N'כניסה זוגית או משפחתית לאתר פופולרי ומבוקש', 85, N'images/north-cascades-national-park-picture-lake-mount-shuksan.webp', 1, 1006, N' ', NULL, 1006)
GO
INSERT [dbo].[Gift] ([Id], [Name], [Description], [Cost], [Picture], [CategoryId], [DonorId], [WinnerName], [CategoryId1], [DonorId1]) VALUES (1037, N'שובר קנייה לרשת מובילה', N'כרטיס מתנה נטען לשימוש במגוון סניפים ומוצרים', 70, N'images/71P2RI16PpL.jpg', 1003, 2, N' ', NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[Gift] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1, N'string', N'string', N'user@example.com', N'string', N'100000.LW0zPlZG7afu9PyPKY434w==.lKqnx3+4+ow2yc1WYcA4UBdD6uChzTLwPINmKLlEsII=', 0)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (2, N'string', N'string', N'use@gmail.com', N'string', N'123456', 0)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (3, N'gili', N'0583255125', N'gili@gmail.com', N'shirathayam', N'100000.Lk8wYdLiJ2xV2fgDN5euWw==.AcLAEAOhZxg0hswa6JqcHoAyqeOtG2+v1pYVQuBPhXw=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (4, N'string', N'string', N'use@example.com', N'string', N'100000.Wi80dxCD0YUceNOeeQwTYw==.z7JAn3tzwVvsuW1dbFVzvt51rxzYLVb72vJOihFHs6Y=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (5, N'string', N'string', N'us@example.com', N'string', N'100000.kHZpPdcvx62aZbivj3e6hA==.k4lKd7QIDfo+jEHg23LskwG7432CkpoDDBoHL5g0tbQ=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1004, N'ggg', N'709870', N'gu@gmail.com', N'string', N'string', 0)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1005, N'string', N'string', N'user@gmail.com', N'string', N'100000.KufpHzghUZHGa4aVcQ8fNA==.ix25cXVMWztkVURFzqGN3M8WdNnVudWJ1qGv/ii9bsk=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1006, N'string', N'string', N'uuu@gmail.com', N'string', N'100000.7Q1vraLvVMdBku+E1Iegag==.FZnGngTPLVuca3deI6OG5Fpw2Ib1UUdug5tmKJO0vUQ=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1007, N'string', N'string', N'uu@gmail.com', N'string', N'100000.J4ebkROdYKoxPuA9FUCEEA==.xbPVQ9Kmw/HHVVtRJ3e6THsIqZMrgtF782GhYRAZz8I=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1008, N'string', N'string', N'u@gmail.com', N'string', N'100000.QXzGF39SPbDXTum139Y7FQ==.KHa+Tdmv2DKxTTymUM7kWzb/T6OTsh9S9ZLJu1FjId0=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1009, N'string', N'string', N'gila@gmail.com', N'string', N'100000.YPY8C/9ejDsbWM5WseE/QQ==.EpaN8SwEkgdkrvdWUDU8Vk9o8ZZzV6SwjGmrEtGH5I8=', 1)
GO
INSERT [dbo].[User] ([Id], [FullName], [Phone], [EMail], [Address], [Password], [Role]) VALUES (1010, N'מנהל אתר', N'0583255125', N'manage@gmail.com', N'shirathayam', N'100000.IqJ60xpQoCzPQUwqPt0s+Q==.Yo4L6fIGR2oj9WTw/Vm9zkAlgIZlFHiUnGZrHs1oD1g=', 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Card] ON 
GO
INSERT [dbo].[Card] ([Id], [UserId], [GiftId], [BuingDate]) VALUES (31, 1009, 1021, CAST(N'2026-02-18T05:28:56.5259469' AS DateTime2))
GO
INSERT [dbo].[Card] ([Id], [UserId], [GiftId], [BuingDate]) VALUES (32, 1009, 1022, CAST(N'2026-02-18T05:28:56.5260463' AS DateTime2))
GO
INSERT [dbo].[Card] ([Id], [UserId], [GiftId], [BuingDate]) VALUES (33, 1009, 1023, CAST(N'2026-02-18T05:28:56.5260470' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Card] OFF
GO
