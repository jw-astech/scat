USE [aspnet-dot-not-a-goat-20170602044944]
GO

/****** Object: Table [dbo].[UserRelationShips] Script Date: 6/6/2017 1:12:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
DROP TABLE [dbo].[UserRelationShips];


GO

CREATE TABLE [dbo].[UserRelationShips] (
    [connectionId]  INT PRIMARY KEY IDENTITY NOT NULL,
    [followerId]    NVARCHAR (128) NOT NULL,
    [followingId]   NVARCHAR (128) NOT NULL
);
*/


/****** Object: Table [dbo].[UserMessages] Script Date: 6/6/2017 12:59:26 PM ******/
/*
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserMessages];


GO
CREATE TABLE [dbo].[UserMessages] (
    [messageId]   INT PRIMARY KEY IDENTITY            NOT NULL,
    [posterId]    NVARCHAR (128) NOT NULL,
    [messageText] NVARCHAR (MAX) NOT NULL,
    [postedDate]  DATETIME       NOT NULL
);
*/


/****** Object: Table [dbo].[UserComments] Script Date: 6/6/2017 12:58:25 PM ******/
/*
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserComments];


GO
CREATE TABLE [dbo].[UserComments] (
    [commentid]   INT PRIMARY KEY IDENTITY	NOT NULL,
    [messageId]   INT            NOT NULL,
    [posterId]    NVARCHAR (128) NOT NULL,
    [commeterId]  NVARCHAR (128) NOT NULL,
    [commentText] NVARCHAR (MAX) NOT NULL
);
*/



/****** Object: Table [dbo].[UserViews] Script Date: 6/6/2017 12:54:20 PM ******/
/* userViews Table
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[UserViews] (
    [Id]         INT IDENTITY PRIMARY KEY NOT NULL,
    [messageId]  INT            NOT NULL,
    [viewedById] NVARCHAR (128) NOT NULL,
    [liked]      BIT            NOT NULL
);
*/

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

Delete from UserRelationShips where 1=1;

-- set up relationships
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@perryId, @doofenshmirtzId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@phineasId, @ferbId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@ferbId, @phineasId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@doofenshmirtzId, @perryId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@candaceId, @ferbId)
INSERT INTO UserRelationShips (followerId,followingId) VALUES (@candaceId, @phineasId)

-- bootstrap messages table
INSERT INTO UserMessages (messageText,posterId, postedDate) Values ('I know what we''re gonna do today @ferb',@phineasId,SYSDATETIME());
waitfor delay '00:00:02'

INSERT INTO UserMessages (messageText,posterId, postedDate) Values ('I am so going to bust @phineas & @ferb',@candaceId,SYSDATETIME());
waitfor delay '00:00:05'

INSERT INTO UserMessages (messageText,posterId, postedDate) Values ('some <script>alert("xss")</script> XSS Maybe?',@ferbId,SYSDATETIME());
waitfor delay '00:00:03'

INSERT INTO UserMessages (messageText,posterId, postedDate) Values ('Behold, the CSRF-inator!!!',@doofenshmirtzId,SYSDATETIME());
waitfor delay '00:00:10'

INSERT INTO UserMessages (messageText,posterId, postedDate) Values ('[platypus sound]',@perryId,SYSDATETIME());