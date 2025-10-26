# Orb Dasher - Unity Game

## Overview
A 3D platformer/action game where the player controls a robot that must collect 3 energy orbs while avoiding security drones in a factory setting.

## Core Features
- Player character with movement and jumping mechanics
- Health system with damage from security drones
- Combat system to defeat enemy drones
- Objective system to track energy orb collection
- Security drones with basic AI that patrol and chase the player
- Energy orbs to collect to win the game

## Controls
- WASD or Arrow Keys: Move the robot
- Spacebar: Jump
- Left Mouse Button or Space: Attack

## Game Mechanics
- Collect 3 Energy Orbs to win the game
- Avoid security drones that damage you on contact
- Defeat security drones using the attack ability
- Navigate through platforms to reach the orbs

## Project Structure
- Assets/Scripts: All C# scripts for gameplay
- Assets/Prefabs: Game object prefabs
- Assets/Materials: Materials for visual assets
- Assets/Scenes: Unity scene files

## Scripts
- PlayerController.cs: Handles movement and jumping
- PlayerHealth.cs: Manages player health and death
- CombatManager.cs: Handles attack mechanics
- ObjectiveTracker.cs: Tracks collected orbs and win condition
- SecurityDroneAI.cs: AI for enemy drones
- EnergyOrb.cs: Orb collection mechanics
- GameUI.cs: UI elements
- PlayerInput.cs: Input handling for attacks

## Installation
1. Open this project in Unity (version 2021.3.15f1 or later)
2. Open MainScene.unity from Assets/Scenes/
3. Press Play to start the game

## Testing the Game
1. The player starts at position (0, 1, 0) on the ground
2. Move around using WASD/arrow keys
3. Jump with the spacebar to navigate platforms
4. Collect the 3 energy orbs placed throughout the level
5. Avoid or defeat the red security drones
6. Win by collecting all 3 orbs