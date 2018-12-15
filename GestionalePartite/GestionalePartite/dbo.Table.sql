CREATE TABLE [dbo].[Giocatori]
(
	[GiocaotreId ] INT NOT NULL PRIMARY KEY, 
    [Nome ] NVARCHAR(50) NOT NULL, 
    [Cognome ] NVARCHAR(50) NOT NULL, 
    [DataNascita ] DATE NOT NULL, 
    [NickName ] NVARCHAR(50) NOT NULL, 
    [Livello ] INT NOT NULL
)
