CREATE TABLE Files (
	ID int NOT NULL,
	Name text,
	path text,
	date date,
	PRIMARY KEY (ID)
);

CREATE TABLE Patients (
	ID int NOT NULL,
	Name text,
	Surname text,
	DoB date,
	PRIMARY KEY (ID)
);

CREATE TABLE File_Patients (
	ID int NOT NULL,
	ID_File int NOT NULL,
	ID_Patient int NOT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (ID_File) REFERENCES Files(ID) ON DELETE CASCADE,
	FOREIGN KEY (ID_Patient) REFERENCES Patients(ID) ON DELETE CASCADE
);

CREATE TABLE Authentication (
	ID int NOT NULL,
	Login text,
	Password text,
	AuthToken text,
	PRIMARY KEY (ID)
);

CREATE TABLE Personel (
	ID int NOT NULL,
	Name text,
	Surname text,
	DoB date,
	Position text,
	ID_Auth int NOT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (ID_Auth) REFERENCES Authentication(ID) ON DELETE CASCADE
);



CREATE TABLE Equipment (
	ID int NOT NULL,
	SerialNumber text,
	ID_Auth int NOT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (ID_Auth) REFERENCES Authentication(ID) ON DELETE CASCADE
);

INSERT INTO Authentication VALUES (1, 'Doctor1', 'doctor', 'Auth1');
INSERT INTO Authentication VALUES (2, 'Doctor2', 'doctor', 'Auth2');
INSERT INTO Authentication VALUES (3, 'Doctor3', 'doctor', 'Auth3');
INSERT INTO Authentication VALUES (4, 'Doctor4', 'doctor', 'Auth4');

INSERT INTO Personel VALUES (1, 'Вася', 'Пупкин', '05-15-2016', 'head', 4);