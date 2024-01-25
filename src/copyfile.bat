set OUTPUT="SonomaWallpaper"

mkdir %OUTPUT%
cd %OUTPUT%

mkdir "data"
copy /Y "..\data" "data"

mkdir "images"
copy /Y "..\images" "images"

copy /Y "..\Microsoft.Toolkit.Win32.UI.XamlHost.Managed.dll" .
copy /Y "..\Microsoft.Toolkit.Win32.UI.XamlHost.winmd" .
copy /Y "..\Microsoft.Toolkit.Wpf.UI.XamlHost.dll" .
copy /Y "..\ModernWpf.Controls.dll" .
copy /Y "..\ModernWpf.dll" .
copy /Y "..\SonomaWallpaper.exe" .
