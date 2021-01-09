VRNeckSafer tries to help to help virtual pilots flying in VR to not break their neck while trying to check their six.
It adds an angular offset to the current viewing angle by pressing a joystick button. Currently working with IL2 with SteamVR.

<img src="https://gitlab.com/NobiWan/vrnecksafer/-/raw/master/VRNeckSafer/Release/VRNSv16.JPG"> 

**How to use it:**

Simply choose the Joystick/HOTAS and the two buttons you want to use for left and right offset and the required rotation angle.
Thats it. It works with normal SteamVR (no Beta required).

If you prefer adding up the offset angle with every button click, select the "Accumulative" option.

If you want to move your head position a few centimeters when using snap view (e.g. to look around your seat) use the Translation feature.
For this to work properly you have to (re)set your neutral head angle (HMD yaw) once, so that the app knows which direction "L/R" and "Fwd" are.
 
Also, as an experimental feature, there is an "Autorotate" setting that can be enabled. Here the Offset angle is automatically activated when turning your head over a defined activation angle and deactivated when below a deactivation angle. No joystick buttons required. :) But don't forget to reset HMD yaw once!

**Update v1.1:**

I added the option to use a joystick button to reset the HMD Yaw angle. To use the autorotate feature look straight ahead and press that button (or the reset button in the GUI). This will tell the app from which central Yaw position the activation/deactivation angles are measured.  

**Update v1.2:**

I included a feature to define translational offsets. Better use only a few centimeters here and reset HMD yaw...
Still some  AV checker might give false alerts, haven't got an idea how to avoid that.  

**Update v1.3:** 

Minor bugfix when no button was selected and a beautiful new icon! ;)

**Update v1.4:**

Added an option to use diagonal Hat positions.
To use it:
-     run VRNeckSafer v1.4 once to update the VRNeckSafer.cfg file
-     exit VRNeckSafer v1.4
-     open VRNeckSafer.cfg in a text editor
-     at the line "Use8WayHat" change false to true
-     safe and exit editor
 
**Update v1.5:**

Separate rotation angles for snap and autorotation

**Update v1.6:**

Compatibility to other major combat sim. 
Added a "temporary freeze" button for autorotation 

I'll stay with the zipped folder this time, the standalone versions gave too much trouble with false av alerts...  There is no difference in usage.
It's still a good idea to use the same button for HMD yaw reset and the in game "Default VR view"!
Also, better keep the HMD standard orientation (arrow on ground on the SteamVR plains) close to your normal front direction. (the HMD yaw reset function trys to compensate, but big angular differences are problematic)

 
Known issues:

problem with  Rift CV1 (no reaction after game is launched?)
problem with Vive Pro (View point centers on base station?)
If anyone got these running, please let me know! 