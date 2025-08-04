# Getting Started with Unity FPS Test Scene

## Quick Start (Immediate Solution)

If Unity shows "script class cannot be found" for the custom modules:

1. **Use QuickSetup.cs** (works immediately):
   - Create an empty GameObject in your scene
   - Add the `QuickSetup` component to it
   - Play the scene - it will create FPS display and basic scene setup

## Full Setup (Custom Modules)

Once Unity compiles the custom assemblies:

### Method 1: Manual Setup
1. Create an empty GameObject
2. Add the `TestSceneSetup` component (from InfiniteBricks.Core)
3. Play the scene

### Method 2: UI Manager Only
1. Create an empty GameObject  
2. Add the `UIManager` component (from InfiniteBricks.UI)
3. Play the scene

## Troubleshooting Assembly Issues

If custom scripts aren't found:

1. **Refresh Assets**: `Assets > Refresh` or `Ctrl+R`
2. **Reimport Scripts**: Select script files → Right-click → `Reimport`
3. **Reimport Assembly Definitions**: Select `.asmdef` files → Reimport
4. **Clear Library**: Close Unity → Delete `Library` folder → Reopen Unity

## Features

### QuickSetup (Basic)
- ✅ Simple FPS display (top-right corner)
- ✅ Color-coded performance (green/yellow/red)
- ✅ Basic scene lighting and ground
- ✅ Works without custom assemblies

### Full System (Advanced)
- ✅ Advanced FPS display with min/max/average
- ✅ Test control panel with buttons
- ✅ Spawn objects for performance testing
- ✅ Toggle VSync, clear objects, reset stats
- ✅ Modular architecture with assemblies

## File Structure

```
Assets/
├── QuickSetup.cs              # Immediate-use setup script
├── Core/                      # Core utilities module
│   ├── Scripts/
│   │   ├── FPSDisplay.cs     # Advanced FPS component
│   │   └── TestSceneSetup.cs # Scene setup utility
│   └── InfiniteBricks.Core.asmdef
└── UI/                        # UI management module
    ├── Scripts/
    │   └── UIManager.cs       # Runtime UI creation
    └── InfiniteBricks.UI.asmdef
```

## Next Steps

1. Test the FPS display with performance-heavy operations
2. Use the test controls to spawn objects and measure impact
3. Experiment with different Unity quality settings
4. Add your own test objects and scenarios