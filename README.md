# SDRSharpPlugins
This containers a crude plugin for SDRSharp that automatically starts the radio upon launching SDRSharp.

Key to add to your plugin file:
```
  <add key="Auto Start Radio" value="SDRSharp.AutoStartRadio.AutoStartRadioPlugin,SDRSharp.AutoStartRadio" />
```

Copy the DLL to the SDRSharp directory.

Tested with Visual Studio 2017 and SDRSharp 1619
