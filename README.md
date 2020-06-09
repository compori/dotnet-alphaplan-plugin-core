# Alphaplan Plugin Framework

## Todo

* Build Instructions
* Test Instructions

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
