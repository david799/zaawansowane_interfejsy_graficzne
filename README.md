# zaawansowane_interfejsy_graficzne

# Struktura bazy danych
```sql
CREATE TABLE "COURSE" (
	"id"	INTEGER NOT NULL UNIQUE,
	"train_id"	INTEGER NOT NULL,
	"ticket_price"	REAL NOT NULL,
	"costs"	REAL NOT NULL,
	"canceled"	BOOLEAN NOT NULL,
	"when" DATETIME NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "TRAIN" (
	"id"	INTEGER NOT NULL UNIQUE,
	"active"	BOOLEAN NOT NULL,
	"capacity"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "USER" (
	"id"	INTEGER NOT NULL UNIQUE,
	"nick"	TEXT NOT NULL,
	"password"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	"surname"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)

CREATE TABLE "TICKET" (
	"id"	INTEGER NOT NULL UNIQUE,
	"course_id"	INTEGER NOT NULL,
	"user_id"	INTEGER NOT NULL,
	"status"	INTEGER NOT NULL,
	FOREIGN KEY("user_id") REFERENCES "USER"("id"),
	FOREIGN KEY("course_id") REFERENCES "COURSE"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
)
```
