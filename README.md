# unity-editor-scripts

A quick Unity Editor script that implements a build-replace-run hotkey for local multiplayer testing on macOS.

First, press CTRL + B to initiate the process.

1. The script looks under Assets/Builds/ for test.app and test1.app to try to delete previous builds
2. Next, it uses the Scriptable Build Pipeline to build the current open scene
3. Next, it copies that build (named test.app under Assets/Builds/test.app) as test1.app
4. Finally it starts both copies of the build, giving you two running clients in addition to the Unity Editor.

The two running copies of your build can be used as clients to connect to the Unity Editor, which can run the local server. 
This can be useful in developing a multiplayer game locally so you don't have to manually rebuild and restart every time you make a change

Good luck! Enjoy!
