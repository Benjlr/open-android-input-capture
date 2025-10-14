# Open Android Input Capture

An open-source Android library for Unity that enables pointer capture functionality on Android devices, allowing games to capture and control mouse/pointer input.

## Overview

This project provides a way to implement pointer capture in Unity games running on Android. By default, Unity's behavior with mouse input is to stop once the mouse has reached the edge of the screen. This plugin allows you to continue moving with your mouse indefinitely, which is essential for first-person mouse gameplay. When enabled, it captures all mouse movements and button presses, preventing the system cursor from appearing and allowing your game to have full control over pointer input. This is especially useful for first-person games, 3D navigation, or any application requiring continuous mouse input without cursor interference.

## Features

- **Pointer Capture**: Capture mouse/pointer movements on Android devices (API 26+)
- **Unity Integration**: Easy-to-use Unity package with simple API
- **Automatic State Management**: Ties capture state to Unity's `Cursor.lockState`
- **Input Compatibility**: Drop-in replacement for Unity's Input system methods
- **Button Support**: Handles up to 7 mouse buttons (left, right, middle, and 4 additional buttons)
- **Scroll Wheel**: Captures both vertical and horizontal scroll input
- **Activity Lifecycle Aware**: Automatically handles Android activity lifecycle events

## Requirements

- Unity 2022.3 LTS or later
- Android API 34 (Android 14) for building the native library
- Android Studio with JDK 17 (for building the AAR library)

## Build Environment

The Android library is configured with the latest stable toolchain as of 2024:

- Android Gradle Plugin 8.5.0
- Gradle 8.7
- Android SDK 34 and Build Tools 34.0.0
- Unity exported library dependencies targeting API level 34

## Project Structure

```
├── AndroidInputCapture/          # Android library source
│   ├── app/                      # Main library module
│   │   └── src/main/java/com/example/androidinputcapture/
│   │       └── PointerCaptureHelper.java
│   └── unityLibrary/             # Unity library dependencies
│
└── AndroidInputCaptureUnityDemo/ # Unity demo project
    └── Assets/OpenPointerCapture/
        ├── Plugins/              # Contains android-input-capture.aar
        ├── Scripts/              # Unity C# scripts
        │   ├── PointerCaptureManager.cs
        │   ├── PointerCaptureNativeInterface.cs
        │   └── CapturedInput.cs
        └── Demo/                 # Demo scene and scripts
```

## Installation

### Option 1: Use Pre-built Unity Package

1. Copy the `AndroidInputCaptureUnityDemo/Assets/OpenPointerCapture` folder to your Unity project's Assets folder
2. The package includes a pre-built AAR file ready to use

### Option 2: Build from Source

1. Open the `AndroidInputCapture` project in Android Studio
2. Build the project to generate the AAR file
3. Copy the generated AAR to your Unity project's `Assets/Plugins/Android` folder
4. Copy the Unity scripts from `AndroidInputCaptureUnityDemo/Assets/OpenPointerCapture/Scripts` to your project

## Usage

### Basic Setup

1. Add `PointerCaptureManager` component to a GameObject in your scene
2. The manager automatically captures pointer input when `Cursor.lockState` is set to `CursorLockMode.Locked`

### Using Captured Input

Replace Unity's Input methods with CapturedInput equivalents:

```csharp
using OpenPointerCapture;

// Instead of Input.GetMouseButtonDown(0)
if (CapturedInput.GetMouseButtonDown(0))
{
    // Handle left click
}

// Instead of Input.GetAxis("Mouse X")
float mouseX = CapturedInput.GetAxis("Mouse X");

// Instead of Input.mouseScrollDelta
Vector2 scrollDelta = CapturedInput.mouseScrollDelta;

// Instead of Input.mousePosition
Vector3 mousePos = CapturedInput.mousePosition;
```

### Manual Control

If you need manual control over pointer capture:

```csharp
// Begin capture
PointerCaptureNativeInterface.beginCapture();

// End capture
PointerCaptureNativeInterface.endCapture();

// Check capture state
bool isCaptured = PointerCaptureNativeInterface.isPointerCaptured();
```

### Event-Based Input

Subscribe to pointer events directly:

```csharp
void OnEnable()
{
    PointerCaptureManager.OnCapturedPointerMoved += HandlePointerMove;
    PointerCaptureManager.OnCapturedMouseButton += HandleMouseButton;
    PointerCaptureManager.OnCapturedScroll += HandleScroll;
}

void HandlePointerMove(Vector2 delta)
{
    // Handle mouse movement
}

void HandleMouseButton(int buttonIndex, bool isDown)
{
    // Handle button press/release
}

void HandleScroll(Vector2 scrollDelta)
{
    // Handle scroll wheel
}
```

## Demo Scene

The project includes a comprehensive demo scene showcasing various features:

- Camera rotation with captured mouse movement
- Object interaction with mouse buttons
- UI elements that respond to captured input
- Visual feedback for button presses and scroll events

To run the demo:
1. Open `AndroidInputCaptureUnityDemo` in Unity
2. Load the scene `Assets/OpenPointerCapture/Demo/OpenPointerCaptureDemo.unity`
3. Build and run on an Android device

## Implementation Details

### Android Side

The `PointerCaptureHelper` class:
- Implements Android's `OnCapturedPointerListener` interface
- Manages activity lifecycle callbacks
- Stores input deltas and button states for Unity to poll
- Handles view attachment/detachment automatically

### Unity Side

- **PointerCaptureNativeInterface**: JNI bridge to communicate with Android
- **PointerCaptureManager**: MonoBehaviour that polls for input and fires events
- **CapturedInput**: Static facade providing Input-compatible API

## Limitations

- Requires Android API 26+ (Android 8.0 Oreo)
- Only works on Android devices with mouse/pointer support
- In Unity Editor, falls back to standard Input methods

## Troubleshooting

### Pointer capture not working
- Ensure your Android device is running API 26 or higher
- Check that the AndroidManifest.xml includes the library
- Verify that `PointerCaptureManager` is active in the scene

### Input lag or missed events
- The system polls for input each frame, ensure stable frame rates
- For high-frequency input, consider increasing the polling rate

## License

This project is open source and available under the [MIT License](LICENSE).

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.
