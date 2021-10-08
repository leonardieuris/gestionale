USE [Gestionale]
GO

/****** Object:  Table [dbo].[Clienti]    Script Date: 19/11/2019 17:09:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clienti](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[RagSoc] [varchar](150) NOT NULL,
	[Piva] [varchar](11) NOT NULL,
	[Indirizzo] [varchar](500) NULL,
	[Attivo] [bit] NOT NULL,
 CONSTRAINT [PK_Clienti] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clienti] ADD  CONSTRAINT [DF_Clienti_Attivo]  DEFAULT ((1)) FOR [Attivo]
GO




USE [Gestionale]
GO

/****** Object:  Table [dbo].[Prodotto]    Script Date: 19/11/2019 17:09:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prodotto](
	[IdProdotto] [int] IDENTITY(1,1) NOT NULL,
	[NomeProdotto] [varchar](500) NOT NULL,
	[Codice8] [varchar](8) NOT NULL,
	[Categoria] [varchar](500) NULL,
	[Qta] [int] NULL,
	[Attivo] [bit] NOT NULL,
 CONSTRAINT [PK_Prodotto] PRIMARY KEY CLUSTERED 
(
	[IdProdotto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Prodotto] ADD  CONSTRAINT [DF_Prodotto_Attivo]  DEFAULT ((0)) FOR [Attivo]
GO






USE [Gestionale]
GO

/****** Object:  Table [dbo].[Ordini]    Script Date: 19/11/2019 17:09:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ordini](
	[IdOrdine] [int] IDENTITY(1,1) NOT NULL,
	[DataOrdine] [datetime] NOT NULL,
	[IdProdotto] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IndirizzoSpedizione] [varchar](500) NULL,
	[Attivo] [bit] NOT NULL,
 CONSTRAINT [PK_Oridini] PRIMARY KEY CLUSTERED 
(
	[IdOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ordini] ADD  CONSTRAINT [DF_Ordini_DataOrdine]  DEFAULT (getdate()) FOR [DataOrdine]
GO

ALTER TABLE [dbo].[Ordini] ADD  CONSTRAINT [DF_Oridini_Attivo]  DEFAULT ((1)) FOR [Attivo]
GO

ALTER TABLE [dbo].[Ordini]  WITH CHECK ADD  CONSTRAINT [FK_Oridini_Clienti] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clienti] ([IdCliente])
GO

ALTER TABLE [dbo].[Ordini] CHECK CONSTRAINT [FK_Oridini_Clienti]
GO

ALTER TABLE [dbo].[Ordini]  WITH CHECK ADD  CONSTRAINT [FK_Oridini_Prodotto] FOREIGN KEY([IdProdotto])
REFERENCES [dbo].[Prodotto] ([IdProdotto])
GO

ALTER TABLE [dbo].[Ordini] CHECK CONSTRAINT [FK_Oridini_Prodotto]
GO



