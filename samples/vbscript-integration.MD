# Integration via DesignKit

In die Global Deklaration (Kunde)

```vb
''' Beschreibung
'''   Führt ein Remote Plugin aus.
'''
''' Parameter
'''   strPlugin          - Name des Plugin inkl. Dateiendung '.dll'
'''   aParameters        - String Array mit Parametern
'''   oResultDict        - Ein CreateObject("Scripting.Dictionary") Objekt zur Aufnahme der Ergebnisse.
Function G_ExecuteRemotePlugin(strPlugin, aParameters, oResultDict)

    Dim bRemoteServiceAvailable : bRemoteServiceAvailable = False

    ' Prüfung ob der Remote Service verfügbar ist.
On Error Resume Next
    bRemoteServiceAvailable = Global.APSIsALSInstanceAvailable()
    If Err.Number <> 0 Then
        bRemoteServiceAvailable = False
    End If

    Call oResultDict.RemoveAll()

    If Not bRemoteServiceAvailable Then

        Call oResultDict.Add("succeeded", "0")
        Call oResultDict.Add("failureMessage", "Der Remoteclient konnte nicht angesprochen werden. " _ 
            & "Bitte prüfen Sie ob der RemoteService gestartet und ob Alphaplan mit diesem verbunden ist. " _ 
            & "Sollte der Fehler nach einem Neustart von Alphaplan immernoch auftreten, kontaktieren Sie Ihren Alphaplansystemadministrator.")

    Else
        
        ' Plugin ausführen und Ergebnis auf Array prüfen.
        Dim aResult : aResult = Global.APSRunALS(strPlugin, aParameters)

        ' MsgBox "VarType(aResult) = " & VarType(aResult)
        ' MsgBox Err.Number & " - " & Err.Description

        If VarType(aResult) And vbArray = vbArray Then
            
            for i = 0 To UBound(aResult)

                ' MsgBox "VarType(aResult(" & i & ")) = " & VarType(aResult(i))
                Dim strItem : strItem = CStr(aResult(i))
                Dim aKeyValuePair : aKeyValuePair = Split(strItem, "=", 2)
                If UBound(aKeyValuePair) = 1 Then
                    Call oResultDict.Add(Trim(aKeyValuePair(0)), Trim(aKeyValuePair(1)))
                End If
            Next
        Else
            Call oResultDict.Add("succeeded", "0")
            Call oResultDict.Add("failureMessage", "Das Rückgabeergebnis war keine Array oder leer.")
        End If
    End If
    
    ' Prüfe ob das Ergebnis verüfgbar ist
    If Not oResultDict.Exists("succeeded") Then 
        Call oResultDict.Add("succeeded", "0")
        If Not oResultDict.Exists("failureMessage") Then 
            Call oResultDict.Add("failureMessage", "Das Rückgabeergebnis enthielt keinen Fehlercode.")
        End If
    End If    

    ' Ergebnis zurückliefern
    Dim bRemoteExecutionSucceeded : bRemoteExecutionSucceeded = oResultDict("succeeded") <> "0"
    G_ExecuteRemotePlugin = bRemoteExecutionSucceeded
    
End Function
```

Beispielaufruf z.B. im Button Code

```vb
    Dim aParameters : aParameters = Array( _
        "aktion=testing.echo", _
        "nachricht=""Hallo Welt!""" _
    )
    Dim strPlugin : strPlugin = "Company.SuperDuper.Plugin.dll"
    
    Dim oResultDict
    Set oResultDict = CreateObject("Scripting.Dictionary")
    If Not G_ExecuteRemotePlugin(strPlugin, aParameters, oResultDict) Then
        MsgBox oResultDict("failureMessage"), vbOkonly + vbExclamation, "Fehler"
        Exit Sub
    End If
    
    MsgBox oResultDict("echo"), vbOkonly + vbInformation, "Result"
```