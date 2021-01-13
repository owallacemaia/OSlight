IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AbrirOS] (
    [Id] uniqueidentifier NOT NULL,
    [Titulo] varchar(200) NOT NULL,
    [NomeReclamante] varchar(200) NOT NULL,
    [DataAbertura] datetime2 NOT NULL,
    [NumeroPoste] varchar(100) NOT NULL,
    [Status] int NOT NULL,
    [Descricao] varchar(MAX) NOT NULL,
    CONSTRAINT [PK_AbrirOS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [AbrirOSId] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_AbrirOS_AbrirOSId] FOREIGN KEY ([AbrirOSId]) REFERENCES [AbrirOS] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [fecharOs] (
    [Id] uniqueidentifier NOT NULL,
    [AbrirOSId] uniqueidentifier NOT NULL,
    [Descricao] varchar(MAX) NOT NULL,
    [DataFechamento] datetime2 NOT NULL,
    CONSTRAINT [PK_fecharOs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_fecharOs_AbrirOS_AbrirOSId] FOREIGN KEY ([AbrirOSId]) REFERENCES [AbrirOS] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Enderecos_AbrirOSId] ON [Enderecos] ([AbrirOSId]);
GO

CREATE UNIQUE INDEX [IX_fecharOs_AbrirOSId] ON [fecharOs] ([AbrirOSId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210113140453_InitApp', N'5.0.1');
GO

COMMIT;
GO

