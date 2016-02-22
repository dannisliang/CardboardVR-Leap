# CardboardVR-Leap
Unity project demonstrating VR using TrinusVR + OpenTrack Redirect, plus Leap Orion (for Oculus) for hand tracking.

This works great for testing VR/AR experiences without expensive hardware (looking at you Oculus).

## Setup and Debugging
1. Install TrinusVR on your desktop and Android device: http://trinusvr.com/
2. Open the Unity project and import the core leap assets:
https://developer.leapmotion.com/unity?id=unity5-core-assets
2. Open the `MainScene`
3. Start TrinusVR, load the configuration file `TrackingConfig\TrinusVR\default.cfg`
4. Adjust inversion and sensitivity settings, and ensure Sensor Output is set to `OpenTrack Redirect`
5. Start TrinusVR app on the Android device, and connect the desktop application
6. Build & Run!

## Implementing Head Tracking
To implement head tracking in an existing project, simply add the `UDPReceive` script to your scene, then the `FaceTrackMovement` script to your camera.

## Implementing Leap Hand Tracking
Add the Leap VR Camera Control script to your camera, then add the `LeapSpace` prefab as a child to your camera (or simply copy it from one of the example scenes).

## Troubleshooting
If you start the demo by looking at the ground or sky, adjust the Yaw Compensation in the FaceTracking script.
You may also need to adjust the inversion and sensitivity in TrinusVR's `Sensors` tab.
