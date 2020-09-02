# Arcade Flyer - MonoGame
This repository contains the code for the Arcade Flyer game built throughout the C# 201 Hy-Tech Club course.

## Setup
The setup is based on [this boilerplate project](https://github.com/andrew-r-king/monogame-vscode-boilerplate). To get the game up and running locally, follow these steps:

1. Download and Install [Visual Studio Code](https://code.visualstudio.com/download)
1. Install the [Official C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code
1. Download and Install [Git](https://git-scm.com/downloads)   
1. Fork and clone the [Arcade Flyer GitHub Repository](https://github.com/hylandtechoutreach/ArcadeFlyer.git)
    - In the command line: `git clone <URL>`
    - In VS Code: `Ctrl`+`Shift`+`P` to open the Command Palette, then run "Git: Clone" and enter
    - Alternatively, download the code directly without cloning it
1. Download and Install [MonoGame](https://www.monogame.net/downloads/)
1. Download and Install the [.NET Core SDK (3.x)](https://dotnet.microsoft.com/download)
    - Make sure to grab the **Core SDK**, NOT the Framework or Runtime 
1. Open VS Code
1. In VS Code, open the **ArcadeFlyer** folder
    - It must be this specific folder!
1. Press `F5` to run the game!

## Project Structure
There are three important folders that make up the **Arcade Flyer** project:

- The [.vscode](./.vscode) folder contains configuration files that tell VS Code how to build and run the game
- The [Content](./Content) folder contains all the assets for the game, and the [Content.mgcb](Content/Content.mgcb) file that tells MonoGame how to build those assets
- The [src](./src) folder contains all the C# code for the project

## The Source Code
Eventually, there will be several code files that make the game run.

The [ArcadeFlyer.csproj](ArcadeFlyer.csproj) file in the main directory contains everything needed to build the project. It should not be altered unless there is a change in OS, framework, or folder structure.

All of the C# code files will be stored in the [src](./src) folder. These files will create the actual elements in the game!

### Main Files
- The [Program](src/Program.cs) class is the main entry point for the project. It simply starts the game.
- The [ArcadeFlyerGame](src/ArcadeFlyerGame.cs) class controls the entire game. It will up the screen, and ultimately determine how each element interacts.