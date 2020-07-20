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

#### Grid

Dvojvrstvový objekt predstavujúci mapu rozdelenú na štvorčeky. Spodná vrstva predstavuje vrstvu slúžiacu na pohyb (zem), na ktorej sú položené všetky objekty. Horná vrstva slúži na umiestnenie všetkých objektov na mape. Ide o hráča, príšery, zničiteľné a nezničiteľné bloky, bomby, explózie a portál do ďalšieho levelu. K tomuto objektu je priradení skript MapDestroyer, ktorý slúži na mazanie blokov a úpravu mapy po výbuchu.

#### Player

Herný objekt, ktorý predstavuje hráča. Priradení je k nemu skript Player, ktorý riadi pohyb a kontroluje kolízie a interakcie s inými objektmi. Ako RigidBody je k nemu priradená animovaná postavička (animáciu riadi animator). Pre jednoduchšie rozšírenie/úpravu obsahuje premenné rýchlosť a počet životov.

#### BombSpawner

Tento objekt slúži na položenie bomby na herný plán. Je k nemu priradený rovnomenný skript. BombSpawner je spojený s hráčom, pretože len ten môže v mojej verzií položiť bombu. V skripte je aj premenná tilemap, do ktorej je dosadená hracia plocha, bomb  - tá predstavuje bombu ako objekt na mape -  a premennú bombCount, ktorá určuje maximálny počet bômb na mape v jednom momente.

#### Enemy

Ide o jednotlivé objekty príšer. Kukaždej kópii je pripojený skript Enemy, ktorý riadi pohyba a interakciu s ostatnými objektmi. Pevný objekt (Rigidbody) slúži na detekciu kolízii s ostatnými objektmi a ide vlastne o obrázok príšery. Premenné horizontal, vpravo, hore určujú smer pohybu.

#### NextLevel

Objekt slúži na teleportovanie sa do nasledujúceho levelu. To nastáva len v prípade, ak žiadna príšera nie je na mape. Objekt obsahuje skript LevelUp, ktorý sa stará o logiku za prechodom do nového levelu. Samotný objekt je len obrázok, ktorý detekuje kolízie.

#### Main Camera a i.

Zvyšné objekty sú veľmi jednoduché. Main Camera vytvára záber a plátno (Canvas) riadi menu pomocou tlačitko (buttons). V menu sú použité dva skripty, GameOver a MainMenu2, riadia zmenu scén pre menu a pri prehre hry.

### Explózia a plameň

Explózia je riadená skriptom MapDestroyer. Spočíva v určení bunky na mape kde je položená bomba a po odpočítavaní sa spúšťa animácia explózie, ktorá vytvára objekt Explosion a kolízia Explosion s inými objektmi odstráni blok (pokiaľ je zničiteľný). Nasleduje propagácia výbuchu do štyroch smerov totožným spôsobom. V prípade kolízie explózia nepokračuje ďalej.

### Kolízie

Kolízie objektov sú riadené pomocou Unity funkcie OnCollisionEnter2D, ktorá zachytáva momenty jednotlivých kolízií pevných objektov (RigidBody)

### Pohyb príšer

Všetky príšery majú implementovaný iba jednoduchý pohyb, v prípade kolízie so stenou zmení sa vektor pohybu o 180 stupňov.

## Záver

### Priebeh práce

Pri výbere enginu som sa rozhodoval medzi Unity a MonoGame. Vďaka recenziám a aj zvedavosti, keďže tento engine využívajú viaceré kvalitné herné tituly, som si zvolil Unity. Napriek tomu, že Unity je často označované ako intuitívne, mal som dlho problém zorientovať sa v novom rozhraní. Veľkou výhodou je ale jeho jednoduchosť a aj s menšími skúsenosťami s programovaním sa dá vytvoriť zaujímavá hra. Určite má tento engine veľký potenciál, ktorý som v tomto projekte ani nedokázal využiť. S istotou sa ešte tomuto enginu budem venovať viac.

### Možné vylepšenia

Najväčším problémom je jednoznačne pohyb príšer. V momentálnej verzií je jednoducho predvídateľné ako sa bude nepriateľ pohybovať. Pokúšal som sa vytvoriť aj nejaký komplikovanejší algoritmus, ale aj kvôli časovej tiesni som nedokázal vytvoriť sofistikovanejšie riešenie.
V pôvodnom pláne som chcel vytvoriť hru, kde by mal užívateľ možnosť upravovať aj nastavenia ako počet životov, počet položených bômb alebo veľkosť explózie. Nakoniec k vytvoreniu takéhoto GUI nedošlo.
Ako rozšírenie do budúcnosti by bolo vhodné pridať nejaké vylepšenia pre hráča, ktoré by získal na konci levelu a generovanie náhodných levelov.
