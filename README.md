# Doodle Drawing App

A Windows Forms drawing and image-editing coursework application. It provides a canvas with drawing tools, text and emoji placement, image loading, colour adjustments, cursor selection, and bitmap export.

**Stack:** C# · Windows Forms · .NET Framework 4.7.2 · `System.Drawing`

## Features

- Pen, brush, and eraser tools with size controls.
- Colour selection, canvas clearing, and fill-related controls.
- Text placement with font and colour settings.
- Emoji insertion and bundled sample images.
- Image loading, grayscale/colour adjustment handlers, and size controls.
- Save the canvas as a **BMP** image.
- A cursor-selection form and a simple demonstration login screen.

## Build and run

1. Use Windows and Visual Studio with **.NET desktop development** and .NET Framework 4.7.2 support.
2. Open [Doodle_222257U.sln](Doodle_222257U.sln).
3. Build the solution and start it from Visual Studio.
4. The entry point opens `Login`. Its comparison values are hard-coded in [Login.cs](Doodle_222257U/Login.cs); inspect or change these locally for the demonstration. This is not an account service or secure authentication system.

Keep the project folder intact. Images and other resources are referenced by the project and generated resource-accessor files.

## Basic drawing workflow

1. Open the main drawing form after the demonstration login.
2. Select a drawing tool, size, and colour, then drag on the canvas.
3. Use the text/font or emoji controls for additional canvas content.
4. Load an image if needed and inspect how it appears on the canvas.
5. Use **Save** to export a bitmap. The implementation uses `ImageFormat.Bmp`; changing a filename's extension does not add another encoder.

## Code guide

| Path | Purpose |
| --- | --- |
| [Program.cs](Doodle_222257U/Program.cs) | Starts the login form |
| [Login.cs](Doodle_222257U/Login.cs) | Demonstration login and transition to the drawing form |
| [MainForm_222257U.cs](Doodle_222257U/MainForm_222257U.cs) | Canvas tools, mouse events, image operations, and save/load handlers |
| [chooseCursor.cs](Doodle_222257U/chooseCursor.cs) | Cursor-selection form |
| `*.Designer.cs`, `*.resx`, `Properties/` | Layouts, resources, and generated accessors |

## Limitations

The canvas is saved as a rendered BMP image rather than an editable layered document. Undo/redo, autosave, and additional export formats are not provided.

## Author

Chua Jia Sheng.
