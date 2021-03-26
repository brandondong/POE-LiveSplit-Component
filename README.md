# POE LiveSplit Component
Load screen time removal and auto splitting for Path of Exile speedrunning.

## Auto Splitting
The component can be configured to automatically split upon entering specific zones or reaching required levels for the first time. This can be used to track progress across sections of the game without the inconvenience of having to manually trigger a split.

[Demonstration](https://i.imgur.com/EN9RCRy.gif)

## Load Removal
Load screen time can be automatically subtracted from your run. This is done by reading the timestamps on client logs.

[Demonstration](https://i.imgur.com/kEhAmBg.gif)

## Setup
1. If you do not have LiveSplit already, [download](http://livesplit.org/downloads/) the latest version (either link is fine)
2. Extract the zip file and run the LiveSplit application executable
3. Right click on the timer and select "Edit Splits"
4. Type "Path of Exile" as the Game Name and click the Activate button below the number of attempts
5. To configure settings such as selecting which zones will result in an automatic split upon entering, click the Settings button next to the Activate button
6. If you are running Path of Exile through Steam, change the log file location in the Settings menu appropriately (the file will most likely be located at C:\Program Files (x86)\Steam\steamapps\common\Path of Exile\logs\Client.txt)
7. To automatically generate splits from your selected zones, click the "Generate Splits" button

## Additional Setup Instructions for Load Removal
Follow these additional instructions if you want to use load removal.

8. Right click on the timer and select "Edit Layout"
9. Click the Layout Settings button
10. Go to Timer -> Timing Method, select Game Time and then press OK
11. Click the + icon in the layout editor and select Timer -> Timer and then click OK

You now have two timers: the top timer uses Game Time (subtracting load screens) and the bottom uses Real Time.

## Limitations
Autosplitting only detects splits on logout/login. This is a limitation of Path of Exile, as it only writes zone entry to the logfile during login.

Autosplitting will likely split incorrectly for speedruns strictly starting in the part 2 storyline. The logs only contain zone names so it is impossible to distinguish between certain zones and their part 1 and part 2 equivalents from the logs alone. The tool does its best to guess based on the zones traversed so far and should have no problems for a typical speedrun starting in part 1.

### Load Removal Timer Accuracy
The lines in the log file that are used as basis for load screen start and end are "Got Instance Details" and "You have entered ..." respectively. From testing, the logs report that I have entered an area slightly before my load screens are finished. Unfortunately, this is the last line the log file reports and may lead to an overestimation of game time. Surprisingly, /played exhibits similar behaviour.

## Development Setup
To build the project, this repository must be cloned recursively.

`git clone --recursive`

It should be able to compile without any further configuration when opening the project with Visual Studio 2015.

For issues and suggestions, please use https://github.com/brandondong/POE-LiveSplit-Component/issues.
