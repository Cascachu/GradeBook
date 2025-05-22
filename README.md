# GradeBook

GradeBook to aplikacja webowa oparta na technologii ASP.NET Core Razor Pages, s�u��ca do zarz�dzania ocenami uczni�w. Projekt umo�liwia �atwe dodawanie, edytowanie oraz przegl�danie ocen przypisanych do poszczeg�lnych uczni�w.

## Funkcje

- Przegl�danie listy ocen dla wybranego ucznia
- Dodawanie nowych ocen (przedmiot, ocena, data, opis)
- Edytowanie istniej�cych ocen
- Usuwanie ocen
- Przejrzysty interfejs u�ytkownika oparty na Razor Pages

## Wymagania

- .NET 9.0
- Visual Studio 2022 lub nowszy

## Instalacja

1. Sklonuj repozytorium:
2. Otw�rz projekt w Visual Studio 2022.
3. Przywr�� zale�no�ci NuGet.
4. Uruchom aplikacj� (F5 lub __Debug > Start Debugging__).

## Struktura projektu

- `Models/` � modele domenowe, np. `Student`, `Grade`, `Class`
- `Views/Grades/` � strony Razor do zarz�dzania ocenami (`AddGrade`, `EditGrade`, `DisplayGrades`)
- `wwwroot/` � zasoby statyczne (CSS, JS)

## U�ytkowanie

Po uruchomieniu aplikacji:
- Wybierz ucznia z listy.
- Przegl�daj, dodawaj, edytuj lub usuwaj oceny.
- Ka�da ocena zawiera przedmiot, warto�� oraz opcjonalny opis.

