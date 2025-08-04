# Core Module

This module contains core functionality and utilities for Infinite Bricks.

## Components

### FPSDisplay
- Displays real-time frame rate information
- Color-coded performance indicators (green >60fps, yellow 30-60fps, red <30fps)
- Shows current, average, min, and max FPS
- Configurable update interval

### TestSceneSetup
- Utility for quickly setting up test scenes
- Creates ground plane, lighting, camera, and UI manager
- Use in editor or at runtime

## Usage

1. Add `FPSDisplay` component to a GameObject with TextMeshProUGUI
2. Configure display settings in the inspector
3. FPS will automatically update during gameplay

## Assembly: InfiniteBricks.Core
- References: Unity.TextMeshPro
- Namespace: InfiniteBricks.Core