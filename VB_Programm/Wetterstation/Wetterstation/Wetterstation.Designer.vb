<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Wetterstation
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Wetterstation))
        Me.tbDebug = New System.Windows.Forms.TextBox()
        Me.cbStoppbits = New System.Windows.Forms.ComboBox()
        Me.cbParität = New System.Windows.Forms.ComboBox()
        Me.cbDatenbits = New System.Windows.Forms.ComboBox()
        Me.cbBaudrate = New System.Windows.Forms.ComboBox()
        Me.cbCom = New System.Windows.Forms.ComboBox()
        Me.lblParität = New System.Windows.Forms.Label()
        Me.lblBaudrate = New System.Windows.Forms.Label()
        Me.lblStoppbits = New System.Windows.Forms.Label()
        Me.lblDatenbits = New System.Windows.Forms.Label()
        Me.lblCOM_Port = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lblEinstellungen = New System.Windows.Forms.Label()
        Me.gbEinstellungen = New System.Windows.Forms.GroupBox()
        Me.btnEinstellungenÖffnen = New System.Windows.Forms.Button()
        Me.btnEinstellungenSchließen = New System.Windows.Forms.Button()
        Me.lblSteuerung = New System.Windows.Forms.Label()
        Me.gbSteuerung = New System.Windows.Forms.GroupBox()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.lblManuell = New System.Windows.Forms.Label()
        Me.btnManuell_Senden = New System.Windows.Forms.Button()
        Me.btnAutomatik = New System.Windows.Forms.Button()
        Me.btnManuell = New System.Windows.Forms.Button()
        Me.btnComSchließen = New System.Windows.Forms.Button()
        Me.btnComÖffnen = New System.Windows.Forms.Button()
        Me.lblCom = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblTemperatur = New System.Windows.Forms.Label()
        Me.lblWindgeschwindigkeit = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lblWindÜbersetzung = New System.Windows.Forms.Label()
        Me.lblTemperaturÜberschrift = New System.Windows.Forms.Label()
        Me.lblWindÜberschrift = New System.Windows.Forms.Label()
        Me.lblTempAktuell = New System.Windows.Forms.Label()
        Me.lblWindAktuell = New System.Windows.Forms.Label()
        Me.lblGleich = New System.Windows.Forms.Label()
        Me.lblTempMittelwert_Title = New System.Windows.Forms.Label()
        Me.lblWindMittelwert_Title = New System.Windows.Forms.Label()
        Me.lblTempMittelwert = New System.Windows.Forms.Label()
        Me.lblWindMittelwert = New System.Windows.Forms.Label()
        Me.pbWindSchwach = New System.Windows.Forms.PictureBox()
        Me.pbWindMittel = New System.Windows.Forms.PictureBox()
        Me.PbWindStark = New System.Windows.Forms.PictureBox()
        Me.PbTempDown = New System.Windows.Forms.PictureBox()
        Me.PbTempneutral = New System.Windows.Forms.PictureBox()
        Me.PbTempUp = New System.Windows.Forms.PictureBox()
        Me.btnTempAuslesen = New System.Windows.Forms.Button()
        Me.btnWindAuslesen = New System.Windows.Forms.Button()
        Me.RTBTemp = New System.Windows.Forms.RichTextBox()
        Me.RTBWind = New System.Windows.Forms.RichTextBox()
        Me.Series_Temp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Series_Wind = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblChartPunkt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblChartTemp = New System.Windows.Forms.Label()
        Me.lblChartWind = New System.Windows.Forms.Label()
        Me.gbEinstellungen.SuspendLayout()
        Me.gbSteuerung.SuspendLayout()
        CType(Me.pbWindSchwach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbWindMittel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbWindStark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbTempDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbTempneutral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbTempUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Series_Temp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Series_Wind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbDebug
        '
        Me.tbDebug.Location = New System.Drawing.Point(227, 66)
        Me.tbDebug.Name = "tbDebug"
        Me.tbDebug.ReadOnly = True
        Me.tbDebug.Size = New System.Drawing.Size(100, 20)
        Me.tbDebug.TabIndex = 49
        '
        'cbStoppbits
        '
        Me.cbStoppbits.FormattingEnabled = True
        Me.cbStoppbits.Items.AddRange(New Object() {"1", "1,5", "2"})
        Me.cbStoppbits.Location = New System.Drawing.Point(65, 71)
        Me.cbStoppbits.Name = "cbStoppbits"
        Me.cbStoppbits.Size = New System.Drawing.Size(121, 21)
        Me.cbStoppbits.TabIndex = 43
        '
        'cbParität
        '
        Me.cbParität.FormattingEnabled = True
        Me.cbParität.Items.AddRange(New Object() {"Keine", "Gerade", "Ungerade"})
        Me.cbParität.Location = New System.Drawing.Point(65, 125)
        Me.cbParität.Name = "cbParität"
        Me.cbParität.Size = New System.Drawing.Size(121, 21)
        Me.cbParität.TabIndex = 42
        '
        'cbDatenbits
        '
        Me.cbDatenbits.FormattingEnabled = True
        Me.cbDatenbits.Items.AddRange(New Object() {"4", "5", "6", "7", "8"})
        Me.cbDatenbits.Location = New System.Drawing.Point(65, 40)
        Me.cbDatenbits.Name = "cbDatenbits"
        Me.cbDatenbits.Size = New System.Drawing.Size(121, 21)
        Me.cbDatenbits.TabIndex = 41
        '
        'cbBaudrate
        '
        Me.cbBaudrate.FormattingEnabled = True
        Me.cbBaudrate.Items.AddRange(New Object() {"1200", "9600", "19200", "115200"})
        Me.cbBaudrate.Location = New System.Drawing.Point(65, 98)
        Me.cbBaudrate.Name = "cbBaudrate"
        Me.cbBaudrate.Size = New System.Drawing.Size(121, 21)
        Me.cbBaudrate.TabIndex = 40
        '
        'cbCom
        '
        Me.cbCom.FormattingEnabled = True
        Me.cbCom.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8"})
        Me.cbCom.Location = New System.Drawing.Point(65, 13)
        Me.cbCom.Name = "cbCom"
        Me.cbCom.Size = New System.Drawing.Size(121, 21)
        Me.cbCom.TabIndex = 39
        '
        'lblParität
        '
        Me.lblParität.AutoSize = True
        Me.lblParität.Location = New System.Drawing.Point(22, 131)
        Me.lblParität.Name = "lblParität"
        Me.lblParität.Size = New System.Drawing.Size(37, 13)
        Me.lblParität.TabIndex = 38
        Me.lblParität.Text = "Parität"
        '
        'lblBaudrate
        '
        Me.lblBaudrate.AutoSize = True
        Me.lblBaudrate.Location = New System.Drawing.Point(9, 103)
        Me.lblBaudrate.Name = "lblBaudrate"
        Me.lblBaudrate.Size = New System.Drawing.Size(50, 13)
        Me.lblBaudrate.TabIndex = 37
        Me.lblBaudrate.Text = "Baudrate"
        '
        'lblStoppbits
        '
        Me.lblStoppbits.AutoSize = True
        Me.lblStoppbits.Location = New System.Drawing.Point(8, 74)
        Me.lblStoppbits.Name = "lblStoppbits"
        Me.lblStoppbits.Size = New System.Drawing.Size(51, 13)
        Me.lblStoppbits.TabIndex = 36
        Me.lblStoppbits.Text = "Stoppbits"
        '
        'lblDatenbits
        '
        Me.lblDatenbits.AutoSize = True
        Me.lblDatenbits.Location = New System.Drawing.Point(7, 44)
        Me.lblDatenbits.Name = "lblDatenbits"
        Me.lblDatenbits.Size = New System.Drawing.Size(52, 13)
        Me.lblDatenbits.TabIndex = 35
        Me.lblDatenbits.Text = "Datenbits"
        '
        'lblCOM_Port
        '
        Me.lblCOM_Port.AutoSize = True
        Me.lblCOM_Port.Location = New System.Drawing.Point(6, 16)
        Me.lblCOM_Port.Name = "lblCOM_Port"
        Me.lblCOM_Port.Size = New System.Drawing.Size(53, 13)
        Me.lblCOM_Port.TabIndex = 34
        Me.lblCOM_Port.Text = "COM-Port"
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'lblEinstellungen
        '
        Me.lblEinstellungen.AutoSize = True
        Me.lblEinstellungen.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEinstellungen.Location = New System.Drawing.Point(43, 25)
        Me.lblEinstellungen.Name = "lblEinstellungen"
        Me.lblEinstellungen.Size = New System.Drawing.Size(177, 31)
        Me.lblEinstellungen.TabIndex = 52
        Me.lblEinstellungen.Text = "Einstellungen"
        '
        'gbEinstellungen
        '
        Me.gbEinstellungen.Controls.Add(Me.cbCom)
        Me.gbEinstellungen.Controls.Add(Me.lblCOM_Port)
        Me.gbEinstellungen.Controls.Add(Me.lblDatenbits)
        Me.gbEinstellungen.Controls.Add(Me.lblStoppbits)
        Me.gbEinstellungen.Controls.Add(Me.lblBaudrate)
        Me.gbEinstellungen.Controls.Add(Me.lblParität)
        Me.gbEinstellungen.Controls.Add(Me.cbBaudrate)
        Me.gbEinstellungen.Controls.Add(Me.cbDatenbits)
        Me.gbEinstellungen.Controls.Add(Me.cbParität)
        Me.gbEinstellungen.Controls.Add(Me.cbStoppbits)
        Me.gbEinstellungen.Location = New System.Drawing.Point(278, 25)
        Me.gbEinstellungen.Name = "gbEinstellungen"
        Me.gbEinstellungen.Size = New System.Drawing.Size(200, 159)
        Me.gbEinstellungen.TabIndex = 53
        Me.gbEinstellungen.TabStop = False
        '
        'btnEinstellungenÖffnen
        '
        Me.btnEinstellungenÖffnen.Location = New System.Drawing.Point(49, 71)
        Me.btnEinstellungenÖffnen.Name = "btnEinstellungenÖffnen"
        Me.btnEinstellungenÖffnen.Size = New System.Drawing.Size(70, 27)
        Me.btnEinstellungenÖffnen.TabIndex = 54
        Me.btnEinstellungenÖffnen.Text = "Öffnen"
        Me.btnEinstellungenÖffnen.UseVisualStyleBackColor = True
        '
        'btnEinstellungenSchließen
        '
        Me.btnEinstellungenSchließen.Enabled = False
        Me.btnEinstellungenSchließen.Location = New System.Drawing.Point(145, 71)
        Me.btnEinstellungenSchließen.Name = "btnEinstellungenSchließen"
        Me.btnEinstellungenSchließen.Size = New System.Drawing.Size(70, 27)
        Me.btnEinstellungenSchließen.TabIndex = 55
        Me.btnEinstellungenSchließen.Text = "Schließen"
        Me.btnEinstellungenSchließen.UseVisualStyleBackColor = True
        '
        'lblSteuerung
        '
        Me.lblSteuerung.AutoSize = True
        Me.lblSteuerung.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSteuerung.Location = New System.Drawing.Point(39, 16)
        Me.lblSteuerung.Name = "lblSteuerung"
        Me.lblSteuerung.Size = New System.Drawing.Size(139, 31)
        Me.lblSteuerung.TabIndex = 56
        Me.lblSteuerung.Text = "Steuerung"
        '
        'gbSteuerung
        '
        Me.gbSteuerung.Controls.Add(Me.lblDebug)
        Me.gbSteuerung.Controls.Add(Me.lblManuell)
        Me.gbSteuerung.Controls.Add(Me.btnManuell_Senden)
        Me.gbSteuerung.Controls.Add(Me.btnAutomatik)
        Me.gbSteuerung.Controls.Add(Me.btnManuell)
        Me.gbSteuerung.Controls.Add(Me.lblSteuerung)
        Me.gbSteuerung.Controls.Add(Me.tbDebug)
        Me.gbSteuerung.Location = New System.Drawing.Point(272, 25)
        Me.gbSteuerung.Name = "gbSteuerung"
        Me.gbSteuerung.Size = New System.Drawing.Size(381, 178)
        Me.gbSteuerung.TabIndex = 57
        Me.gbSteuerung.TabStop = False
        '
        'lblDebug
        '
        Me.lblDebug.AutoSize = True
        Me.lblDebug.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebug.Location = New System.Drawing.Point(212, 16)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(140, 31)
        Me.lblDebug.TabIndex = 63
        Me.lblDebug.Text = "DebugBox"
        '
        'lblManuell
        '
        Me.lblManuell.AutoSize = True
        Me.lblManuell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManuell.Location = New System.Drawing.Point(15, 99)
        Me.lblManuell.Name = "lblManuell"
        Me.lblManuell.Size = New System.Drawing.Size(51, 20)
        Me.lblManuell.TabIndex = 61
        Me.lblManuell.Text = "Bereit"
        '
        'btnManuell_Senden
        '
        Me.btnManuell_Senden.Location = New System.Drawing.Point(122, 96)
        Me.btnManuell_Senden.Name = "btnManuell_Senden"
        Me.btnManuell_Senden.Size = New System.Drawing.Size(75, 23)
        Me.btnManuell_Senden.TabIndex = 60
        Me.btnManuell_Senden.Text = "Senden"
        Me.btnManuell_Senden.UseVisualStyleBackColor = True
        '
        'btnAutomatik
        '
        Me.btnAutomatik.Location = New System.Drawing.Point(45, 136)
        Me.btnAutomatik.Name = "btnAutomatik"
        Me.btnAutomatik.Size = New System.Drawing.Size(126, 23)
        Me.btnAutomatik.TabIndex = 59
        Me.btnAutomatik.Text = "Automatischer  Betrieb"
        Me.btnAutomatik.UseVisualStyleBackColor = True
        '
        'btnManuell
        '
        Me.btnManuell.Location = New System.Drawing.Point(45, 64)
        Me.btnManuell.Name = "btnManuell"
        Me.btnManuell.Size = New System.Drawing.Size(126, 23)
        Me.btnManuell.TabIndex = 58
        Me.btnManuell.Text = "Manueller Betrieb"
        Me.btnManuell.UseVisualStyleBackColor = True
        '
        'btnComSchließen
        '
        Me.btnComSchließen.Enabled = False
        Me.btnComSchließen.Location = New System.Drawing.Point(145, 151)
        Me.btnComSchließen.Name = "btnComSchließen"
        Me.btnComSchließen.Size = New System.Drawing.Size(70, 27)
        Me.btnComSchließen.TabIndex = 62
        Me.btnComSchließen.Text = "Schließen"
        Me.btnComSchließen.UseVisualStyleBackColor = True
        '
        'btnComÖffnen
        '
        Me.btnComÖffnen.Location = New System.Drawing.Point(49, 151)
        Me.btnComÖffnen.Name = "btnComÖffnen"
        Me.btnComÖffnen.Size = New System.Drawing.Size(70, 27)
        Me.btnComÖffnen.TabIndex = 61
        Me.btnComÖffnen.Text = "Öffnen"
        Me.btnComÖffnen.UseVisualStyleBackColor = True
        '
        'lblCom
        '
        Me.lblCom.AutoSize = True
        Me.lblCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCom.Location = New System.Drawing.Point(18, 109)
        Me.lblCom.Name = "lblCom"
        Me.lblCom.Size = New System.Drawing.Size(234, 31)
        Me.lblCom.TabIndex = 60
        Me.lblCom.Text = "COM-Schnittstelle"
        '
        'Timer1
        '
        '
        'lblTemperatur
        '
        Me.lblTemperatur.AutoSize = True
        Me.lblTemperatur.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperatur.Location = New System.Drawing.Point(194, 275)
        Me.lblTemperatur.Name = "lblTemperatur"
        Me.lblTemperatur.Size = New System.Drawing.Size(103, 22)
        Me.lblTemperatur.TabIndex = 63
        Me.lblTemperatur.Text = "Temperatur"
        '
        'lblWindgeschwindigkeit
        '
        Me.lblWindgeschwindigkeit.AutoSize = True
        Me.lblWindgeschwindigkeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindgeschwindigkeit.Location = New System.Drawing.Point(747, 276)
        Me.lblWindgeschwindigkeit.Name = "lblWindgeschwindigkeit"
        Me.lblWindgeschwindigkeit.Size = New System.Drawing.Size(99, 22)
        Me.lblWindgeschwindigkeit.TabIndex = 64
        Me.lblWindgeschwindigkeit.Text = "Windgesch"
        '
        'Timer2
        '
        '
        'lblWindÜbersetzung
        '
        Me.lblWindÜbersetzung.AutoSize = True
        Me.lblWindÜbersetzung.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindÜbersetzung.Location = New System.Drawing.Point(856, 275)
        Me.lblWindÜbersetzung.Name = "lblWindÜbersetzung"
        Me.lblWindÜbersetzung.Size = New System.Drawing.Size(149, 22)
        Me.lblWindÜbersetzung.TabIndex = 65
        Me.lblWindÜbersetzung.Text = "Windübersetzung"
        '
        'lblTemperaturÜberschrift
        '
        Me.lblTemperaturÜberschrift.AutoSize = True
        Me.lblTemperaturÜberschrift.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturÜberschrift.Location = New System.Drawing.Point(150, 239)
        Me.lblTemperaturÜberschrift.Name = "lblTemperaturÜberschrift"
        Me.lblTemperaturÜberschrift.Size = New System.Drawing.Size(162, 31)
        Me.lblTemperaturÜberschrift.TabIndex = 66
        Me.lblTemperaturÜberschrift.Text = "Temperatur:"
        '
        'lblWindÜberschrift
        '
        Me.lblWindÜberschrift.AutoSize = True
        Me.lblWindÜberschrift.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindÜberschrift.Location = New System.Drawing.Point(679, 239)
        Me.lblWindÜberschrift.Name = "lblWindÜberschrift"
        Me.lblWindÜberschrift.Size = New System.Drawing.Size(276, 31)
        Me.lblWindÜberschrift.TabIndex = 67
        Me.lblWindÜberschrift.Text = "Windgeschwindigkeit:"
        '
        'lblTempAktuell
        '
        Me.lblTempAktuell.AutoSize = True
        Me.lblTempAktuell.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempAktuell.Location = New System.Drawing.Point(119, 275)
        Me.lblTempAktuell.Name = "lblTempAktuell"
        Me.lblTempAktuell.Size = New System.Drawing.Size(69, 22)
        Me.lblTempAktuell.TabIndex = 68
        Me.lblTempAktuell.Text = "Aktuell:"
        '
        'lblWindAktuell
        '
        Me.lblWindAktuell.AutoSize = True
        Me.lblWindAktuell.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindAktuell.Location = New System.Drawing.Point(672, 276)
        Me.lblWindAktuell.Name = "lblWindAktuell"
        Me.lblWindAktuell.Size = New System.Drawing.Size(69, 22)
        Me.lblWindAktuell.TabIndex = 69
        Me.lblWindAktuell.Text = "Aktuell:"
        '
        'lblGleich
        '
        Me.lblGleich.AutoSize = True
        Me.lblGleich.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGleich.Location = New System.Drawing.Point(829, 275)
        Me.lblGleich.Name = "lblGleich"
        Me.lblGleich.Size = New System.Drawing.Size(21, 22)
        Me.lblGleich.TabIndex = 70
        Me.lblGleich.Text = "="
        '
        'lblTempMittelwert_Title
        '
        Me.lblTempMittelwert_Title.AutoSize = True
        Me.lblTempMittelwert_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempMittelwert_Title.Location = New System.Drawing.Point(21, 309)
        Me.lblTempMittelwert_Title.Name = "lblTempMittelwert_Title"
        Me.lblTempMittelwert_Title.Size = New System.Drawing.Size(167, 22)
        Me.lblTempMittelwert_Title.TabIndex = 74
        Me.lblTempMittelwert_Title.Text = "Mitttelwert (Akutell):"
        '
        'lblWindMittelwert_Title
        '
        Me.lblWindMittelwert_Title.AutoSize = True
        Me.lblWindMittelwert_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindMittelwert_Title.Location = New System.Drawing.Point(574, 309)
        Me.lblWindMittelwert_Title.Name = "lblWindMittelwert_Title"
        Me.lblWindMittelwert_Title.Size = New System.Drawing.Size(167, 22)
        Me.lblWindMittelwert_Title.TabIndex = 75
        Me.lblWindMittelwert_Title.Text = "Mitttelwert (Akutell):"
        '
        'lblTempMittelwert
        '
        Me.lblTempMittelwert.AutoSize = True
        Me.lblTempMittelwert.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempMittelwert.Location = New System.Drawing.Point(194, 309)
        Me.lblTempMittelwert.Name = "lblTempMittelwert"
        Me.lblTempMittelwert.Size = New System.Drawing.Size(0, 22)
        Me.lblTempMittelwert.TabIndex = 76
        Me.lblTempMittelwert.Visible = False
        '
        'lblWindMittelwert
        '
        Me.lblWindMittelwert.AutoSize = True
        Me.lblWindMittelwert.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWindMittelwert.Location = New System.Drawing.Point(747, 309)
        Me.lblWindMittelwert.Name = "lblWindMittelwert"
        Me.lblWindMittelwert.Size = New System.Drawing.Size(0, 22)
        Me.lblWindMittelwert.TabIndex = 77
        Me.lblWindMittelwert.Visible = False
        '
        'pbWindSchwach
        '
        Me.pbWindSchwach.Image = Global.Wetterstation.My.Resources.Resources.Wind_Schwach
        Me.pbWindSchwach.Location = New System.Drawing.Point(1041, 258)
        Me.pbWindSchwach.Name = "pbWindSchwach"
        Me.pbWindSchwach.Size = New System.Drawing.Size(63, 58)
        Me.pbWindSchwach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbWindSchwach.TabIndex = 80
        Me.pbWindSchwach.TabStop = False
        Me.pbWindSchwach.Visible = False
        '
        'pbWindMittel
        '
        Me.pbWindMittel.Image = Global.Wetterstation.My.Resources.Resources.Wind_Mittel
        Me.pbWindMittel.Location = New System.Drawing.Point(1041, 258)
        Me.pbWindMittel.Name = "pbWindMittel"
        Me.pbWindMittel.Size = New System.Drawing.Size(63, 58)
        Me.pbWindMittel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbWindMittel.TabIndex = 79
        Me.pbWindMittel.TabStop = False
        Me.pbWindMittel.Visible = False
        '
        'PbWindStark
        '
        Me.PbWindStark.Image = Global.Wetterstation.My.Resources.Resources.Wind_Stark
        Me.PbWindStark.Location = New System.Drawing.Point(1041, 258)
        Me.PbWindStark.Name = "PbWindStark"
        Me.PbWindStark.Size = New System.Drawing.Size(63, 58)
        Me.PbWindStark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbWindStark.TabIndex = 78
        Me.PbWindStark.TabStop = False
        Me.PbWindStark.Visible = False
        '
        'PbTempDown
        '
        Me.PbTempDown.Image = Global.Wetterstation.My.Resources.Resources.Temp_Down1
        Me.PbTempDown.Location = New System.Drawing.Point(394, 258)
        Me.PbTempDown.Name = "PbTempDown"
        Me.PbTempDown.Size = New System.Drawing.Size(63, 58)
        Me.PbTempDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbTempDown.TabIndex = 73
        Me.PbTempDown.TabStop = False
        Me.PbTempDown.Visible = False
        '
        'PbTempneutral
        '
        Me.PbTempneutral.Image = Global.Wetterstation.My.Resources.Resources.Temp_neutral
        Me.PbTempneutral.Location = New System.Drawing.Point(394, 258)
        Me.PbTempneutral.Name = "PbTempneutral"
        Me.PbTempneutral.Size = New System.Drawing.Size(63, 58)
        Me.PbTempneutral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbTempneutral.TabIndex = 72
        Me.PbTempneutral.TabStop = False
        '
        'PbTempUp
        '
        Me.PbTempUp.Image = Global.Wetterstation.My.Resources.Resources.Temp_Up
        Me.PbTempUp.Location = New System.Drawing.Point(394, 258)
        Me.PbTempUp.Name = "PbTempUp"
        Me.PbTempUp.Size = New System.Drawing.Size(63, 58)
        Me.PbTempUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbTempUp.TabIndex = 71
        Me.PbTempUp.TabStop = False
        '
        'btnTempAuslesen
        '
        Me.btnTempAuslesen.Location = New System.Drawing.Point(198, 354)
        Me.btnTempAuslesen.Name = "btnTempAuslesen"
        Me.btnTempAuslesen.Size = New System.Drawing.Size(148, 23)
        Me.btnTempAuslesen.TabIndex = 81
        Me.btnTempAuslesen.Text = "Temperatur auslesen"
        Me.btnTempAuslesen.UseVisualStyleBackColor = True
        '
        'btnWindAuslesen
        '
        Me.btnWindAuslesen.Location = New System.Drawing.Point(751, 354)
        Me.btnWindAuslesen.Name = "btnWindAuslesen"
        Me.btnWindAuslesen.Size = New System.Drawing.Size(148, 23)
        Me.btnWindAuslesen.TabIndex = 82
        Me.btnWindAuslesen.Text = " Windgeschw. auslesen"
        Me.btnWindAuslesen.UseVisualStyleBackColor = True
        '
        'RTBTemp
        '
        Me.RTBTemp.Location = New System.Drawing.Point(135, 383)
        Me.RTBTemp.Name = "RTBTemp"
        Me.RTBTemp.ReadOnly = True
        Me.RTBTemp.Size = New System.Drawing.Size(279, 76)
        Me.RTBTemp.TabIndex = 83
        Me.RTBTemp.Text = ""
        '
        'RTBWind
        '
        Me.RTBWind.Location = New System.Drawing.Point(685, 383)
        Me.RTBWind.Name = "RTBWind"
        Me.RTBWind.ReadOnly = True
        Me.RTBWind.Size = New System.Drawing.Size(279, 76)
        Me.RTBWind.TabIndex = 84
        Me.RTBWind.Text = ""
        '
        'Series_Temp
        '
        ChartArea1.Name = "ChartArea1"
        Me.Series_Temp.ChartAreas.Add(ChartArea1)
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Me.Series_Temp.Legends.Add(Legend1)
        Me.Series_Temp.Location = New System.Drawing.Point(135, 494)
        Me.Series_Temp.Name = "Series_Temp"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "Series_Temp"
        Me.Series_Temp.Series.Add(Series1)
        Me.Series_Temp.Size = New System.Drawing.Size(279, 284)
        Me.Series_Temp.TabIndex = 85
        Me.Series_Temp.Text = "Series_Temp"
        '
        'Series_Wind
        '
        ChartArea2.Name = "ChartArea1"
        Me.Series_Wind.ChartAreas.Add(ChartArea2)
        Legend2.Enabled = False
        Legend2.Name = "Legend1"
        Me.Series_Wind.Legends.Add(Legend2)
        Me.Series_Wind.Location = New System.Drawing.Point(685, 494)
        Me.Series_Wind.Name = "Series_Wind"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Legend = "Legend1"
        Series2.Name = "Series_Wind"
        Series2.XValueMember = "fghfhgf"
        Me.Series_Wind.Series.Add(Series2)
        Me.Series_Wind.Size = New System.Drawing.Size(279, 284)
        Me.Series_Wind.TabIndex = 86
        Me.Series_Wind.Text = "Series_Wind"
        '
        'lblChartPunkt
        '
        Me.lblChartPunkt.AutoSize = True
        Me.lblChartPunkt.BackColor = System.Drawing.Color.White
        Me.lblChartPunkt.Location = New System.Drawing.Point(260, 765)
        Me.lblChartPunkt.Name = "lblChartPunkt"
        Me.lblChartPunkt.Size = New System.Drawing.Size(52, 13)
        Me.lblChartPunkt.TabIndex = 87
        Me.lblChartPunkt.Text = "Zeitpunkt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(812, 765)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Zeitpunkt"
        '
        'lblChartTemp
        '
        Me.lblChartTemp.AutoSize = True
        Me.lblChartTemp.BackColor = System.Drawing.SystemColors.Control
        Me.lblChartTemp.Location = New System.Drawing.Point(54, 623)
        Me.lblChartTemp.Name = "lblChartTemp"
        Me.lblChartTemp.Size = New System.Drawing.Size(75, 26)
        Me.lblChartTemp.TabIndex = 89
        Me.lblChartTemp.Text = "Temperatur in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grad Celsius"
        '
        'lblChartWind
        '
        Me.lblChartWind.AutoSize = True
        Me.lblChartWind.BackColor = System.Drawing.SystemColors.Control
        Me.lblChartWind.Location = New System.Drawing.Point(539, 623)
        Me.lblChartWind.Name = "lblChartWind"
        Me.lblChartWind.Size = New System.Drawing.Size(140, 13)
        Me.lblChartWind.TabIndex = 90
        Me.lblChartWind.Text = "Windgeschwindigkeit in m/s"
        '
        'Wetterstation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 831)
        Me.Controls.Add(Me.lblChartWind)
        Me.Controls.Add(Me.lblChartTemp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblChartPunkt)
        Me.Controls.Add(Me.Series_Wind)
        Me.Controls.Add(Me.Series_Temp)
        Me.Controls.Add(Me.RTBWind)
        Me.Controls.Add(Me.RTBTemp)
        Me.Controls.Add(Me.btnWindAuslesen)
        Me.Controls.Add(Me.btnTempAuslesen)
        Me.Controls.Add(Me.pbWindSchwach)
        Me.Controls.Add(Me.pbWindMittel)
        Me.Controls.Add(Me.PbWindStark)
        Me.Controls.Add(Me.lblWindMittelwert)
        Me.Controls.Add(Me.lblTempMittelwert)
        Me.Controls.Add(Me.lblWindMittelwert_Title)
        Me.Controls.Add(Me.lblTempMittelwert_Title)
        Me.Controls.Add(Me.PbTempDown)
        Me.Controls.Add(Me.PbTempneutral)
        Me.Controls.Add(Me.PbTempUp)
        Me.Controls.Add(Me.lblGleich)
        Me.Controls.Add(Me.lblWindAktuell)
        Me.Controls.Add(Me.lblTempAktuell)
        Me.Controls.Add(Me.lblWindÜberschrift)
        Me.Controls.Add(Me.lblTemperaturÜberschrift)
        Me.Controls.Add(Me.lblWindÜbersetzung)
        Me.Controls.Add(Me.lblWindgeschwindigkeit)
        Me.Controls.Add(Me.lblTemperatur)
        Me.Controls.Add(Me.btnComSchließen)
        Me.Controls.Add(Me.btnComÖffnen)
        Me.Controls.Add(Me.lblCom)
        Me.Controls.Add(Me.gbSteuerung)
        Me.Controls.Add(Me.btnEinstellungenSchließen)
        Me.Controls.Add(Me.gbEinstellungen)
        Me.Controls.Add(Me.btnEinstellungenÖffnen)
        Me.Controls.Add(Me.lblEinstellungen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Wetterstation"
        Me.Text = "Wetterstation"
        Me.gbEinstellungen.ResumeLayout(False)
        Me.gbEinstellungen.PerformLayout()
        Me.gbSteuerung.ResumeLayout(False)
        Me.gbSteuerung.PerformLayout()
        CType(Me.pbWindSchwach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbWindMittel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbWindStark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbTempDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbTempneutral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbTempUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Series_Temp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Series_Wind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbDebug As TextBox
    Friend WithEvents cbStoppbits As ComboBox
    Friend WithEvents cbParität As ComboBox
    Friend WithEvents cbDatenbits As ComboBox
    Friend WithEvents cbBaudrate As ComboBox
    Friend WithEvents cbCom As ComboBox
    Friend WithEvents lblParität As Label
    Friend WithEvents lblBaudrate As Label
    Friend WithEvents lblStoppbits As Label
    Friend WithEvents lblDatenbits As Label
    Friend WithEvents lblCOM_Port As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents lblEinstellungen As Label
    Friend WithEvents gbEinstellungen As GroupBox
    Friend WithEvents btnEinstellungenÖffnen As Button
    Friend WithEvents btnEinstellungenSchließen As Button
    Friend WithEvents lblSteuerung As Label
    Friend WithEvents gbSteuerung As GroupBox
    Friend WithEvents lblManuell As Label
    Friend WithEvents btnManuell_Senden As Button
    Friend WithEvents btnAutomatik As Button
    Friend WithEvents btnManuell As Button
    Friend WithEvents btnComSchließen As Button
    Friend WithEvents btnComÖffnen As Button
    Friend WithEvents lblCom As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblDebug As Label
    Friend WithEvents lblTemperatur As Label
    Friend WithEvents lblWindgeschwindigkeit As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents lblWindÜbersetzung As Label
    Friend WithEvents lblTemperaturÜberschrift As Label
    Friend WithEvents lblWindÜberschrift As Label
    Friend WithEvents lblTempAktuell As Label
    Friend WithEvents lblWindAktuell As Label
    Friend WithEvents lblGleich As Label
    Friend WithEvents PbTempUp As PictureBox
    Friend WithEvents PbTempneutral As PictureBox
    Friend WithEvents PbTempDown As PictureBox
    Friend WithEvents lblTempMittelwert_Title As Label
    Friend WithEvents lblWindMittelwert_Title As Label
    Friend WithEvents lblTempMittelwert As Label
    Friend WithEvents lblWindMittelwert As Label
    Friend WithEvents pbWindSchwach As PictureBox
    Friend WithEvents pbWindMittel As PictureBox
    Friend WithEvents PbWindStark As PictureBox
    Friend WithEvents btnTempAuslesen As Button
    Friend WithEvents btnWindAuslesen As Button
    Friend WithEvents RTBTemp As RichTextBox
    Friend WithEvents RTBWind As RichTextBox
    Friend WithEvents Series_Temp As DataVisualization.Charting.Chart
    Friend WithEvents Series_Wind As DataVisualization.Charting.Chart
    Friend WithEvents lblChartPunkt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblChartTemp As Label
    Friend WithEvents lblChartWind As Label
End Class
