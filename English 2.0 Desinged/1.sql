USE [master]
GO
/****** Object:  Database [English]    Script Date: 09.02.2024 11:07:43 ******/
CREATE DATABASE [English]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'English', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\English.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'English_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\English_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [English] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [English].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [English] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [English] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [English] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [English] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [English] SET ARITHABORT OFF 
GO
ALTER DATABASE [English] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [English] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [English] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [English] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [English] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [English] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [English] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [English] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [English] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [English] SET  DISABLE_BROKER 
GO
ALTER DATABASE [English] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [English] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [English] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [English] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [English] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [English] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [English] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [English] SET RECOVERY FULL 
GO
ALTER DATABASE [English] SET  MULTI_USER 
GO
ALTER DATABASE [English] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [English] SET DB_CHAINING OFF 
GO
ALTER DATABASE [English] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [English] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [English] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [English] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'English', N'ON'
GO
ALTER DATABASE [English] SET QUERY_STORE = ON
GO
ALTER DATABASE [English] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [English]
GO
/****** Object:  Table [dbo].[Dictonary]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictonary](
	[Id_dictonary] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Translate] [nvarchar](max) NULL,
	[Id_lections] [int] NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dictonary] PRIMARY KEY CLUSTERED 
(
	[Id_dictonary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id_language] [int] NOT NULL,
	[TitleEnglish] [nvarchar](50) NULL,
	[TitleRussian] [nvarchar](50) NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id_language] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lections]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lections](
	[Id_lections] [int] NOT NULL,
	[Id_language] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[Id_levels] [int] NULL,
 CONSTRAINT [PK_Lections] PRIMARY KEY CLUSTERED 
(
	[Id_lections] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Levels]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levels](
	[Id_level] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Levels] PRIMARY KEY CLUSTERED 
(
	[Id_level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Progress]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Progress](
	[Id_progress] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[Id_lecture] [int] NULL,
 CONSTRAINT [PK_Progress] PRIMARY KEY CLUSTERED 
(
	[Id_progress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id_test] [int] NOT NULL,
	[Id_lections] [int] NULL,
	[Questions] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id_test] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.02.2024 11:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_Users] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id_Users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (1, N'Tea', N'Чай', 2, N'tea.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (2, N'Coffe', N'Кофе', 2, N'coffee.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (3, N'Water', N'Вода', 2, N'water.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (4, N'Compote', N'Компот', 2, N'compote.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (5, N'Beer', N'Пиво', 2, N'beer.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (6, N'Lemonade', N'Лимонад', 2, N'lemonade.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (7, N'Cocktail', N'Коктейль', 2, N'cocktail.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (8, N'Milk', N'Молоко', 2, N'milk.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (9, N'Yogurt', N'Йогурт', 2, N'yougurt.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (10, N'Juice', N'Сок', 2, N'juice.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (12, N'Research has shown that when people smell coffee, they are better at solving analytical problems. The aroma of coffee does not contain caffeine, so, apparently, the placebo effect works in this case.', N'Исследования показали, что, когда люди ощущают запах кофе, они лучше справляются с решением аналитических задач. Аромат кофе не содержит кофеина, так что, по всей видимости, в этом случае действует эффект плацебо.', 6, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (13, N'Camel milk does not curdle, and it can be absorbed by people with lactose intolerance.', N'Верблюжье молоко не сворачивается, и его могут усваивать люди с непереносимостью лактозы.', 6, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (14, N'Mother', N'Мама', 1, N'mother.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (15, N'Father', N'Отец', 1, N'father.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (16, N'Sister', N'Сестра', 1, N'sister.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (17, N'Brother', N'Брат', 1, N'brother.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (18, N'Uncle', N'Дядя', 1, N'uncle.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (19, N'Aunt', N'Тетя', 1, N'aunt.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (20, N'Son', N'Сын', 1, N'son.png')
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (21, N'The family gathered at the table and we celebrated a family holiday - grandmother''s birthday.', N'Семья собралась за столом , и мы отметили семейный праздник - день рождения бабушки.', 4, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (22, N'Our family is very friendly, and we always support and help each other.', N' Наша семья очень дружная, и мы всегда друг друга поддерживаем и помогаем.', 4, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (23, N'Family is the most precious and important thing a person has.', N'Семья - это самое дорогое и важное, что есть у человека.', 4, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (24, N'So we got married, and a new family was formed.', N'Вот мы и расписались, и образовалась новая семья.', 4, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (25, N'Our family is very large, when we get together we cannot fit in one room.', N'Наша семья очень большая, когда мы собираемся вместе, то не можем поместиться в одной комнате.', 4, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (26, N'According to statistics, in China the number of possible grooms significantly exceeds the number of brides. Therefore, if the matter is completely hopeless, parents go to a special marriage market in Shanghai, where they can try to find a home for their child.', N'По статистике, в Китае количество возможных женихов значительно превышает число невест. Поэтому, если дело совсем безнадежное, родители отправляются на специальный брачный рынок в Шанхае, где можно попробовать пристроить чадо.', 7, NULL)
INSERT [dbo].[Dictonary] ([Id_dictonary], [Text], [Translate], [Id_lections], [Image]) VALUES (27, N'In Greece, after the birth of a baby, a woman must stay at home for 40 days. Friends and relatives come to visit my mother and bring small gifts (usually gold or jewelry). It is customary to spit in front of a baby in order to ward off all sorts of evil forces and misfortunes.', N'В Греции после появления малыша на свет женщина должна находиться дома 40 дней. К маме с визитами приходят друзья и родственники и приносят маленькие подарки (обычно это золото или драгоценности). При младенце принято сплевывать, дабы отвести всяческие злые силы и несчастья.', 7, NULL)
GO
INSERT [dbo].[Language] ([Id_language], [TitleEnglish], [TitleRussian]) VALUES (1, N'English', N'Английский')
INSERT [dbo].[Language] ([Id_language], [TitleEnglish], [TitleRussian]) VALUES (2, N'Spanish', N'Испанский')
GO
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (1, 1, N'Семья', 1)
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (2, 1, N'Напитки', 1)
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (4, 1, N'Семья', 2)
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (5, 1, N'Напитки', 2)
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (6, 1, N'Напитки', 3)
INSERT [dbo].[Lections] ([Id_lections], [Id_language], [Title], [Id_levels]) VALUES (7, 1, N'Семья', 3)
GO
INSERT [dbo].[Levels] ([Id_level], [Title]) VALUES (1, N'Ничнающий')
INSERT [dbo].[Levels] ([Id_level], [Title]) VALUES (2, N'Базовый')
INSERT [dbo].[Levels] ([Id_level], [Title]) VALUES (3, N'Продвинутый')
GO
SET IDENTITY_INSERT [dbo].[Progress] ON 

INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (2, 1, 2)
INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (4, 1, 1)
INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (6, 2, 6)
INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (1006, 2, 1)
INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (1007, 2, 2)
INSERT [dbo].[Progress] ([Id_progress], [Id_user], [Id_lecture]) VALUES (1008, 2, 4)
SET IDENTITY_INSERT [dbo].[Progress] OFF
GO
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (1, 2, N'tea', N'чай')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (2, 2, N'coffee', N'кофе')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (3, 2, N'water', N'вода')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (4, 2, N'cola', N'кола')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (5, 2, N'beer', N'пиво')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (6, 2, N'tea', N'чай')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (7, 2, N'coffee', N'кофе')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (8, 2, N'water', N'вода')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (9, 2, N'cola', N'кола')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (10, 2, N'beer', N'пиво')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (11, 6, N'Я хочу выпить кофе', N'I want drink coffee')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (12, 6, N'Пойдем выпить по чашечке чая', N'Let''s go have a cup of tea')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (13, 1, N'son', N'сын')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (14, 1, N'mother', N'мама')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (15, 1, N'uncle', N'дядя')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (16, 1, N'aunt', N'тетя')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (17, 1, N'brother', N'брат')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (18, 4, N'Our _____ is very large, when we get together we cannot fit in one room.', N'family')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (19, 4, N'Our family is very ______, and we always support and help each other.', N'friendly')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (20, 4, N'The family gathered at the table and we celebrated a family holiday - __________ birthday.', N'grandmother''s')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (21, 4, N'So we got ______, and a new family was formed', N'married')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (22, 7, N'У нас самая большая и дружная семья', N'We have the largest and most friendly family')
INSERT [dbo].[Test] ([Id_test], [Id_lections], [Questions], [Answer]) VALUES (23, 7, N'Весь наш коллектив был крепкой и дружной семьей.', N'Our entire team was a strong and friendly family.')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id_Users], [Name], [Surname], [Login], [Password]) VALUES (1, N'Roma', N'Olek', N'OleRoma', N'123')
INSERT [dbo].[Users] ([Id_Users], [Name], [Surname], [Login], [Password]) VALUES (2, N'Guest', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Dictonary]  WITH CHECK ADD  CONSTRAINT [FK_Dictonary_Lections] FOREIGN KEY([Id_lections])
REFERENCES [dbo].[Lections] ([Id_lections])
GO
ALTER TABLE [dbo].[Dictonary] CHECK CONSTRAINT [FK_Dictonary_Lections]
GO
ALTER TABLE [dbo].[Lections]  WITH CHECK ADD  CONSTRAINT [FK_Lections_Language] FOREIGN KEY([Id_language])
REFERENCES [dbo].[Language] ([Id_language])
GO
ALTER TABLE [dbo].[Lections] CHECK CONSTRAINT [FK_Lections_Language]
GO
ALTER TABLE [dbo].[Lections]  WITH CHECK ADD  CONSTRAINT [FK_Lections_Levels] FOREIGN KEY([Id_levels])
REFERENCES [dbo].[Levels] ([Id_level])
GO
ALTER TABLE [dbo].[Lections] CHECK CONSTRAINT [FK_Lections_Levels]
GO
ALTER TABLE [dbo].[Lections]  WITH CHECK ADD  CONSTRAINT [FK_Lections_Test] FOREIGN KEY([Id_language])
REFERENCES [dbo].[Test] ([Id_test])
GO
ALTER TABLE [dbo].[Lections] CHECK CONSTRAINT [FK_Lections_Test]
GO
ALTER TABLE [dbo].[Progress]  WITH CHECK ADD  CONSTRAINT [FK_Progress_Lections] FOREIGN KEY([Id_lecture])
REFERENCES [dbo].[Lections] ([Id_lections])
GO
ALTER TABLE [dbo].[Progress] CHECK CONSTRAINT [FK_Progress_Lections]
GO
ALTER TABLE [dbo].[Progress]  WITH CHECK ADD  CONSTRAINT [FK_Progress_Users] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_Users])
GO
ALTER TABLE [dbo].[Progress] CHECK CONSTRAINT [FK_Progress_Users]
GO
USE [master]
GO
ALTER DATABASE [English] SET  READ_WRITE 
GO
