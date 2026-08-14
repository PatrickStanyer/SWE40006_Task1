README – SampleApp & SampleAppSetup
A lightweight C# console application packaged into a Windows Installer (MSI) using the WiX Toolset.

Overview
This repository contains two related projects:

SampleApp  
A simple .NET Framework console application used for Task 1.1 of SWE40006 Software Deployment and Evolution.
The application prints a confirmation message and waits for user input.

SampleAppSetup  
A WiX v3 setup project that packages SampleApp into a Windows Installer (.msi).
The installer places the application into Program Files, includes a minimal UI, and supports clean uninstallation.

This repository is designed to demonstrate the complete workflow of building, packaging, and deploying a Windows desktop application using Visual Studio and the WiX Toolset.

Project Structure
Code
/
├── SampleApp/
│   ├── Program.cs
│   ├── SampleApp.csproj
│   ├── bin/
│   │   └── Release/
│   │       └── SampleApp.exe
│   └── Properties/
│
└── SampleAppSetup/
    ├── Product.wxs
    ├── SampleAppSetup.wixproj
    ├── bin/
    │   └── Release/
    │       └── SampleAppSetup.msi
    └── References/
⚙️ Prerequisites
Before building the projects, ensure the following are installed:

Windows 10/11

Visual Studio 2022 Community Edition

Workloads:

.NET Desktop Development

Desktop Development with C++

UWP Development (optional)

WiX Toolset v3 Build Tools

WiX v3 Visual Studio Extension

.NET Framework 3.5 (enable via Windows Features if prompted)

Building SampleApp
Open the solution in Visual Studio.

Select Release configuration.

Build the SampleApp project.

Confirm the output exists at:

Code
SampleApp/bin/Release/SampleApp.exe
Code Excerpt
(Full code is in SampleApp/Program.cs)

csharp
Console.WriteLine("Deployment Activity 1: Pass Task Completed!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

Building the MSI Installer (SampleAppSetup)
1. Add Project Reference
The WiX project references the SampleApp project so it can resolve MSBuild variables such as:

$(var.SampleApp.TargetPath)

$(var.SampleApp.TargetDir)

2. Product.wxs Configuration
Key excerpt:

xml
<Directory Id="ProgramFilesFolder">
    <Directory Id="INSTALLFOLDER" Name="SampleApp" />
</Directory>

<DirectoryRef Id="INSTALLFOLDER">
    <Component Id="MainExecutable" Guid="{YOUR-GUID-HERE}">
        <File Id="SampleAppEXE"
              Source="$(var.SampleApp.TargetPath)"
              KeyPath="yes" />
    </Component>
</DirectoryRef>
3. Build the WiX Project
Build SampleAppSetup in Release mode.

The MSI will be generated at:

Code
SampleAppSetup/bin/Release/SampleAppSetup.msi
Testing the Installer
Run the MSI file.

Follow the WixUI_Minimal installation wizard.

Verify installation directory:

Code
C:\Program Files\SampleApp
Launch the installed application.

Uninstall via Apps & Features.

Results
MSI installs SampleApp into Program Files

Application launches successfully

Installer UI loads correctly

Uninstallation works cleanly

All packaging requirements for Task 1.1 are met

Purpose
This repository supports the assessment requirements for:

SWE40006 – Software Deployment and Evolution  
Task 1.1 – Pass Level: Packaging a Simple Application Using WiX

It demonstrates:

Visual Studio environment setup

WiX Toolset configuration

MSI packaging workflow

Installer testing and verification

Future Extensions
This repository forms the foundation for later tasks:

Task 1.2 – Credit Level

Task 1.3 – Distinction Level



Future versions may include:

Multiple components

Custom actions

Registry entries

Start menu shortcuts

Bootstrapper bundles (Burn)

📄 License
This project is for educational use within Swinburne University’s SWE40006 unit.
