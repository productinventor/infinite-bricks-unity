# UI Module

This module handles all UI-related functionality for Infinite Bricks.

## Components

### UIManager
- Creates and manages runtime UI elements
- Automatically sets up:
  - FPS display panel
  - Test control panel with buttons
  - Canvas and event system
- Provides test controls:
  - Spawn 100 test objects
  - Clear all objects
  - Toggle VSync
  - Reset FPS statistics

## Usage

1. Add `UIManager` component to any GameObject in your scene
2. Configure settings in the inspector
3. UI will be created automatically at runtime

## Features

- Dynamic UI creation
- Performance testing controls
- Modular design for easy extension

## Assembly: InfiniteBricks.UI
- References: InfiniteBricks.Core, Unity.TextMeshPro
- Namespace: InfiniteBricks.UI