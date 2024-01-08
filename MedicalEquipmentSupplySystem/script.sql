INSERT INTO users VALUES
(1, 'Lana', 'Kovacevic', 'kovaceviclana2501@gmail.com', 'pass123', 'Blagoja Parovica 92', 'Gajdobra', 'Serbia', 1, 0, true, ' '),
(2, 'Nemanja', 'Kovacevic', 'kovac@gmail.com', 'pass123', 'Blagoja Parovica 92', 'Gajdobra', 'Serbia', 0, 2, true, ' '),
(3, 'Stefan', 'Panzalovic', 'panzalpc@gmail.com', 'pass123', 'Kisacka 27', 'Novi Sad', 'Serbia', 0, 1, true, ' '),
(4, 'Mitar', 'Miric', 'mitric@gmail.com', 'pass123', 'Blagoja Parovica 3', 'Gajdobra', 'Serbia', 0, 2, true, ' '),
(5, 'Petar', 'Petrovic', 'ppet@gmail.com', 'pass123', 'Bulevar Evrope 55', 'Novi Sad', 'Serbia', 0, 2, true, ' '),
(6, 'Marija', 'Markovic', 'mara@gmail.com', 'pass123', 'Kralja Petra I 7a', 'Novi Sad', 'Serbia', 1, 2, true, ' ');

INSERT INTO hospitalworkers VALUES (1, "Hospital 1", 0);

INSERT INTO supplycompanies VALUES
(1, 'Supply Company 1', 'Bulevar Evrope 26a', 'Novi Sad', '', 7.9, 'This is a medical equipment supply company from Novi Sad'),
(2, 'Supply Company 2', 'Knez Mihajlova 3', 'Beograd', '', 6.5, 'Founded in 1889, this is the oldest medical equipment supply in the country'),
(3, 'Supply Company 3', 'Jugoslovenske armije 4', 'Backa Palanka', '', 10, 'The best rated medical equipment supply company in the county'),
(4, 'Supply Company 4', 'Bulevar Evrope 10', 'Novi Sad', '', 7.0, 'This is a medical equipment supply company from Novi Sad');

INSERT INTO companyadministrators VALUES 
(2, 1),
(4, 2),
(5, 3),
(6, 4);

INSERT INTO equipment VALUES 
(1, 'Patient Monitor', 'Neonatal care', 'This is a patient monitor', 1),
(2, 'Defibrillator', 'Emergency', 'This is a defibrillator', 1),
(3, 'Sterilizer','Trauma', 'This is a sterilizer', 1),
(4, 'X-Ray Machine', 'Neonatal care', 'This is a X-Ray Machine', 1),
(5, 'Ultrasound', 'Neonatal care', 'This is a ultrasound', 1),
(6, 'Anestesia machine', 'Surgical' , 'This is a anestesia machine', 1),
(7, 'Hospital Stretcher', 'Emergency', 'This is a hospital stretcher', 2),
(8, 'Patient Monitor', 'Neonatal care', 'This is a patient monitor', 2),
(9, 'Electrosurgical Unit', 'Surgical', 'This is a electrosurgical unit', 2),
(10, 'Anestesia machine', 'Surgical',  'This is a anestesia machine', 2),
(11, 'Sterilizer','Trauma', 'This is a sterilizer', 2),
(12, 'Anestesia machine', 'Surgical' , 'This is a anestesia machine', 3),
(13, 'EKG machine', 'Neonatal care' , 'This is a EKG machine', 3),
(14, 'Respirator', 'Trauma' , 'This is a respirator', 3),
(15, 'Ultrasound', 'Neonatal care', 'This is a ultrasound', 3),
(16, 'Hospital Stretcher', 'Emergency', 'This is a hospital stretcher', 4),
(17, 'Anestesia machine', 'Surgical' , 'This is a anestesia machine', 4);

INSERT INTO equipmentreservation VALUES
(1, '2023-05-20 10:00:00', 48, 13, null, 5),
(2, '2023-07-05 08:30:00', 72, 5, null, 2),
(3, '2023-07-17 13:15:20', 48, 1, null, 2),
(4, '2023-10-03 08:00:00', 48, 12, 1, 5),
(5, '2023-10-10 10:30:00', 24, 9, null, 4),
(6, '2023-12-20 10:00:00', 72, 6, 1, 2),
(7, '2023-12-25 11:20:30', 24, 13, null, 5),
(8, '2023-01-25 08:20:15', 24, 11, null, 4),
(9, '2023-12-27 11:20:00', 72, 12, 1, 5),
(10, '2023-03-08 08:00:00', 48, 3, null, 2);

SELECT * FROM 
users INNER JOIN hospitalworkers
ON users.Id = hospitalworkers.Id;

SELECT * FROM 
equipment INNER JOIN equipmentreservation
ON equipment.Id = equipmentreservation.EquipmentId; 

INSERT INTO users VALUES
(7, 'Working', 'Worker', 'kovaceviclana2501@gmail.com', 'pass123', 'Blagoja Parovica 92', 'Gajdobra', 'Serbia', 1, 0, true, " ");
INSERT INTO hospitalworkers VALUES (7, "Hospital 2", 0);

UPDATE supplycompanies  SET Image = 'https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG' WHERE Id = 1;
UPDATE supplycompanies  SET Image = 'https://images.squarespace-cdn.com/content/v1/5be259959772ae19d121a40d/1550514525411-IJ5Q9G5OZ7SOTZPCNHR4/0-Hero.jpg?format=2500w' WHERE Id = 2;
UPDATE supplycompanies  SET Image = 'https://dbia.org/wp-content/uploads/2020/07/Sharp-Santee-Medical-Office-Bldg-Gallery2-1536x782.jpg' WHERE Id = 3;
UPDATE supplycompanies  SET Image = 'https://wolfmediausa.com/wp-content/uploads/2018/07/Outpatient-HampshireCos-NJ.jpg' WHERE Id = 4;

INSERT INTO complaint VALUES (3, 'complaint body content', 1, null, 2);
INSERT INTO complaint VALUES (2, 'complaint body content', 1, 2, null);

INSERT INTO equipmentreservation VALUES
(15, '2023-04-07 18:00:00', 48, 10, null, 2),
(16, '2023-01-03 11:00:00', 72, 17, null, 4);

select * from users;
delete from users where id = 9;

select * from equipmentreservation
where Id = 13;

UPDATE EquipmentReservation
SET HospitalWorkerId = null
WHERE Id = 13;