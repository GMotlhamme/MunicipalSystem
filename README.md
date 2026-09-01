# MunicipalSystem

## Overview

The Municipal Services Application is a C# Windows Forms application designed
to improve citizen engagement with municipal services in South Africa.

The application currently allows residents to report municipal issues by
providing information about the issue, selecting a category, describing the
problem, and optionally attaching a supporting document or image.

Other planned features, such as Local Events and Announcements and Service
Request Status, are currently disabled as they will be implemented in later
stages of the project.

## Features

### Report Issues

Users can:

- Enter the location of an issue.
- Select an issue category.
- Provide a detailed description.
- Attach an image or document using the file selection dialog.
- Submit their report.
- Receive feedback about the progress of their report.
- Receive confirmation when the report has been successfully submitted.

### Main Menu

The main menu provides access to:

- Report Issues
- Local Events and Announcements
- Service Request Status


## Technologies Used

- C#
- .NET Framework
- Windows Forms
- Visual Studio

## Project Structure

The solution consists of two projects:

### MunicipalSystem

Contains the Windows Forms user interface, including:

- `HomeForm`
- `ReportIssuesForm`

### MunicipalSystem.Core

A shared class library containing the application's core classes.

It currently contains:

- `Issue` - represents a reported municipal issue.
- `IssueService` - manages the collection of reported issues.

## Requirements

To compile and run the application, you will need:

- Microsoft Visual Studio with Windows Forms/.NET Framework development
  support installed.
- .NET 9.

## How to Compile

1. Open the solution in Microsoft Visual Studio.
2. Open the `MunicipalSystem` solution.
3. In Visual Studio, select **Build > Build Solution**.
4. Ensure that the solution builds successfully without errors.

## How to Run

1. Open the project in Visual Studio.
2. Set `MunicipalSystem` as the startup project if it is not already selected.
3. Press **Start** or `F5`.
4. The Municipal Services application's main menu will appear.

## How to Use

### Reporting an Issue

1. Select **Report Issues** from the main menu.
2. Enter the location of the issue.
3. Select an appropriate category.
4. Enter a description explaining the issue.
5. Optionally select **Upload Document** to attach an image or document.
6. Select **Submit**.
7. Follow the on-screen feedback provided by the application.
8. Select **Back to main menu** to return to the main menu.

### Validation

The application requires users to provide:

- A location.
- An issue category.
- A description.

If required information is missing, the application displays an appropriate
message informing the user what needs to be completed.

## Data Handling

Reported issues are represented using the `Issue` class and stored using a
`List<Issue>` within the `IssueService`.

This allows multiple reported issues to be stored and managed while the
application is running.

## User Engagement

The Report Issues form provides users with dynamic progress feedback while
they complete their report. This is intended to encourage users to complete
the reporting process and provide feedback about their progress.

