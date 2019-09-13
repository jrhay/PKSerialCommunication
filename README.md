# PKSerialCommunication

RS-232 Communication library for .NET, with specialized libraries for particular hardware.
Provides .NET Standard library implementation where possible.

## Build tools ##

* Build on Windows OS
* Microsoft Visual Studio 2017 Community Edition

## .NET Standard Soltions ##

+ **SerialCommunicationFramework**

	Provides a generic ISerialPort interface for RS232 communication and TCP/Telnet implementations of that 
	interface to provide a simple common serial communication interface API to higher level libraries.
	
+ **Devices/NewportPowerMeterCommunicationsFramework**

	Uses _SerialCommunicationFramework_ to provide a high-level native .NET interface to 1931/2931 series power
	meters by Newport Corporation. 
	
## .NET Framework Solutions ##

+ **Platforms/WindowsDesktop**
	
	Concrete implementation of ISerialPort using System.IO.Ports.SerialPort for Windows Desktop systems.
	
+ **RealDSerialCommunicationTester**

	Provides a GUI test environment to test all functions of the included libraries on Windows Desktop systems.
	
