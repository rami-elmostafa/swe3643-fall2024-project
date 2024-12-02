# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator

This repository contains the source code for a web-based calculator that performs basic statistical functions, including: computing a mean, a sample and population standard deviation, a z-score, a single variable regression formula, and predict a y value from a regression formula. In addition, unit tests for the calculator logic, that achieve 100% coverage, and Playwright end to end automated tests for the calculator web UI. Included will also be descriptions of runtime environment, how to execute the project from the command line, and how to run the tests from the command line.

##  Table of Contents

- [Environment](#environment) 
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-unit-tests)
- [Reviewing Unit Test Coverage](#reviewing-unit-test-coverage) 
- [Executing End-To-End Tests](#executing-end-to-end-tests)
- [Final Video Presentation](#final-video-presentation) 

*Team Members*: Rami Elmostafa

**Architecture: **

![PlantUML diagram](https://cdn-0.plantuml.com/plantuml/png/fLTXRzem4FtEhx3QBvig_i0qJUqeLIkL5ZNGbMeISfqZjUROsTc1LHF_VNQiW04J8ED3st3llVETNtpkfJOKJPcB3XL2BNB-Xykiqoae-qKp86SzAbWfg558xbN66Hcej1HmHiu5pzxDcoYXyxT3x8S9gZMv1isG5uRF8J7KS6quqyGZtEU2z5HUb0OIcXV2OMHACRs6ERTe9NU1GrMKeeeT1X-ZDm0Q8_ukASBZx9hFPe0W6UXTq3D5JcreD_AQC8N--sKdQCSzbq3n2J84hUroefsm7HUmZGnmGuIKCpEvGPNtxJfNTIs3JFL6sTWJw5AOZLHzH8K3gqopZSBkT58o1ZhypjFrJeQn1doceeGRXJar1d0ZnP2YXaS95MG8w0fg2DlYSrhdw2oRB3UMt90HQAE9tLNou9vh0tw0iwspe5-bfpY49xZ0OTTDxxasZxDgRNhw1AP4gVTWFtq-HV9AY5T0TKZKOOuLxkU5-N3gjMQrkPPzx6ipjNNoD5He09-Y6o-vWL7XJidm_xLR2pwK-HlWGHN_JljcLSuO0BM2JglcUSWUue1hpMLc4rhlqnmCu37vN1RtbbTDR2HOPDovBX03-_P5677z-C5KkyU9-4wkLEA4-iWwJjwlCPHljSY4vl3IlaP7dxIdkwrxkPBfP4WvjX4Oo_uSvCiaQjBuKDZQcfNdLWLCchbtSdwOlTmyPvr0mdFtia7w0zuIm3bWTVBM1-_kr9Z69aNWqiIWRKgph-F2qHbpchARtjipfDlz5h_NnA7Rcnb5HPPlSSrDRSriBcBVyBK2n2kGgwBOlV5v7mnK2aAldvyvB8B7df86bH20sdKsV7PByl1OmEl68h4g8i38HaGmaMRkQKTVfjsHwjfVmLraAEZ70crVjYuaP7qXMKjOwaZP7-7DX5m40DlnCRSkpc34ZO3fdLx7d3lZ-ERhGktmda84PlpbhbciUO96Ht1zjsoxIZ-LMwiEWBOir0_TTjnjVvseKf_2bVtsS_t_4tjjv4mScleBkHsDXWukd4D_Id8BD1MWDVcEQg6zmPbGPKhE0xE-ynG8uyW4UEi615B_HRusfBEwbo3JCXV_0000)

## Environment 

This is a cross-platform application and should work in Windows 10+, Mac OSx Ventura+, and Linux environments. Note that the application has only been carefully tested in Windows 11.

To prepare your environment to execute this application:
 1. [Install the latest .NET runtime (net8.0) for your system.](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) 

 2. [Install Git](https://git-scm.com/downloads) 

 3. Ensure .NET 8.0 and Git were successfully installed:   

    Open a terminal window:

    - Windows (Command Prompt) https://www.wikihow.com/Open-the-Command-Prompt-in-Windows
    - Mac OS (Terminal) [https://support.apple.com/en-kg/guide/terminal/apd5265185d-f365-44cb-8b09-71a064a42125/mac#:~:text=Terminal%20for%20me-,Open%20Terminal,%2C%20then%20double%2Dclick%20Terminal](https://support.apple.com/en-kg/guide/terminal/apd5265185d-f365-44cb-8b09-71a064a42125/mac#:~:text=Terminal for me-,Open Terminal,%2C then double-click Terminal).
    - Linux This will be specific to your Linux distribution. Google for help if you cannot find your Terminal.

    4. From your command line or terminal, type `dotnet --version`. Assuming dotnet is properly installed, you will see something like the following: (windows example)

       ![image-20241201152625243](C:\Users\ramie\AppData\Roaming\Typora\typora-user-images\image-20241201152625243.png)

    5. From your command line or terminal, type `git --version`. Assuming `git` is properly installed, you will see something like the following: (macOS terminal example)[![image-20240822072904716](https://github.com/jeff-adkisson/swe-3643-fall-2024/raw/main/homework/homework-1-assets/image-20240822072904716.png)](https://github.com/jeff-adkisson/swe-3643-fall-2024/blob/main/homework/homework-1-assets/image-20240822072904716.png) 

#### To configure Playwright for end-to-end testing: 

1. Install necessary Playwright dependencies, from your command line or terminal, type

   -  `dotnet add package Microsoft.Playwright.NUnit`

2. Install required browsers, from your command line or terminal, type 

   - `pwsh bin/Debug/net8.0/playwright.ps1 install`

     

     If `pwsh` is not available, you will have to install PowerShell

   - [Install PowerShell for Windows](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.4) 

   - [Install PowerShell for macOS](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-macos?view=powershell-7.4) - recommended/easiest way to install is [.Net Global Tool](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.4#install-as-a-net-global-tool)  

   - [Install PowerShell for Linux](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-linux?view=powershell-7.4) 

## Executing the Web Application

1. Clone the Repository: In command line, enter the following 

   - `git clone https://github.com/rami-elmostafa/swe3643-fall2024-project.git`

2. Navigate to repository folder: In the command line, enter the following

   - `cd swe3643-fall2024-project`

3. Navigate to the Web Application from the repository folder: (Ensure you are in root repository from steps 6&7 from above)  In the command line or terminal, enter the following

   - `cd "src\Calculator\CalculatorWebServerApp"`

4. Restore Dependencies (NuGet for Blazor application): In the command line or terminal, enter the following

   - `dotnet restore`

5. Build the Application: In the command line or terminal, enter the following

   - `dotnet build`

6. Run the Application: After building the project, you can run the Blazor application by typing the following In the command line or terminal

   - `dotnet run`

     You should see output similar to this: 

     ![Screenshot 2024-12-01 163325](C:\Users\ramie\Downloads\Screenshot 2024-12-01 163325.png)

5. After the application starts, launch a browser and connect to http://localhost:5206

   **TROUBLE SHOOTING: **

   - If you see the following error, something is already running on the application's HTTP port. Free up the port, then try again:
     `Unhandled IO exception: Failed to bind to https://127.0.0.1:5206: address already in use.`

## Executing Unit Tests

1. (If already cloned skip to step 3) Clone the Repository: In command line, enter the following 

   - `git clone https://github.com/rami-elmostafa/swe3643-fall2024-project.git`

2. Navigate to repository folder: In the command line, enter the following

   - `cd swe3643-fall2024-project`

     *Tip: To go return to previous directory in windows command line, use `cd ../`*

3. To run the Unit Tests for the Calculator Application, ensure you are in the Calculator Unit Tests directory by entering the following in the command line or terminal (making sure you are in root directory of `swe3643-fall2024-project`)

   - `cd src\Calculator\CalculatorLogicUnitTests`

4. To run the tests, enter the following to the command line or terminal

   - `dotnet test`

     

     **The output should look like the following:**

     $ dotnet test

     Starting test execution, please wait...
     A total of 1 test files matched the specified pattern.
     Starting test execution, please wait...
     A total of 1 test files matched the specified pattern.

     {All 

     Tests}

     Passed!  - Failed:     0, Passed:   22, Skipped:     0, Total:   22, Duration: 39 ms - CalculatorLogicUnitTests.dll (net8.0)



## Reviewing Unit Test Coverage

*Coverage achieved in Calculator Logic module is 100%, this means 100% test coverage of all statements and paths in calculator logic.* 

![image-20241201172600771](C:\Users\ramie\AppData\Roaming\Typora\typora-user-images\image-20241201172600771.png)

## Executing End-To-End Tests

1. The web application MUST be running in order to execute End To End tests, if not already running, go back to 
   - [Run Web Application](#executing-the-web-application)  
2. On the top of the command prompt window, open a new command prompt tab (KEEP THE CURRENT PROMPT- as you need the web app to be running)

2. To run the End To End Tests for the Calculator Application, ensure you are in the Calculator End To End Tests directory by entering the following in the command line or terminal (ensure you are in root directory of `swe3643-fall2024-project`) 

- `cd swe3643-fall2024-project\src\Calculator\CalculatorEndToEndTests`

  *Tip: To go return to previous directory in windows command line, use `cd ../`*

2. To run the tests, enter the following to the command line or terminal

   - `dotnet test`

     

     **The output should look like the following: ** 

  dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  CalculatorEndToEndTests -> /Users/rami/projects/swe-3643-spring-2024-project/src/Calculator/CalculatorEndToEndTests/bin/Debug/net8.0/CalculatorEndToEndTests.dll
Test run for /Users/rami/projects/swe-3643-spring-2024-project/src/Calculator/CalculatorEndToEndTests/bin/Debug/net8.0/CalculatorEndToEndTests.dll (.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.8.0 (arm64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 2 s - CalculatorEndToEndTests.dll (net8.0)



**TROUBLE HANDLING**  

- If you see output similar to the following, you most likely forgot a step from [configure Playwright for end to end testing](#to-configure-playwright-for-end-to-end-testing) 

Microsoft.Playwright.PlaywrightException : Executable doesn't exist at /Users/jeff/Library/Caches/ms-playwright/chromium-1028/chrome-mac/Chromium.app/Contents/MacOS/Chromium
╔════════════════════════════════════════════════════════════╗
║ Looks like Playwright was just installed or updated.                                                                        ║
║ Please run the following command to download new browsers:                                                  ║
║                                                                                                                                                                    ║
║     pwsh bin/Debug/netX/playwright.ps1 install                                                                                 ║
║                                                                                                                                                                    ║
║ <3 Playwright Team                                                                                                                                ║
╚════════════════════════════════════════════════════════════╝



## Final Video Presentation

[Project Presentation on Youtube] ()
