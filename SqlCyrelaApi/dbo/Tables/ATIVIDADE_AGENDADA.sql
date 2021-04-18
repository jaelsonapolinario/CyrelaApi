CREATE TABLE [dbo].[ATIVIDADE_AGENDADA] (
    [id]                   INT            IDENTITY (1, 1) NOT NULL,
    [actualstart]          DATETIME       NULL,
    [actualend]            DATETIME       NULL,
    [pjo_tipodeatividade]  NVARCHAR (250) NOT NULL,
    [subject]              NVARCHAR (250) NOT NULL,
    [pjo_empreendimentoid] NVARCHAR (250) NOT NULL,
    [pjo_blocoid]          NVARCHAR (50)  NOT NULL,
    [pjo_unidadeid]        INT            NOT NULL,
    CONSTRAINT [PK_AT_AGENDADA] PRIMARY KEY CLUSTERED ([id] ASC)
);

