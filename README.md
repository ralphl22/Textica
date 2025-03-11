## Overview

**Textica** is a simple, console-based text adventure game written in C#. The project is structured as a typical C# solution, complete with a project file (`Textica.csproj`) and solution file (`Textica.sln`). The source code is organized into several files, each responsible for different aspects of the game:

- **Entry Point (Main.cs):**  
  The game starts in `Main.cs`, which instantiates core components such as a new character and the main game hub. Notably, the code briefly mentions a `MainMenu` (currently commented out for debugging) and directly creates a new `Character` and a new `TownHub` instance to kick things off.  

- **User Interface (MainMenu.cs):**  
  The `MainMenu.cs` file handles the welcome screen. It sets the console title, displays a title banner ("LEGEND OF TEXTICA"), and waits for a key press before clearing the screen and proceeding.  

- **Game World Navigation (TownHub.cs):**  
  The `TownHub.cs` file acts as the central hub for the player. Here, the game continuously displays the character’s status and presents navigational options. Depending on the user’s input, players can enter areas such as the city watch, the merchant’s shop, or venture into the forest. This file also contains nested classes (e.g., `CityWatch` and `Forest`) that manage specific interactions like quest assignments and combat scenarios.  

- **Other Components:**  
  Additional files like `Character.cs`, `Combat.cs`, and `Item.cs` (likely define the game’s core mechanics—character creation, combat handling (including fights with goblins), and item management, respectively.  `Merchant.cs` manages interactions with the in-game merchant.
  
---

## Usage Instructions

### Building and Running the Game

1. **Clone or Download the Repository:**  
   Use Git to clone the repository or download it as a ZIP file from [GitHub](https://github.com/ralphl22/Textica).

2. **Open the Project:**
   - **Using Visual Studio:**  
     Open the solution file (`Textica.sln`) in Visual Studio. This will load all project files and dependencies.
   - **Using .NET CLI:**  
     Navigate to the project folder in your terminal and use the commands:
     ```bash
     dotnet build
     dotnet run
     ```

### Playing the Game

1. **Start-Up:**  
   When you run the project, the console window will open displaying the **Main Menu**:
   - The console title is set to *"Legend of Textica"*.
   - A banner ("LEGEND OF TEXTICA") is displayed.
   - You’ll be prompted with “PRESS ANY KEY TO CONTINUE”. Once you press a key, the screen clears.

2. **Character Creation:**  
   - The game initializes a new character.  
   - If character data isn’t already provided (e.g., the character name is null), the game will automatically create one.

3. **Navigating the Game World:**  
   - After character creation, you are brought to the **Town Hub**.  
   - Here, the game continuously displays your character’s status (level, experience, etc.) along with options for navigation.
   - **Available Commands:**  
     - **"city watch" or "watch":** Visit the city watch building to receive quests or interact with the NPC (such as accepting a quest to defeat goblins).  
     - **"merchant":** Interact with the merchant for possible trading or quest-related dialogue.  
     - **"forest":** Venture into the forest, where further commands (e.g., “goblin huts” to engage in combat) can be used to progress through encounters.  
     - **"inventory":** Check your current inventory.
     - **"help":** Displays a short help message about available commands.

4. **Interacting in Specific Areas:**  
   - **City Watch:**  
     When visiting the city watch, you’ll encounter dialogue with an NPC who may offer quests. For example, you might be tasked with defeating goblins in exchange for a reward.
   - **Forest:**  
     In the forest, you can explore the area. Typing commands such as "goblin huts" initiates combat sequences (handled by `Combat.cs`), while other inputs may provide descriptive text about the surroundings.
   - **Merchant and Inventory:**  
     These options allow for additional interactions like trading or reviewing your collected items.

5. **Console Enhancements:**  
   - The game makes use of console color changes (e.g., yellow for the title) and beeps to enhance the text-based experience.
   - Clear instructions and prompts guide you on what input to use, and invalid inputs are handled gracefully by displaying a message and prompting again.
