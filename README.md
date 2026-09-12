# ReqnrollAuto

## Overview

ReqnrollAuto is a C# test automation framework built using **.NET 8, Reqnroll, NUnit, Selenium WebDriver, and Allure Report**.

The framework follows a **Behaviour-Driven Development (BDD)** approach. Test scenarios are written in Gherkin feature files, while step definitions and Page Object classes contain the automation implementation.

The framework also uses a centralized configuration approach for application settings, test credentials, and Allure reporting paths.

---

## Technology Stack

* **C#**
* **.NET 8**
* **Reqnroll**
* **NUnit**
* **Selenium WebDriver**
* **Google Chrome / ChromeDriver**
* **Allure Report**
* **Visual Studio Code**

---

## Project Structure

```text
ReqnrollAuto/
│
├── Features/
│   └── Login.feature
│
├── StepDefinitions/
│   └── LoginSteps.cs
│
├── Pages/
│   └── LoginPage.cs
│
├── Hooks/
│   └── TestHooks.cs
│
├── TestSettings/
│   ├── TestSettings.cs
│   └── TestSettingsProvider.cs
│
├── appsettings.json
├── allureConfig.json
├── ReqnrollAuto.csproj
└── README.md
```

---

## Project Components

### Features

The `Features` folder contains Reqnroll feature files written using **Gherkin syntax**.

Feature files describe application behaviour in a readable format using:

* Feature
* Scenario
* Given
* When
* Then
* And

Example:

```gherkin
Feature: Login

  Scenario: Login to shopping cart

    Given I navigate to the shopping cart application
    When I enter valid login credentials
    And I click the login button
    Then I should be logged in successfully
```

---

### StepDefinitions

The `StepDefinitions` folder contains the C# implementation of the Gherkin steps.

`LoginSteps.cs` connects the steps defined in `Login.feature` with the appropriate Page Object methods.

This separation keeps the feature files readable and prevents Selenium implementation details from being placed directly inside the feature files.

---

### Pages

The `Pages` folder contains the **Page Object Model (POM)** classes.

`LoginPage.cs` contains:

* Web element locators
* Page navigation
* User interactions
* Login-related methods

The Page Object Model helps reduce code duplication and keeps Selenium-related implementation separate from test scenarios.

---

### Hooks

The `Hooks` folder contains test lifecycle management.

`TestHooks.cs` is responsible for activities such as:

* Starting the Chrome browser before a scenario
* Creating the Selenium WebDriver
* Maximizing the browser window
* Closing the browser after the scenario
* Disposing the WebDriver

This provides a common setup and cleanup process for the automated tests.

---

## Test Configuration

The project uses separate configuration files and a configuration provider to avoid hard-coding environment-specific values in the test implementation.

### appsettings.json

`appsettings.json` contains application and test configuration values such as:

* Application URL
* Username
* Password
* Other environment-specific settings

Example:

```json
{
  "TestSettings": {
    "Url": "https://example.com",
    "Username": "test-user",
    "Password": "test-password"
  }
}
```


### TestSettings

The `TestSettings` folder contains the classes responsible for managing test configuration.

#### TestSettings.cs

`TestSettings.cs` represents the configuration model used by the automation framework.

It provides strongly typed access to configuration values.

#### TestSettingsProvider.cs

`TestSettingsProvider.cs` is responsible for loading configuration from the configuration files and making the settings available to the test classes.

This approach avoids directly reading configuration values from multiple places throughout the framework.

---

## Allure Configuration

Allure reporting is configured separately using:

```text
allureConfig.json
```

The configuration file is located in the **root directory** of the project.

Example:

```json
{
  "allure": {
    "resultsDirectory": "allure-results",
    "reportDirectory": "allure-report"
  }
}
```

The configuration defines the locations used by Allure for:

### allure-results

The `allure-results` directory contains the test execution results generated during test execution.

These files are used by Allure to build the test report.

### allure-report

The `allure-report` directory contains the generated Allure HTML report.

The report can be opened in a browser to view:

* Test execution results
* Passed tests
* Failed tests
* Test steps
* Test duration
* Test history
* Failure information

The generated Allure directories are not part of the source code and should normally be excluded from Git.

---

## Prerequisites

Before running the project, make sure the following are installed:

### .NET 8 SDK

Check the installed version:

```bash
dotnet --version
```

The project targets:

```text
net8.0
```

### Google Chrome

Google Chrome is required because the automation framework uses Selenium with ChromeDriver.

### Allure Commandline

Allure Commandline is required to generate and open the Allure report.

Verify the installation:

```bash
allure --version
```

---

## Installing Project Dependencies

Navigate to the project directory:

```bash
cd ReqnrollAuto
```

Restore the NuGet packages:

```bash
dotnet restore
```

---

## Build the Project

Build the project using:

```bash
dotnet build
```

A successful build should complete without compilation errors.

---

## Running Tests

Run all automated tests:

```bash
dotnet test
```

Run the tests with normal console output:

```bash
dotnet test --logger "console;verbosity=normal"
```

---

## Running a Specific Test

A specific test can be executed using the NUnit test name.

Example:

```bash
dotnet test --filter "Name~LoginToShoppingCart"
```

---

## Allure Test Reporting

The Allure reporting process consists of three main steps:

1. Execute the automated tests.
2. Generate the Allure HTML report.
3. Open the generated report.

### Step 1: Run Tests

```bash
dotnet test
```

This generates the Allure test result files in the configured:

```text
allure-results
```

directory.

### Step 2: Generate the Report

Run:

```bash
allure generate allure-results -o allure-report --clean
```

The `--clean` option removes the previous generated report before creating the new report.

### Step 3: Open the Report

Run:

```bash
allure open allure-report
```

This opens the generated Allure report in the browser.

---

## Complete Test and Allure Command

The complete workflow can be executed as:

```bash
rm -rf allure-results allure-report
dotnet test
allure generate allure-results -o allure-report --clean
allure open allure-report
```

This process:

1. Removes previous Allure results.
2. Removes the previous Allure report.
3. Executes the automated tests.
4. Generates fresh Allure results.
5. Creates a new HTML report.
6. Opens the report in the browser.

---

## Framework Architecture

The framework follows a layered automation structure:

```text
Feature File
     │
     ▼
Step Definitions
     │
     ▼
Page Object
     │
     ▼
Selenium WebDriver
     │
     ▼
Web Application
```

Configuration is handled separately:

```text
appsettings.json
        │
        ▼
TestSettingsProvider
        │
        ▼
TestSettings
        │
        ▼
Test / Page Objects
```

Allure reporting is handled through the reporting configuration:

```text
Test Execution
      │
      ▼
allure-results
      │
      ▼
Allure Generate
      │
      ▼
allure-report
      │
      ▼
Browser
```

---

## Advantages of the Framework

### BDD Approach

Reqnroll allows test scenarios to be written in a business-readable format using Gherkin.

### Page Object Model

Selenium interactions are separated from the test steps, making the framework easier to maintain.

### Centralized Configuration

Application settings and test configuration are managed separately from the automation implementation.

### Reusable Test Hooks

Browser setup and cleanup are managed centrally through `TestHooks`.

### Allure Reporting

Allure provides detailed test execution reports that make it easier to understand test results and failures.

---

## Git Configuration

The following generated files and directories should normally not be committed to Git:

```text
bin/
obj/
allure-results/
allure-report/
```

A suitable `.gitignore` should contain:

```text
bin/
obj/
allure-results/
allure-report/
```

Configuration files containing real credentials should also be protected from source control.

---

## Troubleshooting

### Tests do not start

Run:

```bash
dotnet restore
dotnet build
```

Then try:

```bash
dotnet test
```

### Browser does not start

Check that Google Chrome is installed and that Selenium can create a ChromeDriver instance.

### Configuration values are not loaded

Check:

* `appsettings.json`
* `TestSettings.cs`
* `TestSettingsProvider.cs`
* Configuration file location
* Configuration property names

Make sure the property names in the configuration file match the properties expected by the configuration classes.

### Allure results are not generated

First run:

```bash
dotnet test
```

Then check whether the following directory contains result files:

```text
allure-results/
```

If the directory is empty, check the Allure configuration and test integration.

### Allure report contains old results

Remove the previous directories:

```bash
rm -rf allure-results allure-report
```

Then execute:

```bash
dotnet test
allure generate allure-results -o allure-report --clean
allure open allure-report
```

---

## Best Practices

* Keep Gherkin scenarios simple and readable.
* Keep Selenium locators inside Page Object classes.
* Avoid hard-coded URLs and credentials in test classes.
* Keep configuration separate from test implementation.
* Use `TestSettingsProvider` for centralized configuration access.
* Use hooks for browser setup and cleanup.
* Generate a fresh Allure report after test execution.
* Do not commit `allure-results` or `allure-report`.
* Do not commit passwords, tokens, or other sensitive information.
* Keep the framework structure consistent as the number of test scenarios grows.

---

## Future Enhancements

The framework can be extended with:

* Multiple browser support
* Cross-browser testing
* Parallel test execution
* Environment-specific configuration
* Additional Page Objects
* Additional BDD feature files
* CI/CD integration
* Screenshot capture for failed tests
* Allure attachments
* Test data management
* API automation
* Docker-based test execution

---

## Author

**ReqnrollAuto – C# Test Automation Framework**

Built using C#, .NET 8, Reqnroll, NUnit, Selenium WebDriver, and Allure Report.
