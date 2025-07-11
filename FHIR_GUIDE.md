# SETUP AND DEVELOPING AN APPLICATION IN HL7-FHIR IN WINDOWS:
This is a guide document on how to start and build an **HL7-FHIR app project** in Visual Studio Code.  
This application is developed in **C#**, using external **NuGet** packages to support development.


## The 1st Project:
The first project will consist in communicating with the server by getting a list of patients, searching for an specific one and a getting a short and brief description about patient resources.

## Needed Tools
The developent of the app will need certain requirements. 

- [**VISUAL STUDIO**](https://visualstudio.microsoft.com/)**/**[**VISUAL STUDIO CODE**](https://visualstudio.microsoft.com/)

- [**Windows Pretty Terminal**](https://www.hanselman.com/blog/how-to-make-a-pretty-prompt-in-windows-terminal-with-powerline-nerd-fonts-cascadia-code-wsl-and-ohmyposh) **(not Mandatory)**

- [**HL7-FHIR V4**](https://www.nuget.org/packages/Hl7.Fhir.R4/)

- [**GIT**](https://git-scm.com/)

- [**.NET**](https://dotnet.microsoft.com/download/dotnet-core) **(Preference Up to date)**

- [**C# XML Documentation Comments**](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment)

##  CREATE AND SETUP THE WORK ENVIRONMENT

First, you need to create the folders and access the folder that you chose as your project directory.

### Create And Acceed the Folder:
````bash
- mkdir FhirApp
- cd FhirApp
 ````
### Creating Project
````bash
- dotnet new console - n <NameOfProject>
- cd FhirDemo   
 ````

the -n option is short for --name.

It specifies the name of the project that the dotnet new command will create.

## INSTALL THE PACKAGES:
When working with HL7 standard and choosing a version of the protocol, it is not possible to run different versions in the same project, so choose one wisely and search for wich one will be better for you to chose.

## SETUP THE NUGETS (CHOOSE A VERSION):

### HL7-FHIR V-STU3:
```bash
- dotnet add package Hl7.Fhir.STU3 
- dotnet add package Hl7.Fhir.Specification.STU3
```
### HL7-FHIR V-R4:
```bash
- dotnet add package Hl7.Fhir.R4
- dotnet add package Hl7.Fhir.Specification.R4
```
### HL7-FHIR V-R4B:
```bash
- dotnet add package Hl7.Fhir.R4B
- dotnet add package Hl7.Fhir.Specification.R4B
```
### HL7-FHIR V-R5:
```bash
- dotnet add package Hl7.Fhir.R5 
- dotnet add package Hl7.Fhir.Specification.R5
```
## RUN THE PROJECT:
To start the project in visual run the following comand:

```bash
dotnet run --project <NameOfProject>
```

## Resume: