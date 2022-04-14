--					Create Database Fast Drivers  ----------------
--					Author: Michael Stickel
-- ****************************************************************
GO
USE MASTER
GO
IF EXISTS(	SELECT	name
			FROM	master..sysdatabases
			WHERE	name = N'BITServices'
	 )
DROP DATABASE BITServices;
GO
CREATE DATABASE BITServices;
GO
USE BITServices;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availability](
	[ContractorID] [int] NOT NULL,
	[AvailableDate] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[FinishTime] [time](7) NOT NULL,
 CONSTRAINT [Availability_pk] PRIMARY KEY CLUSTERED 
(
	[ContractorID] ASC,
	[AvailableDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[PostCode] [nchar](4) NOT NULL,
	[State] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [Client_pk] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contractor]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contractor](
	[ContractorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[PostCode] [nchar](6) NOT NULL,
	[State] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[ContractorRating] [decimal](6, 2) NOT NULL,
	[PayRate] [decimal](6, 2) NOT NULL,
	[Profile] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [Contractor_pk] PRIMARY KEY CLUSTERED 
(
	[ContractorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractorSkill]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractorSkill](
	[ContractorID] [int] NOT NULL,
	[SkillName] [nvarchar](50) NOT NULL,
 CONSTRAINT [ContractorSkill_pk] PRIMARY KEY CLUSTERED 
(
	[ContractorID] ASC,
	[SkillName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobStatusID] [int] NOT NULL,
	[ContractorID] [int] NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[TravelDistance] [int] NOT NULL,
	[EstimatedHours] [int] NOT NULL,
	[ActualHours] [int] NOT NULL,
	[SkillName] [nvarchar](50) NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [Job_pk] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobFeedback]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobFeedback](
	[JobID] [int] NOT NULL,
	[FeedbackItem_No] [tinyint] NOT NULL,
	[Feedback] [nvarchar](2000) NOT NULL,
 CONSTRAINT [JobFeedback_pk] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[FeedbackItem_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobStatus]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobStatus](
	[JobStatusID] [int] IDENTITY(1,1) NOT NULL,
	[JobStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [JobStatus_pk] PRIMARY KEY CLUSTERED 
(
	[JobStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillName] [nvarchar](50) NOT NULL,
 CONSTRAINT [Skill_pk] PRIMARY KEY CLUSTERED 
(
	[SkillName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 14/04/2022 7:30:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[PostCode] [nchar](4) NOT NULL,
	[State] [nvarchar](30) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](300) NOT NULL,
	[StaffType] [nvarchar](30) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [Staff_pk] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Availability]  WITH CHECK ADD  CONSTRAINT [Contractor_Availability_fk] FOREIGN KEY([ContractorID])
REFERENCES [dbo].[Contractor] ([ContractorID])
GO
ALTER TABLE [dbo].[Availability] CHECK CONSTRAINT [Contractor_Availability_fk]
GO
ALTER TABLE [dbo].[ContractorSkill]  WITH CHECK ADD  CONSTRAINT [Contractor_ContractorSkill_fk] FOREIGN KEY([ContractorID])
REFERENCES [dbo].[Contractor] ([ContractorID])
GO
ALTER TABLE [dbo].[ContractorSkill] CHECK CONSTRAINT [Contractor_ContractorSkill_fk]
GO
ALTER TABLE [dbo].[ContractorSkill]  WITH CHECK ADD  CONSTRAINT [FK_ContractorSkill_ContractorSkill] FOREIGN KEY([ContractorID], [SkillName])
REFERENCES [dbo].[ContractorSkill] ([ContractorID], [SkillName])
GO
ALTER TABLE [dbo].[ContractorSkill] CHECK CONSTRAINT [FK_ContractorSkill_ContractorSkill]
GO
ALTER TABLE [dbo].[ContractorSkill]  WITH CHECK ADD  CONSTRAINT [Skill_ContractorSkill_fk] FOREIGN KEY([SkillName])
REFERENCES [dbo].[Skill] ([SkillName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContractorSkill] CHECK CONSTRAINT [Skill_ContractorSkill_fk]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [BOOKINGSTATUS_BOOKING_fk] FOREIGN KEY([JobStatusID])
REFERENCES [dbo].[JobStatus] ([JobStatusID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [BOOKINGSTATUS_BOOKING_fk]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [CONTRACTOR_BOOKING_fk] FOREIGN KEY([ContractorID])
REFERENCES [dbo].[Contractor] ([ContractorID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [CONTRACTOR_BOOKING_fk]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [Customer_Job_fk] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [Customer_Job_fk]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [Skill_Job_fk] FOREIGN KEY([SkillName])
REFERENCES [dbo].[Skill] ([SkillName])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [Skill_Job_fk]
GO
ALTER TABLE [dbo].[JobFeedback]  WITH CHECK ADD  CONSTRAINT [Job_JobFeedback_fk] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobFeedback] CHECK CONSTRAINT [Job_JobFeedback_fk]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff] CHECK  (([StaffType]='Coordinator' OR [StaffType]='Admin'))
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff]
GO











USE [BITServices]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (1, N'Blizzard', N'Wrongway 39', N'Crows Nest', N'2035', N'NSW', N'0456666312', N'info@blizzard.com', N'blizzard', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (5, N'Amazon', N'Bluestreet 52', N'Chatswood', N'2020', N'NSW', N'0454545422', N'info@amazon.com', N'amazon', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (6, N'Nestle', N'Greenstreet 35', N'Hornsby', N'2021', N'NSW', N'0455552211', N'info@nestle.com', N'nestle', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (7, N'Coke', N'Bluestreet 66', N'Chatswood', N'2020', N'NSW', N'0444555322', N'info@coke.com', N'amazon', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (9, N'Samsung', N'Broadway 444', N'Crows Nest', N'2035', N'NSW', N'0456556331', N'info@samsung.com', N'samsung', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (10, N'Nvidia', N'Backstreet 5', N'Manly', N'2035', N'NSW', N'0452266312', N'info@nvidia.com', N'nvidia', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (12, N'Apple', N'Atlantic Hwy 323', N'CBD', N'2001', N'NSW', N'0456116312', N'info@apple.com', N'apple', N'password', 1)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (13, N'MySpace', N'Long Road 10', N'Warrawee', N'2089', N'QLD', N'0453332211', N'admin@myspace.com', N'myspace', N'pw', 0)
GO
INSERT [dbo].[Client] ([ClientID], [CompanyName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [Active]) VALUES (121, N'Supercell', N'High Road 1001', N'Milsons Point', N'2066', N'NT', N'0404049392', N'info@sc.com', N'supercell', N'pw', 0)
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Contractor] ON 
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (1, N'Richard', N'Astley', N'Oxfordstreet 16', N'CBD', N'2004  ', N'NSW', N'0422324512', N'rastley@mail.com', N'rastley', N'password', CAST(8.20 AS Decimal(6, 2)), CAST(50.00 AS Decimal(6, 2)), N'../Images/richard.jpg', 1)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (3, N'Andy', N'Miller', N'Park Street 21', N'Petersham', N'2054  ', N'NSW', N'0445653212', N'amiller@gmail.com', N'amiller', N'password', CAST(5.60 AS Decimal(6, 2)), CAST(85.00 AS Decimal(6, 2)), N'../Images/catProfile2.jpg', 1)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (4, N'Bill', N'Smith', N'Purpleroad 88', N'Hornsby', N'2099  ', N'NSW', N'0467381212', N'bsmith@yahoo.com', N'bsmith', N'pass', CAST(7.90 AS Decimal(6, 2)), CAST(68.00 AS Decimal(6, 2)), N'../Images/catProfile3.jpg', 1)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (11, N'Linda', N'Jackson', N'George Street 40', N'CBD', N'2004  ', N'NSW', N'0453434328', N'linda@mail.com', N'ljackson', N'pw', CAST(7.00 AS Decimal(6, 2)), CAST(54.00 AS Decimal(6, 2)), N'../Images/disasterGirl.jpeg', 0)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (13, N'Tim', N'Smith', N'Pitt Road 12', N'Killara', N'2101  ', N'NSW', N'0499383831', N'tsmith@yahoo.com', N'tsmith', N'password', CAST(9.00 AS Decimal(6, 2)), CAST(75.00 AS Decimal(6, 2)), N'../Images/successKid.jpg', 0)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (23, N'Simon', N'Jones', N'High Street 101', N'CBD', N'2001  ', N'ACT', N'0434343434', N'sjones@mail.com', N'sjones', N'pw', CAST(5.00 AS Decimal(6, 2)), CAST(25.00 AS Decimal(6, 2)), N'../Images/placeholder-profile.png', 0)
GO
INSERT [dbo].[Contractor] ([ContractorID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [ContractorRating], [PayRate], [Profile], [Active]) VALUES (26, N'Sally', N'Summers', N'Long Lane 11', N'Hornsby', N'2020  ', N'NSW', N'0404040401', N'ssummers@mail.com', N'ssummers', N'pw', CAST(8.00 AS Decimal(6, 2)), CAST(48.00 AS Decimal(6, 2)), N'../Images/placeholder-profile.png', 0)
GO
SET IDENTITY_INSERT [dbo].[Contractor] OFF
GO
SET IDENTITY_INSERT [dbo].[JobStatus] ON 
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (1, N'Unassigned')
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (2, N'Assigned')
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (3, N'Rejected')
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (4, N'Accepted')
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (5, N'Completed')
GO
INSERT [dbo].[JobStatus] ([JobStatusID], [JobStatus]) VALUES (6, N'Verified')
GO
SET IDENTITY_INSERT [dbo].[JobStatus] OFF
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'.NET')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'C#')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'C++')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'CSS')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'HTML')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'Java')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'JavaScript')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'MySQL')
GO
INSERT [dbo].[Skill] ([SkillName]) VALUES (N'Ruby')
GO
SET IDENTITY_INSERT [dbo].[Job] ON 
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (1, 1, NULL, N'Backstreet 2', N'Petersham', N'2090', N'NSW', CAST(N'2022-12-05' AS Date), CAST(N'10:00:00' AS Time), 50, 5, 0, N'C#', 1)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (2, 1, NULL, N'Long Road 3', N'Milsons Point', N'2010', N'NSW', CAST(N'2022-10-10' AS Date), CAST(N'08:00:00' AS Time), 100, 9, 5, N'HTML', 5)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (4, 1, NULL, N'Test Street 10', N'Brookvale', N'2040', N'NSW', CAST(N'2022-05-14' AS Date), CAST(N'10:00:00' AS Time), 10, 5, 0, N'HTML', 5)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (12, 1, NULL, N'Test Street 11', N'TestSub', N'1234', N'TAS', CAST(N'2022-05-26' AS Date), CAST(N'16:00:00' AS Time), 0, 4, 0, N'Ruby', 7)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (13, 2, 13, N'Broadway 18', N'Strathfield', N'2022', N'NSW', CAST(N'2022-06-17' AS Date), CAST(N'13:00:00' AS Time), 0, 2, 0, N'Java', 13)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (17, 1, NULL, N'My Street 11', N'Hornsby', N'2020', N'NSW', CAST(N'2022-06-03' AS Date), CAST(N'16:00:00' AS Time), 0, 5, 0, N'C++', 121)
GO
INSERT [dbo].[Job] ([JobID], [JobStatusID], [ContractorID], [Street], [Suburb], [PostCode], [State], [Date], [StartTime], [TravelDistance], [EstimatedHours], [ActualHours], [SkillName], [ClientID]) VALUES (21, 2, 3, N'sdaf', N'dasf', N'sdaf', N'ACT', CAST(N'2022-05-14' AS Date), CAST(N'08:00:00' AS Time), 0, 2, 0, N'C#', 7)
GO
SET IDENTITY_INSERT [dbo].[Job] OFF
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (1, CAST(N'2022-04-17' AS Date), CAST(N'13:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (1, CAST(N'2022-05-11' AS Date), CAST(N'09:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (1, CAST(N'2022-05-12' AS Date), CAST(N'09:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (1, CAST(N'2022-05-13' AS Date), CAST(N'09:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (1, CAST(N'2022-12-05' AS Date), CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (3, CAST(N'2022-04-11' AS Date), CAST(N'12:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (3, CAST(N'2022-05-14' AS Date), CAST(N'08:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (3, CAST(N'2022-05-16' AS Date), CAST(N'08:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (3, CAST(N'2022-05-17' AS Date), CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (4, CAST(N'2022-04-05' AS Date), CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (4, CAST(N'2022-04-11' AS Date), CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (4, CAST(N'2022-04-23' AS Date), CAST(N'12:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (4, CAST(N'2022-04-30' AS Date), CAST(N'12:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (4, CAST(N'2022-06-03' AS Date), CAST(N'08:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (11, CAST(N'2022-04-22' AS Date), CAST(N'11:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (11, CAST(N'2022-05-21' AS Date), CAST(N'12:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (11, CAST(N'2022-06-17' AS Date), CAST(N'11:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (13, CAST(N'2022-06-17' AS Date), CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[Availability] ([ContractorID], [AvailableDate], [StartTime], [FinishTime]) VALUES (23, CAST(N'2022-04-28' AS Date), CAST(N'13:00:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (1, N'.NET')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (1, N'C#')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (1, N'C++')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (1, N'HTML')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (1, N'JavaScript')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'C#')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'C++')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'HTML')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'Java')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'JavaScript')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (3, N'Ruby')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (4, N'C#')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (4, N'C++')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (4, N'CSS')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (4, N'HTML')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (4, N'Java')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (11, N'C++')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (11, N'CSS')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (11, N'Java')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (11, N'JavaScript')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (11, N'Ruby')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (13, N'C#')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (13, N'C++')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (13, N'Java')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (13, N'JavaScript')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (13, N'Ruby')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (23, N'HTML')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (23, N'JavaScript')
GO
INSERT [dbo].[ContractorSkill] ([ContractorID], [SkillName]) VALUES (23, N'Ruby')
GO
INSERT [dbo].[JobFeedback] ([JobID], [FeedbackItem_No], [Feedback]) VALUES (1, 2, N'All Good')
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 
GO
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [StaffType], [Active]) VALUES (1, N'Peter', N'Parker', N'Green Street 11', N'Manly', N'2069', N'NSW', N'04320344', N'pparker@mail.com', N'pparker', N'password', N'Admin', 1)
GO
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [StaffType], [Active]) VALUES (2, N'Lois', N'Lane', N'Broadway 23', N'Brookvale', N'2070', N'NSW', N'043949591', N'llane@yahoo.com', N'llane', N'pw', N'Coordinator', 1)
GO
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [StaffType], [Active]) VALUES (3, N'Rocky', N'Balboa', N'Backstreet 19', N'Strathfield', N'2090', N'NSW', N'042232203', N'rockyb@mail.com', N'rockyb', N'pass', N'Coordinator', 1)
GO
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Street], [Suburb], [PostCode], [State], [Phone], [Email], [UserName], [Password], [StaffType], [Active]) VALUES (4, N'Sandi', N'Flanders', N'Park Lane 12', N'Bondi', N'2055', N'NSW', N'049874894', N'sandy@mail.com', N'sandyf', N'pw', N'Admin', 0)
GO
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
