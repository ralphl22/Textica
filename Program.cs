// mainMenu instance commented out to save time on debugging, and because the MainMenu class is fine as is.

//MainMenu mainMenu = new MainMenu();
Character character = new Character();
TownHub townHub = new TownHub();  

// Serves as the main menu of the game - user can press any key to continue to character creation 

class MainMenu 
{
    public MainMenu()
    {
        Console.Title = "Legend of Textica";

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("LEGEND OF TEXTICA");
        Console.WriteLine();
        Console.Write("PRESS ANY KEY TO CONTINUE");

        Console.ReadKey(true);

        Console.Beep(800, 100);

        Console.ForegroundColor= ConsoleColor.White;

        Console.Clear();
    }
}


// Handles anything important in regards to the user's character, including character creation and stats

class Character
{
   // Declares important fields for the user's character in the game

   private protected string _characterName;
   private protected string _characterClass;
   private protected string _response;
   private protected int _characterLevel;
   private protected int _currentExperiencePoints;
   private protected int _experiencePointsToLevelUp;
   private protected float _healthPoints;
   private protected float _armorPoints;
   private protected float _speedPoints;


    // Allows the user to choose their name and character class

    public void CharacterCreation()
    {
        do
        {
            Console.Write("What is thy name, adventurer? ");

            _characterName = Console.ReadLine();

            Console.Beep(800, 100);

            Console.Write("Are thy sure this is the name thy choseth? (y or n): ");

            _response = Console.ReadLine();

            Console.Beep(800, 100);

            if (_response == "N" || _response == "n")
            {
                continue;
            }

            do
            {
                Console.WriteLine("Choose thy class, adventurer: ");
                Console.WriteLine("1 - Fighter");
                Console.WriteLine("2 - Rogue");
                Console.WriteLine("3 - Grammaturge");

                _response = Console.ReadLine();

                Console.Beep(800, 100);

                if (_response == "1")
                {
                    _healthPoints = 15;
                    _armorPoints = 10;
                    _speedPoints = 3;
                    _characterClass = "Fighter";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Fighter");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The fighter is the most basic of the classes. Armed with sword, shield, and plate armor, it is a balanced class that can take on any foe. Highest constitution of the classes.");
                }
                if (_response == "2")
                {
                    _healthPoints = 10;
                    _armorPoints = 5;
                    _speedPoints = 10;
                    _characterClass = "Rogue";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Rogue");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The rogue uses stealth and tricky to misdirect and evade foes. Weaker in consitution with lesser armor compared to a fighter, but stronger than a mage, and quicker than both.");
                }
                if (_response == "3")
                {
                    _healthPoints = 5;
                    _armorPoints = 3;
                    _speedPoints = 5;
                    _characterClass = "Grammaturge";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Grammaturge");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The grammaturge is a master of grammaturgy: using words as a medium for magick powers. Though weaker and slower than the fighter and rogue, the grammaturge makes up for it with both offensive and defensive healing magicks, assuming you find the right words!");
                }

                Console.Write("Are thy sure this is the class thy choseth? (y or n): ");

                _response = Console.ReadLine();

                Console.Beep(800, 100);

                if (_response == "N" || _response == "n")
                {
                    continue;
                }

                Console.Write($"Welcome to the lands of Textica, ");

                CharacterClassColorCheck();

                Console.Write($"{_characterName} the {_characterClass}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("!");

            } while (_characterClass == null || _characterName == null);

        } while (_characterClass == null || _characterName == null);

    }

    // Handles current character level and EXP gain

    public void CharacterLevelAndExperience()
    {
        // Intial character level

        _characterLevel = 1;

      
        // Intial EXP required to level up

        _experiencePointsToLevelUp = 10;

        // EXP required to level up based on what the user's current EXP is


        switch (_currentExperiencePoints)
        {
            // 10 EXP for level 2, 20 for level 2, 30 for level 3, 40 for level 4, and 40 for level 5


            case 10:
                _characterLevel = 2;
                _experiencePointsToLevelUp = 20;
                break;
            case 20:
                _characterLevel = 3;
                _experiencePointsToLevelUp = 30;
                break;
            case 30:
                _characterLevel = 4;
                _experiencePointsToLevelUp = 40;
                break;
            case 40:
                _characterLevel = 5;
                break;
        }
    }

    // Displays what the character's status is: name, class, HP, AP, and SPD

    private protected void CharacterStatus()
    {
        Console.WriteLine($"{_characterName} the {_characterClass} ");

        Console.ForegroundColor = ConsoleColor.White;

        Console.Write($"Level: {_characterLevel} ");

        Console.Write($"EXP: {_currentExperiencePoints}/{_experiencePointsToLevelUp} ");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {_healthPoints} ");

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write($"AP: {_armorPoints} ");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($"SPD: {_speedPoints}");

        Console.ForegroundColor = ConsoleColor.White;
    }

    // Makes it so the character's name and class in CharacterStatus() changes color based on what class the user chooses in CharacterCreation()

    private protected void CharacterClassColorCheck()
    {
        if (_characterClass == "Fighter")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

        }
        if (_characterClass == "Rogue")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

        }
        if (_characterClass == "Grammaturge")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }    
}

// Allows the user to interact with and take quests from NPCs in the city

class TownHub : Character
{
    public TownHub()
    {
        CharacterCreation();
        CharacterClassColorCheck();
        CharacterLevelAndExperience();
        CharacterStatus();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"Welcome to the city of Textica, {_characterName}! Where do you want to go?");
        Console.WriteLine("1 - Tavern");
        Console.WriteLine("2 - City Watch");
        Console.WriteLine("3 - Mayor's Office");
        Console.WriteLine("4 - Merchant");

        _response = Console.ReadLine();
    }
}