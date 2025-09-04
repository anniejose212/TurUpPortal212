# TurUpPortal212 – UI Test Automation (C# · Selenium · NUnit)

This repository contains automated UI tests for the TurnUp Portal using **C#**, **Selenium WebDriver**, and **NUnit** with a simple Page Object Model (POM).

---

## 📂 Project Structure

```text
TurUpPortal212/
 ├── Pages/              # Page Objects (LoginPage, HomePage, TMPage, etc.)
 ├── Tests/              # NUnit test classes
 ├── Utilities/          # Helpers (waits, screenshots, common functions)
 ├── App.config          # Application configuration
 ├── TurUpPortal212.csproj  # C# project file
 ├── TurUpPortal212.sln     # Visual Studio solution file
 ├── .gitignore          # Git ignore rules
 ├── DEVLOG.md           # Developer log (progress and changes)
 └── README.md           # Project overview and documentation
```

## 🔄 Improvements

### Centralised WebDriver management
- Introduced a **Base** class instead of repeating driver setup/teardown in every test class.  
- Test classes now inherit from `Base`, keeping them shorter and cleaner.  

### Multi-browser support
- Added a `switch(browser)` in `Base` to allow running tests on **Chrome, Firefox, or Edge**.  
- Default is Chrome, but this makes cross-browser validation possible without rewriting tests.  

### Browser configuration improvements
- Added Chrome options (start maximised, disable password manager, etc.).  
- Easier to extend with headless runs or custom download directories.  

### Use of stable locators
- Prefer **IDs** and **CSS selectors** where possible.  
- When XPath is necessary, use attribute combinations with `and` for resilience, for example:  
  ```csharp
  By.XPath("//a[@title='Go to the last page' and @class='k-link k-pager-nav k-pager-last']")
  ```
 - Avoids brittle absolute paths like  - Avoids brittle absolute paths like:
  ```csharp
    //*[@id="container"]/p/a```

### Removed repetitive code
- Tests no longer create new driver instances manually.  
- Page Objects are used consistently for login, navigation, and CRUD actions.  

### More maintainable waits
- Reduced reliance on `Thread.Sleep` in favour of explicit waits.  
- Tests run faster and fail less often due to timing issues.  

### Cleaner Page Object usage
- Each page encapsulates its own logic (e.g., `CreateTimeRecord`, `EditTimeRecord`, `DeleteTimeRecord`).  
- Tests now express *what is being tested*, not *how Selenium executes it*.  

## 📌 Next Steps
- Add keys for user authentication in `app.config`.  
- Add screenshot capture for failed tests.
- Add automation for another module.
- more optimisation with waithelpers for CRUD in Time module. 
