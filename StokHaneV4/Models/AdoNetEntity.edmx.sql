
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/18/2021 17:09:28
-- Generated from EDMX file: C:\Users\JesKs\source\repos\StokHaneV4\StokHaneV4\Models\AdoNetEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB0345WB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TabHane_Tabisletme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabHane] DROP CONSTRAINT [FK_TabHane_Tabisletme];
GO
IF OBJECT_ID(N'[dbo].[FK_TabKullanici_TabYetki]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabKullanici] DROP CONSTRAINT [FK_TabKullanici_TabYetki];
GO
IF OBJECT_ID(N'[dbo].[FK_TabLogRasyon_TabHane]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabLogRasyon] DROP CONSTRAINT [FK_TabLogRasyon_TabHane];
GO
IF OBJECT_ID(N'[dbo].[FK_TabLogRasyon_TabKullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabLogRasyon] DROP CONSTRAINT [FK_TabLogRasyon_TabKullanici];
GO
IF OBJECT_ID(N'[dbo].[FK_TabLogRasyon_TabRasyon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabLogRasyon] DROP CONSTRAINT [FK_TabLogRasyon_TabRasyon];
GO
IF OBJECT_ID(N'[dbo].[FK_TabRasyon_TabKullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabRasyon] DROP CONSTRAINT [FK_TabRasyon_TabKullanici];
GO
IF OBJECT_ID(N'[dbo].[FK_Tabrasyontarifi_TabRasyon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tabrasyontarifi] DROP CONSTRAINT [FK_Tabrasyontarifi_TabRasyon];
GO
IF OBJECT_ID(N'[dbo].[FK_Tabrasyontarifi_Taburun]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tabrasyontarifi] DROP CONSTRAINT [FK_Tabrasyontarifi_Taburun];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_TabAlsatkul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_TabAlsatkul];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_Tabirsaliye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_Tabirsaliye];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_TabKullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_TabKullanici];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_TabKullanici1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_TabKullanici1];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_TabmiktarCins]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_TabmiktarCins];
GO
IF OBJECT_ID(N'[dbo].[FK_TabUrunGenel_Taburun]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TabUrunGenel] DROP CONSTRAINT [FK_TabUrunGenel_Taburun];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TabAlsatkul]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabAlsatkul];
GO
IF OBJECT_ID(N'[dbo].[TabHane]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabHane];
GO
IF OBJECT_ID(N'[dbo].[Tabirsaliye]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tabirsaliye];
GO
IF OBJECT_ID(N'[dbo].[Tabisletme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tabisletme];
GO
IF OBJECT_ID(N'[dbo].[TabKullanici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabKullanici];
GO
IF OBJECT_ID(N'[dbo].[TabLogRasyon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabLogRasyon];
GO
IF OBJECT_ID(N'[dbo].[TabmiktarCins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabmiktarCins];
GO
IF OBJECT_ID(N'[dbo].[TabRasyon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabRasyon];
GO
IF OBJECT_ID(N'[dbo].[Tabrasyontarifi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tabrasyontarifi];
GO
IF OBJECT_ID(N'[dbo].[Taburun]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taburun];
GO
IF OBJECT_ID(N'[dbo].[TabUrunGenel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabUrunGenel];
GO
IF OBJECT_ID(N'[dbo].[TabYetki]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabYetki];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TabAlsatkul'
CREATE TABLE [dbo].[TabAlsatkul] (
    [idalsatkul] int IDENTITY(1,1) NOT NULL,
    [alsatkultur] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TabHane'
CREATE TABLE [dbo].[TabHane] (
    [idTavukhane] int IDENTITY(1,1) NOT NULL,
    [idisletme] int  NOT NULL,
    [TavukhaneAdi] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Tabirsaliye'
CREATE TABLE [dbo].[Tabirsaliye] (
    [idirsaliye] int IDENTITY(1,1) NOT NULL,
    [irsaliyeKod] nvarchar(50)  NOT NULL,
    [girdiTarih] datetime  NOT NULL,
    [firma] nvarchar(50)  NULL,
    [firma2] nvarchar(50)  NULL,
    [Aktiflik] bit  NULL
);
GO

-- Creating table 'Tabisletme'
CREATE TABLE [dbo].[Tabisletme] (
    [idisletme] int  NOT NULL,
    [isletmeKod] nvarchar(50)  NOT NULL,
    [isletmeAdi] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TabKullanici'
CREATE TABLE [dbo].[TabKullanici] (
    [idKullanici] int IDENTITY(1,1) NOT NULL,
    [KulAdi] nvarchar(50)  NOT NULL,
    [kulisim] nvarchar(50)  NOT NULL,
    [kulsoyisim] nvarchar(50)  NOT NULL,
    [eposta] nvarchar(50)  NOT NULL,
    [tel] nvarchar(50)  NOT NULL,
    [idyetki] int  NOT NULL,
    [sonerisim] datetime  NOT NULL,
    [kulsif] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TabLogRasyon'
CREATE TABLE [dbo].[TabLogRasyon] (
    [idislem] int IDENTITY(1,1) NOT NULL,
    [idRasyon] int  NOT NULL,
    [İdHane] int  NOT NULL,
    [idKullanici] int  NOT NULL,
    [islemTarihi] datetime  NOT NULL
);
GO

-- Creating table 'TabmiktarCins'
CREATE TABLE [dbo].[TabmiktarCins] (
    [idmiktarcins] int IDENTITY(1,1) NOT NULL,
    [miktarturu] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TabRasyon'
CREATE TABLE [dbo].[TabRasyon] (
    [idRasyon] int IDENTITY(1,1) NOT NULL,
    [RasyonAdi] nvarchar(50)  NOT NULL,
    [Aktiflik] bit  NULL,
    [idkullanici] int  NULL
);
GO

-- Creating table 'Tabrasyontarifi'
CREATE TABLE [dbo].[Tabrasyontarifi] (
    [idRasyonTarif] int IDENTITY(1,1) NOT NULL,
    [idRasyon] int  NOT NULL,
    [TarifMiktar] float  NOT NULL,
    [idUrun] int  NOT NULL
);
GO

-- Creating table 'Taburun'
CREATE TABLE [dbo].[Taburun] (
    [idurun] int IDENTITY(1,1) NOT NULL,
    [UrunAdi] nvarchar(50)  NOT NULL,
    [stokKod] nvarchar(50)  NULL,
    [Aktiflik] bit  NULL
);
GO

-- Creating table 'TabUrunGenel'
CREATE TABLE [dbo].[TabUrunGenel] (
    [idurungenel] int IDENTITY(1,1) NOT NULL,
    [idUrun] int  NOT NULL,
    [idirsaliye] int  NOT NULL,
    [miktar] float  NOT NULL,
    [idmiktarcins] int  NOT NULL,
    [idalsatkul] int  NOT NULL,
    [fiyat] decimal(19,4)  NULL,
    [Aktiflik] bit  NULL,
    [idkullanici] int  NULL,
    [miktarKalan] float  NULL
);
GO

-- Creating table 'TabYetki'
CREATE TABLE [dbo].[TabYetki] (
    [idYetki] int IDENTITY(1,1) NOT NULL,
    [Yetkiadi] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [idalsatkul] in table 'TabAlsatkul'
ALTER TABLE [dbo].[TabAlsatkul]
ADD CONSTRAINT [PK_TabAlsatkul]
    PRIMARY KEY CLUSTERED ([idalsatkul] ASC);
GO

-- Creating primary key on [idTavukhane] in table 'TabHane'
ALTER TABLE [dbo].[TabHane]
ADD CONSTRAINT [PK_TabHane]
    PRIMARY KEY CLUSTERED ([idTavukhane] ASC);
GO

-- Creating primary key on [idirsaliye] in table 'Tabirsaliye'
ALTER TABLE [dbo].[Tabirsaliye]
ADD CONSTRAINT [PK_Tabirsaliye]
    PRIMARY KEY CLUSTERED ([idirsaliye] ASC);
GO

-- Creating primary key on [idisletme] in table 'Tabisletme'
ALTER TABLE [dbo].[Tabisletme]
ADD CONSTRAINT [PK_Tabisletme]
    PRIMARY KEY CLUSTERED ([idisletme] ASC);
GO

-- Creating primary key on [idKullanici] in table 'TabKullanici'
ALTER TABLE [dbo].[TabKullanici]
ADD CONSTRAINT [PK_TabKullanici]
    PRIMARY KEY CLUSTERED ([idKullanici] ASC);
GO

-- Creating primary key on [idislem] in table 'TabLogRasyon'
ALTER TABLE [dbo].[TabLogRasyon]
ADD CONSTRAINT [PK_TabLogRasyon]
    PRIMARY KEY CLUSTERED ([idislem] ASC);
GO

-- Creating primary key on [idmiktarcins] in table 'TabmiktarCins'
ALTER TABLE [dbo].[TabmiktarCins]
ADD CONSTRAINT [PK_TabmiktarCins]
    PRIMARY KEY CLUSTERED ([idmiktarcins] ASC);
GO

-- Creating primary key on [idRasyon] in table 'TabRasyon'
ALTER TABLE [dbo].[TabRasyon]
ADD CONSTRAINT [PK_TabRasyon]
    PRIMARY KEY CLUSTERED ([idRasyon] ASC);
GO

-- Creating primary key on [idRasyonTarif] in table 'Tabrasyontarifi'
ALTER TABLE [dbo].[Tabrasyontarifi]
ADD CONSTRAINT [PK_Tabrasyontarifi]
    PRIMARY KEY CLUSTERED ([idRasyonTarif] ASC);
GO

-- Creating primary key on [idurun] in table 'Taburun'
ALTER TABLE [dbo].[Taburun]
ADD CONSTRAINT [PK_Taburun]
    PRIMARY KEY CLUSTERED ([idurun] ASC);
GO

-- Creating primary key on [idurungenel] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [PK_TabUrunGenel]
    PRIMARY KEY CLUSTERED ([idurungenel] ASC);
GO

-- Creating primary key on [idYetki] in table 'TabYetki'
ALTER TABLE [dbo].[TabYetki]
ADD CONSTRAINT [PK_TabYetki]
    PRIMARY KEY CLUSTERED ([idYetki] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idalsatkul] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_TabAlsatkul]
    FOREIGN KEY ([idalsatkul])
    REFERENCES [dbo].[TabAlsatkul]
        ([idalsatkul])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_TabAlsatkul'
CREATE INDEX [IX_FK_TabUrunGenel_TabAlsatkul]
ON [dbo].[TabUrunGenel]
    ([idalsatkul]);
GO

-- Creating foreign key on [idisletme] in table 'TabHane'
ALTER TABLE [dbo].[TabHane]
ADD CONSTRAINT [FK_TabHane_Tabisletme]
    FOREIGN KEY ([idisletme])
    REFERENCES [dbo].[Tabisletme]
        ([idisletme])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabHane_Tabisletme'
CREATE INDEX [IX_FK_TabHane_Tabisletme]
ON [dbo].[TabHane]
    ([idisletme]);
GO

-- Creating foreign key on [İdHane] in table 'TabLogRasyon'
ALTER TABLE [dbo].[TabLogRasyon]
ADD CONSTRAINT [FK_TabLogRasyon_TabHane]
    FOREIGN KEY ([İdHane])
    REFERENCES [dbo].[TabHane]
        ([idTavukhane])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabLogRasyon_TabHane'
CREATE INDEX [IX_FK_TabLogRasyon_TabHane]
ON [dbo].[TabLogRasyon]
    ([İdHane]);
GO

-- Creating foreign key on [idirsaliye] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_Tabirsaliye]
    FOREIGN KEY ([idirsaliye])
    REFERENCES [dbo].[Tabirsaliye]
        ([idirsaliye])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_Tabirsaliye'
CREATE INDEX [IX_FK_TabUrunGenel_Tabirsaliye]
ON [dbo].[TabUrunGenel]
    ([idirsaliye]);
GO

-- Creating foreign key on [idyetki] in table 'TabKullanici'
ALTER TABLE [dbo].[TabKullanici]
ADD CONSTRAINT [FK_TabKullanici_TabYetki]
    FOREIGN KEY ([idyetki])
    REFERENCES [dbo].[TabYetki]
        ([idYetki])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabKullanici_TabYetki'
CREATE INDEX [IX_FK_TabKullanici_TabYetki]
ON [dbo].[TabKullanici]
    ([idyetki]);
GO

-- Creating foreign key on [idKullanici] in table 'TabLogRasyon'
ALTER TABLE [dbo].[TabLogRasyon]
ADD CONSTRAINT [FK_TabLogRasyon_TabKullanici]
    FOREIGN KEY ([idKullanici])
    REFERENCES [dbo].[TabKullanici]
        ([idKullanici])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabLogRasyon_TabKullanici'
CREATE INDEX [IX_FK_TabLogRasyon_TabKullanici]
ON [dbo].[TabLogRasyon]
    ([idKullanici]);
GO

-- Creating foreign key on [idkullanici] in table 'TabRasyon'
ALTER TABLE [dbo].[TabRasyon]
ADD CONSTRAINT [FK_TabRasyon_TabKullanici]
    FOREIGN KEY ([idkullanici])
    REFERENCES [dbo].[TabKullanici]
        ([idKullanici])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabRasyon_TabKullanici'
CREATE INDEX [IX_FK_TabRasyon_TabKullanici]
ON [dbo].[TabRasyon]
    ([idkullanici]);
GO

-- Creating foreign key on [idkullanici] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_TabKullanici]
    FOREIGN KEY ([idkullanici])
    REFERENCES [dbo].[TabKullanici]
        ([idKullanici])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_TabKullanici'
CREATE INDEX [IX_FK_TabUrunGenel_TabKullanici]
ON [dbo].[TabUrunGenel]
    ([idkullanici]);
GO

-- Creating foreign key on [idkullanici] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_TabKullanici1]
    FOREIGN KEY ([idkullanici])
    REFERENCES [dbo].[TabKullanici]
        ([idKullanici])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_TabKullanici1'
CREATE INDEX [IX_FK_TabUrunGenel_TabKullanici1]
ON [dbo].[TabUrunGenel]
    ([idkullanici]);
GO

-- Creating foreign key on [idRasyon] in table 'TabLogRasyon'
ALTER TABLE [dbo].[TabLogRasyon]
ADD CONSTRAINT [FK_TabLogRasyon_TabRasyon]
    FOREIGN KEY ([idRasyon])
    REFERENCES [dbo].[TabRasyon]
        ([idRasyon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabLogRasyon_TabRasyon'
CREATE INDEX [IX_FK_TabLogRasyon_TabRasyon]
ON [dbo].[TabLogRasyon]
    ([idRasyon]);
GO

-- Creating foreign key on [idmiktarcins] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_TabmiktarCins]
    FOREIGN KEY ([idmiktarcins])
    REFERENCES [dbo].[TabmiktarCins]
        ([idmiktarcins])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_TabmiktarCins'
CREATE INDEX [IX_FK_TabUrunGenel_TabmiktarCins]
ON [dbo].[TabUrunGenel]
    ([idmiktarcins]);
GO

-- Creating foreign key on [idRasyon] in table 'Tabrasyontarifi'
ALTER TABLE [dbo].[Tabrasyontarifi]
ADD CONSTRAINT [FK_Tabrasyontarifi_TabRasyon]
    FOREIGN KEY ([idRasyon])
    REFERENCES [dbo].[TabRasyon]
        ([idRasyon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tabrasyontarifi_TabRasyon'
CREATE INDEX [IX_FK_Tabrasyontarifi_TabRasyon]
ON [dbo].[Tabrasyontarifi]
    ([idRasyon]);
GO

-- Creating foreign key on [idUrun] in table 'Tabrasyontarifi'
ALTER TABLE [dbo].[Tabrasyontarifi]
ADD CONSTRAINT [FK_Tabrasyontarifi_Taburun]
    FOREIGN KEY ([idUrun])
    REFERENCES [dbo].[Taburun]
        ([idurun])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tabrasyontarifi_Taburun'
CREATE INDEX [IX_FK_Tabrasyontarifi_Taburun]
ON [dbo].[Tabrasyontarifi]
    ([idUrun]);
GO

-- Creating foreign key on [idUrun] in table 'TabUrunGenel'
ALTER TABLE [dbo].[TabUrunGenel]
ADD CONSTRAINT [FK_TabUrunGenel_Taburun]
    FOREIGN KEY ([idUrun])
    REFERENCES [dbo].[Taburun]
        ([idurun])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TabUrunGenel_Taburun'
CREATE INDEX [IX_FK_TabUrunGenel_Taburun]
ON [dbo].[TabUrunGenel]
    ([idUrun]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------