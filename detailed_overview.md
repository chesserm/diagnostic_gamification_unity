# Gameplay Overview

This cross-platform mobile game was created in Unity using C#. The project is structured so that the user opens the app and is first presented with a Main Menu, where the user's avatar and current experience level is visible. From the Main Menu, the user can select any of the following options: 

- Play
- Shop
- Customize
- Statistics

## The Play Loop

The Play button will take the user to what we call the "play loop." In the play loop, the user is presented with the information corresponding to a single case from the database of acute respiratory failure patients. However, the information is structured similarly to how a doctor would receive information on a patient if they were diagnosing them in real-life. The user is first presented with the patient's medical history and symptom information on an initial screen. 

After reviewing this information, the user is taken to the main play page, where they can select to either diagnose the underlying cause of the patient's acute respiratory failure or to investigate the presence of a symptom in the patient (e.g. conduct a general exam, check their lungs, order an x-ray, etc). If the user selects a symptom to investigate, they are presented with the corresponding information from the database and then asked to select a reason for how the data impacted the user's suspected diagnosis of the underlying cause of the patient's acute respiratory failure. These reasoning options were given to us by Dr. Valley. By forcing the user to select each symptom and then provide reasoning for how the symptom data impacts their reasoning, we are able to compare their reasoning to expert reasoning and pinpoint exactly where the user's chain of diagnostic reasoning first goes wrong (and potentially leads to an incorrect diagnosis).

This process of choosing to investigate a symptom or conduct an exam, being presented with the data, and being forced to select a reasoning for how the data impacted their suspected diagnosis repeats as many times as the user likes. This is why we call this section of the application the "Play Loop." However, once the user has decided to diagnose the underlying cause of the patient's acute respiratory failure, they can select to do so from the main play page. At which point, they will select from three choices:

- COPD
- CHF
- Pneumonia

After selecting a diagnosis the user will be brought to a summary page. Here, they will see if their suspected diagnosis is correct or not and will also be able to compare each of their selected reasoning choices (selected after investigating each potential symptom) to expert reasoning choices. Finally, they will be rewarded experience points and coins for their performance (more details on the calculations of these rewards below).

## Other Pages

After completing each case, the user will be brought to the Main Menu once again. From here they can select "Play" to diagnose another case from the database or any of the other options. They can also review their performance diagnosing patients in the "Statistics" page, spend the coins they earned to unlock cosmetic items in the "Shop" page, or customize their character in the "Customize" page. Finally, there is a "Help" page, where the user can go for reference and tutorial information about the application.


# Project Organization

As a precursor to this section, it is worth noting that our team did not have experience with Unity, or game development experience at all for that matter, when starting development on this project. So, if there are unconventional or outdated methods seen utilized in the project, please feel free to correct them.


## Unity Project Structure

The project is currently organized so that each screen/page the user sees in the application has its own Scene, with the play loop encompassing the vast majority of the applications scenes. Here is a list of the scenes in the application:


### Non-Play Loop Scenes

- **MainMenu**: This is the first scene the user is presented with when opening the application and is how they navigate between the play loop and other features/scenes.
- **Statistics**: This scene is accessed from a button on the **MainMenu** and allows the user to review their performance diagnosing patients in the play loop.
- **Shop**: The shop scene is accessed from a button on the **MainMenu** and allows the user to spend the coins they earn in the play loop to purchase cosmetic items for their robot doctor avatar.
- **Customize**: The customize scene is accessed from a button on the **MainMenu** and allows the user to customize their robot avatar with cosmetics purchased in the **Shop**.
- **Help**: The help  scene is accessed from a button on the **MainMenu** and provides information on how the application functions for the user's reference.


### Play Loop Scenes

 - **Play**: The initial play loop scene where initial patient information is presented
 - **PlayMain**: The central page of the play loop where the user can choose to investigate a symptom or diagnose the patient's cause of Respiratory Failure.
 - **PlaySymptomList**: The scene that contains the list of symptoms the user can investigate.
 - **PlaySymptomData**: The scene that follows **PlaySymptomList** and displays the data for the symptom selected in **PlaySymptomList**
 - **PlayReasoning**: The scene that follows **PlaySymptomData** and presents reasoning choices for the user to indicate how the symptom data impacted their current suspected diagnosis for the underlying cause of the patient's respiratory failure.
    
    - Note: This page is only displayed after the first time the user views the symptom's data. It is also not displayed for the "Head Exam" and "Skin Exam" options, since the data in the database was nearly identical for all 20 cases provided (there was no variation to base reasoning options off of).

- **PlayDiagnose**: This scene presents the three options for diagnosing the underlying cause of the patient's respiratory failure.
- **PlaySummary** : This scene is presented to the user after they select an option from **PlayDiagnose** and summarizes their results on this case, which includes:

    - Indicating whether the user's diagnosis was correct.
    - Providing expert comments for how the true diagnosis was determined for the patient by medical doctors.
    - Allowing the user to compare their reasoning choices for each investigated symptom with correct choices for each symptom.
    - Rewarding the user with coins and experience points based on their performance 
- **CompareReasoning**: This scene is displayed if the user clicks the button on **PlaySummary** to compare their reasoning results. It allows the user to toggle through their investigated symptoms (in the order they chose them) and see if their selections were correct or not. For studying, this will allow the user to pinpoint where their reasoning is incorrect or where they were led astray.

    - NOTE: The button on **PlaySummary** that takes the user to **CompareReasoning** is not displayed if they did not investigate any symptoms with reasoning (i.e. if they didn't investigate any symptoms or only investigated the head and/or neck exam).

Each scene is organized so that all elements are children of a single GameObject (usually called `ScreenContainer` - or something similar). This allowed us to attach scripts as components to the parent GameObject that all the children could easily find and access in a centralized location.

# Configuring the Canvas and Camera for each Scene

To ensure that the application will scale with various screen sizes, we did the following:

- All of our development was done with a reference resolution of 720 pixel width by 1080 pixel height. This can be configured in the Game Tab of the Unity Editor.
- Each Canvas GameObject (one per scene) needs to have its "Canvas Scaler" Component set to "Scale with Screen Size" with the following settings:
    - Reference Resolution: 
        - X: 720
        - Y: 1080
    - Screen Match Mode: "Match Width or Height"
    - Match: 0.5
    - Reference Pixels Per Unit: 100

Furthermore, since we only needed to display the User Interface canvas to the user, the main camera for each scene is organized such that it is always centered-on, and the same size as, the "Canvas" GameObject in each scene. The Canvas GameObject contains all user interface elements displayed on the screen for the user. To ensure that the camera would scale with the canvas when device resolutions changed from the reference/development resolution (which is `720x1080`) the following some changes were made to the default camera object created by Unity:

1. The name of the Camera must not be changed from the `"Main Camera"`
2. The Camera was made sure to be set to Orthographic with a size of `540`. 
3. A Rect Transform component was added to the camera object - this replaces the default Transform component
4. The Main Camera was made to be the first child of the Canvas GameObject in the hierarchy.
5. The Main Camera needs to add a Script Component and select the script "CameraScaler.cs"

The `CameraScaler.cs` script will ensure the canera size is rescaled to match the canvas - which scales with screen resolution. 

# Codebase

Each scene in the project has one script, usually titled the same as the Scene name, that handles all back-end functionality for the Scene. This scene is always attached to the parent/container GameObject of all other GameObjects in the scene (often called `ScreenContainer`). However, there are some exceptions that need to be outlined below:

### The Player Class

The player class, implemented in `Player.cs`, is in charge of managing values for the player's progress. Such as:
- Overall accuracy diagnosing patients
- Accuracy diganosing each cause of respiratory failure
- Current coin balance
- Current experience earned
- Items purchased in the item shop

This class was implemented as a stateless class that has no current state and merely acts as an interface to PlayerPrefs, the built-in simple persistant storage in Unity.

## The Helper Namespace

There are some utility functions, static classes, and enums that we have defined in a custom namespace for use elsewhere in the program. The implementation of these functions can be found in `Helpers.cs` and the namespace is mostly only used in the play loop. 


## The Case Information static class

The `CaseInformation` static class is implemented in `CaseInformation.cs` and is in charge of managing the state of the player's progress in the play loop. It's values are initialized when entering the play loop through the `Play` Scene and are reset after leaving the `PlaySummary` Scene. 


## The Shop Page

The `Shop` Scene's back-end is implemented in two scripts: `ShopButton.cs` and `ShopItemHandler.cs`. The `ShopButton.cs` script is dependent on the `ShopItemHandler.cs` script. 


# Remote Databases

There are two remote endpoints that the project connects to during the application. 

The first is a MongoDB database that stores the text informatin for each case. It is accessed once per case in the play loop. Specifically, it is accessed through the `get_patient_data()` function in the `CaseInformation` class (implemented in `CaseInformation.cs`), but it is called in the `Start()` function of the `Play` Scene (found in `Play.cs`). The endpoint for the database can be found there.
- The repository for the API created for this can be found [here](https://github.com/mahirtaq/diagnostic-api)

The second endpoint is an Imgur database that holds the re-sized x-ray images for each case. The script `getxray.cs` implements the interface for this and the `Start()` function from the script actually fetches the image. This script was created to inherit from MonoBehavior, so it needs to only be attached to a GameObject in a Scene of interest to work. Currently, it is only used in the `PlaySymptomData` scene.


# Calculation of Rewards

The rewards for each case in the play loop are calculated as follows:

- Base Rewards (awarded no matter how they did)
    - Coins = (50 * difficultyMod)
    - Exp   = (100 * difficultyMod)
- Correct Diagnosis
    - Coins += (50 * difficultyMod)
    - Exp   += (150 * difficultyMod)
- Reward for correct reasoning choices
    - Coins += (10 * difficultyMod)
    - Exp   += (25 * difficultyMod)
- Bonus that is applied for using the least amount of info possible
    - Coins += (maxNumSymptoms * (60/difficultyMod) - ((60 / difficultyMod) * numSymptomsInvestigated)
    - Exp   += (maxNumSymptoms * (90/difficultyMod) - ((90 / difficultyMod) * numSymptomsInvestigated)

Where the difficulty modification scaling (based on the difficulty for the case) is:
- Easy: 1.0
- Med:  2.0
- Hard: 3.0

The maxNumSymptoms is currently 9.

Therefore, the minimal amount of information theyt can earn per diagnostic session is incorrectly diagnosing a case without investigating any symptoms is:
- Coins = 50
- Exp   = 100

Similarly, the maximum amount of rewards possible, for correctly diagnosing the patient without needing any symptom investigations, is:
- Coins = 480
- Exp   = 1020

The reward symptom is implemented in `PlaySummary.cs` for the `PlaySummary` scene.

# Experience Level System

The experience level system is currently implemented in the Player class (`Player.cs`) and is determined as follows:

- Level 0: Undergraduate Student
    - [0, 1,000) experience points
- Level 1: Medical Student
    - [1,000, 3,000) experience points
- Level 2: Residency Physician
    - [3,000, 7,500) experience points
- Level 3: Physician
    - [7,500, 10,000) experience points
- Level 4: Expert Specialist
    - 10,000+ experience points


# Visual Assets

The avatar and all customizable visual assets for the project were created in [piskelapp](https://www.piskelapp.com/) by our team members.

The visual assets for the project are in the Assets folder of the repository, but they can also be found at [this Google Drive folder](https://drive.google.com/drive/folders/1oe2Hl-OgIC-Rn81MLCe5XuDC_WBEUOXQ?usp=sharing), which includes additional assets that were created, but not yet added to the project.

## Asset Packs

The following two (free) Unity Store Asset packs were used to improve the UI and create the patient avatar respectively:
 - [Modern GUI Skin](https://assetstore.unity.com/packages/2d/gui/modern-gui-skin-19561) 
 - [2000+ Faces](https://assetstore.unity.com/packages/2d/characters/2000-faces-139263) 





