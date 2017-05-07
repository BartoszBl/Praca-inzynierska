CREATE TABLE [dbo].[Operations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Imie_wlasciciela] NCHAR(100) NULL, 
    [Nazwisko_wlasciciela] NCHAR(100) NULL, 
    [Imie_zwierzecia] NCHAR(100) NULL, 
    [Gatunek] NCHAR(100) NULL, 
    [Rodzaj_operacji] NCHAR(100) NULL, 
    [Opis_operacji] NCHAR(100) NULL, 
    [Data_operacji] DATE NULL
)
