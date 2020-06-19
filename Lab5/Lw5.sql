-- 2.

CREATE TABLE dvd (
	dvd_id INTEGER NOT NULL,
	tile TEXT NOT NULL,
	production_year INTEGER NOT NULL,
	PRIMARY KEY(dvd_id, AUTOINCREMENT)
);

CREATE TABLE customer (
	customer_id INTEGER NOT NULL,
	first_name TEXT NOT NULL,
	last_name TEXT NOT NULL,
	pasport_code INTEGER NOT NULL,
        registration_date TEXT NOT NULL,
	PRIMARY KEY(customer_id, AUTOINCREMENT)
);

CREATE TABLE offer (
	offer_id INTEGER NOT NULL,
	dvd_id INTEGER NOT NULL,
	customer_id INTEGER NOT NULL,
	tile TEXT NOT NULL,
	offer_date TEXT NOT NULL,
	return_date TEXT,
	PRIMARY KEY(offer_id, AUTOINCREMENT)
);

-- 3.

INSERT INTO dvd (title, production_year) VALUES ('1+1', 2012);
INSERT INTO dvd (title, production_year) VALUES ('Левша', 2015);
INSERT INTO dvd (title, production_year) VALUES ('Елки', 2010);
INSERT INTO dvd (title, production_year) VALUES ('Братья', 20101);

INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Иван', 'Васильевич', 1245, '2002-06-21');
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Мария', 'Иванова', 3418, '1998-09-06');
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Дмитрий', 'Микушов', 5293, '2005-03-30');
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Данил', 'Волков',6212, '2003-11-09');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (1, 1, '2020-05-23', '2020-06-23');
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (2, 2, '2020-01-14', '2020-01-29');
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (3, 3, '2020-04-30', NULL);
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (4, 4, '2020-08-08', '2020-09-08');

-- 4.

SELECT * FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

-- 5.

SELECT offer.return_date, dvd.title
FROM offer JOIN dvd ON offer.dvd_id = dvd.dvd_id
WHERE offer.return_date IS NULL;

-- 6.

SELECT customer.customer_id, customer.first_name, customer.last_name, customer.passport_code, customer.registration_date, 
dvd.dvd_id, dvd.title
FROM offer JOIN dvd ON offer.dvd_id = dvd.dvd_id
JOIN customer ON offer.customer_id = customer.customer_id
WHERE strftime('%Y', offer.offer_date) = '2020';