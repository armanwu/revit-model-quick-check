# Revit Model Quick Check

A minimal Revit add-in that runs a quick health check:

- Warnings count
- Imported CAD (DWG)
- Linked CAD (DWG)
- In-place families

## Build

Open the solution in Visual Studio, add references to `RevitAPI.dll` and `RevitAPIUI.dll`, then build.

## Install

1. Copy the built DLL to a fixed folder, e.g. `C:\MyRevitAddins\RevitModelQuickCheck.dll`
2. Copy the `.addin` file to:
   `C:\ProgramData\Autodesk\Revit\Addins\20XX\`
3. Edit the `.addin` `<Assembly>` path to match your DLL location.
