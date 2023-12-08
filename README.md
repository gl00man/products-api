# Projekt REST API z bazą danych
*Autor: gl00man <maciekbereda46@gmail.com>*

## Opis
Projekt ten jest realizacją wymagań specyfikacji, które obejmują stworzenie REST API.

## TODO
- dodać stored procedures
- testy jednostowe/integracyjne

## Wymagania
Projekt spełnia następujące wymagania:

1. Posiada dwa endpointy.
2. **Endpoint 1 (SyncDatabase):** Realizuje kroki opisane poniżej:
   - Pobiera plik Products.csv i zapisuje go na dysku lokalnym.
   - Odczytuje produkty z powyższego pliku, zapisując dane produktów, które nie są kablami oraz są wysyłane w przeciągu 24h, do tabeli SQL.
   - Pobiera plik Inventory.csv i zapisuje go na dysku lokalnym.
   - Odczytuje dane o stanie magazynowym z powyższego pliku i zapisuje stany produktów wysyłane w przeciągu 24h do tabeli SQL.
   - Pobiera plik Prices.csv i zapisuje go na dysku lokalnym.
   - Odczytuje ceny produktów z powyższego pliku i zapisuje dane w tabeli SQL. Projekt dba o uwzględnienie jednostki logistycznej produktu.
3. **Endpoint 2 (GetProduct):** Akceptuje SKU produktu jako parametr i zwraca następujące informacje:
   - Nazwa produktu
   - EAN
   - Nazwa producenta
   - Kategoria
   - URL do zdjęcia produktu
   - Stan magazynowy
   - Jednostka logistyczna produktu
   - Cena netto zakupu produktu
   - Koszt dostawy
4. Obejmuje odpowiednie komentarze do napisanego kodu.

## Technologie
Projekt został zrealizowany przy użyciu następujących technologii:
- .NET 7
- C#
- SQL
- Dapper (biblioteka ORM)

## Struktura projektu
```
ProductsAPI
    ├───Clients
    ├───Controllers
    ├───Database
    ├───DTOs
    │   └───Product
    │
    ├───Middleware
    ├───Models
    │   ├───Exceptions
    │   └───Product
    │
    ├───Properties
    ├───Repositories
    └───Services
```
