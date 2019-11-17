# Kjøre prosjektet
Siden dette er et .Net Core prosjekt med Entity Framework Core så må man må oppdatere databasemodellen selv. Åpne Nuget package console
	Ligger under Tools -> NuGet package manager -> Package manager console.

I konsollet skriver du "Update-Datbase"
Hvis den feiler fordi databasen allerede finnes kan du skrive "Drop-Database". 

# Angular

Kjør "npm install" inne i /ClientApp hvis du får problemer med angular. Bør være nok til å få prosjektet til å kjøre.


# Design

Applikasjonen bruker bootstrap collapse for trestrukturen, og Iconic icons for tommel opp/ned icon. I navigasjonsmenyen er 
det lenket til "Hjem" og "Bruker spørsmål"


# Flyt

Route: /

I applikasjonen så er det en hoved side. Den har en trestruktur som viser øverst i treet kategorier. 
En kategori kan ha flere spørsmål tilknyttet kategorien. Etter å ha spurt Tor så var det ikke nødvendig å ha flere svar til et spørsmål.

Route: /userquestions

Siden hvor alle brukerspørsmål ligger.
Sånn jeg skjønte det så ønsket du at man skulle ha en side med liste med alle spørsmålene som brukeren har stillt.


# Database seeding. 

Tok inspirasjon fra asp.net docs for database initialization: github:aspnet/AspNetCore.Docs
Program.cs
	https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/data/ef-mvc/intro/samples/cu-final/Program.cs
DbInitializer:
	https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/data/ef-mvc/intro/samples/cu-final/Data/DbInitializer.cs


# Prosjekt struktur

Jeg bruker Angular sammen med en Web API.
Begge ligger i samme prosjekt ("VyKundeservice") men Angular kommuniserer via WebAPI
for å samhandle med datbasen.
Dette er fordi det står i oppgaven at jeg ikke trenger å lagdele applikajsonen.


# Dynamisk trestruktur

Det spiller ingen rolle hvor mange kategorier eller spørsmål som ligger i databasen, det er ikke hardkodet kategorier elle spørsmål. 
Alt hentes ut fra [HttpGet] /api/Faq.


# Rating (Tommel opp/ned)

I applikasjonen så der det mulig å gi en tommel opp/ned på et spørsmål. 
Det sjekkes at tommel opp/ned blir registrert, og vil bare oppdatere listen hvis det lagres i datbasen.
Hvis det skjer noen galt med API-et som gjør at den ikke returnerer spørsmålet så vil ikke UI-et ikke oppdatere ratingen.

Dette skjer i "user-question.service.ts".
