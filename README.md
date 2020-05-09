# bobaBlast
## Boba shooter mobile game for COMP-225 (Software Development), Spring 2020 <br>
**Developed by:** Bernadette Clermont, Ivy Contreras, Jacqueline Ong, Haley Vien

🔗 **Notion:** https://www.notion.so/bobablast/Development-Blog-3a09defd83dd43c391aa3dead4fa6838 <br>
🔗 **Project Vision Document:**
https://docs.google.com/document/d/156GKFkgeoR5s4o4MerlBipi90ecgu62k9No5QuvH0hA/edit?usp=sharing

## Checkout and develop
**Required:** Unity 2019.3.5f1 or above with Android Build Support module (Personal license), GitHub Desktop <br>
**Recommended:** Visual Studio Code
- Clone this repository to your machine with GitHub Desktop
- Start Unity, and select the project folder **"bobaBlast"** if prompted; this will open the project for editing
- Make your edits - as examples, you may reposition items in the Scene view, change their components in the Inspector or modify C# scripts to attach to game components 
- You can test your edits in Unity by hitting the Play button - don't forget to change the script`gameManger.cs` to accept spacebar input instead of touch (see "Known Errors" section)
- When you're done with your edits, make sure to **save** in Unity
- Switch over to GitHub Desktop; your changes should be visible (note that changes to `Main.unity` are expected if you added or changed any game object) 
- Commit and push your changes 🍵

## Build
- Make sure that you have the Android Built Support module, with Android SDK & NDK Tools and OpenJDK installed with your version of Unity (these can be downloaded from the "Installs" menu on Unity Hub)
- Follow these [tutorials](https://learn.unity.com/tutorial/building-for-mobile#5c7f8528edbc2a002053b4a1) to build for both iOS and Android

## Installation and Run (Mobile)
- **iOS:** Refer to the "Testing the game on your iOS device" section of this [tutorial](https://learn.unity.com/tutorial/building-for-mobile#5c7f8528edbc2a002053b4a2) <br>
- **Android:** The easiest way is to upload the `.apk` from the Build step to Google Drive, and download and install it on your Android device. You can also transfer it to your device via a cable connection and your computer's file explorer. Make sure the option to install unknown apps is enabled on your device.

## Known Errors
- Refer to this repository's Issues tracker for current bugs and features to be added in the future
- A common mistake when building the app to your mobile device is to forget the code accepting touch input (lines 52, 53, 60 and their closing brackets) in the script ‘gameManger.cs` if it was changed to accept another type of input before
- Vice versa, if you have issues accepting spacebar input when you checkout this project, check lines 54, 61 and their closing brackets and comment out the code accepting touch input
- If the game crashes in Unity’s Play mode, make sure that the “Error Pause” option is disabled in the Console Window

## Sources
- Refer to the [Sources](https://www.notion.so/bobablast/Sources-b4e667e1b7d042be9f8e8278b656282e) tab of our Notion for a list of some of the assets and resources we used to develop the game
- Code sources are also credited in commemnts in the scripts

![alt text](https://i.imgur.com/1Hq5TUs.png "App icon by Haley Vien")
