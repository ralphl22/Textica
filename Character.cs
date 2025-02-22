// Handles anything important in regards to the user's character and NPCs

// Responsible for managing the player character
public class Character
{
    // Declares important fields for the user's character in the game
    public string CharacterName { get; set; }
    public string CharacterClass { get; set; }
    public float CharacterDamage { get; set; }
    public int CharacterAccurarcy { get; set; }
    public string Response { get; set; }
    public int CharacterLevel { get; set; }
    public int CurrentExperiencePoints { get; set; }
    public int ExperiencePointsToLevelUp { get; set; }
    public float CharacterHealthPoints { get; set; }
    public float CharacterArmorPoints { get; set; }
    public float CharacterSpeedPoints { get; set; }
    public int GoldAmount { get; set; }
    public bool IsCharacterCreated { get; set; }


    // Allows the user to choose their name and character class

    public void CharacterCreation()
    {
        do
        {
            Console.Write("What is thy name, adventurer? ");

            CharacterName = Console.ReadLine();

            Console.Beep(800, 100);

            Console.Write("Are thy sure this is the name thy choseth? (y or n): ");

            Response = Console.ReadLine();

            Console.Beep(800, 100);

            if (Response == "N" || Response == "n")
            {
                continue;
            }

            do
            {
                Console.WriteLine("Choose thy class, adventurer: ");
                Console.WriteLine("1 - Fighter");
                Console.WriteLine("2 - Rogue");
                Console.WriteLine("3 - Grammaturge");

                Response = Console.ReadLine();

                Console.Beep(800, 100);

                if (Response == "1")
                {
                    CharacterHealthPoints = 15;
                    CharacterArmorPoints = 10;
                    CharacterSpeedPoints = 3;
                    CharacterClass = "Fighter";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Fighter");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {CharacterHealthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {CharacterArmorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {CharacterSpeedPoints}");

                    Console.ResetColor();

                    Thread.Sleep(2000);

                    Console.WriteLine("The fighter is the most basic of the classes. Armed with sword, shield, and plate armor, it is a balanced class that can take on any foe. Highest constitution of the classes.");
                }
                if (Response == "2")
                {
                    CharacterHealthPoints = 10;
                    CharacterArmorPoints = 5;
                    CharacterSpeedPoints = 10;
                    CharacterClass = "Rogue";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Rogue");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {CharacterHealthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {CharacterArmorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {CharacterSpeedPoints}");

                    Console.ResetColor();

                    Thread.Sleep(2000);

                    Console.WriteLine("The rogue uses stealth and tricky to misdirect and evade foes. Weaker in consitution with lesser armor compared to a fighter, but stronger than a mage, and quicker than both.");
                }
                if (Response == "3")
                {
                    CharacterHealthPoints = 5;
                    CharacterArmorPoints = 3;
                    CharacterSpeedPoints = 5;  
                    CharacterClass = "Grammaturge";

                    CharacterClassColorCheck();

                    Console.WriteLine("The Grammaturge");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {CharacterHealthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {CharacterArmorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {CharacterSpeedPoints}");

                    Console.ResetColor();

                    Thread.Sleep(2000);

                    Console.WriteLine("The grammaturge is a master of grammaturgy: using words as a medium for magick powers. Though weaker and slower than the fighter and rogue, the grammaturge makes up for it with both offensive and defensive healing magicks, assuming you find the right words!");
                }

                Console.Write("Are thy sure this is the class thy choseth? (y or n): ");

                Response = Console.ReadLine();

                Console.Beep(800, 100);

                if (Response == "N" || Response == "n")
                {
                    continue;
                }

                Console.Clear();

                Console.Write($"Welcome to the lands of Textica, ");

                CharacterClassColorCheck();

                Console.Write($"{CharacterName} the {CharacterClass}");

                Console.ResetColor();

                Console.WriteLine("!");

                Thread.Sleep(2000);

            } while (CharacterClass == "1" || CharacterName == "1");

        } while (CharacterClass == "1" || CharacterName == "1");

    }
    // Handles current character level and EXP gain
    public void CharacterLevelAndExperience()
    {
        // Intial character level

        CharacterLevel = 1;


        // Intial EXP required to level up

        ExperiencePointsToLevelUp = 10;

        // EXP required to level up based on what the user's current EXP is


        switch (CurrentExperiencePoints)
        {
            // 10 EXP for level 2, 20 for level 2, 30 for level 3, 40 for level 4, and 40 for level 5


            case 10:
                CharacterLevel = 2;
                ExperiencePointsToLevelUp = 20;
                break;
            case 20:
                CharacterLevel = 3;
                ExperiencePointsToLevelUp = 30;
                break;
            case 30:
                CharacterLevel = 4;
                ExperiencePointsToLevelUp = 40;
                break;
            case 40:
                CharacterLevel = 5;
                break;
        }
    }
    // Displays what the character's status is: name, class, HP, AP, and SPD
    public void CharacterStatus()
    {
        Console.WriteLine($"{CharacterName} the {CharacterClass} ");

        Console.ResetColor();

        Console.Write($"Level: {CharacterLevel} ");

        Console.Write($"EXP: {CurrentExperiencePoints}/{ExperiencePointsToLevelUp} ");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {CharacterHealthPoints} ");

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write($"AP: {CharacterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write($"SPD: {CharacterSpeedPoints}");

        Console.ResetColor();

        Console.WriteLine($" Gold: {GoldAmount} G");

    }

    // Makes it so the character's name and class in CharacterStatus() changes color based on what class the user chooses in CharacterCreation()
    public void CharacterClassColorCheck()
    {
        if (CharacterClass == "Fighter")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

        }
        if (CharacterClass == "Rogue")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

        }
        if (CharacterClass == "Grammaturge")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
// Responsible for hostile NPC monsters
public class Monster
{
    public string MonsterClass { get; set; }

    public float MonsterHealthPoints { get; set; }

    public float MonsterArmorPoints { get; set; }

    public float MonsterSpeedPoints { get; set; }

    public float MonsterDamage { get; set; }

    public int MonsterAccurarcy { get; set; }

    public Monster(string monsterClass, float monsterHealthPoints, float monsterArmorPoints, float monsterSpeedPoints)
    {
        MonsterClass = monsterClass;

        MonsterHealthPoints = monsterHealthPoints;

        MonsterArmorPoints = monsterArmorPoints;

        MonsterSpeedPoints = monsterSpeedPoints;
    }

    public void MonsterStatus()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"{MonsterClass}");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {MonsterHealthPoints} ");

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write($"AP: {MonsterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($"SPD: {MonsterSpeedPoints} ");

        Console.ResetColor();
    }
}
public class GoblinFighter : Monster
{
    public GoblinFighter() : base("Goblin Fighter", 10, 0, 0)
    {

    }

}
public class GoblinArcher : Monster
{
    public GoblinArcher() : base("GoblinArcher", 5, 0, 3)
    {

    }
}