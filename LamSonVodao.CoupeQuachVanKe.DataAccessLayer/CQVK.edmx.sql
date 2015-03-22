
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2015 00:15:02
-- Generated from EDMX file: E:\Workspace\CSharp\CoupeQVK\DataAccessLayer\CQVK.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CoupeQVK2015];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClubParticipant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet] DROP CONSTRAINT [FK_ClubParticipant];
GO
IF OBJECT_ID(N'[dbo].[FK_AdresseClub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdresseSet] DROP CONSTRAINT [FK_AdresseClub];
GO
IF OBJECT_ID(N'[dbo].[FK_CoupeAdresse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoupeSet] DROP CONSTRAINT [FK_CoupeAdresse];
GO
IF OBJECT_ID(N'[dbo].[FK_CoupeAire]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AireSet] DROP CONSTRAINT [FK_CoupeAire];
GO
IF OBJECT_ID(N'[dbo].[FK_AireEpreuve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpreuveSet] DROP CONSTRAINT [FK_AireEpreuve];
GO
IF OBJECT_ID(N'[dbo].[FK_EncadrantEpreuve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet_Encadrant] DROP CONSTRAINT [FK_EncadrantEpreuve];
GO
IF OBJECT_ID(N'[dbo].[FK_CompétiteurClassement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultatSet] DROP CONSTRAINT [FK_CompétiteurClassement];
GO
IF OBJECT_ID(N'[dbo].[FK_EpreuveClassement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultatSet] DROP CONSTRAINT [FK_EpreuveClassement];
GO
IF OBJECT_ID(N'[dbo].[FK_AdresseResponsable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdresseSet] DROP CONSTRAINT [FK_AdresseResponsable];
GO
IF OBJECT_ID(N'[dbo].[FK_EncadrantCompetiteurTechnique]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet_Competiteur] DROP CONSTRAINT [FK_EncadrantCompetiteurTechnique];
GO
IF OBJECT_ID(N'[dbo].[FK_EncadrantRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleSet] DROP CONSTRAINT [FK_EncadrantRole];
GO
IF OBJECT_ID(N'[dbo].[FK_EpreuveStatut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpreuveSet] DROP CONSTRAINT [FK_EpreuveStatut];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetiteurEpreuve_Competiteur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetiteurEpreuve] DROP CONSTRAINT [FK_CompetiteurEpreuve_Competiteur];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetiteurEpreuve_Epreuve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetiteurEpreuve] DROP CONSTRAINT [FK_CompetiteurEpreuve_Epreuve];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePeriode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PeriodeSet] DROP CONSTRAINT [FK_RolePeriode];
GO
IF OBJECT_ID(N'[dbo].[FK_EpreuveDetailEpreuve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpreuveSet] DROP CONSTRAINT [FK_EpreuveDetailEpreuve];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailEpreuveSexe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailsSet] DROP CONSTRAINT [FK_DetailEpreuveSexe];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailEpreuveCategorieGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailsSet] DROP CONSTRAINT [FK_DetailEpreuveCategorieGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailEpreuveCategoriePoids]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailsSet] DROP CONSTRAINT [FK_DetailEpreuveCategoriePoids];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailEpreuveTypeEpreuve]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailsSet] DROP CONSTRAINT [FK_DetailEpreuveTypeEpreuve];
GO
IF OBJECT_ID(N'[dbo].[FK_Encadrant_inherits_Participant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet_Encadrant] DROP CONSTRAINT [FK_Encadrant_inherits_Participant];
GO
IF OBJECT_ID(N'[dbo].[FK_Competiteur_inherits_Participant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet_Competiteur] DROP CONSTRAINT [FK_Competiteur_inherits_Participant];
GO
IF OBJECT_ID(N'[dbo].[FK_Responsable_inherits_Participant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantSet_Responsable] DROP CONSTRAINT [FK_Responsable_inherits_Participant];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ParticipantSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantSet];
GO
IF OBJECT_ID(N'[dbo].[AireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AireSet];
GO
IF OBJECT_ID(N'[dbo].[CoupeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoupeSet];
GO
IF OBJECT_ID(N'[dbo].[ClubSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubSet];
GO
IF OBJECT_ID(N'[dbo].[AdresseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdresseSet];
GO
IF OBJECT_ID(N'[dbo].[EpreuveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EpreuveSet];
GO
IF OBJECT_ID(N'[dbo].[ResultatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResultatSet];
GO
IF OBJECT_ID(N'[dbo].[RoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleSet];
GO
IF OBJECT_ID(N'[dbo].[StatutSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatutSet];
GO
IF OBJECT_ID(N'[dbo].[PeriodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodeSet];
GO
IF OBJECT_ID(N'[dbo].[DetailsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetailsSet];
GO
IF OBJECT_ID(N'[dbo].[SexeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SexeSet];
GO
IF OBJECT_ID(N'[dbo].[CategorieGradeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorieGradeSet];
GO
IF OBJECT_ID(N'[dbo].[TypeEpreuveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeEpreuveSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriePoidsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriePoidsSet];
GO
IF OBJECT_ID(N'[dbo].[ParticipantSet_Encadrant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantSet_Encadrant];
GO
IF OBJECT_ID(N'[dbo].[ParticipantSet_Competiteur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantSet_Competiteur];
GO
IF OBJECT_ID(N'[dbo].[ParticipantSet_Responsable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantSet_Responsable];
GO
IF OBJECT_ID(N'[dbo].[CompetiteurEpreuve]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetiteurEpreuve];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ParticipantSet'
CREATE TABLE [dbo].[ParticipantSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [ClubParticipant_Participant_Id] int  NOT NULL
);
GO

-- Creating table 'AireSet'
CREATE TABLE [dbo].[AireSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Coupe_Id] int  NOT NULL
);
GO

-- Creating table 'CoupeSet'
CREATE TABLE [dbo].[CoupeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Annee] nvarchar(max)  NOT NULL,
    [Adresse_Id] int  NOT NULL
);
GO

-- Creating table 'ClubSet'
CREATE TABLE [dbo].[ClubSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [NumeroAffiliation] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdresseSet'
CREATE TABLE [dbo].[AdresseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Voie] nvarchar(max)  NOT NULL,
    [Numero] nvarchar(max)  NOT NULL,
    [Complement] nvarchar(max)  NOT NULL,
    [CodePostal] nvarchar(max)  NOT NULL,
    [Ville] nvarchar(max)  NOT NULL,
    [AdresseClub_Adresse_Id] int  NOT NULL,
    [AdresseResponsable_Adresse_Id] int  NOT NULL
);
GO

-- Creating table 'EpreuveSet'
CREATE TABLE [dbo].[EpreuveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Aire_Id] int  NOT NULL,
    [Statut_Id] int  NOT NULL,
    [Details_Id] int  NOT NULL
);
GO

-- Creating table 'ResultatSet'
CREATE TABLE [dbo].[ResultatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Classement] nvarchar(max)  NOT NULL,
    [Score] nvarchar(max)  NOT NULL,
    [Abandon] nvarchar(max)  NOT NULL,
    [Blessure] nvarchar(max)  NOT NULL,
    [Disqualification] nvarchar(max)  NOT NULL,
    [Absence] nvarchar(max)  NOT NULL,
    [Renvoi] nvarchar(max)  NOT NULL,
    [Competiteur_Id] int  NOT NULL,
    [Epreuve_Id] int  NOT NULL
);
GO

-- Creating table 'RoleSet'
CREATE TABLE [dbo].[RoleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Encadrant_Id] int  NOT NULL
);
GO

-- Creating table 'StatutSet'
CREATE TABLE [dbo].[StatutSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PeriodeSet'
CREATE TABLE [dbo].[PeriodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Matin] nvarchar(max)  NOT NULL,
    [ApresMidi] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'DetailsSet'
CREATE TABLE [dbo].[DetailsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sexe_Id] int  NOT NULL,
    [CategorieGrade_Id] int  NOT NULL,
    [CategoriePoids_Id] int  NOT NULL,
    [TypeEpreuve_Id] int  NOT NULL
);
GO

-- Creating table 'SexeSet'
CREATE TABLE [dbo].[SexeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorieGradeSet'
CREATE TABLE [dbo].[CategorieGradeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeEpreuveSet'
CREATE TABLE [dbo].[TypeEpreuveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriePoidsSet'
CREATE TABLE [dbo].[CategoriePoidsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ValeurBasse] nvarchar(max)  NOT NULL,
    [ValeurHaute] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ParticipantSet_Encadrant'
CREATE TABLE [dbo].[ParticipantSet_Encadrant] (
    [TailleTenue] nvarchar(max)  NOT NULL,
    [EstCompetiteur] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Epreuve_Id] int  NOT NULL
);
GO

-- Creating table 'ParticipantSet_Competiteur'
CREATE TABLE [dbo].[ParticipantSet_Competiteur] (
    [Niveau] nvarchar(max)  NOT NULL,
    [CategorieGrade] nvarchar(max)  NOT NULL,
    [DateNaissance] nvarchar(max)  NOT NULL,
    [Sexe] nvarchar(max)  NOT NULL,
    [LicenceFFKDA] nvarchar(max)  NOT NULL,
    [InscriptionValidee] nvarchar(max)  NOT NULL,
    [AnneePratique] nvarchar(max)  NOT NULL,
    [Poids] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Encadrant_Id] int  NOT NULL
);
GO

-- Creating table 'ParticipantSet_Responsable'
CREATE TABLE [dbo].[ParticipantSet_Responsable] (
    [Telephone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'CompetiteurEpreuve'
CREATE TABLE [dbo].[CompetiteurEpreuve] (
    [Competiteurs_Id] int  NOT NULL,
    [Epreuves_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ParticipantSet'
ALTER TABLE [dbo].[ParticipantSet]
ADD CONSTRAINT [PK_ParticipantSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AireSet'
ALTER TABLE [dbo].[AireSet]
ADD CONSTRAINT [PK_AireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoupeSet'
ALTER TABLE [dbo].[CoupeSet]
ADD CONSTRAINT [PK_CoupeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClubSet'
ALTER TABLE [dbo].[ClubSet]
ADD CONSTRAINT [PK_ClubSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdresseSet'
ALTER TABLE [dbo].[AdresseSet]
ADD CONSTRAINT [PK_AdresseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EpreuveSet'
ALTER TABLE [dbo].[EpreuveSet]
ADD CONSTRAINT [PK_EpreuveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResultatSet'
ALTER TABLE [dbo].[ResultatSet]
ADD CONSTRAINT [PK_ResultatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [PK_RoleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatutSet'
ALTER TABLE [dbo].[StatutSet]
ADD CONSTRAINT [PK_StatutSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodeSet'
ALTER TABLE [dbo].[PeriodeSet]
ADD CONSTRAINT [PK_PeriodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetailsSet'
ALTER TABLE [dbo].[DetailsSet]
ADD CONSTRAINT [PK_DetailsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SexeSet'
ALTER TABLE [dbo].[SexeSet]
ADD CONSTRAINT [PK_SexeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorieGradeSet'
ALTER TABLE [dbo].[CategorieGradeSet]
ADD CONSTRAINT [PK_CategorieGradeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeEpreuveSet'
ALTER TABLE [dbo].[TypeEpreuveSet]
ADD CONSTRAINT [PK_TypeEpreuveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriePoidsSet'
ALTER TABLE [dbo].[CategoriePoidsSet]
ADD CONSTRAINT [PK_CategoriePoidsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipantSet_Encadrant'
ALTER TABLE [dbo].[ParticipantSet_Encadrant]
ADD CONSTRAINT [PK_ParticipantSet_Encadrant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipantSet_Competiteur'
ALTER TABLE [dbo].[ParticipantSet_Competiteur]
ADD CONSTRAINT [PK_ParticipantSet_Competiteur]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipantSet_Responsable'
ALTER TABLE [dbo].[ParticipantSet_Responsable]
ADD CONSTRAINT [PK_ParticipantSet_Responsable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Competiteurs_Id], [Epreuves_Id] in table 'CompetiteurEpreuve'
ALTER TABLE [dbo].[CompetiteurEpreuve]
ADD CONSTRAINT [PK_CompetiteurEpreuve]
    PRIMARY KEY CLUSTERED ([Competiteurs_Id], [Epreuves_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClubParticipant_Participant_Id] in table 'ParticipantSet'
ALTER TABLE [dbo].[ParticipantSet]
ADD CONSTRAINT [FK_ClubParticipant]
    FOREIGN KEY ([ClubParticipant_Participant_Id])
    REFERENCES [dbo].[ClubSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubParticipant'
CREATE INDEX [IX_FK_ClubParticipant]
ON [dbo].[ParticipantSet]
    ([ClubParticipant_Participant_Id]);
GO

-- Creating foreign key on [AdresseClub_Adresse_Id] in table 'AdresseSet'
ALTER TABLE [dbo].[AdresseSet]
ADD CONSTRAINT [FK_AdresseClub]
    FOREIGN KEY ([AdresseClub_Adresse_Id])
    REFERENCES [dbo].[ClubSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdresseClub'
CREATE INDEX [IX_FK_AdresseClub]
ON [dbo].[AdresseSet]
    ([AdresseClub_Adresse_Id]);
GO

-- Creating foreign key on [Adresse_Id] in table 'CoupeSet'
ALTER TABLE [dbo].[CoupeSet]
ADD CONSTRAINT [FK_CoupeAdresse]
    FOREIGN KEY ([Adresse_Id])
    REFERENCES [dbo].[AdresseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoupeAdresse'
CREATE INDEX [IX_FK_CoupeAdresse]
ON [dbo].[CoupeSet]
    ([Adresse_Id]);
GO

-- Creating foreign key on [Coupe_Id] in table 'AireSet'
ALTER TABLE [dbo].[AireSet]
ADD CONSTRAINT [FK_CoupeAire]
    FOREIGN KEY ([Coupe_Id])
    REFERENCES [dbo].[CoupeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoupeAire'
CREATE INDEX [IX_FK_CoupeAire]
ON [dbo].[AireSet]
    ([Coupe_Id]);
GO

-- Creating foreign key on [Aire_Id] in table 'EpreuveSet'
ALTER TABLE [dbo].[EpreuveSet]
ADD CONSTRAINT [FK_AireEpreuve]
    FOREIGN KEY ([Aire_Id])
    REFERENCES [dbo].[AireSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AireEpreuve'
CREATE INDEX [IX_FK_AireEpreuve]
ON [dbo].[EpreuveSet]
    ([Aire_Id]);
GO

-- Creating foreign key on [Epreuve_Id] in table 'ParticipantSet_Encadrant'
ALTER TABLE [dbo].[ParticipantSet_Encadrant]
ADD CONSTRAINT [FK_EncadrantEpreuve]
    FOREIGN KEY ([Epreuve_Id])
    REFERENCES [dbo].[EpreuveSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EncadrantEpreuve'
CREATE INDEX [IX_FK_EncadrantEpreuve]
ON [dbo].[ParticipantSet_Encadrant]
    ([Epreuve_Id]);
GO

-- Creating foreign key on [Competiteur_Id] in table 'ResultatSet'
ALTER TABLE [dbo].[ResultatSet]
ADD CONSTRAINT [FK_CompétiteurClassement]
    FOREIGN KEY ([Competiteur_Id])
    REFERENCES [dbo].[ParticipantSet_Competiteur]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompétiteurClassement'
CREATE INDEX [IX_FK_CompétiteurClassement]
ON [dbo].[ResultatSet]
    ([Competiteur_Id]);
GO

-- Creating foreign key on [Epreuve_Id] in table 'ResultatSet'
ALTER TABLE [dbo].[ResultatSet]
ADD CONSTRAINT [FK_EpreuveClassement]
    FOREIGN KEY ([Epreuve_Id])
    REFERENCES [dbo].[EpreuveSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EpreuveClassement'
CREATE INDEX [IX_FK_EpreuveClassement]
ON [dbo].[ResultatSet]
    ([Epreuve_Id]);
GO

-- Creating foreign key on [AdresseResponsable_Adresse_Id] in table 'AdresseSet'
ALTER TABLE [dbo].[AdresseSet]
ADD CONSTRAINT [FK_AdresseResponsable]
    FOREIGN KEY ([AdresseResponsable_Adresse_Id])
    REFERENCES [dbo].[ParticipantSet_Responsable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdresseResponsable'
CREATE INDEX [IX_FK_AdresseResponsable]
ON [dbo].[AdresseSet]
    ([AdresseResponsable_Adresse_Id]);
GO

-- Creating foreign key on [Encadrant_Id] in table 'ParticipantSet_Competiteur'
ALTER TABLE [dbo].[ParticipantSet_Competiteur]
ADD CONSTRAINT [FK_EncadrantCompetiteurTechnique]
    FOREIGN KEY ([Encadrant_Id])
    REFERENCES [dbo].[ParticipantSet_Encadrant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EncadrantCompetiteurTechnique'
CREATE INDEX [IX_FK_EncadrantCompetiteurTechnique]
ON [dbo].[ParticipantSet_Competiteur]
    ([Encadrant_Id]);
GO

-- Creating foreign key on [Encadrant_Id] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [FK_EncadrantRole]
    FOREIGN KEY ([Encadrant_Id])
    REFERENCES [dbo].[ParticipantSet_Encadrant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EncadrantRole'
CREATE INDEX [IX_FK_EncadrantRole]
ON [dbo].[RoleSet]
    ([Encadrant_Id]);
GO

-- Creating foreign key on [Statut_Id] in table 'EpreuveSet'
ALTER TABLE [dbo].[EpreuveSet]
ADD CONSTRAINT [FK_EpreuveStatut]
    FOREIGN KEY ([Statut_Id])
    REFERENCES [dbo].[StatutSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EpreuveStatut'
CREATE INDEX [IX_FK_EpreuveStatut]
ON [dbo].[EpreuveSet]
    ([Statut_Id]);
GO

-- Creating foreign key on [Competiteurs_Id] in table 'CompetiteurEpreuve'
ALTER TABLE [dbo].[CompetiteurEpreuve]
ADD CONSTRAINT [FK_CompetiteurEpreuve_Competiteur]
    FOREIGN KEY ([Competiteurs_Id])
    REFERENCES [dbo].[ParticipantSet_Competiteur]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Epreuves_Id] in table 'CompetiteurEpreuve'
ALTER TABLE [dbo].[CompetiteurEpreuve]
ADD CONSTRAINT [FK_CompetiteurEpreuve_Epreuve]
    FOREIGN KEY ([Epreuves_Id])
    REFERENCES [dbo].[EpreuveSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetiteurEpreuve_Epreuve'
CREATE INDEX [IX_FK_CompetiteurEpreuve_Epreuve]
ON [dbo].[CompetiteurEpreuve]
    ([Epreuves_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'PeriodeSet'
ALTER TABLE [dbo].[PeriodeSet]
ADD CONSTRAINT [FK_RolePeriode]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[RoleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePeriode'
CREATE INDEX [IX_FK_RolePeriode]
ON [dbo].[PeriodeSet]
    ([Role_Id]);
GO

-- Creating foreign key on [Details_Id] in table 'EpreuveSet'
ALTER TABLE [dbo].[EpreuveSet]
ADD CONSTRAINT [FK_EpreuveDetailEpreuve]
    FOREIGN KEY ([Details_Id])
    REFERENCES [dbo].[DetailsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EpreuveDetailEpreuve'
CREATE INDEX [IX_FK_EpreuveDetailEpreuve]
ON [dbo].[EpreuveSet]
    ([Details_Id]);
GO

-- Creating foreign key on [Sexe_Id] in table 'DetailsSet'
ALTER TABLE [dbo].[DetailsSet]
ADD CONSTRAINT [FK_DetailEpreuveSexe]
    FOREIGN KEY ([Sexe_Id])
    REFERENCES [dbo].[SexeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailEpreuveSexe'
CREATE INDEX [IX_FK_DetailEpreuveSexe]
ON [dbo].[DetailsSet]
    ([Sexe_Id]);
GO

-- Creating foreign key on [CategorieGrade_Id] in table 'DetailsSet'
ALTER TABLE [dbo].[DetailsSet]
ADD CONSTRAINT [FK_DetailEpreuveCategorieGrade]
    FOREIGN KEY ([CategorieGrade_Id])
    REFERENCES [dbo].[CategorieGradeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailEpreuveCategorieGrade'
CREATE INDEX [IX_FK_DetailEpreuveCategorieGrade]
ON [dbo].[DetailsSet]
    ([CategorieGrade_Id]);
GO

-- Creating foreign key on [CategoriePoids_Id] in table 'DetailsSet'
ALTER TABLE [dbo].[DetailsSet]
ADD CONSTRAINT [FK_DetailEpreuveCategoriePoids]
    FOREIGN KEY ([CategoriePoids_Id])
    REFERENCES [dbo].[CategoriePoidsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailEpreuveCategoriePoids'
CREATE INDEX [IX_FK_DetailEpreuveCategoriePoids]
ON [dbo].[DetailsSet]
    ([CategoriePoids_Id]);
GO

-- Creating foreign key on [TypeEpreuve_Id] in table 'DetailsSet'
ALTER TABLE [dbo].[DetailsSet]
ADD CONSTRAINT [FK_DetailEpreuveTypeEpreuve]
    FOREIGN KEY ([TypeEpreuve_Id])
    REFERENCES [dbo].[TypeEpreuveSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailEpreuveTypeEpreuve'
CREATE INDEX [IX_FK_DetailEpreuveTypeEpreuve]
ON [dbo].[DetailsSet]
    ([TypeEpreuve_Id]);
GO

-- Creating foreign key on [Id] in table 'ParticipantSet_Encadrant'
ALTER TABLE [dbo].[ParticipantSet_Encadrant]
ADD CONSTRAINT [FK_Encadrant_inherits_Participant]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ParticipantSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ParticipantSet_Competiteur'
ALTER TABLE [dbo].[ParticipantSet_Competiteur]
ADD CONSTRAINT [FK_Competiteur_inherits_Participant]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ParticipantSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ParticipantSet_Responsable'
ALTER TABLE [dbo].[ParticipantSet_Responsable]
ADD CONSTRAINT [FK_Responsable_inherits_Participant]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ParticipantSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------