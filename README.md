# DynaBlaster

## Zadanie

Vlastná verzia 2D hry Dyna Blaster, prvýkrát vydaná v roku 1990 pod názvom [Bomberman](https://www.youtube.com/watch?v=VWyTDXFPC84). Súčasťou hry je Bomberman (hráč) a príšery, ktoré musí hráč zničiť, aby mohol postúpiť do ďalšieho levelu. Hra je vytvorená pomocou enginu Unity.

## Užívateľská časť

### Ovládanie

Klasické ovládanie WASD alebo šípky, položenie bomby pomocou Space a Esc pre ukončenie levelu. V užívateľskom rozhraní je ovládanie pomocou myšky.

### Úrovne

Hra obsahuje 3 rôzne levely. Vďaka jednoduchému ovládaniu je možné vytvoriť ďalšie levely v Unity editore.

### Cieľ hry

Úlohou hráča je zničiť príšery vo všetkých troch leveloch. Hráč má jeden život a môže použiť v jednom momente 3 bomby.
Hra končí:
1.  Hráč prejde cez portál v poslednom levele
2.  Hráč je zničený (exploduje pri ňom bomba alebo sa dotkne príšery)

## Programátorská časť

Na úpravu hry je potrebný [Unity engine](https://unity3d.com/get-unity/download)

### Štruktúra

Hra je rozdelená do jednotlivých skriptov (popisy pri jednotlivých funkciách)

#### Kolízie

Kolízie objektov sú riadené pomocou Unity funkcie OnCollisionEnter2D, ktorá zachytáva momenty jednotlivých kolízií pevných objektov (RigidBody)

#### Pohyb príšer

Všetky príšery majú implementovaný iba jednoduchý pohyb, v prípade kolízie so stenou zmení sa vektor pohybu o 180 stupňov.

## Záver

### Priebeh práce

Pri výbere enginu som sa rozhodoval medzi Unity a MonoGame. Vďaka recenziám a aj zvedavosti, keďže tento engine využívajú viaceré kvalitné herné tituly, som si zvolil Unity. Napriek tomu, že Unity je často označované ako intuitívne, mal som dlho problém zorientovať sa v novom rozhraní. Veľkou výhodou je ale jeho jednoduchosť a aj s menšími skúsenosťami s programovaním sa dá vytvoriť zaujímavá hra. Určite má tento engine veľký potenciál, ktorý som v tomto projekte ani nedokázal využiť. S istotou sa ešte tomuto enginu budem venovať viac.

### Možné vylepšenia

Najväčším problémom je jednoznačne pohyb príšer. V momentálnej verzií je jednoducho predvídateľné ako sa bude nepriateľ pohybovať. Pokúšal som sa vytvoriť aj nejaký komplikovanejší algoritmus, ale aj kvôli časovej tiesni som nedokázal vytvoriť sofistikovanejšie riešenie.
V pôvodnom pláne som chcel vytvoriť hru, kde by mal užívateľ možnosť upravovať aj nastavenia ako počet životov, počet položených bômb alebo veľkosť explózie. Nakoniec k vytvoreniu takéhoto GUI nedošlo.
Ako rozšírenie do budúcnosti by bolo vhodné pridať nejaké vylepšenia pre hráča, ktoré by získal na konci levelu a generovanie náhodných levelov.
