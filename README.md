# RoboDoc

Robodoc is a cross-platform mobile game created to help medical students increase their accuracy in diagnosing the underlying cause of acute respiratory failure. 

The application was created by University of Michigan computer science students

- Matthew Chesser (chesserm@umich.edu)
- Andrew (AJ) Kempton (kemptona@umich.edu)
- Husain Rasheed (hrasheed@umich.edu)
- Mahir Taqbeem (mahirtaq@umich.edu) 

as their Major Design Experience project (final senior project) for the course EECS 495: Software for Accessibility tought by Dr. David Chesney and David Nie during the Fall 2020 semester. 

The project was created for, and in collaboration with, Dr. Thomas Valley and Clarice Hibbard of Michigan Medicine.


# Medical Background 

Acute Respiratory Failure is a medical condition in which patients are unable to perform the necessary gas exchange from Oxygen to Carbon Dioxide and often need assistance breathing through a ventilator. Early and accurate diagnosis of the underlying cause of Acute Respiratory Failure is crucial for patient survival. There are three main causes of Acute Respiratory Failure:

- Chronic Obstructive Pulmonary Disease (COPD)
- Congestive Heart Failure (CHF)
- Pneumonia 

The treatment for each of these conditions can have serious negative effects if treatment is given to a patient whose true underlying cause is not what the doctors suspect.  

# Project Background 

Dr. Thomas Valley of Michigan Medicine and his colleagues developed a database of 1,000 cases of previous acute respiratory failure where the true underlying cause of the patient's condition was determined by three medical doctors and labeled for each case. 

Senior-level undergraduate computer science students in EECS 495: Software Accessibility at the University of Michigan were given the opportunity to use this database to develop a mobile game to be used by Medical Students to improve their accuracy diagnosing the underlying cause of patients' Acute Respriatory Failure. The database was created so that there are no HIPAA violations or concerns. 

The Fall 2020 EECS 495 course and the development of this project , was structured similarly to a software engineering lifecycle common in industry. Teams were required to develop the application so that there was an Alpha, Beta, and Omega release for the software. Documentation was created and presentations were given for each of these releases. The master branch of this GitHub repository represents the project's most recent state (which at the time of writing this documentation, is the same as the final omega release for the course). However, there are beta_release and omega_release Git branches that represent the project's exact state at the time of the Beta and Omega releases respectively.

Development on the project was initially started in MonoGame and the alpha release was completed using this framework. However, the development efficiency in MonoGame - compared to Unity - was abysmal for those new to game development. As a result, our team migrated our C# backend code to Unity after our alpha release. This **significantly** improved our development efficiency and User Interface. If anyone is interested in viewing the alpha release of the project created at Monogame, the public GitHub repository can be found [here](https://github.com/chesserm/diagnostic_gamification_monogame). 

# Detailed Project Overview

A detailed overview of the project, with extensive technical documentation, can be found in this repository (and in this same directory) in the `detailed_overview.md` file.

# Setup and Building the Application

## Unity Setup

To setup the project in Unity and to view the project through the Unity editor, follow the steps found in the `setup_instructions.md` located in the `setup_instructions` folder of the repository

## Building the Application to Android and iOS

To build the project to android, follow the steps for `Configuring Build Settings` on the [official Unity documentation](https://docs.unity3d.com/2018.4/Documentation/Manual/android-BuildProcess.html).

Similary, to build the project to iOS, you must be on a Mac and follow the steps under `iOS build settings` on the [official Unity documentation](https://docs.unity3d.com/2018.4/Documentation/Manual/BuildSettingsiOS.html).

# Next steps/future development

This is an ongoing open-source project that, while fully functional, has the potential for significant improvements. Below are some of the improvements our team did not have the time to get to during our semester of dedicated work on the project:

0. Increase the experience points required for each level
    - The experience points required for each level are detailed in `detailed_overview.md` in documentation and are implemented in the Player class (`Player.cs`). Currently, the experience point ranges are low for the purpose of testing and demonstration. These need to be re-designed to more reasonable ranges.
1. Improved UI
    - Currently the application uses the [Modern GUI Skin](https://assetstore.unity.com/packages/2d/gui/modern-gui-skin-19561) Asset Pack from the Unity Store to spruce up our User Interface. Admittedly, none of us were skilled in graphic design or UI/UX design, so we kept the UI simple and focused on the functionality.

2. Improve the patient avatar
    - Currently the patient avatar, displayed in the `PlayMain` scene, uses the [2000+ Faces](https://assetstore.unity.com/packages/2d/characters/2000-faces-139263) Unity Store Asset Pack to create a simple patient avatar which matches the gender to the gender of the case in the database and randomizes the assets otherwise. It currently does not match the patient's age accurately or match the overall aesthetic of the game. 

3. Add a Leaderboard 
    - This would compare the users' overall accuracy and accuracy diagnosing each cause of acute respiratory failure. To implement this, a database will need to be setup and a unique identifier system for player IDs will need to be implemented.

4. Significantly increase the RoboDoc avatar's integration in the play loop
    - Currently, only the face of the user's customized Robot Doctor avatar is displayed in the `PlayMain` Scene. We had ambitions to create an animated waiting room scene where the user could select the patient they would diagnose in the play loop, however, this was not something we had bandwidth for.

5. Aggregate user statistics on accuracy and reasoning
    - By aggregating statistics on users' accuracy on cases and reasoning, we can create a dataset that gives insight into insufficient training in users. If users also voluntarily enter their medical school, this could help medical schools improve their education.

6. Implement the Color Customization for assets
    - Currently, the visual assets have variations for the following colors:
        - Grey (#43464B)
        - Bronze (#813E24)
        - Silver (#C0C0C0)
        - Gold (#D4AF37)
        - Platinum (#D0F6FF)
    - The plan was to allow users to unlock the color customizations as they leveled up (through gaining experience points). The assets are already created and available at [this Google Drive folder](https://drive.google.com/drive/folders/1oe2Hl-OgIC-Rn81MLCe5XuDC_WBEUOXQ?usp=sharing) and the backend logic just needs to be written.

7. Increase the quantity and quality of customizable assets.
    - Currently all of the customizable assets for the game were created by our team members in [piskelapp](https://www.piskelapp.com/) and can be found at this [Google Drive folder](https://drive.google.com/drive/folders/1oe2Hl-OgIC-Rn81MLCe5XuDC_WBEUOXQ?usp=sharing). Creating more options for customization would help incentivize use of the game.

