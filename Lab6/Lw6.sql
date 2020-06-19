-- 1.

CREATE TABLE PC (
	id INTEGER NOT NULL,
	cpu INTEGER NOT NULL,
	memory INTEGER NOT NULL,
	hdd INTEGER NOT NULL,
	PRIMARY KEY(id AUTOINCREMENT)
);

INSERT INTO PC (cpu, memory, hdd) VALUES (1600, 2000, 500);
INSERT INTO PC (cpu, memory, hdd) VALUES (2400, 3000, 800);
INSERT INTO PC (cpu, memory, hdd) VALUES (3200, 3000, 1200);
INSERT INTO PC (cpu, memory, hdd) VALUES (2400, 2000, 500);

-- 1)
SELECT id, cpu, memory FROM PC
WHERE memory = 3000;

-- 2)
SELECT MIN(hdd) AS hdd FROM PC;

-- 3)
SELECT COUNT(hdd) AS count_hdd, hdd FROM PC
WHERE hdd = (SELECT MIN(hdd) FROM PC)
GROUP BY hdd;

-- 2.

CREATE TABLE track_downloads ( 
      download_id INTEGER NOT NULL, 
      track_id INTEGER NOT NULL, 
      user_id INTEGER NOT NULL, 
      download_time TIMESTAMP NOT NULL DEFAULT 0,  
      PRIMARY KEY (download_id AUTOINCREMENT) 
); 

INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (1, 1, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (1, 2, '2010-10-13');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (1, 3, '2010-12-31');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (2, 1, '2011-01-05');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (2, 2, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (2, 3, '2010-11-19');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (3, 1, '2010-09-17');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (3, 2, '2010-11-21');
INSERT INTO track_downloads (track_id, user_id, download_time ) VALUES (3, 3, '2010-12-09');

SELECT download_count, COUNT(*) AS user_count
FROM (
	SELECT COUNT(*) AS download_count FROM track_downloads
	WHERE date(download_time) = '2010-11-19'
	GROUP BY user_id
)
GROUP BY download_count;

-- 3.
/*
DATETIME 
Хранит время в виде целого числав вида YYYYMMDDHHMMSS используя 8 байт
Время не зависит от временной зоны(часового пояса)

TIMESTAMP
Хранит целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года по усреднённому времени Гринвича(нулевой часовой пояс) занимая 4 байта
При получении из базы отображается с учётом часового пояса
*/

-- 4
CREATE TABLE student (
	id_student	INTEGER NOT NULL,
	name		TEXT NOT NULL,
	PRIMARY KEY(id_student AUTOINCREMENT)
);

CREATE TABLE course (
	id_course	INTEGER NOT NULL,
	name		TEXT NOT NULL,
	PRIMARY KEY(id_course AUTOINCREMENT)
);

CREATE TABLE student_on_course (
	id_student_on_course	INTEGER NOT NULL,
	id_student	INTEGER NOT NULL,
	id_course	INTEGER NOT NULL,
	FOREIGN KEY(id_student) REFERENCES student(id_student),
	FOREIGN KEY(id_course) REFERENCES course(id_course)
	PRIMARY KEY(id_student_on_course AUTOINCREMENT)
);

INSERT INTO student (name) VALUES ('Иван');
INSERT INTO student (name) VALUES ('Максим');
INSERT INTO student (name) VALUES ('Евгений');
INSERT INTO student (name) VALUES ('Никита');
INSERT INTO student (name) VALUES ('Николай');
INSERT INTO student (name) VALUES ('Алиса');
INSERT INTO student (name) VALUES ('Мария');
INSERT INTO student (name) VALUES ('Анастасия');

INSERT INTO course (name) VALUES ('История');
INSERT INTO course (name) VALUES ('Иностранный язык');
INSERT INTO course (name) VALUES ('Физическая культура');
INSERT INTO course (name) VALUES ('Физика');
INSERT INTO course (name) VALUES ('Экономика');

INSERT INTO student_on_course (id_student, id_course) VALUES (1, 1);
INSERT INTO student_on_course (id_student, id_course) VALUES (2, 1);
INSERT INTO student_on_course (id_student, id_course) VALUES (3, 1);
INSERT INTO student_on_course (id_student, id_course) VALUES (5, 1);

INSERT INTO student_on_course (id_student, id_course) VALUES (1, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (2, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (3, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (4, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (5, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (6, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (7, 2);
INSERT INTO student_on_course (id_student, id_course) VALUES (8, 2);

INSERT INTO student_on_course (id_student, id_course) VALUES (4, 3);
INSERT INTO student_on_course (id_student, id_course) VALUES (6, 3);
INSERT INTO student_on_course (id_student, id_course) VALUES (7, 3);
INSERT INTO student_on_course (id_student, id_course) VALUES (8, 3);

INSERT INTO student_on_course (id_student, id_course) VALUES (4, 4);
INSERT INTO student_on_course (id_student, id_course) VALUES (6, 4);
INSERT INTO student_on_course (id_student, id_course) VALUES (8, 4);

INSERT INTO student_on_course (id_student, id_course) VALUES (1, 5);
INSERT INTO student_on_course (id_student, id_course) VALUES (2, 5);
INSERT INTO student_on_course (id_student, id_course) VALUES (3, 5);
INSERT INTO student_on_course (id_student, id_course) VALUES (4, 5);
INSERT INTO student_on_course (id_student, id_course) VALUES (5, 5);
INSERT INTO student_on_course (id_student, id_course) VALUES (6, 5);

-- 1)
SELECT COUNT(id_course)
FROM (
	SELECT id_student, id_course FROM student_on_course
	GROUP BY id_course
	HAVING COUNT(student_on_course.id_student) > 5
);

-- 2)
SELECT student.name, course.name FROM student_on_course
INNER JOIN student ON student_on_course.id_student = student.id_student
INNER JOIN course ON student_on_course.id_course = course.id_course
ORDER BY student.name ASC;

-- 5.
/*
Да, может если значение не объявлено ограничение NOT NULL
NULL - отсутствие автомобиля у рабочего
*/
CREATE TABLE car(
	id_car INTEGER
);

CREATE TABLE worker(
	id_worker INTEGER,
	id_car INTEGER,
	FOREIGN KEY(id_car) REFERENCES car(id_car)
	PRIMARY KEY(id_worker AUTOINCREMENT)
);

INSERT INTO car (id_car) VALUES (null);
INSERT INTO worker (id_car) VALUES (null);


-- 6.
/*
Синтаксис команды: SELECT DISTINCT column_name FROM table_name
	column_name -  название столбца(может быть несколько)
	table_name - название таблицы
*/
CREATE TABLE person(
	id_person INTEGER NOT NULL,
	name TEXT NOT NULL,
	age INTEGER NOT NULL,
	PRIMARY KEY(id_person AUTOINCREMENT)
);

INSERT INTO person (name, age) VALUES ('Алексей', 19);
INSERT INTO person (name, age) VALUES ('Максим', 43);
INSERT INTO person (name, age) VALUES ('Влад', 19);
INSERT INTO person (name, age) VALUES ('Максим', 15);

--Вернёт Алексей, Максим, Влад
SELECT DISTINCT name FROM person;

--Вернёт 19, 43, 15
SELECT DISTINCT age FROM person;

--Вернёт все записи
SELECT DISTINCT name, age FROM person;



--Task 7
CREATE TABLE users (
	id_users INTEGER NOT NULL,
	name TEXT NOT NULL,
	PRIMARY KEY(id_users AUTOINCREMENT)
);

CREATE TABLE orders (
	id_orders INTEGER NOT NULL,
	id_users INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY(id_users) REFERENCES users(id_users),
	PRIMARY KEY(id_orders AUTOINCREMENT)
);

INSERT INTO users (name) VALUES ('Мая');
INSERT INTO users (name) VALUES ('Дарья');
INSERT INTO users (name) VALUES ('Петр');
INSERT INTO users (name) VALUES ('Данил');
INSERT INTO users (name) VALUES ('Андрей');

INSERT INTO orders (id_users, status) VALUES (1, 0);
INSERT INTO orders (id_users, status) VALUES (1, 1);
INSERT INTO orders (id_users, status) VALUES (1, 0);
INSERT INTO orders (id_users, status) VALUES (1, 1);
INSERT INTO orders (id_users, status) VALUES (1, 1);
INSERT INTO orders (id_users, status) VALUES (1, 0);

INSERT INTO orders (id_users, status) VALUES (2, 1);
INSERT INTO orders (id_users, status) VALUES (2, 1);
INSERT INTO orders (id_users, status) VALUES (2, 1);
INSERT INTO orders (id_users, status) VALUES (2, 0);
INSERT INTO orders (id_users, status) VALUES (2, 1);
INSERT INTO orders (id_users, status) VALUES (2, 1);
INSERT INTO orders (id_users, status) VALUES (2, 1);

INSERT INTO orders (id_users, status) VALUES (3, 0);
INSERT INTO orders (id_users, status) VALUES (3, 0);

INSERT INTO orders (id_users, status) VALUES (4, 0);
INSERT INTO orders (id_users, status) VALUES (4, 0);
INSERT INTO orders (id_users, status) VALUES (4, 0);
INSERT INTO orders (id_users, status) VALUES (4, 0);

INSERT INTO orders (id_users, status) VALUES (5, 0);
INSERT INTO orders (id_users, status) VALUES (5, 1);
INSERT INTO orders (id_users, status) VALUES (5, 1);
INSERT INTO orders (id_users, status) VALUES (5, 1);
INSERT INTO orders (id_users, status) VALUES (5, 0);
INSERT INTO orders (id_users, status) VALUES (5, 1);
INSERT INTO orders (id_users, status) VALUES (5, 1);

-- 1)
SELECT users.id_users, name FROM users
JOIN orders ON orders.id_users = users.id_users
GROUP BY orders.id_users
HAVING SUM(orders.status) < 1;

-- 2)
SELECT users.id_users, name FROM users
JOIN orders ON orders.id_users = users.id_users
GROUP BY orders.id_users
HAVING SUM(orders.status) > 5;

-- 8.
/*
WHERE - это ограничивающее выражение. Оно выполняется до того, как будет получен результат операции. Нельзя применять к агрегатным функциям. 
HAVING - фильтрующее выражение. Оно применяется к результату операции и выполняется уже после того как этот результат будет получен. Возможно использование агрегатных функций.
Выражения WHERE используются вместе с операциями SELECT, UPDATE, DELETE, в то время как HAVING только с SELECT и предложением GROUP BY.
*/