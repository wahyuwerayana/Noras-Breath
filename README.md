# **Nora's Breath**
<div align="center">
  <img src="https://github.com/user-attachments/assets/24b059a6-c748-44e5-a877-8ff380faa1f4" width="60%">
</div>

# 📖Documentation
- Made using Unity Editor 2022.3.38f1
- Assets are made by the Game Artist + from Itch.io

## 📂File Description
```
├── IGI Showcase Project             # This folder contains all the project files.
     ├── Assets                      #  This folder contains all of the game assets such as scripts, models, scenes, animations, etc.
        ├── 3D Models                # This folder contains all the 3D Models that is used in the game.
        ├── Animation                # This folder contains the animation and animator controller used for the gameobjects.
        ├── ...
        ├── Font                     # Folder for the fonts used in the game.
        ├── Prefab                   # This folder contains the gameobject prefab to use in the game scenes.
        ├── Scenes                   # This folder contains scene for the game. You can open these scenes to play the game via Unity.
        ├── Scripts                  # This folder contains all of the game script files.
        ├── Sounds                   # This folder contains sounds that is being used for the game.
        ├── UI                       # The UI Assets for the game interface.
        ├── ....
     ├── ...
```

## 📑Scripts
### **Player**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `CameraControl.cs` | This script is responsible for the camera control of the player, such as rotating and changing the focus island |
| `Barricade.cs` | The Barricade mechanism in the game to block the enemy |
| `Tower.cs` | The Tower mechanism in the game to attack the enemy with a tower |
| `Projectile.cs` | The Tower Projectile mechanism to find the nearest enemy and attack them |
### **Enemy**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `Enemy.cs` | The script for managing all the enemy mechanism such as the behaviours and attributes |
### **System**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `AudioManager.cs` | Responsible for managing the audio system in the game |
| `BuildObjectController.cs` | Responsible for managing defense building |
| `ButtonFaceCamera.cs` | Make the button face the camera when it rotates |
| `ClickableObject.cs` | Make a certain object can be clicked for defense building |
| `EnemySpawningSystem.cs` | Responsible for managing the enemy spawning algorithm |
| `InitiateIsland.cs` | When starting the game, randomized the island |
| `etc` |  |

## Contribution
I am here acting as a Game Programmer, tasked with implementing all the mechanisms of this game, starting from generating random islands, building towers, enemies following waypoints, post processing using Unity Post Processing, etc.

## 👥The Team
- [Aaron Medhavi Kusnandar](https://github.com/Aaronmedhavi) as the Game Artist
- [I Gde Wahyu Werayana Kusuma](https://github.com/wahyuwerayana) as the Game Programmer
- [Kelvin](https://github.com/KleponBiru) as the Game Designer

<br />

## 📄About
Nora's Breath is a 3D Tower Defense game. Player will take place as a little seed, using the power of spirit given by Nora to protect Yggdrasil. Fight the enemy till the end and protect Yggdrasil at all cost.

## 🎯Gameplay
Survive the wave by defeating the enemies and collect Spirit Crystal to enhance your defense. Build towers and barricades to fight off the enemies. Don't let the enemies take down the Yggdrasil Tree.

## 🕹️Controls
| Key Binding | Function |
| ----------- | -------- |
| A, D  | Rotate Camera |
| Q, E | Switch between island |
| Left Mouse Button | Build defense (click on spirit seed or barricade place) |
