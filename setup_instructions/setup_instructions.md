# Setup Instructions 

For our beta release, our team migrated our C# game logic from Monogame to Unity. While this will decrease the application's memory and speed efficiency, it has greatly improved our development speed and will improve the aesthetic of our application. 

In order to download our code and play around with the application, please follow these steps:

1. Make sure Unity version 2019.4.13f1
    - While the application may work with a different Unity version, this has not been tested and all development work was done on this version
2. Close unity (Git works best with unity if Git work is done while Unity is closed)
3. Make sure the Git repo is on the "beta_release" branch
4. Open Unity and open the application
5. Check for camera issues (see below)
6. In the "Project" window of the Unity UI, navigate to `/Assets/Scenes/` and double click on "MainMenu"
7. Click the play button at the top of the Unity window to play the game. 


## Potential Camera Issues (step 5 above)
One quirk our group has encountered irregularly with Git and Unity, is that, sometimes, the location of assets within scenes are moved around. This has not impacted any of our game logic and only impacts aesthetics.

 We hope to get this resolved through the use of Unity Collab, but our group was not willing to attempt to transition to Collab before beta release due to the issues Unity Collab was experiencing the past couple of weeks. This is a temporary fix to the issue that we fully expect to have resolved by our Omega release.


Please check each scene by doing the following:

1. Go to the "Project" window within the Unity UI and navigate to the `/Assets/Scenes/` directory. Double clicking on a scene will open the scene. 
2. Click on the "Game" tab at the top of the screen.
3. Compare the previewed screen with the image file that has the same name as the scene in this repo at `/setup_instructions/scene_images/`.
4. If the scene preview in the "game" tab of the Unity preview differs from the image, please do the following:
    1. Click on the "scene" tab at the top of the Unity UI to bring you to the scene editor
    2. Expand the hierarchy of GameObject assets in the "Hierarchy" panel of the Unity UI
        - Try not to expand buttons (the naming of buttons should be clear, but in case they are not, buttons should only have a "Text" child object in the hierarchy)
    3. Clicking on the different objects in the hierarchy to view what object corresponds to what visual asset.
    4. Once you find the asset that appears to differ from the image in the repository, do the following:
        1. Click on the GameObject in the hierarchy
        2. Click anywhere on the window showing the scene
        3. Press "w" to ensure you are in "move" mode (as opposed to "scale", "rotate", etc)
        4. Click and drag on the square to move it where it should be
    5. Lastly, do the following to make sure the camera is properly positioned:
        1. In the hierarchy window, click on "Main Camera"
        2. Click anywhere on the window showing the scene
        3. Make sure the window matches up with the box outline that all of the UI elements are placed in (the canvas). If it is not matched up, you may need to resize the Main Camera and move it to line it up.







