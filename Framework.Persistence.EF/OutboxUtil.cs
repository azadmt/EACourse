namespace Framework.Persistence.EF
{
    public static class OutboxUtil
    {
        public static void CreateTableIfNotExist()
        {
            var sql = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Outbox]') AND type in (N'U'))
                    BEGIN
                        SET ANSI_NULLS ON
                        GO

                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE TABLE [dbo].[Outbox](
	                        [Id] [bigint] IDENTITY(1,1) NOT NULL,
	                        [EventType] [nvarchar](500) NOT NULL,
	                        [EventBody] [nvarchar](max) NOT NULL,
	                        [PublishedAt] [datetime] NULL,
	                        [Created] [datetime] NOT NULL,
	                        [EventId] [uniqueidentifier] NOT NULL
                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                        GO
                       ALTER TABLE [dbo].[Outbox] ADD  CONSTRAINT [DF_Outbox_Created]  DEFAULT (getdate()) FOR [Created]

                    END";
        }
    }
}
