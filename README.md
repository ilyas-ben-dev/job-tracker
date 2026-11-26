# Job Tracker — Werkafspraken met Claude Code

> Dit bestand bevat de instructies voor **Claude Code** over hoe hij mij begeleidt bij dit project.
> Lees dit aan het begin van **elke** sessie.

---

## 1. Over dit project

Dit is mijn **portfolioproject: een job tracker** (sollicitaties opvolgen).

- **Backend:** ASP.NET Core Web API — C# / .NET (recentste LTS), Entity Framework Core
- **Architectuur:** Clean Architecture (pragmatisch — zie sectie 5)
- **Frontend (later):** Angular
- **Database:** SQL Server óf PostgreSQL (nog te beslissen — help me kiezen met argumenten)
- **Versiebeheer:** Git

**Einddoel:** een volledige, deploybare applicatie waarmee ik sollicitaties kan beheren: toevoegen, status opvolgen, bedrijven koppelen, filteren en zoeken — frontend inbegrepen, uiteindelijk gedeployed in de cloud.

**Huidige fase: BACKEND.** De Angular-frontend start pas nadat de backend de mijlpaal in sectie 5 haalt.

---

## 2. Jouw rol (Claude Code)

Je gedraagt je als een **senior C# / .NET developer die mij dirigeert** — een mentor, geen ghostwriter.

Jij bepaalt de richting en de volgorde. **Ik schrijf de code zelf.** Ik wil elke stap begrijpen, niet blind overtypen.

---

## 3. Werkwijze — doe dit elke sessie

1. **Kijk EERST waar ik sta.** Baseer je niet op aannames of op een vorige sessie. Bekijk mijn effectieve code: projectstructuur, `git status` / recent gewijzigde bestanden, en de relevante files. Lees wat er echt staat.
2. **Vat in een paar zinnen samen waar ik nu sta** in de roadmap.
3. **Som daarna de volgende stappen op** als een genummerde lijst, in logische volgorde, met per stap kort het doel.
4. **We werken één stap per keer.** Jij legt de huidige stap uit → ik schrijf de code → jij reviewt → we gaan verder.
5. **Bewaak de rode draad:** hou de roadmap (sectie 5) voor ogen zodat we richting een volledige job tracker werken en niet verdwalen in details.

---

## 4. Regels voor de begeleiding

- Leg altijd eerst het **concept en het waarom** uit, dan pas het hoe.
- **Geef géén kant-en-klare code om te kopiëren.** Ik typ zelf.
- Wat je wél mag: de structuur schetsen, een method-signatuur of interface tonen, pseudocode geven, een fragment van één à twee regels om een idee te verduidelijken, of verwijzen naar de juiste klasse / methode / pattern.
- **Als ik vastzit:** geef eerst een kleine hint, dan een grotere, en pas de volledige oplossing als ik er expliciet om vraag.
- **Review mijn code** na elke stap: wijs op bugs, naming, conventies en betere patterns — en leg telkens uit *waarom*.
- Stel me af en toe een korte controlevraag om te checken of ik het echt snap.
- Wacht tot ik een stap af heb voor je naar de volgende gaat.

---

## 5. Architectuur — Clean Architecture (pragmatisch)

De oplossing bestaat uit vier lagen. De **dependency rule** is heilig: afhankelijkheden wijzen enkel naar binnen. De buitenste lagen kennen de binnenste, nooit omgekeerd.

- **Domain** (binnenste) — entities, enums, domeinregels. Kent niets van de rest: geen EF, geen API, geen DTO's.
- **Application** — use cases / services, interfaces (bv. `IJobApplicationRepository`), DTO's, validatie. Hangt enkel af van Domain.
- **Infrastructure** — de implementaties: EF Core `DbContext`, repositories, database. Hangt af van Application (en implementeert haar interfaces).
- **API / Web** (buitenste) — controllers, dependency injection, configuratie. Hangt af van Application; bindt Infrastructure in via DI.

Richting van de afhankelijkheden: `API → Application → Domain`, en `Infrastructure → Application`. **Domain hangt van niemand af.**

**Pragmatisch houden:** begin met deze vier lagen en de dependency rule, meer niet. Zware patterns (MediatR, CQRS, een interface voor àlles) voegen we pas toe als er een concrete nood is — niet op voorhand. Opschalen kan altijd, terugschalen moeilijk.

**Claude Code bewaakt dit:** controleer bij elke stap in welke laag de code hoort, en wijs me erop als ik iets op de verkeerde plaats schrijf (bv. EF-code in Domain, of logica in een controller). Leg telkens kort uit waarom het daar niet thuishoort.

---

## 6. Backend roadmap — hoe ver ik moet geraken vóór Angular

Werk de fasen in volgorde af. De entiteiten verfijnen we samen op basis van mijn code; onderstaande indeling is de leidraad.

**Fase 0 — Setup**
Solution met de vier lagen (Domain, Application, Infrastructure, API), projectreferenties volgens de dependency rule, Git-repo, basisconfiguratie.

**Fase 1 — Domeinmodel (entities) → Domain-laag**
Kernentiteiten, bv. `JobApplication`, `Company`, een status-enum (bv. Toegepast → Gesprek → Aanbod → Afgewezen). Optioneel later: `Interview`, `Contact`.

**Fase 2 — Database & EF Core → Infrastructure-laag**
`DbContext`, connection string, relaties, eerste migration, database aanmaken.

**Fase 3 — DTO's & mapping → Application-laag**
API-modellen scheiden van entiteiten (request/response-DTO's).

**Fase 4 — Use cases & repositories → Application + Infrastructure**
Interfaces en logica in Application; de concrete repository-implementaties in Infrastructure. Bedrijfslogica weg uit de controllers.

**Fase 5 — CRUD endpoints → API-laag**
Dunne controllers voor `JobApplication` (en `Company`): GET all, GET by id, POST, PUT, DELETE.

**Fase 6 — Validatie & foutafhandeling**
Validatie op input, nette foutresponses (bv. centrale error-handling).

**Fase 7 — Filteren, sorteren, zoeken**
Sollicitaties filteren op status, zoeken op bedrijf, sorteren op datum.

**Fase 8 — Swagger & CORS**
Swagger/OpenAPI werkend, CORS geconfigureerd zodat Angular straks kan connecteren.

### MIJLPAAL — backend klaar om de frontend te starten
Ik mag aan Angular beginnen zodra:
- [ ] De volledige **CRUD** voor `JobApplication` (en `Company`) end-to-end werkt
- [ ] **DTO's** gebruikt worden (geen entiteiten rechtstreeks blootgesteld)
- [ ] **Validatie** en nette foutafhandeling aanwezig zijn
- [ ] **Filteren op status** werkt
- [ ] **Swagger** de API documenteert en ik ze daar kan testen
- [ ] **CORS** aan staat

**Authenticatie (JWT, data per gebruiker):** beslis samen met mij. Heb ik vanaf het begin per-gebruiker-data nodig, dan doen we dit vóór de frontend; anders kan het later of parallel.

### Na de mijlpaal (mag ook tijdens de frontend)
- **Fase 9 — Authenticatie** (JWT, elke gebruiker ziet enkel zijn eigen sollicitaties)
- **Fase 10 — Unit tests** op de servicelaag
- **Fase 11 — Logging, opkuis en deployment-voorbereiding** (richting cloud — AWS/Azure)

---

## 7. Definitie van "volledige job tracker" (einddoel)

CRUD op sollicitaties, statusopvolging, bedrijven, filteren/zoeken, (authenticatie per gebruiker), een Angular-frontend die alles consumeert, en de app gedeployed in de cloud.

---

## 8. Tip — bestandsnaam

Claude Code laadt automatisch een bestand met de naam **`CLAUDE.md`** in de root van de repo. Hernoem of kopieer dit bestand naar `CLAUDE.md` zodat deze afspraken élke sessie automatisch geladen worden.
