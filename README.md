# Geometry Dash Like - Unity Game

## Description

This project is my final year project for obtaining my Federal Certificate of Competence (CFC). It is a video game greatly inspired by Geometry Dash.
The main goal of the project is to replicate the basic movements of the game, including moving, jumping, and encountering various obstacles.

### Built with

* Unity
* C#

## Getting Started

### Prerequisites

* Game engine : Unity (2022.3.19f1)
* Software management tool : Unity hub
* Code editor : Rider (2023.3.3)

## Deployment

### Setup Unity

1. [Install unity](https://unity.com/fr/download)
2. Clone the repository ```https://github.com/CPNV-TPI/GEOMETRY-DASH-LIKE/tree/release/1.0.0```
3. Open the "Geometry_dash_like" folder in the cloned repository with Unity Hub.
4. Install the proposed version of unity (2022.3.19f1).
5. If you aren't going to use visual studio, feel free uncheck the visual studio download.

### Build project

1. Configure Build Settings:
    * Go to File > Build Settings.
    * Choose the target platform (PC) from the Platform list.
2. Build the Project:
    * Click on File > Build & Run or File > Build Settings and then click Build.
      * Make sure to have the 3 scenes loaded with the correct index position:
        * 0 - Menu
        * 1 - RollingObjectLevel
        * 2 - FlyingObjectLevel
    * Choose a location to save your build files and click Save.
    * Unity will compile your project and create the build for the selected platform.

### Install test coverage

1. Select the tab :
   * Windows > packet manager.
2. Search "code coverage" and install it.
3. Select the tab
   * Window > Analysis > code coverage
4. click on the "Enable Code Coverage" checkbox
    * Click on "Switch to debug mode" if the message appear

### Run Test

1. Select the tab :
   * Windows > General > Test runner.
2. click "Run All" to run all the tests.
3. The tests must run in 1 second maximum.

## Directory structure

```shell
├───Documentation
│   └───Class_diagram
└───Geometry_dash_like
    ├───.vscode
    ├───Assets
    │   ├───Prefabs
    │   ├───Scenes
    │   ├───Scripts
    │   ├───Settings
    │   │   └───Scenes
    │   ├───Tests
    │   ├───TextMesh Pro
    │   │   ├───Documentation
    │   │   ├───Fonts
    │   │   ├───Resources
    │   │   │   ├───Fonts & Materials
    │   │   │   ├───Sprite Assets
    │   │   │   └───Style Sheets
    │   │   ├───Shaders
    │   │   └───Sprites
    │   └───Textures
    ├───Packages
    └───ProjectSettings
        └───Packages
            └───com.unity.testtools.codecoverage
```

## Collaborate

I use conventional commits to help users understand my changes and for better versioning management.

* [How to commit](https://www.conventionalcommits.org/en/v1.0.0/)

Git flow is the workflow that I use for better project management.

* [How to use my workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

## Contact

Thomas Petermann - <Thomas.Petermann@eduvaud.ch>
