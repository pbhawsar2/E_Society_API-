drop table SocietyMemberInfo
drop table MessageTable

CREATE TABLE [dbo].[SocietyMemberInfo] (
    [SMID]          INT    PRIMARY KEY   IDENTITY (10, 1) NOT NULL,
    [Password]      VARCHAR (20)  NOT NULL,
    [Name]          VARCHAR (30)  NOT NULL,
    [Address]       VARCHAR (100) NOT NULL,
    [Email]         VARCHAR (40)  NOT NULL,
    [ContactNumber] BIGINT        NOT NULL,
    [AccountType]   VARCHAR (20)  NOT NULL,
    [HouseNo]       VARCHAR (10)  DEFAULT NULL,
    [BusinessName]  VARCHAR (30)  DEFAULT NULL,
    [Rent]          BIGINT  DEFAULT 0
);

CREATE TABLE [dbo].[MessageTable] (
    [MsgID]        INT    PRIMARY KEY    IDENTITY (1, 1) NOT NULL,
    [SMID]         INT           NOT NULL,
    [Name]         VARCHAR (30)  NOT NULL,
    [AccountType]  VARCHAR (20)  NOT NULL,
    [MessageTitle] VARCHAR (100) NOT NULL,
    [Message]      VARCHAR (410) NOT NULL,
    [DateTime]     VARCHAR (25)  NOT NULL
);