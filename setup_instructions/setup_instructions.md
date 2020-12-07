# Setup Instructions 

For our beta release, our team migrated our C# game logic from Monogame to Unity. While this will decrease the application's memory and speed efficiency, it has greatly improved our development speed and will improve the aesthetic of our application. 

In order to download our code and play around with the application, please follow these steps:

1. Make sure Unity version 2019.4.13f1
    - While the application may work with a different Unity version, this has not been tested and all development work was done on this version
2. Close unity (Git works best with unity if Git work is done while Unity is closed)
3. Make sure the Git repo is on the "omega_release" branch
4. Open Unity and open the application
5. Go to the Game Window (at the top of the unity editor) and change the project development resolution
    - There should be a drop down right next to the dropdown with "Display 1" that needs to be clicked on
    - At the bottom of the drop down, click the plus symbol to add a new option
    - Create a new option called 720p that uses "Fixed Resolution" and has a width of 720 and a height of 1080
    - Finish creating this option and select it as the current selection in the drop down 
6. Check for camera issues (see below)
7. In the "Project" window of the Unity UI, navigate to `/Assets/Scenes/` and double click on "MainMenu"
8. Click the play button at the top of the Unity window to play the game. 


## Potential Camera Issues (step 6 above)
One quirk our group has encountered irregularly with Git and Unity, is that, sometimes, the location of assets within scenes are moved around. While we were hoping to transition to Unity Collab for our Omega release, we were unable to complete this transition due to bandwidth. Additionally, we believe the issues are fixed for the most part, but this extra validation is included just in-case. 

Please check each scene by doing the following:

0. Run the game and click through everything to see if there are any clear visual issues. If not, this entire section can be skipped.
1. Go to the "Project" window within the Unity UI and navigate to the `/Assets/Scenes/` directory. Double clicking on a scene will open the scene.
2. Press `Ctrl + S` to save the scene
    - There are known issues with Unity's Scroll View that make this necessary for some scenes.
3. Click on the "Game" tab at the top of the screen.
4. Compare the previewed screen with the image file that has the same name as the scene in this repo at `/setup_instructions/scene_images/`.
5. If the scene preview in the "game" tab of the Unity preview differs from the image, please do the following:
    1. Click on the "scene" tab at the top of the Unity UI to bring you to the scene editor
    2. Expand the hierarchy of GameObject assets in the "Hierarchy" panel of the Unity UI
        - Try not to expand buttons (the naming of buttons should be clear, but in case they are not, buttons should only have a "Text" child object in the hierarchy)
    3. Clicking on the different objects in the hierarchy to view what object corresponds to what visual asset.
    4. Once you find the asset that appears to differ from the image in the repository, do the following:
        1. Click on the GameObject in the hierarchy
        2. Click anywhere on the window showing the scene
        3. Press "w" to ensure you are in "move" mode (as opposed to "scale", "rotate", etc)
        4. Click and drag on the square to move it where it should be

Doing these steps for each scene should ensure they are as they should be. We apologize for any inconvenience setting this up.

