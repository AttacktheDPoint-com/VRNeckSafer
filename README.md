# VRNeckSafer — Revival

<p>
  <img src="https://img.shields.io/badge/original-abandoned-important.svg" alt="Original Status">
  <img src="https://img.shields.io/badge/last%20original%20commit-2022--06-lightgrey.svg" alt="Last Original Commit">
  <img src="https://img.shields.io/badge/license-GPL--3.0-blue.svg" alt="License">
  <img src="https://img.shields.io/badge/fixes-23%20bugs-brightgreen.svg" alt="Fixes">
  <img src="https://img.shields.io/badge/revival-active-brightgreen.svg" alt="Revival Status">
</p>

> **This is not just a fork.** This repo contains NobiWan's original [VRNeckSafer](https://gitlab.com/NobiWan/vrnecksafer) with a community fix pass — 23 bug fixes, crash guards, resource leak fixes, and performance optimizations. No new features were added. The original author's code and design are preserved; we only fixed things that were broken. See the [OpenXR version (XRNeckSafer)](https://github.com/AttacktheDPoint-com/XRNeckSafer-Rework) for the same treatment on the OpenXR codebase.

**Latest stable:** [v2.10](https://github.com/AttacktheDPoint-com/VRNeckSafer-Revival/releases/tag/v2.10) (drop-in replacement for v2.09) | **Beta:** [v2.11 betas](https://github.com/AttacktheDPoint-com/VRNeckSafer-Revival/releases) (VR behavior changes, needs headset testing)

---

## What's in the community patch?

**v2.10 (stable)** — Safe fixes only, no VR behavior changes:
- Fixed modifier device dropdown resetting main button assignment
- Fixed pitch limit triggering when looking down instead of up
- Fixed crash on invalid PitchLimForAutorot in config
- Fixed toggle state leaking to config file (missed presses on reload)
- Fixed GDI handle leaks in graph window (bitmaps and brushes)
- Fixed dialog windows leaking native resources
- Fixed Hold button dialogs titled "Button for Reset"
- Fixed Zero button not resetting yaw offset (called wrong method)
- Fixed MultiButtons Cancel leaving VRStuff with stale config
- Fixed joystick scan crash on unplug during scan dialog
- Atomic config writes to prevent corruption on crash
- Suppressed unnecessary config writes during startup
- App-specific singleton mutex name
- Clean exception handling on SteamVR failure

**v2.11-beta** — VR behavior changes (needs headset testing before use):
- **beta1:** Eliminated chaperone boundary grid flickering (CommitWorkingCopy replaces ShowWorkingSetPreview)
- **beta2:** Eliminated single-frame glitch on offset change (skip commit on reset pose)
- **beta3:** SteamVR disconnect handling (shows status instead of crashing)

---

## Description

VRNeckSafer tries to help virtual pilots flying in VR to not break their neck while trying to check their six.
It adds an angular offset to the current viewing angle by pressing a joystick button. Currently working with IL2, DCS, and War Thunder **with SteamVR**. (for the OpenXR version look here : [**XRNeckSafer**](https://github.com/AttacktheDPoint-com/XRNeckSafer-Rework))

<img src="https://gitlab.com/NobiWan/vrnecksafer/-/raw/master/VRNeckSafer/Release/VRNSv209.JPG">    <img src="https://gitlab.com/NobiWan/vrnecksafer/-/raw/master/VRNeckSafer/Release/VRNSv209b.JPG"> 
 

**How to use it:**

Simply choose the two joystick/HOTAS buttons you want to use for left and right offset and the required rotation angle and set the Reset button as shown on the app.
When in the game, press the assigned reset button to calibrate.
Thats it. It works with normal SteamVR (no Beta required).


If you prefer adding up the offset angle with every button click, select the "Accumulative" option.

If you want to move your head position a few centimeters when using snap view (e.g. to look around your seat) use the Translation feature.

Enable the "Autorotation" feature to automatically activate the offset when turning your head over defined activation angles and deactivated when below a deactivation angle. No joystick buttons required.
This can be done in several steps. To temporarily inhibit autorotation use the Hold buttons.

---

**Options Menu — Game Mode, Position Compensation, and App Mode explained:**

VRNS works by shifting the SteamVR tracking origin so the game re-projects your view at a different angle. Three settings in the Options menu control how this works. Getting them right for your game matters — wrong settings can cause the view to drift or snap to unexpected positions.

*Game Mode* (Options > Game Mode)

This tells VRNS which SteamVR tracking space to use for reading your head position and writing the offset.

| Setting | What it does |
|---------|-------------|
| **Auto** | Asks SteamVR which space the game requested. This is correct for most setups. |
| **Force seated** | Always uses the seated tracking space. The origin is wherever you were sitting when SteamVR calibrated. |
| **Force standing** | Always uses the standing tracking space. The origin is at floor level in the center of your play area. |

IL-2 requests seated mode from SteamVR. DCS requests standing mode. If your game reports the wrong mode (some headset runtimes override the game's choice), use the Force options.

- **IL-2:** Auto (detects seated) or Force seated
- **DCS:** Auto (detects standing) or Force standing
- **If you're unsure:** look at the "(Mode: seated)" or "(Mode: standing)" label at the bottom of the VRNS window — it shows what's currently active

*Position Compensation* (Options > Pos. Compensation)

When you press the Reset button in-game, VRNS captures your current physical head position as a reference point. Position Compensation uses this to account for the fact that you're not sitting exactly at the tracking origin — without it, rotating the view can shift your apparent position because the rotation is around the tracking origin, not around your head.

| Setting | What it does |
|---------|-------------|
| **when seated** | Compensates only when the game is in seated mode. This is the default. |
| **when standing** | Compensates only when the game is in standing mode. |
| **always** | Always compensates regardless of mode. |
| **never** | No position compensation — rotation is always around the tracking origin. |

Which one you need depends on which game you fly:

- **IL-2 (seated mode):** Use **"when seated"** (default). IL-2 uses seated tracking where your calibrated sitting position is the origin. Position compensation adjusts for any difference between your actual head position and that origin, keeping the rotation centered on you.
- **DCS (standing mode):** Use **"when standing"** or **"never"**. DCS uses standing tracking and handles its own seated position internally via HMD yaw offset. Position compensation is usually not needed — if the view drifts when you rotate, try toggling between "when standing" and "never" to see which feels right.
- **If rotation shifts your view sideways:** You need position compensation turned on for your current mode.
- **If rotation feels correct already:** Leave it as-is or set to "never".

Note: Position compensation is only recalculated when you press the Reset button. If you move your chair or shift position, press Reset again to recalibrate.

*App Mode* (Options > App Mode)

| Setting | What it does |
|---------|-------------|
| **Overlay** | VRNS registers as a SteamVR overlay app. This starts SteamVR automatically if it's not running. Recommended for most users. |
| **Background** | VRNS registers as a background app. SteamVR must already be running before you launch VRNS. Use this if Overlay mode causes conflicts with other VR software. |

This setting takes effect on next launch — changing it while running does nothing until you restart VRNS.

*Recommended settings:*

| | IL-2 | DCS | War Thunder |
|---|------|-----|------------|
| Game Mode | Auto | Auto | Auto |
| Pos. Compensation | when seated | when standing | when seated |
| App Mode | Overlay | Overlay | Overlay |

War Thunder uses seated tracking mode like IL-2. The same settings should work. If the view drifts on rotation, try "always" for Position Compensation.

---

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

**Update v2.0:**

new features/changes:
+ seperate joysticks for each button
+ modifiers
+ several steps for autorotate 
+ buttons can be scanned/recognized 
+ More than one Hold button
+ buttons can be inverted
+ buttons can toggle
+ only a single instance allowed
+ start minimized
+ minimize to tray
+ config file can be added as parameter
+ options to fiddle with: 
   force seated/standing mode
   position compensation
   app mode can be "Background" (requires SteamVR to already run) or "Overlay" (starts SteamVR on its own)
 
**Update v2.01:**

minor change: typo fix in GUI and allowed Autorotation with Accumulative mode.
 
**Update v2.02:**

hotfix for DCS   

**Update v2.03:**

fix for fwd translation when autorotation to left 

**Update v2.04:**

**Update v2.05:**
- added fancy diagram to help understand the autorot values
- fixed offset bug reintroduced in v2.04

**Update v2.06:**
- corrected error in translation when HMD Offset is big for IL-2
- reset button resets accumulative offset
- added pitch limit (options menu). when HMD pitch (looking up) is bigger than limit autorot goes on hold. default is 90 deg = not effective 

 **Update v2.07:**
 - fixed GUI font
 - Added option to select more than one button for manual rotation

 **Update v2.08:**
 - Added option to select more than one reset button

 **Update v2.09:**
 - Fixed crash when joystick disconnects. Reacquires joystick when reconnected.
 - Added seperate reset button for accumulative mode

known issues:
still problems with Valve Index and Varjo Aero

---

## Support This Project

This project was revived by **[Attack the D Point](https://github.com/AttacktheDPoint-com)** — we find abandoned open-source projects, fix them, and ship them.

If this fix saved you time, consider supporting the work:

<a href="https://github.com/sponsors/AttacktheDPoint-com"><img src="https://img.shields.io/badge/Sponsor_on_GitHub-%E2%9D%A4-ea4aaa.svg" alt="GitHub Sponsors"></a>
<a href="https://ko-fi.com/atdpt"><img src="https://img.shields.io/badge/Buy_a_Coffee-ko--fi-ff5e5b.svg" alt="Ko-fi"></a>

Your support helps us keep reviving projects like this one. See what else we're working on at [AttacktheDPoint-com](https://github.com/AttacktheDPoint-com).

---

## Credits

All credit for the original project goes to **[NobiWan](https://gitlab.com/NobiWan)** and its contributors. This fork exists because the original was too good to let die.

*Licensed under GPL-3.0 — same as the original.*
