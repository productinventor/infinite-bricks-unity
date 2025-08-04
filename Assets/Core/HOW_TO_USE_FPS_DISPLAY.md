# How to Use FPSDisplay.cs

## Prerequisites
1. **TextMeshPro**: Make sure TextMeshPro is imported in your project
   - Go to `Window → TextMeshPro → Import TMP Essential Resources`

## Setup Instructions

### Method 1: Manual UI Setup (Recommended)
1. **Create UI Canvas**:
   - Right-click in Hierarchy → `UI → Canvas`
   - This creates Canvas, EventSystem automatically

2. **Create Text Component**:
   - Right-click on Canvas → `UI → Text - TextMeshPro`
   - Position it where you want (e.g., top-right corner)

3. **Add FPSDisplay Component**:
   - Select the TextMeshPro GameObject
   - In Inspector, click `Add Component`
   - Search for `FPSDisplay` and add it

4. **Configure in Inspector**:
   - Update Interval: 0.5 (updates every half second)
   - Show Min Max: ✓ (shows minimum and maximum FPS)
   - Show Average: ✓ (shows average FPS)
   - Color thresholds: Good (60), Warning (30)

### Method 2: Quick Setup
1. **Create Empty GameObject**:
   - Right-click in Hierarchy → `Create Empty`
   - Name it "FPS Manager"

2. **Add TestSceneSetup Component**:
   - Add Component → Search "TestSceneSetup"
   - This will create the UI automatically when you play

## Expected Result
- **FPS Display** appears in top-right corner
- **Color Coding**:
  - 🟢 Green: 60+ FPS (Good performance)
  - 🟡 Yellow: 30-60 FPS (Warning)
  - 🔴 Red: <30 FPS (Poor performance)
- **Information Shown**:
  - Current FPS
  - Average FPS (if enabled)
  - Min/Max FPS (if enabled)

## Troubleshooting

### "Script class cannot be found"
1. **Refresh Assets**: `Assets → Refresh` (Ctrl+R)
2. **Wait for Compilation**: Check bottom-right of Unity for compilation progress
3. **Reimport Scripts**: Select FPSDisplay.cs → Right-click → Reimport

### Assembly Issues
If you get assembly resolution errors:
1. The scripts use custom assembly definitions (InfiniteBricks.Core)
2. Unity needs to compile these assemblies first
3. Wait for compilation to finish (no errors in Console)

### TextMeshPro Missing
If you get TextMeshPro errors:
1. `Window → TextMeshPro → Import TMP Essential Resources`
2. Restart Unity if needed

## Customization
- **Update Interval**: How often FPS updates (0.5s recommended)
- **Colors**: Customize the color thresholds for performance indicators
- **Display Options**: Toggle min/max and average display
- **Position**: Move the TextMeshPro GameObject to any screen position

## Performance Impact
- Minimal performance impact (<0.1ms per frame)
- Updates only every 0.5 seconds by default
- No garbage collection during runtime