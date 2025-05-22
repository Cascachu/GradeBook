# GradeBook

GradeBook to aplikacja webowa oparta na technologii ASP.NET Core Razor Pages, s³u¿¹ca do zarz¹dzania ocenami uczniów. Projekt umo¿liwia ³atwe dodawanie, edytowanie oraz przegl¹danie ocen przypisanych do poszczególnych uczniów.

## Funkcje

- Przegl¹danie listy ocen dla wybranego ucznia
- Dodawanie nowych ocen (przedmiot, ocena, data, opis)
- Edytowanie istniej¹cych ocen
- Usuwanie ocen
- Przejrzysty interfejs u¿ytkownika oparty na Razor Pages

## Wymagania

- .NET 9.0
- Visual Studio 2022 lub nowszy

## Instalacja

1. Sklonuj repozytorium:
2. Otwórz projekt w Visual Studio 2022.
3. Przywróæ zale¿noœci NuGet.
4. Uruchom aplikacjê (F5 lub __Debug > Start Debugging__).

## Struktura projektu

- `Models/` – modele domenowe, np. `Student`, `Grade`, `Class`
- `Views/Grades/` – strony Razor do zarz¹dzania ocenami (`AddGrade`, `EditGrade`, `DisplayGrades`)
- `wwwroot/` – zasoby statyczne (CSS, JS)

## U¿ytkowanie

Po uruchomieniu aplikacji:
- Wybierz ucznia z listy.
- Przegl¹daj, dodawaj, edytuj lub usuwaj oceny.
- Ka¿da ocena zawiera przedmiot, wartoœæ oraz opcjonalny opis.

