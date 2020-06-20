# TimeFreezer
 
## About

TimeFreezer is a console app that demonstrates how to freeze<b><i>*</i></b> Windows Time & Date.

\*As far as I know, there is no clean and easy way to really FREEZE Windows Time, the program sets the time at regular interval using the [SetSystemTime](http://www.pinvoke.net/default.aspx/kernel32/SetSystemTime.html) API.

When the user decides to resync the time, it makes sure the windows time service is running and sends a resync command to the executable located in system32.
