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

## Reproduce on Windows

**Prerequisites:** Git, Windows, Visual Studio with the **.NET desktop development** workload, and the **.NET Framework 4.7.2 targeting/developer pack**. This solution uses .NET Framework rather than a cross-platform .NET application.

```powershell
git clone https://github.com/ChuaJiaSheng/doodle-drawing-app.git
cd doodle-drawing-app
Start-Process .\\Doodle_222257U.sln
```

In Visual Studio, select **Debug / Any CPU**, set `Doodle_222257U` as the startup project if prompted, then choose **Build → Build Solution** and press **F5**. Keep all resource files with the project.

Alternatively, in a **Developer PowerShell for Visual Studio** terminal at the repository root:

```powershell
msbuild .\\Doodle_222257U.sln /p:Configuration=Debug /p:Platform=AnyCPU
& .\\Doodle_222257U\\bin\\Debug\\Doodle_222257U.exe
```

**First launch:** the app opens the demonstration login form. In `Doodle_222257U/Login.cs`, locate the comparison in `btnLogin_Click`. For a local demo, set the username/password literals in both the success and failure conditions to values of your choice, then rebuild and sign in with those same values. Do not reuse a real account password; these are plain-text demo comparisons.

**Expected result:** after the demo login, the drawing window opens. Select a pen or brush, draw a stroke, save to a `.bmp` file, and reopen that file to confirm the exported image contains the drawing.

**Troubleshooting:** an MSB3644/framework-reference error usually means the targeting pack is missing; `msbuild` not found means the command was run outside a Visual Studio developer terminal. Missing resource errors require restoring the resource files and their original relative paths. If login always fails, check that both comparison branches use the same demo values.

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
