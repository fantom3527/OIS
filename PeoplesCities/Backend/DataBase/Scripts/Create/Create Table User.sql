Create Table "User"
(
"Id" UUID Primary Key,
"City_Id" UUID References "City"("Id"),
"Name" Varchar(50) Not NUll,
"Email" Varchar(80),
"TS" Timestamp Default now()
);