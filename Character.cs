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
        GoldAmount = 0;

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

            Console.Clear();

            Console.Write($"Welcome to the lands of Textica, ");

            Console.Write($"{CharacterName} the {CharacterClass}");

            Console.ResetColor();

            Console.WriteLine("!");

            Thread.Sleep(2000);

        } while (CharacterName == null);
    }
    // Automatically creates a character for testing purposes
    public void AutoCharacterCreation()
    {
        if (CharacterName == null)
        {
            CharacterName = "John Smith";
            CharacterHealthPoints = 10;
            GoldAmount = 0;
            CharacterSpeedPoints = 3;
        }
    }
    // Handles current character level and EXP gain
    public static void CharacterLevelAndExperience()
    {
        // Initial character level
        CharacterLevel = 1;

        // Intial EXP required to level up

        ExperiencePointsToLevelUp = 25;

        // EXP required to level up based on what the user's current EXP is

        switch (CurrentExperiencePoints)
        {
            // 10 EXP for level 2, 20 for level 2, 30 for level 3, 40 for level 4, and 40 for level 5

            case 25:
                CharacterLevel = 2;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 45;
                break;
            case 20:
                CharacterLevel = 3;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 30;
                break;
            case 30:
                CharacterLevel = 4;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to {CharacterLevel}!");
                ExperiencePointsToLevelUp = 40;
                break;
            case 40:
                CurrentExperiencePoints = 0;
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
public class Inventory
{
    public static List<Inventory> InventoryList = new List<Inventory>() { new Sword(), new HealthPotion(), new LeatherArmor()};
    public static void InventoryCheck()
    {
        string response;

        while (true)
        {
            if (Combat.IsInCombat == true)
            {
                Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

                foreach (Item inventoryItem in InventoryList)
                {
                    if (inventoryItem != new LeatherArmor() && inventoryItem != new ChainmailArmor() && inventoryItem != new Sword() && inventoryItem != new Bow())
                    {
                        Console.WriteLine($"{inventoryItem}");
                    }
                }

                Console.WriteLine("Type the name of the item for more information, or type exit to exit the inventory.");

                response = Console.ReadLine();

                if (response == "exit")
                {
                    break;
                }
                if (response == "healthpotion" || response == "HealthPotion")
                {
                    Console.WriteLine("A red health potion. Heals 5 HP.");

                    Console.ReadKey(true);

                    Console.WriteLine("Do you want to use the health potion?");

                    response = Console.ReadLine();

                    if (response == "yes")
                    {
                        Console.WriteLine("Health potion used! You restore 5 HP!");
                        Character.CharacterHealthPoints = Character.CharacterHealthPoints + 5;
                    }
                    if (response == "no")
                    {
                        continue;
                    }
                    Console.ReadKey(true);
                }
            }
            Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

            foreach (Item inventoryItem in InventoryList)
            {
                Console.WriteLine($"{inventoryItem}");
            }
     
            Console.WriteLine("Type the name of the item for more information, or type exit to exit the inventory.");
    
            response = Console.ReadLine();
            Console.Beep(800, 100);

            if (response == "exit")
            {
                break;
            }
            if (response == "sword" || response == "Sword")
            {
                Weapon sword = new Sword();

                Console.WriteLine($"A common sword. Deals {sword.WeaponDamage} DMG.");
            }
            if (response == "leatherarmor" || response == "LeatherArmor")
            {
                Armor leatherArmor = new LeatherArmor();
                Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");
            }
            if (response == "healthpotion" || response == "HealthPotion")
            {
                Console.WriteLine("A red health potion. Heals 5 HP.");
            }
            Console.ReadKey(true);
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
    public GoblinFighter() : base("Goblin Fighter", 10, 0, 1)
    {

    }
}
public class GoblinArcher : Monster
{
    public GoblinArcher() : base("Goblin Archer", 5, 0, 5)
    {

    }
}