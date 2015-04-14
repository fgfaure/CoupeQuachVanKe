
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2015 21:50:42
-- Generated from EDMX file: E:\Workspace\CSharp\Dropbox\CoupeQVK\LamSonVoDao.CoupeQuachVanKe.EntityFrameworkBase2Model\CoupeQuachVanKe.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CoupeQuachVanKeContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Aires_dbo_Coupes_CoupeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aires] DROP CONSTRAINT [FK_dbo_Aires_dbo_Coupes_CoupeId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Aires_dbo_NetClient_ClientId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aires] DROP CONSTRAINT [FK_dbo_Aires_dbo_NetClient_ClientId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Competiteurs_dbo_CategoriePratiquants_CategoriePratiquantId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competiteurs] DROP CONSTRAINT [FK_dbo_Competiteurs_dbo_CategoriePratiquants_CategoriePratiquantId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Competiteurs_dbo_Clubs_ClubId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competiteurs] DROP CONSTRAINT [FK_dbo_Competiteurs_dbo_Clubs_ClubId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Competiteurs_dbo_Epreuves_Epreuve_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competiteurs] DROP CONSTRAINT [FK_dbo_Competiteurs_dbo_Epreuves_Epreuve_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Competiteurs_dbo_EquipesSongLuyen_EquipeSongLuyen_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competiteurs] DROP CONSTRAINT [FK_dbo_Competiteurs_dbo_EquipesSongLuyen_EquipeSongLuyen_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Disponibilites_dbo_Encadrants_EncadrantId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Disponibilites] DROP CONSTRAINT [FK_dbo_Disponibilites_dbo_Encadrants_EncadrantId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Encadrants_dbo_Clubs_ClubId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encadrants] DROP CONSTRAINT [FK_dbo_Encadrants_dbo_Clubs_ClubId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Encadrants_dbo_Coupes_Coupe_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encadrants] DROP CONSTRAINT [FK_dbo_Encadrants_dbo_Coupes_Coupe_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Epreuves_dbo_Aires_Aire_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Epreuves] DROP CONSTRAINT [FK_dbo_Epreuves_dbo_Aires_Aire_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Epreuves_dbo_CategoriePratiquants_CategorieId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Epreuves] DROP CONSTRAINT [FK_dbo_Epreuves_dbo_CategoriePratiquants_CategorieId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Epreuves_dbo_TypeEpreuves_TypeEpreuveId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Epreuves] DROP CONSTRAINT [FK_dbo_Epreuves_dbo_TypeEpreuves_TypeEpreuveId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_EpreuvesCombat_dbo_Epreuves_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpreuvesCombat] DROP CONSTRAINT [FK_dbo_EpreuvesCombat_dbo_Epreuves_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_EquipesSongLuyen_dbo_Clubs_ClubId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipesSongLuyen] DROP CONSTRAINT [FK_dbo_EquipesSongLuyen_dbo_Clubs_ClubId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Medecins_dbo_Coupes_CoupeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Medecins] DROP CONSTRAINT [FK_dbo_Medecins_dbo_Coupes_CoupeId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_NetClient_dbo_NetClientTypes_NetClientTypeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NetClient] DROP CONSTRAINT [FK_dbo_NetClient_dbo_NetClientTypes_NetClientTypeId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ResponsablesClub_dbo_Clubs_ClubId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResponsablesClub] DROP CONSTRAINT [FK_dbo_ResponsablesClub_dbo_Clubs_ClubId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ResponsablesCoupe_dbo_Coupes_CoupeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResponsablesCoupe] DROP CONSTRAINT [FK_dbo_ResponsablesCoupe_dbo_Coupes_CoupeId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Resultats_dbo_Competiteurs_CompetiteurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultats] DROP CONSTRAINT [FK_dbo_Resultats_dbo_Competiteurs_CompetiteurId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Resultats_dbo_Epreuves_EpreuveId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultats] DROP CONSTRAINT [FK_dbo_Resultats_dbo_Epreuves_EpreuveId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_TypeEpreuves_dbo_Coupes_CoupeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeEpreuves] DROP CONSTRAINT [FK_dbo_TypeEpreuves_dbo_Coupes_CoupeId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aires]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aires];
GO
IF OBJECT_ID(N'[dbo].[CategoriePratiquants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriePratiquants];
GO
IF OBJECT_ID(N'[dbo].[Clubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clubs];
GO
IF OBJECT_ID(N'[dbo].[Competiteurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competiteurs];
GO
IF OBJECT_ID(N'[dbo].[Coupes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coupes];
GO
IF OBJECT_ID(N'[dbo].[Disponibilites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Disponibilites];
GO
IF OBJECT_ID(N'[dbo].[Encadrants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Encadrants];
GO
IF OBJECT_ID(N'[dbo].[Epreuves]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Epreuves];
GO
IF OBJECT_ID(N'[dbo].[EpreuvesCombat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EpreuvesCombat];
GO
IF OBJECT_ID(N'[dbo].[EquipesSongLuyen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipesSongLuyen];
GO
IF OBJECT_ID(N'[dbo].[Medecins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medecins];
GO
IF OBJECT_ID(N'[dbo].[NetClient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NetClient];
GO
IF OBJECT_ID(N'[dbo].[NetClientTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NetClientTypes];
GO
IF OBJECT_ID(N'[dbo].[ResponsablesClub]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResponsablesClub];
GO
IF OBJECT_ID(N'[dbo].[ResponsablesCoupe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResponsablesCoupe];
GO
IF OBJECT_ID(N'[dbo].[Resultats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resultats];
GO
IF OBJECT_ID(N'[dbo].[TypeEpreuves]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeEpreuves];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aires'
CREATE TABLE [dbo].[Aires] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(255)  NOT NULL,
    [CoupeId] int  NOT NULL,
    [Coupe_Id] int  NOT NULL,
    [NetClient_Id] int  NOT NULL
);
GO

-- Creating table 'Clubs'
CREATE TABLE [dbo].[Clubs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [NumeroAffiliation] nvarchar(255)  NOT NULL,
    [InscriptionIsCorrect] bit  NOT NULL,
    [ResponsableClub_Id] int  NOT NULL
);
GO

-- Creating table 'Competiteurs'
CREATE TABLE [dbo].[Competiteurs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(255)  NOT NULL,
    [Grade] int  NOT NULL,
    [DateNaissance] datetime  NOT NULL,
    [Sexe] int  NOT NULL,
    [LicenceFFKDA] nvarchar(255)  NOT NULL,
    [AnneePratique] int  NOT NULL,
    [Poids] int  NULL,
    [NbAnneePratique] int  NOT NULL,
    [InscritPourQuyen] bit  NOT NULL,
    [InscritPourBaiVuKhi] bit  NOT NULL,
    [InscritPourCombat] bit  NOT NULL,
    [InscritPourSongLuyen] bit  NOT NULL,
    [InscriptionValidePourCoupe] bit  NOT NULL,
    [InscriptionIsCorrect] bit  NOT NULL,
    [CategoriePratiquant_Id] int  NOT NULL,
    [Club_Id] int  NOT NULL,
    [EquipeSongLuyen_Id] int  NOT NULL
);
GO

-- Creating table 'Coupes'
CREATE TABLE [dbo].[Coupes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Description] nvarchar(255)  NOT NULL,
    [Voie] nvarchar(255)  NULL,
    [Numero] int  NULL,
    [Complement] nvarchar(255)  NULL,
    [CodePostal] nchar(5)  NOT NULL,
    [Ville] nvarchar(255)  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [DateFin] datetime  NOT NULL
);
GO

-- Creating table 'Disponibilites'
CREATE TABLE [dbo].[Disponibilites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Role] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Matin] bit  NOT NULL,
    [Encadrant_Id] int  NOT NULL
);
GO

-- Creating table 'Encadrants'
CREATE TABLE [dbo].[Encadrants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(255)  NOT NULL,
    [MailContact] nvarchar(255)  NULL,
    [TailleTenue] int  NOT NULL,
    [EstCompetiteur] bit  NULL,
    [Sexe] int  NOT NULL,
    [InscriptionIsCorrect] bit  NOT NULL,
    [Club_Id] int  NOT NULL
);
GO

-- Creating table 'Epreuves'
CREATE TABLE [dbo].[Epreuves] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [Description] nvarchar(255)  NULL,
    [Statut] int  NOT NULL,
    [GenreCategorie] int  NOT NULL,
    [GradeAutorise] int  NOT NULL,
    [IsMerged] bit  NOT NULL,
    [Aire_Id] int  NOT NULL,
    [TypeEpreuve_Id] int  NOT NULL,
    [CategoriePratiquant_Id] int  NOT NULL
);
GO

-- Creating table 'Medecins'
CREATE TABLE [dbo].[Medecins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(255)  NOT NULL,
    [Telephone] nvarchar(max)  NULL,
    [MailContact] nvarchar(255)  NULL,
    [Coupe_Id] int  NOT NULL
);
GO

-- Creating table 'ResponsablesClubs'
CREATE TABLE [dbo].[ResponsablesClubs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(255)  NOT NULL,
    [Adresse] nvarchar(255)  NULL,
    [Telephone] nchar(14)  NULL,
    [EmailContact] nvarchar(255)  NULL,
    [InscriptionIsCorrect] bit  NOT NULL,
    [MailContact] nvarchar(255)  NULL
);
GO

-- Creating table 'ResponsablesCoupes'
CREATE TABLE [dbo].[ResponsablesCoupes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(255)  NOT NULL,
    [Adresse] nvarchar(255)  NULL,
    [Telephone] nchar(14)  NULL,
    [EmailContact] nvarchar(255)  NULL,
    [MailContact] nvarchar(255)  NULL,
    [Coupe_Id] int  NOT NULL
);
GO

-- Creating table 'Resultats'
CREATE TABLE [dbo].[Resultats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InscriptionValidee] bit  NOT NULL,
    [Classement] int  NOT NULL,
    [Score] int  NOT NULL,
    [Abandon] bit  NOT NULL,
    [Blessure] bit  NOT NULL,
    [Disqualification] bit  NOT NULL,
    [Absence] bit  NOT NULL,
    [Renvoi] bit  NOT NULL
);
GO

-- Creating table 'CategoriePratiquants'
CREATE TABLE [dbo].[CategoriePratiquants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [AgeMax] int  NOT NULL,
    [AgeMin] int  NOT NULL
);
GO

-- Creating table 'EquipesSongLuyen'
CREATE TABLE [dbo].[EquipesSongLuyen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Numero] int  NOT NULL
);
GO

-- Creating table 'NetClient'
CREATE TABLE [dbo].[NetClient] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsConnected] bit  NOT NULL,
    [Ip] nvarchar(max)  NULL,
    [NetClientType_Id] int  NOT NULL
);
GO

-- Creating table 'NetClientTypes'
CREATE TABLE [dbo].[NetClientTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientType] nvarchar(max)  NULL
);
GO

-- Creating table 'TypeEpreuves'
CREATE TABLE [dbo].[TypeEpreuves] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Technique] bit  NOT NULL
);
GO

-- Creating table 'ParticipationSet'
CREATE TABLE [dbo].[ParticipationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Competiteur_Id] int  NOT NULL,
    [Epreuve_Id] int  NOT NULL,
    [Resultat_Id] int  NOT NULL
);
GO

-- Creating table 'Epreuves_EpreuveCombat'
CREATE TABLE [dbo].[Epreuves_EpreuveCombat] (
    [PoidsMini] real  NOT NULL,
    [PoidsMaxi] real  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Epreuves_EpreuveTechnique'
CREATE TABLE [dbo].[Epreuves_EpreuveTechnique] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Aires'
ALTER TABLE [dbo].[Aires]
ADD CONSTRAINT [PK_Aires]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clubs'
ALTER TABLE [dbo].[Clubs]
ADD CONSTRAINT [PK_Clubs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competiteurs'
ALTER TABLE [dbo].[Competiteurs]
ADD CONSTRAINT [PK_Competiteurs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Coupes'
ALTER TABLE [dbo].[Coupes]
ADD CONSTRAINT [PK_Coupes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Disponibilites'
ALTER TABLE [dbo].[Disponibilites]
ADD CONSTRAINT [PK_Disponibilites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Encadrants'
ALTER TABLE [dbo].[Encadrants]
ADD CONSTRAINT [PK_Encadrants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Epreuves'
ALTER TABLE [dbo].[Epreuves]
ADD CONSTRAINT [PK_Epreuves]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Medecins'
ALTER TABLE [dbo].[Medecins]
ADD CONSTRAINT [PK_Medecins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResponsablesClubs'
ALTER TABLE [dbo].[ResponsablesClubs]
ADD CONSTRAINT [PK_ResponsablesClubs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResponsablesCoupes'
ALTER TABLE [dbo].[ResponsablesCoupes]
ADD CONSTRAINT [PK_ResponsablesCoupes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Resultats'
ALTER TABLE [dbo].[Resultats]
ADD CONSTRAINT [PK_Resultats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriePratiquants'
ALTER TABLE [dbo].[CategoriePratiquants]
ADD CONSTRAINT [PK_CategoriePratiquants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipesSongLuyen'
ALTER TABLE [dbo].[EquipesSongLuyen]
ADD CONSTRAINT [PK_EquipesSongLuyen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NetClient'
ALTER TABLE [dbo].[NetClient]
ADD CONSTRAINT [PK_NetClient]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NetClientTypes'
ALTER TABLE [dbo].[NetClientTypes]
ADD CONSTRAINT [PK_NetClientTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeEpreuves'
ALTER TABLE [dbo].[TypeEpreuves]
ADD CONSTRAINT [PK_TypeEpreuves]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [PK_ParticipationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Epreuves_EpreuveCombat'
ALTER TABLE [dbo].[Epreuves_EpreuveCombat]
ADD CONSTRAINT [PK_Epreuves_EpreuveCombat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Epreuves_EpreuveTechnique'
ALTER TABLE [dbo].[Epreuves_EpreuveTechnique]
ADD CONSTRAINT [PK_Epreuves_EpreuveTechnique]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Coupe_Id] in table 'ResponsablesCoupes'
ALTER TABLE [dbo].[ResponsablesCoupes]
ADD CONSTRAINT [FK_CoupeResponsableCoupe]
    FOREIGN KEY ([Coupe_Id])
    REFERENCES [dbo].[Coupes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoupeResponsableCoupe'
CREATE INDEX [IX_FK_CoupeResponsableCoupe]
ON [dbo].[ResponsablesCoupes]
    ([Coupe_Id]);
GO

-- Creating foreign key on [Coupe_Id] in table 'Medecins'
ALTER TABLE [dbo].[Medecins]
ADD CONSTRAINT [FK_CoupeMedecin]
    FOREIGN KEY ([Coupe_Id])
    REFERENCES [dbo].[Coupes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoupeMedecin'
CREATE INDEX [IX_FK_CoupeMedecin]
ON [dbo].[Medecins]
    ([Coupe_Id]);
GO

-- Creating foreign key on [Coupe_Id] in table 'Aires'
ALTER TABLE [dbo].[Aires]
ADD CONSTRAINT [FK_CoupeAire]
    FOREIGN KEY ([Coupe_Id])
    REFERENCES [dbo].[Coupes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoupeAire'
CREATE INDEX [IX_FK_CoupeAire]
ON [dbo].[Aires]
    ([Coupe_Id]);
GO

-- Creating foreign key on [NetClient_Id] in table 'Aires'
ALTER TABLE [dbo].[Aires]
ADD CONSTRAINT [FK_AireNetClient]
    FOREIGN KEY ([NetClient_Id])
    REFERENCES [dbo].[NetClient]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AireNetClient'
CREATE INDEX [IX_FK_AireNetClient]
ON [dbo].[Aires]
    ([NetClient_Id]);
GO

-- Creating foreign key on [NetClientType_Id] in table 'NetClient'
ALTER TABLE [dbo].[NetClient]
ADD CONSTRAINT [FK_NetClientNetClientType]
    FOREIGN KEY ([NetClientType_Id])
    REFERENCES [dbo].[NetClientTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NetClientNetClientType'
CREATE INDEX [IX_FK_NetClientNetClientType]
ON [dbo].[NetClient]
    ([NetClientType_Id]);
GO

-- Creating foreign key on [Aire_Id] in table 'Epreuves'
ALTER TABLE [dbo].[Epreuves]
ADD CONSTRAINT [FK_AireEpreuve]
    FOREIGN KEY ([Aire_Id])
    REFERENCES [dbo].[Aires]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AireEpreuve'
CREATE INDEX [IX_FK_AireEpreuve]
ON [dbo].[Epreuves]
    ([Aire_Id]);
GO

-- Creating foreign key on [TypeEpreuve_Id] in table 'Epreuves'
ALTER TABLE [dbo].[Epreuves]
ADD CONSTRAINT [FK_TypeEpreuveEpreuve]
    FOREIGN KEY ([TypeEpreuve_Id])
    REFERENCES [dbo].[TypeEpreuves]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeEpreuveEpreuve'
CREATE INDEX [IX_FK_TypeEpreuveEpreuve]
ON [dbo].[Epreuves]
    ([TypeEpreuve_Id]);
GO

-- Creating foreign key on [ResponsableClub_Id] in table 'Clubs'
ALTER TABLE [dbo].[Clubs]
ADD CONSTRAINT [FK_ClubResponsableClub]
    FOREIGN KEY ([ResponsableClub_Id])
    REFERENCES [dbo].[ResponsablesClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubResponsableClub'
CREATE INDEX [IX_FK_ClubResponsableClub]
ON [dbo].[Clubs]
    ([ResponsableClub_Id]);
GO

-- Creating foreign key on [CategoriePratiquant_Id] in table 'Epreuves'
ALTER TABLE [dbo].[Epreuves]
ADD CONSTRAINT [FK_EpreuveCategoriePratiquant]
    FOREIGN KEY ([CategoriePratiquant_Id])
    REFERENCES [dbo].[CategoriePratiquants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EpreuveCategoriePratiquant'
CREATE INDEX [IX_FK_EpreuveCategoriePratiquant]
ON [dbo].[Epreuves]
    ([CategoriePratiquant_Id]);
GO

-- Creating foreign key on [CategoriePratiquant_Id] in table 'Competiteurs'
ALTER TABLE [dbo].[Competiteurs]
ADD CONSTRAINT [FK_CompetiteurCategoriePratiquant]
    FOREIGN KEY ([CategoriePratiquant_Id])
    REFERENCES [dbo].[CategoriePratiquants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetiteurCategoriePratiquant'
CREATE INDEX [IX_FK_CompetiteurCategoriePratiquant]
ON [dbo].[Competiteurs]
    ([CategoriePratiquant_Id]);
GO

-- Creating foreign key on [Club_Id] in table 'Competiteurs'
ALTER TABLE [dbo].[Competiteurs]
ADD CONSTRAINT [FK_ClubCompetiteur]
    FOREIGN KEY ([Club_Id])
    REFERENCES [dbo].[Clubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubCompetiteur'
CREATE INDEX [IX_FK_ClubCompetiteur]
ON [dbo].[Competiteurs]
    ([Club_Id]);
GO

-- Creating foreign key on [Club_Id] in table 'Encadrants'
ALTER TABLE [dbo].[Encadrants]
ADD CONSTRAINT [FK_ClubEncadrant]
    FOREIGN KEY ([Club_Id])
    REFERENCES [dbo].[Clubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubEncadrant'
CREATE INDEX [IX_FK_ClubEncadrant]
ON [dbo].[Encadrants]
    ([Club_Id]);
GO

-- Creating foreign key on [EquipeSongLuyen_Id] in table 'Competiteurs'
ALTER TABLE [dbo].[Competiteurs]
ADD CONSTRAINT [FK_EquipeSongLuyenCompetiteur]
    FOREIGN KEY ([EquipeSongLuyen_Id])
    REFERENCES [dbo].[EquipesSongLuyen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipeSongLuyenCompetiteur'
CREATE INDEX [IX_FK_EquipeSongLuyenCompetiteur]
ON [dbo].[Competiteurs]
    ([EquipeSongLuyen_Id]);
GO

-- Creating foreign key on [Encadrant_Id] in table 'Disponibilites'
ALTER TABLE [dbo].[Disponibilites]
ADD CONSTRAINT [FK_EncadrantDisponibilite]
    FOREIGN KEY ([Encadrant_Id])
    REFERENCES [dbo].[Encadrants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EncadrantDisponibilite'
CREATE INDEX [IX_FK_EncadrantDisponibilite]
ON [dbo].[Disponibilites]
    ([Encadrant_Id]);
GO

-- Creating foreign key on [Competiteur_Id] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [FK_CompetiteurParticipation]
    FOREIGN KEY ([Competiteur_Id])
    REFERENCES [dbo].[Competiteurs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetiteurParticipation'
CREATE INDEX [IX_FK_CompetiteurParticipation]
ON [dbo].[ParticipationSet]
    ([Competiteur_Id]);
GO

-- Creating foreign key on [Epreuve_Id] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [FK_EpreuveParticipation]
    FOREIGN KEY ([Epreuve_Id])
    REFERENCES [dbo].[Epreuves]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EpreuveParticipation'
CREATE INDEX [IX_FK_EpreuveParticipation]
ON [dbo].[ParticipationSet]
    ([Epreuve_Id]);
GO

-- Creating foreign key on [Resultat_Id] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [FK_ParticipationResultat]
    FOREIGN KEY ([Resultat_Id])
    REFERENCES [dbo].[Resultats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipationResultat'
CREATE INDEX [IX_FK_ParticipationResultat]
ON [dbo].[ParticipationSet]
    ([Resultat_Id]);
GO

-- Creating foreign key on [Id] in table 'Epreuves_EpreuveCombat'
ALTER TABLE [dbo].[Epreuves_EpreuveCombat]
ADD CONSTRAINT [FK_EpreuveCombat_inherits_Epreuve]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Epreuves]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Epreuves_EpreuveTechnique'
ALTER TABLE [dbo].[Epreuves_EpreuveTechnique]
ADD CONSTRAINT [FK_EpreuveTechnique_inherits_Epreuve]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Epreuves]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------