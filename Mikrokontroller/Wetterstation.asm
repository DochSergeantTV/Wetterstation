;+-------------------------------------------------------------------------------------------------------------------------------------
;I Titel: 		 Wetterstation (Temperatur und Wind)
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Funktion: 	 Windimpulse messen, zählen und an den PC mit Kenzeichnung senden. Temperatur messen und Rohwert mit Kennzeichnung an den PC senden.
;I				 Automatik -und Manuellbetrieb sind durch Taster und LED´s zu bedienen und zu erkennen. Ebenfalls kann ein Signal vom PC für den Modus
;I				 Empfangen werden.
;I
;I Beschreibung: Mittels des Temperatursensor an PC0 (10bit) wird durch einen ADC ein ADC-Wert erzeugt. 
;I 				 Dieser wird dann mit einer Kennzeichnung (00000001) als führender 8-Bit-Wert gesendet (Über UART).
;I				
;I				 Mittels des Windsensors an PD4 wird ein 8-Bit Zähler hochgezählt. Nach 1sec wird dann die Zählung beendet und der Wert 
;I				 wird nach einem leeren Register von 8-Bit gesendet.
;I				
;I				 Zur Kennzeichnung (00000010) wird  ein führender 8-Bit-Wert gesendet. Das Das Kennzeichnungsregister ist r23 bzw. r22. Nachfolgend kommt r24 und r25
;I				 Beispiel einer Teilsendensendung:		10000001 		| 		00000001 		| 		01010010	
;I														Kennzeichen	 			ADC-Wert				ADC-Wert
;I
;I				 Wenn der Windmesser einen Wert über 8-Bit zählt, so löst dieses einen Interupt aus und das Gerät muss neugestartet werden (Alle LEDs an)
;i				 oder am PC der COM geschlossen werden	
;I
;I				 Damit ein manueller Modus erfolgen kann, wird durch den Taster 1 der manuelle Betrieb gestartet (Interrupt INT0 ausgelöst).
;I				 In diesem kann man mit erneuter Betätigung (Taster 1) ein Signal manuell schicken lassen. 
;I				 Damit am PC ein manueller Betrieb erkannt wird ist das 
;I				 führende Bit der Kennzeichnung eine 1, wenn Automatik aktiv ist, dann ist es eine 0.
;I				 Eine Umschaltung der Modi erfolgt durch Interrupts.
;I				 Kennzeichen des Modus sind nach Aktivierung (1-Mal betätigung) das Leuchten der Roten LED. Wenn erneut gedrückt wird,
;I				 um zu senden, dann leuchtet während des Vorgangs die gelbe LED. Das Signal wird an PD7 verglichen.
;I				 Der automatische Modus wird durch den Taster 2 gestartet und führt die automatisch Messungen aus und sendet diese an den PC (jede 1sek).
;I				 Im automatischen Modus leuchtet die Grüne LED.
;I
;I				 Am PC kann ebenfalls der Modus geändert werden. Dazu erfolgt nach Sendung ein Interrupt am uC und der Modus wird geändert.
;I				 Beim Interrupt wird im Register 22 (Kennzeichnungsregister) das Bit 7 oder 8 geändert. Durch die Änderung von Bit 8 kann der Modus
;I				 umgeschalten werden. Dabei wird zudem ein Register (r19) hochgezählt, um beim Manuellbetrieb ein Senden zu ermöglichen.
;i				 An Bit 7 kann der uC wieder in die Main geschoben werden.
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Entwicklungsboard (Verdrahtung)
;I Eingänge: 	 Windmesser 	  = 	PD4 (T0   = 8bit)
;I				 Temperatursensor =		PC0 (ADC0 = 10bit)
;I				 Taster 1		  = 	PD2	(INT0) und PD7
;I				 Taster 2		  =		PD3	(INT1)
;I
;I Ausgänge: 	 Rote LED		  = 	PB1
;I				 Gelbe LED		  =		PB3
;I				 Grüne LED		  =		PB5
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Prozessor: 	 ATmega8
;I Taktfrequenz: 3,6864 MHz
;I Sprache: 	 Assembler
;I Programm: 	 AVR Studio 4.18
;I
;I Datum: 		 22.02.2022
;I Autor: 		 
;+-------------------------------------------------------------------------------------------------------------------------------------
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Initialisierungskopf: Assembler
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Einbinden der Definitionsdatei "m8def.inc"

 	.include "m8def.inc"	 		;"m8def.inc" ist Definitionsdatei für ATmega8 uC

;+-------------------------------------------------------------------------------------------------------------------------------------
;I Reset und Interruptvektoren

			rjmp conf				; 1 POWER ON RESTET
			rjmp manuell_interrupt 	; 2 Int0-Interrupt
			rjmp automatik_interrupt; 3 Int1-Interrupt
			reti 					; 4 TC2 Compare Match
			reti 					; 5 TC2 Overflow
			reti 					; 6 TC1 Capture
			reti 					; 7 TC1 Compare Match A
			reti 					; 8 TC1 Compare Match B
			reti 					; 9 TC1 Overflow
			rjmp Notfall 			; 10 TC0 Overflow
			reti 					; 11 SPI, STC Serial Transfer Complete
			rjmp Recieve 			; 12 UART Rx Complete
			reti 					; 13 UART Data Register Empty
			reti 					; 14 UART Tx Complete
			reti 					; 15 ADC Conversion Complete
			reti 					; 16 EEPROM Ready
			reti 					; 17 Analog Comparator
			reti 					; 18 TWI (IC) Serial Interface
			reti 					; 19 Store Program Memory Ready

;+-------------------------------------------------------------------------------------------------------------------------------------
    
	conf:							;Sprungmarke "conf" (Sprung zur Sprungmarke nach dem Auslösen des RESET)

	sei 							;Aktivieren aller Interrups
	
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Stackpointer initialisieren (Der Stackpointer managet den Ruecksprung aus einem Unterprogramm)
	
	ldi r16,0x04					;Stackpointer auf RAM-Ende (Memory Adresse $045F)
	out SPH,r16						;High Adressteil (04)
	ldi r16,0x5F					;
	out SPL,r16						;Low Adressteil (5F)

;+-------------------------------------------------------------------------------------------------------------------------------------
;I Hardwarekonfiguration:

;|MCUCR Register für externe Interrups konfigurieren
;| 	(festlegen wie der externe Interrupt ausgelöst wird)
;| 	ACHTUNG: keine bitweise Einstellungen (z.B. cbi, sbi) für die
;| 			 I/O Regsiter MCUCR und GICR möglich
;| ACHTUNG:  externer Interrupt soll ausgelöst werden bei negativer
;| 			 also fallender Flanke (Tasterbetätigung => 1 [unbetätigt] auf 0 [betätigt])
	ldi r16, 0b00001010 			;negative/fallende Flanke an INT1 (ISC11 = 1, ISC10 = 0)
									;negative/fallende Flanke an INT0 (ISC01 = 1, ISC00 = 0)
									;Einstellungen (Bits) für INT0
									; ISC00 (bit: 0), ISC01 (bit: 1)
									;Einstellungen (Bits) für INT1
									; ISC10 (bit:2), ISC11 (bit: 3)

	out MCUCR, r16 					;Konfiguration in MCUCR laden

;|GICR (General Interrupt Control Register)
;| externen Interrupt freischalten (aktiv)
	ldi r16, 0b11000000 			;INT1/INT0 aktiv (ACHTUNG: GICR lässt sich nur byteweise
									;konfigurieren)
									;Bit7 = INT1
									;Bit6 = INT0

	out GICR, r16 					;Konfiguration GICR


;LEDs Konfigurieren

	ldi r16, 0b00101010				;Bit1/Rote LED  = 1 => auf Ausgang setzen
									;Bit3/Gelbe LED = 1 => auf Ausgang setzen
									;Bit5/Grüne LED = 1 => auf Ausgang setzen
	out DDRB, r16					;Ins Datenrichtungsregister laden

;UART Konfigurieren


	ldi r16, 23						;Einstellen der Baurate auf 9600 BPS
	out UBRRL, r16

	ldi r16, 0b10000110				;Maske zur Konfiguration des UART Ports
									;Bit7/URSEL = 1 Wahl des Registers UCSRC statt UBRRH
									;Bit6/UMSEL = 0 asynchron Betrieb (Standard UART)
									;Bit5/UPM1 	= Bit 4/UPM0 = 0 Parityscheck gesperrt (Fehlerprüfung aus)
									;Bit3/USBS 	= 0 => 1 Stoppbit (siehe Grund. Geräte-Manager und Workpad)
									;Bit2/UCSZ1 = Bit1/UCSZ0 = 11 => 8 Datenbits (siehe G. Geräte-Manager)
									;Bit0/UCPOL = 0 bei asynchron Modus
	out UCSRC, r16

	ldi r16, 0b10011000 			;Maske TxD (Sender) und RxD (Empfänger) über UART frei schalten
									;Bit7/RXCIE USART RX Complete Interrupt Enable, Löst einen Interrupt nach erfolgreichen Recieven aus
									;Bit4/RXEN UART-Empfänger (RxD, receiver enable) frei schalten
									;Bit3/TXEN UART-Sender (TxD, transmitter enable) frei schalten
	out UCSRB, r16					;UCSRB konfigurieren

;Timer Konfigurieren

	ldi r16, 0b00000001				;Maske Timer/Counter Interrupt Mask Register
									;Bit0/TOIE0 = 1 => Interrupt nach Overflow
	out TIMSK, r16

	ldi r16, 0b00000110				;Fallende Flanke an Counter einstellen. Counter wird standartgemäß eingeschaltet
									;Bit2-0/CS02-00: Clock Select
	out TCCR0, r16

;Taster Konfigurieren | Pullup aktivieren

	sbi PORTD, 2					;PD2 auf +5V ("1") setzen => Taster 1
	sbi PORTD, 3					;PD3 auf +5V ("1") setzen => Taster 2
	sbi PORTD, 7					;PD7 auf +5V ("1") setzen => Taster 1

;AD-Wandler einstellen

	ldi r17,0b01000000				;Bit6/REFS0 = 1 (interne Referenzspannung 5V verwenden)
									;Bit5/ADLAR = 0 (AD-Ergebnis wie folgt speichern:
									;						oberen 2 Bit in ADCH, unteren 8 Bit in ADCL)
									;Bit0/MUX (Kanal ADC0/PC0 wählen)
	out ADMUX, r17					;ADMUX konfigurieren

	ldi r17,0b10000101				;Bit7/ADEN (Funktion: AD Wandler einschalten)
									;Bit6/ADSC (Start Conservation auf 0 = aus um noch keine Daten aufzunehmen)
									;Bit2/ADPS2 + Bit0/ADPS0 Teiler für Wandlerfequenz auf 32 einstellen)
									;ACHTUNG: Wandlerfequenz = Taktfrequenz / Teiler
									; f = 3,6864 MHz / 32 = 115KHz
									;Die Wandlerfrequenz sollte immer zwischen 50KHz und 200KHz liegen.
									;Beachten Sie die Tabelle zur Bestimmung des Teilers (ADPS2 - ADPS0)
	out ADCSRA, r17	
	
	ldi r22, 0b11111111				;Setzen des Kennzeichnungsregisters für die Messungen
									;Volle Register wird gesetzt, damit nicht direkt in Automatik gesprungen wird, sondern erst nach Interrupt	
									
	ldi r19, 0						;Leeren von r19, um den Manuellbetrieb mit Taster zu erkennen		
;+-------------------------------------------------------------------------------------------------------------------------------------
;I Hauptprogramm
main:

	ldi r21, 0b00000000				;Alle LEDs werden ausgeschaltet
	out PORTB, r21					;PORTB konfigurieren


	cpi r22, 0b10000000				;Vergleich mit r22 ob der Modus manuell an ist
	breq manuell					;Wenn ja, dann springe zu manuell
	cpi r22, 0b00000000				;Vergleich mit r22 ob der Modus automatik an ist
	breq automatik					;Wenn ja, dann springe zu automatik

	rjmp main						;Mainloop


;Nach einem Interrupt durch Taster für manuell
manuell_interrupt:
	ldi r22, 0b10000000				;Kennzeichnung des manuellen Betriebs für das Senden und Abfragen

	reti							;Zurückspringen an Punkt vor Interrupt


;Nach einem Interrupt durch Taster für automatik
automatik_interrupt:
	ldi r22, 0b00000000				;Kennzeichnung des automatischen Betriebs für das Senden und Abfragen

	reti							;Zurückspringen an Punkt vor Interrupt


;Nach einen Interurpt durch Recieve
Recieve:

	in r22, UDR						;Das Recieveregister in r22 laden
	inc r19							;Hochzählen von r19 um zu erkennen dass ein recive stattfand

	reti							;Zurückspringen an Punkt vor Interrupt


;Notfall-Routine, wenn ein Overflow an TC0 stattfindet
Notfall:
	ldi r20, 0b00101010				;Alle LED´s auf an um Notfall zu signalisieren
	out PORTB, r20					;Register r20 in PORTB laden

	cpi r22, 0b01000000				;Vergleich, ob am PC der COM geschlossen wurde
	breq main						;Wenn ja dann wieder zur main

	rjmp Notfall					;Loop um weiter in Notfall zu bleiben
	


;Manuell Modus zum Senden der Daten
manuell:
	
	ldi r19, 1						;laden einer 1 in r19	

	ldi r21, 0b00000010				;Kennzeichnung für den Nutzer mit einer roten LED um den manuellen Betrieb zu zeigen
	out PORTB, r21					;Rote LED an
										

;Interrups von INT0 nicht zulassen aber von INT1 für automatik zulassen
;|GICR (General Interrupt Control Register)
;| externen Interrupt freischalten (aktiv/inaktiv)
	ldi r16, 0b10000000 			;INT1 aktiv /INT0 inaktiv (ACHTUNG: GICR lässt sich nur byteweise
									;konfigurieren)
									;Bit7 = INT1
									;Bit6 = INT0

	out GICR, r16 					;Konfiguration GICR


	in r21, PIND					;I/O Register PIND einlesen

	andi r21, 0b10000000			;Filter anwenden, für PD7

	cpi r21, 0b10000000				;Prüft ob der Taster losgelassen wurde
	breq manuell_pruefe				;Wenn der Taster nicht losgelassen wurde, dann loop mit rjmp

	cpi r22, 0b00000000				;Vergleich mit r22 ob der Modus automatik an ist
	breq automatik					;Wenn ja, dann springe zu automatik


	rjmp manuell					;Sprung zu manuell

;Prüfung für Manuell-Modus
manuell_pruefe:

	cpi r22, 0b01000000				;Vergleich ob Bit 7 => COM geschlossen aktiv ist
	breq main						;Wenn ja dann zur main

	cpi r19, 2						;Prüft ob am Pc der Manuellbetrieb ein 2 mal benutzt wurde
	breq manuell_senden				;Wenn ja, dann zu senden

	in r21, PIND					;I/O Register PIND einlesen

	andi r21, 0b10000000			;Filter anwenden, für PD7

	cpi r21, 0b00000000				;Prüft ob der Taster 1 gedrückt ist

	breq manuell_senden				;Wenn ja, dann senden

	cpi r22, 0b00000000				;Vergleich mit r22 ob der Modus automatik an ist
	breq automatik					;Wenn ja, dann springe zu automatik



	rjmp manuell_pruefe				;Wenn nichts gedrückt wurde, dann nochmal prüfen

;Manuell Daten senden
manuell_senden:

	ldi r19, 1						;R19 zurücksetzen, damit erneut gesendet werden kann vom Pc aus mit Manuellbetrieb

	ldi r21, 0b00001010				;Kennzeichnung für den Nutzer mit einer roten LED um den manuellen Betrieb zu zeigen. 
									;Gelbe LED zustätzlich um zu zeigen, dass Daten gesendet werden
	out PORTB, r21					;Rote LED an und Gelbe an

	rcall counter					;Sprung zur Counter-Routine 
	rcall temperatur				;Sprung zur Temperatur-Routine

	cpi r22, 0b00000000				;Vergleich mit r22 ob der Modus automatik an ist
	breq automatik					;Wenn ja, dann springe zu automatik

	rjmp manuell					;Rücksprung zu manuell
	
;Automatikmodus starten
automatik:
	
	ldi r19, 0						;Setzen von r19 auf 0 damit nicht von pc wenn Automatik war auf manuell_senden gesprungen wird

;|GICR (General Interrupt Control Register)
;| externen Interrupt freischalten (aktiv)
	ldi r16, 0b01000000 			;INT1 inativ/INT0 aktiv (ACHTUNG: GICR lässt sich nur byteweise
									;konfigurieren)
									;Bit7 = INT1
									;Bit6 = INT0

	out GICR, r16 					;Konfiguration GICR

	ldi r21, 0b00100000				;Aktivieren der grünen LED für automatischen Betrieb
	out PORTB, r21					;Grüne LED an


	ldi r22, 0b00000000				;Kennzeichnung des automatischen Betriebs für das Senden und Abfragen



	rcall counter					;Sprung zur Counter-Routine 
	rcall temperatur				;Sprung zur Temperatur-Routine
	rcall schleife					;Pause für 1 Sekunde

	cpi r22, 0b10000000				;Vergleich mit r22 ob der Modus manuell an ist
	breq manuell					;Wenn ja, dann springe zu manuell

	andi r22, 0b01000000			;Filtern von r22, denn sonst ist das Bit 8 vielleicht belegt
	cpi r22, 0b01000000				;Vergleich ob Bit 7 => COM geschlossen aktiv ist
	breq main						;Wenn ja dann zur main

	rjmp automatik					;automatikloop


;Temperaturaufnahme
temperatur:

	sbi ADCSRA ,ADSC		    	;Messung starten

	messung:
				sbic ADCSRA, ADSC	;Wenn kein Bit gesetzt, Messung beenden und überspringe den nächsten Befehl
				rjmp messung		;Erneut messen

				ldi r23, 0b00000001	;Kennzeichnung für Temperatur

				in r25, ADCL		;Messwert in r25 speichern, ADCL
				in r24, ADCH		;Messwert in r24 speichern, ADCH
				rcall senden		;Sprung zu senden um die aufgenommenen Daten zu senden

			ret						;Rücksprung zum vorherigen Punkt

;Zähleraufnahme
counter:

	ldi r23, 0b00000010				;Kennzeichnung für Wind

	ldi r25, 0						;Zähler wird auf 0 gesetzt (Startwert)
	out TCNT0, r25					;In das Zähler-Register laden

	rcall schleife					;Aufruf der Schleife, währendessen wird der Zähler für 1 Sekunde zählen

	in r25, TCNT0					;Nach 1sek wird der Zählwert in r21 geladen um gesendet zu werden	
	ldi r24, 0						;r24 wird geleert damit dort nichts gesendet wird		
	rcall senden					;Sprung zu senden			


	ret								;Rücksprung zum vorherigen Punkt




;Wert an PC senden
senden:

	add r23, r22					;Addiert r23 und r22 in r23 um beim PC ermitteln zu können welche Werte ankommen

	senden1:

			sbis UCSRA, UDRE 		;Bit5/UDRE = 1 . Sendepuffer UDR leer
									;UDRE = 1 Sendepuffer (UDR) leer . dann
									; überspringe nächsten Befehl
									;UDRE = 1 Daten im Sendepuffer (UDR) . dann
									; nächsten Befehl (Rücksprung) ausführen
			rjmp senden1			;Daten im Sendepuffer = Rücksprung nach senden
			out UDR, r23 			;Byte aus r23 in den Sendepuffer UDR schieben

			ldi r23, 0				;r23 wird gelert, damit eine erneute Kennzeichnung erfolgen kann

			rcall schleife			;Schleifenaufruf um eine Pause zwischen des Sendes zu erzeugen

	senden2:

			sbis UCSRA, UDRE 		;Bit5/UDRE = 1 . Sendepuffer UDR leer
									;UDRE = 1 Sendepuffer (UDR) leer . dann
									; überspringe nächsten Befehl
									;UDRE = 1 Daten im Sendepuffer (UDR) . dann
									; nächsten Befehl (Rücksprung) ausführen
			rjmp senden2 			;Daten im Sendepuffer = Rücksprung nach senden
			out UDR, r24 			;Byte aus r24 in den Sendepuffer UDR schieben

			rcall schleife			;Schleifenaufruf um eine Pause zwischen des Sendes zu erzeugen

	senden3:

			sbis UCSRA, UDRE 		;Bit5/UDRE = 1 . Sendepuffer UDR leer
									;UDRE = 1 Sendepuffer (UDR) leer . dann
									; überspringe nächsten Befehl
									;UDRE = 1 Daten im Sendepuffer (UDR) . dann
									; nächsten Befehl (Rücksprung) ausführen
			rjmp senden3 			;Daten im Sendepuffer = Rücksprung nach senden
			out UDR, r25 			;Byte aus r25 in den Sendepuffer UDR schieben

			rcall schleife			;Schleifenaufruf um eine Pause zwischen des Sendes zu erzeugen

		ret							;Rücksprung zum vorherigen Punkt


;Zeitschleife 1sec
;t = 3 * 20  * (240 * (255+1) + 1) / 3686400
;t = ca. 1sec

schleife:

	.EQU nloop6 = 20				; Dritte Schleife
	.EQU nloop5 = 240				; Zweite Schleife
	.EQU nloop4 = 255				; Erste Schleife
	.DEF rcnt3 = R18 				; Drittes Register
	.DEF rcnt2 = R17 				; Zweites Register
	.DEF rcnt1 = R16 				; Erstes Register

	; Beginn äußerste Schleife
	ldi rcnt3,nloop6 				; Laden drittes Register

	; Beginn mittlere Schleife
	loop6: 							; Sprungziel Beginn mittlere Schleife
	ldi rcnt2,nloop5 				; Laden zweites Register
	loop5: 							; Sprungziel Beginn innere Schleife
	ldi rcnt1,nloop4 				; Laden erstes Register
	loop4: 							; Sprungziel innere Schleife
	dec rcnt1 						; Erniedrige erstes Register
	brne loop4 						; Springe falls nicht Null
	dec rcnt2 						; Erniedrige zweites Register
	brne loop5 						; Springe falls nicht Null
	dec rcnt3 						; Erniedrige drittes Register
	brne loop6 						; Springe falls nicht Null

	ret								; Rücksprung zum vorrherigen Punkt