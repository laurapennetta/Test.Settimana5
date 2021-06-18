CREATE DATABASE LibrettoUniversitario

CREATE TABLE Esame(
   ID INT IDENTITY(1,1) NOT NULL,
   Nome VARCHAR (50) NOT NULL,
   CFU INT NOT NULL,
   DataEsame DATE NOT NULL,
   Voto INT NOT NULL,
   Passato VARCHAR (2) NOT NULL,
   PRIMARY KEY (ID),
   UNIQUE(ID, Nome, CFU),
   CHECK(Passato IN ('SI','NO')),
   CHECK(Voto > 0 AND Voto < 30),
   CHECK(CFU > 0)
)

CREATE TABLE Studente(
   Matricola VARCHAR(7) PRIMARY KEY,
   Nome VARCHAR (30) NOT NULL,
   Cognome VARCHAR (30) NOT NULL,
   AnnoNascita DATE NOT NULL,
   UNIQUE(Matricola),
   UNIQUE(Nome, Cognome, AnnoNascita)
)

CREATE TABLE StudenteEsame(
 EsameID INT NOT NULL,
 StudenteID VARCHAR(7) NOT NULL,
 FOREIGN KEY(EsameID) REFERENCES Esame(ID),
 FOREIGN KEY(StudenteID) REFERENCES Studente(Matricola),
 UNIQUE(StudenteID, EsameID)
)

--ESAME:
INSERT INTO Esame VALUES ('Fisica 1', 12, '17/05/2021', 27, 'SI')
INSERT INTO Esame VALUES ('Fisica 2', 12, '27/06/2021', 25, 'SI')
INSERT INTO Esame VALUES ('Analisi 1', 12, '05/04/2019', 29, 'SI')
INSERT INTO Esame VALUES ('Teoria dei Segnali', 9, '24/06/2020', 24, 'SI')
INSERT INTO Esame VALUES ('Fotonica', 12, '15/03/2020', 29, 'SI')
INSERT INTO Esame VALUES ('Elettrotecnica', 6, '03/02/2020', 28, 'SI')
INSERT INTO Esame VALUES ('Fisica 1', 12, '17/05/2021', 27, 'SI')
INSERT INTO Esame VALUES ('Elettronica Digitale', 6, '18/07/2021', 29, 'SI')
INSERT INTO Esame VALUES ('Chimica', 9, '13/12/2019', 25, 'SI')
INSERT INTO Esame VALUES ('Elettronica 1', 12, '17/12/2020', 27, 'SI')
INSERT INTO Esame VALUES ('Campi elettromagnetici 1', 9, '15/11/2020', 26, 'SI')
SELECT * FROM Esame
--STUDENTE:
INSERT INTO Studente VALUES ('524005', 'Mauro', 'Monti', '17/07/1998')
--STUDENTESAME:
INSERT INTO StudenteEsame VALUES (2, '524005')
INSERT INTO StudenteEsame VALUES (3, '524005')
INSERT INTO StudenteEsame VALUES (4, '524005')

SELECT s.Matricola, s.Nome, s.Cognome, s.AnnoNascita, e.Nome, e.CFU, e.Voto, e.Passato, e.DataEsame 
FROM Studente s
JOIN StudenteEsame se
ON se.StudenteID = s.Matricola
JOIN Esame e
ON e.ID = se.EsameID