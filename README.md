# zaawansowane_interfejsy_graficzne

# Struktura bazy danych
```sql
CREATE TABLE COURSE (
	"id"	INTEGER NOT NULL UNIQUE,
	"train_id"	INTEGER NOT NULL,
	"ticket_price"	REAL NOT NULL,
	"costs"	REAL NOT NULL,
	"canceled"	BOOLEAN NOT NULL,
	"starts_at"	DATETIME NOT NULL,
	"ends_at"	DATETIME NOT NULL,
	"starting_point"	TEXT NOT NULL,
	"destination"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "TRAIN" (
	"id"	INTEGER NOT NULL UNIQUE,
	"active"	BOOLEAN NOT NULL,
	"name" TEXT NOT NULL,
	"capacity"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "USER" (
	"id"	INTEGER NOT NULL UNIQUE,
	"nick"	TEXT NOT NULL,
	"password"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	"surname"	TEXT NOT NULL,
	"IS_ADMIN" BOOLEAN NOT NULL CHECK("IS_ADMIN" IN (0,1)),
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "TICKET" (
	"id"	INTEGER NOT NULL UNIQUE,
	"course_id"	INTEGER NOT NULL,
	"user_id"	INTEGER NOT NULL,
	"status"	INTEGER NOT NULL,    -- 1 ticket is active, 0 ticket is not active
	PRIMARY KEY("id" AUTOINCREMENT)
)

INSERT INTO TRAIN ("active", "name", "capacity") values
(0, "inactive", 120),
(1, "small train", 5),
(1, "medium train", 50),
(1, "large train", 500),
(1, "small the second", 5),
(1, "medium the second", 50),
(1, "large the second", 500),
(1, "small the third", 5),
(1, "medium the third", 50),
(1, "large the third", 500);

```
