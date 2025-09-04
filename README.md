# TurUpPortal212 – UI Test Automation (C# · Selenium · NUnit)

This repository contains automated UI tests for the TurnUp Portal using **C#**, **Selenium WebDriver**, and **NUnit** with a simple Page Object Model (POM).

---

## 📂 Project Structure

```text
TurUpPortal212/
 ├── Pages/       # Page Objects (LoginPage, HomePage, TMPage, etc.)
 ├── Tests/       # NUnit test classes
 ├── Utilities/   # Helpers (waits, screenshots, common functions)
 ├── Base.cs      # Base class: WebDriver setup/teardown + browser switch
 └── README.md
🔄 Improvements vs. Earlier Version (TAProgramme)
Centralised WebDriver management

Introduced a Base class instead of repeating driver setup/teardown in every test class.

Test classes now inherit from Base, keeping them shorter and cleaner.

Multi-browser support

Added a switch(browser) in Base to allow running tests on Chrome, Firefox, or Edge.

Default is Chrome, but this makes cross-browser validation possible without rewriting tests.

Browser configuration improvements

Added Chrome options (start maximised, disable password manager, etc.).

Easier to extend with headless runs or custom download directories.

Use of stable locators

Prefer IDs and CSS selectors where possible.

When XPath is necessary, use attribute combinations with and for resilience, for example:

csharp
Copy code
By.XPath("//a[@title='Go to the last page' and @class='k-link k-pager-nav k-pager-last']")
Avoids brittle absolute paths like //*[@id="container"]/p/a.

Removed repetitive code

Tests no longer create new driver instances manually.

Page Objects are used consistently for login, navigation, and CRUD actions.

More maintainable waits

Reduced reliance on Thread.Sleep in favour of explicit waits.

Tests run faster and fail less often due to timing issues.

Cleaner Page Object usage

Each page encapsulates its own logic (e.g., CreateTimeRecord, EditTimeRecord, DeleteTimeRecord).

Tests now express what is being tested, not how Selenium executes it.

▶️ Running Tests
bash
Copy code
dotnet restore
dotnet test
You can choose a browser by setting the browser variable in Base (default = Chrome).

📌 Next Steps
Add screenshots on failure.

Strengthen locator strategy further (e.g., data-* attributes, roles).

Add CI pipeline with cross-browser matrix (Chrome, Firefox, Edge).

📖 Developer Log
[2025-09-04] Introduced Base Class and Multi-Browser Support
Created Base.cs to centralise WebDriver setup/teardown.

Added switch(browser) to support Chrome, Firefox, and Edge.

Cleaned up tests so they only contain intent, not driver setup code.

[2025-09-05] Stable Locator Strategy
Replaced brittle absolute XPaths with stable locators (IDs, CSS).

When XPath is used, added and conditions for extra reliability.

This reduced test flakiness and made locators easier to maintain.
