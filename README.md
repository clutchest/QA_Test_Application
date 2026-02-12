# Playwright .NET – End-to-End Tests for Registration of a QA Test Project

Automated **end-to-end (E2E)** tests for a web application's registration flows using **Playwright for .NET**.

Tests cover:
- Successful registration + login flow
- Negative scenarios (invalid email, duplicate email, password mismatch, too short password, missing terms, etc.)
- Form state validation (empty on load, field values after input)
- Navigation (e.g. "Already have an account" link)
- Error message verification (custom spans like `#emailError`, `#passwordErrorMessage`)

## Tech Stack

- **Playwright** (.NET) – 1.58.0
- **.NET** – 8.0
- **NUnit** – 3.14.0
- **Microsoft.Playwright.NUnit** – 1.58.0
- **Microsoft.NET.Test.Sdk** – 17.8.0
- **C#** 12+ with nullable reference types and implicit usings

## Prerequisites

1. **.NET 8.0 SDK** installed
2. **Visual Studio** / **VS Code** with C# extension
3. **Playwright browsers** (Chromium, Firefox, WebKit)

Install browsers once (run in terminal from project root):

```bash
dotnet tool install --global Microsoft.Playwright.CLI
playwright install --with-deps

## Project Structure
TestAssignment/
├── Pages/
│   ├── BasePage.cs
│   └── DashboardPage.cs
│   ├── LoginPage.cs
│   ├── RegisterPage.cs
├── TestData/
│   └── TestData.cs
├── RegisterTests.cs
└── test.runsettings

Installation

Clone the repository
Open .sln file
Install required packages
Build project
Open test explorer and run cases
