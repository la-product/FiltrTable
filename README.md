# Filtr prodejů aut

Jednoduchá Windows Forms aplikace (.NET, C#) pro vyhodnocení prodejů aut ze souboru XML.

## Co aplikace umí

- Tlačítkem **"Vybrat soubor..."** se vybere a načte XML soubor s prodeji (např. `data/prodeje.xml`).
- Selectbox **Prodeje** filtruje data podle dne prodeje: **Vše** / **Víkend** (sobota, neděle).
- Selectbox **DPH** filtruje data podle sazby DPH: **Vše** / **19%** / **20%**.
- Oba filtry se kombinují a tabulka pod nimi zobrazuje pro každý model auta:
  - **Celkem bez DPH**
  - **Celkem s DPH**

  Částky jsou formátované s mezerou jako oddělovačem tisíců, na dvě desetinná místa, v měně CZK.

### Formát vstupního XML

```xml
<prodeje>
  <auto>
    <nazev_modelu>Škoda Octavia</nazev_modelu>
    <datum_prodeje>2010-12-02</datum_prodeje>
    <cena>500000.00</cena>
    <dph>20</dph>
  </auto>
  ...
</prodeje>
```

## Požadavky

- [.NET 10 SDK]
- Windows (aplikace používá Windows Forms)

## Spuštění

V kořenovém adresáři projektu:

```sh
dotnet run
```

Případně sestavení a spuštění zvlášť:

```sh
dotnet build
.\bin\Debug\net10.0-windows\TescoSW_task.exe
```

Po spuštění klikněte na **"Vybrat soubor..."** a vyberte `data/prodeje.xml`.
