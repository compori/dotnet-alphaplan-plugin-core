# Verweise zur Alphaplan Installation

## Hintergrund

Die Alphaplan Schnittstellen Plugins erfordern i.R. einen Verweis auf Assemblies im app Verzeichnis 
der Alphaplan Installation z.B. die Base.dll Datei.

Nun hat evtl. jeder Entwickler seine eigne Verzeichnisstruktur f�r die lokale Alphaplan Installationen und Versionen 
oder es kann nicht �ber eine Richtline/Arbeitsanweisung �ber die Struktur frei entschieden werden, 
da z.B. unterschiedliche Unternehmen oder IT-Umgebungen zum Tragen kommen. 

*Fazit:* Die Verzeichnisstruktur l�sst sich nicht durch eine "Orga" festlegen.

## Das eigentliche Probleme

Wenn die Solution ausgecheckt wird, muss der Entwickler erstmal alle Verweise z.B. auf die Base.dll anpassen, damit 
die Quellen �bersetzt werden k�nnen. Das hat wierderum hat zur Folge, dass sich die Projektdateien �ndern, in dem die 
Quellen f�r die Verweise gespeichert sind.

Dies verursacht wiederum ein Commitvorschlag beim Einchecken, da sich Dateien ge�ndert haben, obwohl sich in der Sache 
am Quellcode nichts ge�ndert haben k�nnte. Das f�hrt zu dutzenden Commit Meldung wie "�ndere Base.dll Verweis".

## L�sung

Es wird innerhalb der Verzeichnisstruktur des Repository ein fest definiertes Verzeichnis erstellt, in dem sich nur 
Links befinden, die dann in das konkrete Alphaplanverzeichnis verweisen. Die Links werden nicht von der Quellcodeverwaltung 
getrackt und m�ssen nur einmalig eingerichtet werden. In der .gitignore muss dementsprechend folgender Eintrag stehen

```
# External references e.g. Alphaplan via link. ignore all folders and files under this folder but the README.md
*
!.gitignore
!README.md
```

Die Orte zu den Veweisen in den Projektdateien z.B. auf die Base.dll zeigen nur auf das verkn�pfte Verzeichnis.
Eine �nderung in den Projektreferenzen muss also nicht mehr stattfinden.

Das Quellverzeichnis f�r die Referenzierung ist das Verzeichnis, in dem diese README Datei liegt. Die 
Standard Alpahplan Installation liegt unter alphaplan. Bei weiteren Versionen oder Installationen muss einmalig 
via organisatorische Richtlinie definiert werden, wie diese Verkn�pfungen hei�en sollen.

Mit folgenden Befehl wird dann z.B. das Alphaplanverzeichnis `C:\Alphaplan\MeineInstallation\ALPHAPLAN` unter 
`references\alphaplan` eingebunden. Achtung es wird die sog. "Junction" Verkn�pfung verwendet, so sieht es aus, 
als ob das komplette Verzeichnisstruktur unter `references\alphaplan` liegt.

_HINWEIS_ Bei der Junction Verkn�pfung k�nnen nur Verweise auf dem lokalen Computer verwendet werden.

## Einrichtung

* Startpunkt ist das Wurzelverzeichnis des Repositories.
* �ffnen der Developer Konsole in Visual Studio
* Ersetzen des Pfad ```C:\Alphaplan\MeineInstallation\ALPHAPLAN``` mit der Verzeichnis in dem das app, Faktura usw. Unterverzeichnis liegt.

Powershell Variante
```
cd .\references\
cmd /c mklink /J alphaplan C:\Alphaplan\MeineInstallation\ALPHAPLAN
```

Konsole Variante
```
cd references
mklink /J alphaplan C:\Alphaplan\MeineInstallation\ALPHAPLAN
```

Die Ausgabe erfolgt dann wie folgt

```
Verbindung erstellt f�r alphaplan <<===>> C:\Alphaplan\MeineInstallation\ALPHAPLAN
```

## Beispiel

Folgende Befehle erstellen die Verkn�pfungen zu den unterschiedlichen Alphaplan Versionen.

```
cd references
mklink /J alphaplan-2100-287 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.2100.287
mklink /J alphaplan-2850-200 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.2800.200
mklink /J alphaplan-3400-134 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.3400.134
mklink /J alphaplan-3850-478 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.3850.478
mklink /J alphaplan-4900-311 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.4900.311
mklink /J alphaplan-5500-170 D:\Alphaplan\Entwicklung\Plugin.Core\ALPHAPLAN.5500.170
```