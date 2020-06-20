# TimeFreezer
 
## About

TimeFreezer is a console app that demonstrates how to freeze<b><i>*</i></b> Windows Time & Date.
When the user decides to resync the time, it makes sure the windows time service is running and sends a resync command to the executable located in system32.

\*As far as I know, there is no way to really FREEZE Windows Time, what the programs does is that it sets the time at regular interval using the [SetSystemTime](http://www.pinvoke.net/default.aspx/kernel32/SetSystemTime.html) API.
