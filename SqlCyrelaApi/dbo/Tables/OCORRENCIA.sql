CREATE TABLE [dbo].[OCORRENCIA] (
    [id]                   INT            IDENTITY (1, 1) NOT NULL,
    [ticketnumber]         NVARCHAR (50)  NOT NULL,
    [pjo_clientedaunidade] NVARCHAR (250) NULL,
    [pjo_empreendimentoid] NVARCHAR (250) NULL,
    [pjo_bloco]            NVARCHAR (50)  NULL,
    [pjo_unidade]          INT            NULL,
    [pjo_bandeira]         NVARCHAR (50)  NULL,
    [description]          NVARCHAR (250) NULL,
    CONSTRAINT [PK_OCORRENCIA] PRIMARY KEY CLUSTERED ([id] ASC)
);

