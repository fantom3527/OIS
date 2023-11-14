# OIS

Разделы:
1) Описание - используемые технологии.
2) Инструкция по запуску проекта.

1 Описание - используемые технологии.

Проект состоит из 3х частей: Frontend, Identity Server, Web Api.
В качестве БД - PostgreSQL, SQLite.

Сущности City и User реализуют CRUD. Wheather симулирует сервис погоды через моки (Wiremock)

В Docker поднято:
* Web Api 
* PostgeSQL
* PgAdmin
* WireMock
* Identity Server
* Frontend

1.1 Frontend: 
React + TypeScript (Использовал NSwagStudio для автогенерации) - пока что не стал декомпозировать или приводить в соответствии к нормам этот файл, так как пока что frontend демонстрационный.
* Перед использованием надо нажать залогиниться, ввести пароль от 4 знаков.
* Затем будет отображаться список наименований городов, если он есть.
* В поле ввода для города, набрать наименование города, нажать Enter и город добавиться.

1.2 Identity Server:
c# и БД в виде SQLite. Содержит небольшую логику + вьюшки регистрации и входа.
* Библиотека IdentityServer4

1.3 Web Api
C# + Entity Framework, БД в виде SQLite или PostgreSQL (пока что настраивается в appsettings.json) и WireMock.
Также в проекте:
* Automapper
* Mediatr + SQRS
* DependencyInjection
* Валидация данных
* Middleware
* xUnit тесты
* Swagger и Swagger UI - с документацией xml комментариев и с возможностью авторизации, выбором версии Api + инфа обо мне
* Версионирование Api
* Логирование через Serilog

2 Инструкция по запуску проекта.

Предисловие:
Самый простой способ запустить проект - через Docker,
если его нет, то необходимо будет запускать Web Api с БД SQLite - так как она автогенерируется настроенная при запуске Api.

2.1 Запуск через Docker.
При использовании Docker, Web Api использует PostgreSQL в качестве БД.

Адреса:
Web Api - 	  http://localhost:7247/index.html
Identity Server - http://localhost:7088/
Frontend - 	  http://localhost:3000/

* Необходимо поднять в контейнеры Docker Backend, Identity Server, Frontend.
* Запустить данные контейнеры.
* Далее необходимо открыть Front по адресу http://localhost:3000/ и зарегестрироваться, пароль больше 4х символов
* После регистрации, можно будет добавить город, а также будет доступен ТОКЕН аутентификации, он понадобится, если нужно протестировать весь функионал Web Api -> 
нажать F12 на странице вьюшки -> в выпавшем окне выбрать вкладку Application -> Storage -> Local Storage -> http://localhost:3000 -> 
В списке будет доступен по Key = "token", необходимо скопировать из Value значение.
Данное значение надо будет применить в Swagger:
* Открыть по ссылке Web Api swagger http://localhost:7247/index.html.
* Справа будет зеленная кнопка "Authorize", нажать на нее и в поле ввести скопированный токен для 2х версий Api.
* После чего будут доступны комманды на выполнение.

Если не получается что-то, надо проверить:
Проект Web Api:
* Файл appsettings.json должна быть строка:
"DbConnection": "Host=postgres_db;Port=5432;Database=testpeoplescities;Username=postgres;Password=123",
* Startup.cs должна быть строка у AddJwtBearer():
options.Authority = "http://localhost:7088/";

Проект Frontend
* Файл user-service.ts должна быть строка:
authority: 'http://localhost:7088/',
* Файл CityList.tsx должна быть строка:
const apiClient = new Client('http://localhost:7247');

2.2 Запуск Web Api без Docker, в качетсве: БД SQLite или PostgreSQL - на выбор.

Адреса:
Web Api - 	  https://localhost:7247/index.html
Identity Server - https://localhost:7088/
Frontend - 	  http://localhost:3000/

2.2.1 Backend - Web Api

Выбор БД осуществляется в проекте Backend - Web Api в файле appsettings.json:
* SQLite:
  "DbConnection": "Data Source=TestOIS.PeoplesCities.db"
  "IsSQLiteProDbProvifer": "true"

* PostgreSQL:
  "DbConnection": "Host=postgres_db;Port=5432;Database=testpeoplescities;Username=postgres;Password=123"
  "IsSQLiteProDbProvifer": "false"

Надо убедиться, что в файле Startup.cs должна быть строка у AddJwtBearer():
options.Authority = "https://localhost:7088/";

Запустить все тесты (необязательно). В Visual Studio 2022 это делается:
Вкладка "Тест" -> "Запуск всех тестов"

Выбрать в IDE в качестве запускаемого проекта "PeoplesCities.WebApi"

Зупастить Web Api.

2.2.2 Identity Server
Не требует настроек - просто запустить.

2.2.3 Frontend
Скачать библиотеки через команду npm install.

Проверить в файлах:
* Файл user-service.ts должна быть строка:
  authority: 'https://localhost:7088/',
* Файл CityList.tsx должна быть строка:
  const apiClient = new Client('https://localhost:7247');

Запуск через команду npm start.

2.2.4 Swagger - Web Api
Для использования Swagger необходимо проделать действия:
* Открыть Front по адресу https://localhost:3000/ и зарегестрироваться, пароль больше 4х символов
* После регистрации, можно будет добавить город, а также будет доступен ТОКЕН аутентификации, он понадобится, если нужно протестировать весь функионал Web Api -> 
  нажать F12 на странице вьюшки -> в выпавшем окне выбрать вкладку Application -> Storage -> Local Storage -> http://localhost:3000 -> 
  в списке будет доступен по Key = "token", необходимо скопировать из Value значение.
Данное значение надо будет применить в Swagger:
* Открыть по ссылке Web Api swagger https://localhost:7247/index.html.
* Справа будет зеленная кнопка "Authorize", нажать на нее и в поле ввести скопированный токен для 2х версий Api.
* После чего будут доступны комманды на выполнение.
