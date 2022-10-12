##Praktikos-Darbas

#Aplikacija susideda is dvieju daliu frontend ir backend
    1. FrontEnd
        Frontend parasyta React kalba. Aplikacijos paleidimo seka:
        1. npm install (parsiuncia appso dependencies)
        2. npm run build (pabuildina appsa)
        3. npm start (appsas startuoja)
    2. BackEnd
       BackEnd susideda is dvieju daliu db ir api.
       Api implementacija pasirinkta .net core 6.0 framwork su Swagger tools.
       Duombazei pasirinkta sqlite, duombaze sukuriama pasitelkiant migration scripts
       Paleidimas:
       dotnet restore (projecto kataloge)
       dotnet build (projecto kataloge)
       dotnet run (projecto kataloge)

