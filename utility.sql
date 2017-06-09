--perry follows doofenshmirtz
--phineas follows ferb
--ferb follows phineas
--doofenshmirtz follows perry
--candace follows phineas
--candace follows ferb

Declare @candaceId nvarchar(200);
Declare @phineasId nvarchar(200);
Declare @ferbId nvarchar(200);
Declare @doofenshmirtzId nvarchar(200);
Declare @perryId nvarchar(200);

-- create users with the email addresses below first, then run this script to bootstrap
SET @candaceId = (Select [id] from dbo.AspNetUsers where Email='candace@tri.state')
SET @phineasId = (Select [id] from dbo.AspNetUsers where Email='phineas@tri.state')
SET @ferbId = (Select [id] from dbo.AspNetUsers where Email='ferb@tri.state')
SET @doofenshmirtzId = (Select [id] from dbo.AspNetUsers where Email='doofenshmirtz@tri.state')
SET @perryId = (Select [id] from dbo.AspNetUsers where Email='perry@owca.gov')

--select @candaceId,@phineasId,@ferbId,@doofenshmirtzId,@perryId

--select * from UserRelationShips

--Alter TABLE AspNetUsers ADD UserBioText NVARCHAR(max) NULL

INSERT INTO UserRelationShips (followerId,followingId) VALUES (@perryId, @doofenshmirtzId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@phineasId, @ferbId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@ferbId, @phineasId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@doofenshmirtzId, @perryId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@candaceId, @ferbId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@candaceId, @phineasId)


GO

/****** Object: Table [dbo].[AspNetUsers] Script Date: 6/5/2017 4:52:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[AspNetUsers];


GO
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Hometown]             NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL
);

-- create relationships table

CREATE TABLE [dbo].[UserRelationShips]
(
	[connectionId] INT NOT NULL PRIMARY KEY, 
    [followerId] NVARCHAR(128) NOT NULL, 
    [followingId] NVARCHAR(128) NOT NULL, 
    [inviteStatus] NCHAR(10) NOT NULL, 
    [inviteMessage] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_UserRelationShips_Follower] FOREIGN KEY ([followerId]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_UserRelationShips_Following] FOREIGN KEY ([followingId]) REFERENCES [AspNetUsers]([Id])
)

-- create messages table

CREATE TABLE [dbo].[Table]
(
	[messageId] INT NOT NULL PRIMARY KEY, 
    [posterId] NVARCHAR(128) NOT NULL, 
    [posterMessage] NVARCHAR(MAX) NOT NULL, 
    [postedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([posterId]) REFERENCES [AspNetUsers]([Id]) 
)

-- create user views table
CREATE TABLE [dbo].[UserViews]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [messageId] INT NOT NULL, 
    [viewedById] NVARCHAR(128) NOT NULL, 
    [liked] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_UserViews_UserMessages] FOREIGN KEY ([messageId]) REFERENCES [UserMessages]([messageId])
)

-- user comments
/****** Object: Table [dbo].[UserComments] Script Date: 6/5/2017 5:23:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserComments];


GO
CREATE TABLE [dbo].[UserComments] (
    [commentid]  INT            NOT NULL,
    [messageId]  INT            NOT NULL,
    [posterId]   NVARCHAR (128) NOT NULL,
    [commeterId] NVARCHAR (128) NOT NULL,
	[commentText] NVARCHAR(MAX) NOT NULL
);
