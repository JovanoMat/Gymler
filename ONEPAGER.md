# Gymler
SEW/INSY Projekt


Gymler ist ein Fortschrittstracker für die erbrachten Leistungen im Fitnessstudio. Jede*r Nutzer*in hat die Auswahl zwischen vielen verschiedenen Übungen, zu denen die durchgeführten Sätze, durchgeführten Wiederholungen pro Satz und benutztes Gewicht gespeichert werden kann. 
Es kann jede Zeit eine Statistik aufgerufen werden, die den Fortschritt in übersichtlichen Diagrammen anzeigt. 
Schließlich hat jede*r Nutzer*in die Möglichkeit, einen zusammengestellten Trainingsplan zu speichern, der aus verschiedenen Übungen und Notizen bestehen kann.  

Wichtige Routen für dieses Projekt sind:
- Holen aller Daten von durchgeführten Übungen bestimmter Nutzer*innen zum erstellen von Statistiken
- Holen aller nötigen Daten, zum befüllen der Steuerungselemente in dem WPF
- Erstellen neuer Pläne zu einem Nutzer
- Hinzufügen von Übungen zu Plänen
- Entfernen von Übungen von Plänen
- Ändern von Übungsdurchführungen

Das UI besteht aus einem Login Fenster, hat sich der*die Nutzer*in erfolgreich eingeloggt, so wird das Hauptfenster angezeigt. In dem Hauptfenster sind die Traininspläne in einem Datagrid zu sehen, wird auf einen Plan geklickt so erscheinen die Übungen, 
die dieser Plan beinhält in einem eigenen Datagrid, sonst wird in dem selben Datagrid alle Übungen angezeigt. Über dem Datagrid der Übungen ist eine Textbox, mit der nach bestimmten Übungen gesucht werden kann. Unter dem Datagrid der Pläne sitzen ein Button zum Entfernen
von Übungen und ein Button zum Hinzufügen von Übungen. Beim Drücken des "Übung entfernen" Buttons wird die ausgewählte Übung entfernt, sollte der "Übung hinzufügen" Button gedrückt werden, so erscheint ein kleines Fenster, in dem die zu hinzufügende Übung ausgewehlt und 
das Hinzufügen bestätigt wird. Zusätzlich gibt es einen Knopf, mit dem die Statistiken der Nutzer*innen angezeigt werden kann. Schließlich sitzt am unteren Ende des Hauptfensters ein Textblock, auf dem wichtige Meldungen ausgegeben werden. 
