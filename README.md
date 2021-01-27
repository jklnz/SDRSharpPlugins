# SDRSharpPlugins
This contains a crude plugin for SDRSharp that automatically starts the radio five seconds after launching SDRSharp. Mainly useful for decoding setups (e.g. to auto start after a computer shutdown).

Key to add to your plugin file:
```
  <add key="Auto Start Radio" value="SDRSharp.AutoStartRadio.AutoStartRadioPlugin,SDRSharp.AutoStartRadio" />
```
If you want it to set the frequency when starting you need to add this key to your App Settings in SdrSharp.exe.config
```
    <add key="asrfrequency" value="157950000" />
```
Copy the DLL to the SDRSharp directory.

Tested with Visual Studio 2017 and SDRSharp 1619
