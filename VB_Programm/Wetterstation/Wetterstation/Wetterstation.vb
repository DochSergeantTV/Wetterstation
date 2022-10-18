'Bibliotheken
Imports System.ComponentModel
Imports System
Imports System.Text
Imports System.IO.Ports
Imports Microsoft.VisualBasic.FileIO

'Eigentliches Programm
Public Class Wetterstation

#Region "Definitionen"
    'In diesem Bereich werden die Varriablen gespeichert, welche im Verlauf des Programms benutzt werden

    Delegate Sub SetTextCallback(ByVal [text] As String) ' Delegate
    Dim Portzustand As Boolean 'booleanscher Wert für Umschaltung Port auf/zu

    'Kennzeichnungsregister
    Dim Kennzeichnung_1 As Integer
    Dim Kennzeichnung_2 As Integer

    'Winddeutung
    Dim Counter_1 As Integer
    Dim Counter_2 As Integer

    'Temperaturaddierung
    Dim Temp_1 As Integer
    Dim Temp_2 As Integer

    'Buffer für die Werte
    Dim Temp_Buffer As Integer
    Dim Wind_Buffer As Integer

    'Aktuelle Werte
    Dim Temperatur_Wert As Double
    Dim Wind_Counter As Integer

    'Durchschnitt des Windes
    Dim Wind As Integer
    Dim Wind1 As Integer
    Dim Wind_Durchschnitt As Double

    'Durchschnitt der Temperatur
    Dim Temp As Integer
    Dim Temp1 As Integer
    Dim Temp_Durchschnitt As Double

    'Für die Diagramme
    Dim c As Integer

#End Region

#Region "Form"
    Private Sub Wetterstation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gbSteuerung.Visible = False
        gbEinstellungen.Visible = False
        btnManuell_Senden.Enabled = False
        lblTemperatur.Text = ""
        lblWindgeschwindigkeit.Text = ""
        lblWindÜbersetzung.Text = ""
        PbTempDown.Visible = False
        PbTempneutral.Visible = False
        PbTempUp.Visible = False

        SerielleComs()          'Führt die SubRoutine SerielleCOMs aus

        'Standarteinstellungen für 8N1
        cbCom.SelectedIndex = 2 'COM-PORT COM3
        cbBaudrate.SelectedIndex = 1 'Baudrate 9600
        cbDatenbits.SelectedIndex = 4 'Datenbits 8
        cbParität.SelectedIndex = 0 'Parität keine (none)
        cbStoppbits.SelectedIndex = 0 'Stoppbits
        SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub

    Private Sub Wetterstation_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'SerialPort beim Beenden schließen
        Try
            SerialPort1.Write(Chr(64))
        Catch ex As Exception
            SerialPort1.Close()
        End Try

        SerialPort1.Close()
    End Sub

#End Region

#Region "Subs"
    Sub SerielleComs()
        'zeigt alle verfügbaren COM-Ports in ComboBox 1
        For Each COMPort As String In My.Computer.Ports.SerialPortNames
            cbCom.Items.Add(COMPort)
        Next
    End Sub

    Private Sub SerialPort1_DataReceieved(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'Empfängt den Text
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)
        'leitet empfangenen Daten mittels des Delegaten von SerialPort1 in tbDebug
        If Me.tbDebug.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.tbDebug.Text &= Asc([text])
            Me.tbDebug.Text = Me.tbDebug.Text + " "
        End If
    End Sub
#End Region

#Region "Einstellungen"
    'Der Beich der Einstellungen welche getätigt werden können
    Private Sub btnEinstellungenÖffnen_Click(sender As Object, e As EventArgs) Handles btnEinstellungenÖffnen.Click

        btnEinstellungenÖffnen.BackColor = Color.FromArgb(0, 255, 0)
        btnEinstellungenSchließen.BackColor = BackColor
        btnEinstellungenÖffnen.Enabled = False
        btnEinstellungenSchließen.Enabled = True
        gbEinstellungen.Visible = True
        btnComÖffnen.BackColor = BackColor
        btnComSchließen.BackColor = BackColor

    End Sub

    Private Sub btnEinstellungenSchließen_Click(sender As Object, e As EventArgs) Handles btnEinstellungenSchließen.Click

        btnEinstellungenSchließen.BackColor = Color.FromArgb(255, 0, 0)
        btnEinstellungenÖffnen.BackColor = BackColor
        btnEinstellungenSchließen.Enabled = False
        btnEinstellungenÖffnen.Enabled = True
        gbEinstellungen.Visible = False
        btnComÖffnen.BackColor = BackColor
        btnComSchließen.BackColor = BackColor

    End Sub
#End Region

#Region "COM-Schnittstelle"
    'Die Region handelt von der COMschnittstelle
    Private Sub btnComÖffnen_Click(sender As Object, e As EventArgs) Handles btnComÖffnen.Click

        Try
            btnComÖffnen.BackColor = Color.FromArgb(0, 255, 0)
            btnComSchließen.BackColor = BackColor
            btnComÖffnen.Enabled = False
            btnComSchließen.Enabled = True
            gbSteuerung.Visible = True
            btnEinstellungenÖffnen.Enabled = False
            btnEinstellungenSchließen.Enabled = False
            btnEinstellungenSchließen.BackColor = BackColor
            btnEinstellungenÖffnen.BackColor = BackColor

            'Zuweisung der Einstellung

            Dim Baudrate As Integer = cbBaudrate.Text
            Dim Datenbits As Integer = cbDatenbits.Text
            Dim Stoppbits As Integer = cbStoppbits.Text

            SerialPort1.BaudRate = Baudrate
            SerialPort1.DataBits = Datenbits
            SerialPort1.StopBits = Stoppbits

            Select Case True
                Case cbParität.SelectedIndex = 0
                    SerialPort1.Parity = IO.Ports.Parity.None 'keine Parität
                Case cbParität.SelectedIndex = 1
                    SerialPort1.Parity = IO.Ports.Parity.Even 'gerade Parität
                Case cbParität.SelectedIndex = 2
                    SerialPort1.Parity = IO.Ports.Parity.Odd  'ungerade Parität
            End Select

            'Port öffnen
            SerialPort1.Open()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Öffnen der Schnittstelle", "Fehler")
            BtnSchließen()
        End Try


    End Sub

    Private Sub btnComSchließen_Click(sender As Object, e As EventArgs) Handles btnComSchließen.Click

        BtnSchließen()

    End Sub


    Private Sub BtnSchließen()
        btnComSchließen.BackColor = Color.FromArgb(255, 0, 0)
        btnComÖffnen.BackColor = BackColor
        btnComSchließen.Enabled = False
        btnComÖffnen.Enabled = True
        gbSteuerung.Visible = False
        btnEinstellungenÖffnen.Enabled = True
        btnManuell.Enabled = True
        btnManuell_Senden.Enabled = False
        tbDebug.Text = ""
        btnAutomatik.Enabled = True

        btnComÖffnen.Enabled = False
        Timer2.Interval = 5000
        Timer2.Start()

        Try
            SerialPort1.Write(Chr(64))
            SerialPort1.Close() 'Port schließen
        Catch ex As Exception

        End Try

    End Sub
#End Region


#Region "Steuerung"
    'In diesem Bereich geht es um die Steuerung der Buttons

    Private Sub btnManuell_Senden_Click(sender As Object, e As EventArgs) Handles btnManuell_Senden.Click

        btnManuell_Senden.Enabled = False
        btnAutomatik.Enabled = False
        lblManuell.Text = "Nicht Bereit"
        'Werte und Timer einstellen
        Timer1.Interval = 5000
        Timer1.Start()
        'Senden von einer 128 an den uC für den Modus Manuell, beachten dass beim 2 mal der 128 erst gesendet wird
        SerialPort1.Write(Chr(128))

    End Sub

    Private Sub btnManuell_Click(sender As Object, e As EventArgs) Handles btnManuell.Click

        btnManuell_Senden.Enabled = True
        btnManuell.Enabled = False
        btnAutomatik.Enabled = True
        'Senden von einer 128 an den uC für den Modus Manuell
        SerialPort1.Write(Chr(128))

    End Sub
    Private Sub btnAutomatik_Click(sender As Object, e As EventArgs) Handles btnAutomatik.Click
        'Wert 0 an uC senden für automatischen Betrieb
        SerialPort1.Write(Chr(0))
        btnManuell.Enabled = True
        btnManuell_Senden.Enabled = False
        btnAutomatik.Enabled = False
    End Sub

#End Region

#Region "Rechnung"
    'In diesem Bereich finden alle Rechnungen statt welche benötigt werden und daraus resultierende Methodenaufrufe

    Private Sub tbDebug_TextChanged(sender As Object, e As EventArgs) Handles tbDebug.TextChanged
        'Wenn die TextboxDebug geändert wurde dann wird der Bereich ausgeführt

        Dim testString As String = tbDebug.Text 'weißt dem String testString den Inhalt von tbDebug zu
        Dim testArray() As String = Split(testString)   'Trennt mit dem leerzeichen die Werte voneinander

        'Wenn der Array eine Länge von 7 erreich dann das:
        'Dabei wird jedes Element zur richtigen Methode Weitergeleitet
        If testArray.Length = 7 Then
            Kennzeichnung_1 = testArray(0)  'Wird nicht verwendet, kann aber genutzt werden
            Counter_1 = testArray(1)    'Unwichtig, da wir nur einen 8-Bit Counter haben
            Counter(testArray(2))   'Der 8-Bit Zähler, Methodenaufruf
            Kennzeichnung_2 = testArray(3)  'Wird nicht verwendet, kann aber genutzt werden
            Temperatur_Addierung(testArray(4), testArray(5))    'Werte für die Temperatur übergeben, Methodenaufruf
            tbDebug.Text = ""   'Danach leeren
        End If

    End Sub

    Private Sub Temperatur_Addierung(ByVal Wert_1 As Integer, ByVal Wert_2 As Integer)
        'In diesem Bereich wir der Bereich vom 9 und 10Bit interpretiert und mit den ersten 8 Bits verechnet
        Select Case Wert_1
            Case 0
                Temp_1 = 0
            Case 1
                Temp_1 = 256
            Case 2
                Temp_1 = 512
            Case 3
                Temp_1 = 768
        End Select
        Temperatur(Temp_1 + Wert_2) 'Werte an Temperatur übergeben, Methodenaufruf

    End Sub

    Private Sub Temperatur(ByVal ADC_Wert As Integer)
        'Temperatur beinhaltet die Berechnung des Temperaturwertes in Grad Celsius

        'Label und PictureBoxen Setzung
        lblTempMittelwert.Visible = True
        PbTempUp.Visible = False
        PbTempneutral.Visible = True
        PbTempDown.Visible = False

        'Berechnung der Temperatur
        Temperatur_Wert = Math.Round((-0.5 * ADC_Wert) + 315.165) '315 aufgrund von Messfehler, da 319 nicht korrekte Werte wiedergibt, siehe Regression

        'Wenn der ADC-Wert außerhalb des Wertebereichs liegt
        If ADC_Wert > 700 Then
            lblTemperatur.Text = "Fehler am Sensor"
        ElseIf ADC_Wert < 500 Then
            lblTemperatur.Text = "Fehler am Sensor"
        Else 'Wenn alles passt
            lblTemperatur.Text = Temperatur_Wert & " Grad Celsius" 'Temperatur zum Label übergeben
            CreateCSVfile("../../../../../Datenbank/Wertespeicher.csv", Temperatur_Wert.ToString(), Wind_Counter.ToString()) 'Daten speichern

            'Diagramm für Temperatur
            Me.Series_Temp.Series("Series_Temp").Points.AddXY(c, Temperatur_Wert) 'Diagramm der Temperatur beschreiben
            c += 1 'Dafür wird das c genutzt, damit immer ein neuer x-Wert entstehen kann, auch übergreifen auf das Diagramm von Wind

            'Durchschnitt für Temperatur berechnen
            Temp += Temperatur_Wert
            Temp1 += 1
            Temp_Durchschnitt = Temp / Temp1
            lblTempMittelwert.Text = Math.Round(Temp_Durchschnitt, 2) & " Grad"

            'Steuerung des Anzeigepfeils
            If Temp_Buffer = 0 Then
                PbTempneutral.Visible = True
            ElseIf Temp_Buffer > Temperatur_Wert Then
                PbTempDown.Visible = True
                PbTempneutral.Visible = False
            ElseIf Temp_Buffer < Temperatur_Wert Then
                PbTempUp.Visible = True
                PbTempneutral.Visible = False
            End If
            Temp_Buffer = Temperatur_Wert

        End If





    End Sub

    Private Sub Counter(ByVal Counter)

        'Label und PB anpassen für die Anzeigen
        lblWindMittelwert.Visible = True
        pbWindSchwach.Visible = False
        pbWindMittel.Visible = False
        PbWindStark.Visible = False

        'Windgeschwindigkeit berechnen, beachten der 4 Impulse pro 1 m/s
        Wind_Counter = Counter / 4
        lblWindgeschwindigkeit.Text = Wind_Counter & " m/s"

        'Der Winddruchschnitt wird berechnet
        Wind += Wind_Counter
        Wind1 += 1
        Wind_Durchschnitt = Wind / Wind1
        lblWindMittelwert.Text = Math.Round(Wind_Durchschnitt, 2) & " m/s"

        'Deutung der Geschwindigkeiten in Benennungen
        If Wind_Counter = 0 Then
            lblWindÜbersetzung.Text = "Kein Wind"
            pbWindSchwach.Visible = True
        ElseIf Wind_Counter < 3 Then
            lblWindÜbersetzung.Text = "leichte Briese"
            pbWindSchwach.Visible = True
        ElseIf Wind_Counter < 10 Then
            lblWindÜbersetzung.Text = "frische Briese"
            pbWindMittel.Visible = True
        ElseIf Wind_Counter < 14 Then
            lblWindÜbersetzung.Text = "Starker Wind"
            pbWindMittel.Visible = True
        ElseIf Wind_Counter < 20 Then
            lblWindÜbersetzung.Text = "Stürmischer Wind"
            PbWindStark.Visible = True
        ElseIf Wind_Counter < 25 Then
            lblWindÜbersetzung.Text = "Sturm"
            PbWindStark.Visible = True
        ElseIf Wind_Counter < 32 Then
            lblWindÜbersetzung.Text = "Orkanartiker Sturm"
            PbWindStark.Visible = True
        ElseIf Wind_Counter > 32 Then
            lblWindÜbersetzung.Text = "Orkan"
            PbWindStark.Visible = True
        End If

        'Diagramm erstellen mit den Werten und c als x-Wert von Temperatur
        Me.Series_Wind.Series("Series_Wind").Points.AddXY(c, Wind_Counter)

    End Sub
#End Region

#Region "Timer"
    'Timer wird genutzt, damit wir versetzt die Buttons aktivieren und deaktivieren können
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Wenn Timer1 ausgelaufen ist dann passiert das folgende

        btnManuell_Senden.Enabled = True
        btnAutomatik.Enabled = True
        Timer1.Stop()
        lblManuell.Text = "Bereit"

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'Wenn Timer2 ausgelaufen ist dann passiert das folgende
        btnComÖffnen.Enabled = True
        Timer2.Stop()

    End Sub


#End Region

#Region "Speicherung in CSV"

    Private Sub CreateCSVfile(ByVal _strCustomerCSVPath As String, ByVal _Temperatur As String, ByVal _Geschwingkeit As String)
        'Unterfunktion zum erstellen oder beschreiben der csv-Datei
        Try
            'Versuche den Aufruf

            Dim objWriter As IO.StreamWriter = IO.File.AppendText(_strCustomerCSVPath)
            'Definiert den objWriter und wo dieser schreiben soll

            If IO.File.Exists(_strCustomerCSVPath) Then
                'Wenn die Datei existiert, dann ....

                objWriter.Write(DateTime.Now.ToString(“dd.MM.yyyy HH:mm:ss”) & " Temperatur: " & _Temperatur & " ")
                objWriter.Write(Environment.NewLine)
                'Schreib eine neue Linie nach Abschluss, damit wir immer eine neue Zeile beschreiben
                objWriter.Write(DateTime.Now.ToString(“dd.MM.yyyy HH:mm:ss”) & " Geschwindigkeit: " & _Geschwingkeit)
                'Schreibt das Datum mit einem String und der Varriable in die Datei
                'Das Unterstrich mit der Varriable haben wir oben in der Sub-Funktion definiert und wird übergeben

                objWriter.Write(Environment.NewLine)
                'Schreib eine neue Linie nach Abschluss, damit wir immer eine neue Zeile beschreiben

            End If
            objWriter.Close()
            'Beendet den objWriter


        Catch ex As Exception
            'sonst der Aufruf bei Fehlern
            MessageBox.Show("Fehler beim Schreiben", "ERROR")
        End Try
    End Sub




#End Region

#Region "Lesen der CSV"
    Private Sub Lesen(ByVal Definition)
        'Zum Lesen der Datei, Definition ist, welchen Typ der Daten wir auslesen möchten

        Try
            'Versuche den Aufruf

            Using MyReader As New Microsoft.VisualBasic.
                 FileIO.TextFieldParser("../../../../../Datenbank/Wertespeicher.csv")
                'Liest die Datei ein, welche am Ort gespeichert sind

                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                'Nach einem Komma soll eine neue Zeile beginnen und geschrieben werden


                Dim currentRow As String()
                'Kreiert eine neue Varriable als Array des Typs: String

                While Not MyReader.EndOfData
                    'Solange nicht das Ende der Daten in der Datei ist soll dieses Skirpt ausgeführt werden
                    Try
                        'Versuche...

                        currentRow = MyReader.ReadFields()
                        'Weißt der Varriablen die zu lesenden Felder zu (Also erschaft er ein interrierbares Objekt)

                        Dim currentField As String
                        'Kreiert eine Varriable von Typ String

                        For Each currentField In currentRow
                            'Arbeitet sich durch jedes Element in CurrentRow und gibt das currentFiled, also den Inhalt wieder

                            Dim i As Integer
                            'Kreiert die lokale varriable i von Typ int, da wir nach abwechselnde Zeilen haben nutzen wir das aus

                            'Erste Zeile wird ausgelesen und dann die 3 und so weiter
                            If Definition = "Temp" Then
                                If i Mod 2 = 0 Then
                                    RTBTemp.Text = RTBTemp.Text + currentField + " Grad " + Environment.NewLine
                                    i += 1
                                Else
                                    i += 1
                                End If

                            End If

                            'Zweite Zeile wird ausgelesen dann die 4 und so weiter
                            If Definition = "Wind" Then
                                If i Mod 2 = 1 Then
                                    RTBWind.Text = RTBWind.Text + currentField + " m/s " + Environment.NewLine
                                    i += 1
                                Else
                                    i += 1
                                End If
                            End If


                        Next




                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        'Wenn eine Zeile falsch ist von Format oder sonstiges, wird es übersprungen

                        MsgBox("Line " & ex.Message & "Ist nicht korrekt und wird übersprungen")
                        'Kennen wir ja... :D
                        'ex.Massage ist der Fehler 

                    End Try
                End While
            End Using

        Catch ex As Exception
            'sonst der Aufruf bei Fehlern
            MessageBox.Show("Fehler beim Lesen, keine Datei vorhanden", "ERROR")
        End Try

    End Sub


    Private Sub btnTempAuslesen_Click(sender As Object, e As EventArgs) Handles btnTempAuslesen.Click
        RTBTemp.Text = ""
        Lesen("Temp")
    End Sub

    Private Sub btnWindAuslesen_Click(sender As Object, e As EventArgs) Handles btnWindAuslesen.Click
        RTBWind.Text = ""
        Lesen("Wind")
    End Sub


#End Region

End Class
