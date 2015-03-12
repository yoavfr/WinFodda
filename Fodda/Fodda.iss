; -- Fodda.iss --
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=Fodda
AppVersion=1.0
DefaultDirName={pf}\Fodda
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\Fodda.exe
Compression=lzma2
SolidCompression=yes
OutputDir=bin\Release

[Files]
Source: "bin\Release\Fodda.exe"; DestDir: "{app}"
Source: "bin\Release\Shell.dll"; DestDir: "{app}"
Source: "bin\Release\Interop.WIA.dll"; DestDir: "{app}"

[Icons]
Name: "{commonprograms}\Fodda"; Filename: "{app}\Fodda.exe"
Name: "{commondesktop}\Fodda"; Filename: "{app}\Fodda.exe"