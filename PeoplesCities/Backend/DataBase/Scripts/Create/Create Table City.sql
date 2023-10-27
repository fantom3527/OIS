CREATE TABLE "City" (
"Id" UUID Primary Key,
"Name" Varchar(50) NOT NULL,
"Description" Text,
"TS" Timestamp Default NOW()
);