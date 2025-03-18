// Handles anything important in regards to the user's character and NPCs

// Responsible for managing the player character
public class Character
{
    // Declares important properties for the user's character in the game
    public static string CharacterName { get; set; }
    public static string CharacterClass { get; set; }
    public float CharacterDamage { get; set; }
    public int CharacterAccurarcy { get; set; }
    private string Response { get; set; }
    public static int CharacterLevel { get; set; }
    public static int CurrentExperiencePoints { get; set; }
    public static int ExperiencePointsToLevelUp { get; set; }
    public static float CharacterHealthPoints { get; set; }
    public static float CharacterArmorPoints { get; set; }
    public static float CharacterSpeedPoints { get; set; }
    public static int GoldAmount { get; set; }
    public static bool IsCharacterCreated { get; set; }

    // Allows the user to choose their name and character class
    public void  CharacterCreation()
    {
        while (true) 
        {
            Console.Write("What is thy name, adventurer? ");

            CharacterName = Console.ReadLine();

            Console.Beep(800, 100);

            Console.Write("Are thy sure this is the name thy choseth? (y or n): ");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "y" && CharacterName != "" && CharacterName != null || Response == "Y" && CharacterName != "" && CharacterName != null)
            {
                Console.Write($"Welcome to the lands of Textica, {CharacterName}!");

                GoldAmount = 50;

                Inventory inventory = new Inventory();

                Console.ReadKey(true);

                Console.Clear();

                break;
            }
            else
            {
                Console.Clear();
                continue;
            }
        }
    }
    // Automatically creates a character for testing purposes
    public void AutoCharacterCreation()
    {
        if (CharacterName == null)
        {
            CharacterName = "John Smith";
            CharacterHealthPoints = 10;
            GoldAmount = 50;
            CharacterSpeedPoints = 3;

            Inventory inventory = new Inventory();
        }
    }
    // Handles current character level and EXP gain
    public static void CharacterLevelAndExperience()
    {
        if (CharacterLevel == 5)
        {
            CurrentExperiencePoints = 0;
            ExperiencePointsToLevelUp = 0;
        }

        // Initial character level
        if (CharacterLevel == 0) CharacterLevel = 1;

        // Intial EXP required to level up
        if (ExperiencePointsToLevelUp == 0) ExperiencePointsToLevelUp = 100;

        // EXP required to level up based on what the user's current EXP is: current EXP is the default value of 0 intially 
        switch (CurrentExperiencePoints)
        {
            // 100 EXP for level 2, 200 for level 2, 300 for level 3, 400 for level 4, and 400 for level 5

            case 100:
                CharacterLevel = 2;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 200;
                break;
            case 200:
                CharacterLevel = 3;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 300;
                break;
            case 300:
                CharacterLevel = 4;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 400;
                break;
            case 400:
                CurrentExperiencePoints = 0;
                ExperiencePointsToLevelUp = 0;
                CharacterLevel = 5;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                break;
        }
    }
    // Displays what the character's status is: name, class, HP, AP, and SPD
    public static void CharacterStatus()
    {
        Console.WriteLine($"{CharacterName}");

        Console.ResetColor();

        Console.Write($"Lvl {CharacterLevel} ");

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.Write($"EXP: {CurrentExperiencePoints}/{ExperiencePointsToLevelUp} ");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {CharacterHealthPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write($"AP: {CharacterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Write($"SPD: {CharacterSpeedPoints}");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($" {GoldAmount} G");

        Console.ResetColor();
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
    public float MonsterAccurarcy { get; set; }
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

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write($"AP: {MonsterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine($"SPD: {MonsterSpeedPoints} ");

        Console.ResetColor();
    }
}
public class DefaultMonster : Monster
{
    public DefaultMonster(): base("Default Monster", 0, 0, 0)
    {

    }
}
public class GoblinFighter : Monster
{
    public GoblinFighter() : base("Goblin Fighter", 10, 0, 3)
    {

    }
}
public class GoblinArcher : Monster
{
    public GoblinArcher() : base("Goblin Archer", 5, 0, 4)
    {

    }
}