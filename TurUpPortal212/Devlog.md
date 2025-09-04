This is my personal log of building and improving the test automation framework.  
Each entry captures what I worked on, why I changed things, and what I learned.

---

## [2025-09-02] Base Class + Multi-Browser Support
I finally got rid of the repetitive WebDriver setup code!  
Now all tests inherit from a single `Base` class. It sets up Chrome, Firefox, or Edge depending on what I choose.  
Feels much cleaner — the tests now only focus on intent, not driver plumbing.

---

## [2025-09-04] Stable Locator Strategy
XPath hell is over (well… mostly).  
I replaced fragile absolute XPaths with IDs and CSS selectors.  
For tricky cases, I used `and` conditions inside XPath, which makes them way more resilient.  
The tests are noticeably less flaky now, and the code is easier to read.
