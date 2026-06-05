FitnessTracker
Projekt:
FitnessTracker to aplikacja internetowa stworzona w ASP.NET Core MVC ktora sluzy do organizacji treningów fitness oraz zarządzania trenerami.

Funkcjonalnosci:
Dodawanie treningów
Edycja treningów
Usuwanie treningów
Wyszukiwanie treningów
Zarządzanie trenerami
Relacje miedzy treningami i trenerami
Walidacja formularzy
Obsluga bazy danych SQLite
Obsluga Docker
Technologie
ASP.NET Core MVC
Entity Framework Core
SQLite
Bootstrap
Docker
Uruchomienie aplikacji
Otwórz projekt w Visual Studio
Wykonaj migracje:
Add-Migration InitialCreate
Update-Database
Uruchom projekt przyciskiem F5
Uruchomienie Docker

docker build -t fitnesstracker .
docker run -p 8080:8080 fitnesstracke