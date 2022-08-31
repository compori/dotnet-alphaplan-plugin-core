# Alphaplan Plugin Framework

## Cake installieren oder aktualisieren

In der Powershell mit Administratorenrechten sollte das Cake Build Tool global installiert werden.
Optional kann ein nuget Konfigurationsdatei übergeben werden.

```
dotnet tool install --global Cake.Tool --configfile C:\Tools\Nuget\NuGet.Config
```

Wenn Cake bereits installiert ist, kann nach Updates gesucht werden.

```
dotnet tool update --global Cake.Tool --configfile C:\Tools\Nuget\NuGet.Config
```

## Build starten

Im Stammverzeichnis folgenden Befehl ausführen.

```
dotnet cake
```

## Hinweis

Damit die Test für 2850 und 3150 laufen ist es notwendig die xunit.dll für die 1.9.2 ins GAC zu installieren.

Z.B. ausgehende vom Stammverzeichnis der Solution:

```
cd .\references\alphaplan-2850\app\Data\Eigene
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\gacutil.exe" -i .\xunit.dll
```

Im GAC steht dann folgender Eintrag:

```
xunit, Version=1.9.2.1705, Culture=neutral, PublicKeyToken=8d05b1bb7a6fdb6c, processorArchitecture=MSIL
```
