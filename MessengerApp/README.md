# MessengerApp

Einfache WPF Messenger-Anwendung  
Diese Anwendung simuliert einen Chat zwischen zwei separaten Fenstern (A und B). Beide Fenster k�nnen sich gegenseitig Nachrichten schicken, die sofort angezeigt werden.

## Funktionen

- **Mehrere Fenster:** �ber das Hauptfenster k�nnen zwei verschiedene Messenger-Fenster ("Fenster A" und "Fenster B") ge�ffnet werden.
- **Echtzeit-Nachrichten�bertragung:** Eine Nachricht, die in einem Fenster gesendet wird, erscheint sofort im jeweils anderen Fenster.
- **Leere Nachricht verhindern:** Beim Versuch, eine leere Nachricht zu senden, erscheint eine Warnmeldung.
- **Benutzer-IDs:** Jedes Fenster hat eine eigene Kennung ("A" oder "B") und Nachrichten werden entsprechend gekennzeichnet.

## Screenshot

![MessengerApp Chat Beispiel](image1)

*Beispiel f�r den Nachrichtenaustausch zwischen Fenster A und B.*

## Verwendung

1. �ffne das Projekt mit Visual Studio.
2. Baue und starte das Projekt (F5).
3. Im Hauptfenster erscheinen folgende Buttons:
    - **Fenster A �ffnen**
    - **Fenster B �ffnen**
4. �ffne beide Messenger-Fenster �ber die Buttons.
5. In jedem Fenster kannst du eine Nachricht eingeben und mit dem Button "Senden" verschicken.
6. Die gesendete Nachricht erscheint im eigenen Fenster als "Ich: Nachricht" und im anderen Fenster als "[A/B]: Nachricht".

## Projektstruktur

- `MainWindow.xaml` & `MainWindow.xaml.cs`  
  Hauptfenster, Verwaltung und Verbindung der Messenger-Fenster.
- `MessengerWindow.xaml` & `MessengerWindow.xaml.cs`  
  Messenger-Benutzeroberfl�che und Nachrichtenlogik.
- `MessageEventArgs.cs` (optional als eigene Datei)  
  Spezielle EventArgs-Klasse f�r die Nachrichten�bertragung.

## Erweiterungsideen

- Nachrichtenverlauf speichern
- Benutzername, Farbe oder Icon f�r jedes Fenster
- Senden per ENTER-Taste erm�glichen
- Netzwerkf�higer Chat zwischen mehreren Computern

## Beitrag

Pull Requests und Issues sind willkommen!

---

**Hinweis:** Diese Anwendung dient zu Lernzwecken und zeigt die Grundlagen von WPF-Events und Fensterkommunikation.