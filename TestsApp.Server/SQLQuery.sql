CREATE TABLE [Questions]
(
	[Id] INT NOT NULL UNIQUE,
	[Text] NVARCHAR(400) NOT NULL,
	[Answer] NVARCHAR(1) NOT NULL,
	[Var1] NVARCHAR(100) NOT NULL,
	[Var2] NVARCHAR(100) NOT NULL,
	[Var3] NVARCHAR(100),
	[Var4] NVARCHAR(100)
)

INSERT INTO [Questions]
       (Id, Text, Answer, Var1, Var2, Var3, Var4)
VALUES (1, N'Любимое слово Кожевникова?', '2', N'лол', N'кек', N'мур', N'гав' ),
       (2, N'Что скажет Алпатов в начале лекции?', '3', N'Добрый день!',  N'Здравствуйте, товарищи!', N'Здравствуйте, коллеги.',N'Спокойной ночи'),
       (3, N'Как всё у Щукина?', '1', N'Пи-пи-пичально', N'Замечательно', N'Шикарно', N'Плохо');
