# MessengerApp

Einfache WPF Messenger-Anwendung  
Diese Anwendung simuliert einen Chat zwischen zwei separaten Fenstern (A und B). Beide Fenster können sich gegenseitig Nachrichten schicken, die sofort angezeigt werden.

## Funktionen

- **Mehrere Fenster:** Über das Hauptfenster können zwei verschiedene Messenger-Fenster ("Fenster A" und "Fenster B") geöffnet werden.
- **Echtzeit-Nachrichtenübertragung:** Eine Nachricht, die in einem Fenster gesendet wird, erscheint sofort im jeweils anderen Fenster.
- **Leere Nachricht verhindern:** Beim Versuch, eine leere Nachricht zu senden, erscheint eine Warnmeldung.
- **Benutzer-IDs:** Jedes Fenster hat eine eigene Kennung ("A" oder "B") und Nachrichten werden entsprechend gekennzeichnet.

## Screenshot

![MessengerApp Chat Beispiel](image1)

*Beispiel für den Nachrichtenaustausch zwischen Fenster A und B.*

## Verwendung

1. Öffne das Projekt mit Visual Studio.
2. Baue und starte das Projekt (F5).
3. Im Hauptfenster erscheinen folgende Buttons:
    - **Fenster A öffnen**
    - **Fenster B öffnen**
4. Öffne beide Messenger-Fenster über die Buttons.
5. In jedem Fenster kannst du eine Nachricht eingeben und mit dem Button "Senden" verschicken.
6. Die gesendete Nachricht erscheint im eigenen Fenster als "Ich: Nachricht" und im anderen Fenster als "[A/B]: Nachricht".

## Projektstruktur

- `MainWindow.xaml` & `MainWindow.xaml.cs`  
  Hauptfenster, Verwaltung und Verbindung der Messenger-Fenster.
- `MessengerWindow.xaml` & `MessengerWindow.xaml.cs`  
  Messenger-Benutzeroberfläche und Nachrichtenlogik.
- `MessageEventArgs.cs` (optional als eigene Datei)  
  Spezielle EventArgs-Klasse für die Nachrichtenübertragung.

## Erweiterungsideen

- Nachrichtenverlauf speichern
- Benutzername, Farbe oder Icon für jedes Fenster
- Senden per ENTER-Taste ermöglichen
- Netzwerkfähiger Chat zwischen mehreren Computern

## Beitrag

Pull Requests und Issues sind willkommen!

---

**Hinweis:** Diese Anwendung dient zu Lernzwecken und zeigt die Grundlagen von WPF-Events und Fensterkommunikation.