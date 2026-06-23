[Setup]
AppName=OpenViewer3D
AppVersion=1.0
DefaultDirName={localappdata}\Autodesk\Revit\Addins\2024\OpenViewer3D
DefaultGroupName=OpenViewer3D
OutputDir=output
OutputBaseFilename=OpenViewer3D_Setup
Compression=lzma
SolidCompression=yes

[Files]
Source: "..\src\OpenViewer3D\bin\Release\OpenViewer3D.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "..\src\OpenViewer3D\OpenViewer3D.addin"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\OpenViewer3D"; Filename: "{app}"

[Run]
Filename: "notepad.exe"; Description: "Open install folder"; Flags: postinstall
