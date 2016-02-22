# CardboardVR-Leap
Unity project demonstrating VR using TrinusVR + OpenTrack Redirect, plus Leap Orion (for Oculus) for hand tracking.

## Setup and Debugging
1. Import the core leap assets:
https://developer.leapmotion.com/unity?id=unity5-core-assets&platform=windows&version=4.0.0
2. Start TrinusVR, load the configuration file 'TrackingConfig\TrinusVR\default.cfg'
3. Adjust inversion and sensitivity settings, and ensure Sensor Output is set to 'OpenTrack Redirect'
4. Start TrinusVR app on the Android device, and connect the desktop application
5. Open the MainScene, Build & Run!

## Troubleshooting
If you start the demo by looking at the ground or sky, adjust the Yaw Compensation in the FaceTracking script.