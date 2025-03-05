// Allows the user to interact with and take quests from NPCs in the city
public class TownHub
{
    public static bool ForestAccess { get; set; }
    private string Response { get; set; }
    private int MessageCount { get; set; }
    public static bool VisitedArea { get; set; }
    public TownHub()
    {
       Character character = new Character();

        Character.IsCharacterCreated = true;

        if (Character.IsCharacterCreated == false)
        {
            character.CharacterCreation();
        }
        else while (Character.CharacterName == null)
        {
            Character.CharacterClass = "Fighter"; character.AutoCharacterCreation();
        }

        ForestAccess = true;

        // Initial access to forest not granted until player accepts a quest in the city watch area
        while (true)
        {
            if (ForestAccess == true)
            {
                /*
                if (MessageCount == 0)
                {
                    Console.Beep(800, 100);

                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("New area unlocked!");

                    Console.ResetColor();

                    Thread.Sleep(2000);

                    Console.Clear();

                    MessageCount++;
                }*/

                Character.CharacterLevelAndExperience();

                Console.WriteLine("--------------------------------------------------");

                Character.CharacterStatus();

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine($"Welcome to the city of Textica, {Character.CharacterName}! What do you want to do, or where do you want to go?");

                Response = Console.ReadLine();
                Console.Beep(800, 100);

                switch (Response)
                {
                    case "city watch":
                    case "watch":
                        Console.Clear();
                        new CityWatch();
                        break;
                    case "mayor office":
                    case "mayor":
                        Console.Clear();
                        new MayorOffice();
                        break;
                    case "merchant":
                        Console.Clear();
                        new Merchant();
                        break;
                    case "forest":
                        Console.Clear();
                        new Forest();
                        break;
                    case "inventory":
                        Inventory.InventoryCheck();
                        break;
                    case "help":
                        Console.WriteLine("If you want to go somewhere or do something, type that in lowercase and nothing else. Consider the tavern, merchant, city watch, or your inventory.");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("That doesn't seem to work!");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
            else
            {
                while (true)
                {
                    Character.CharacterLevelAndExperience();

                    Console.WriteLine("--------------------------------------------------");

                    Character.CharacterStatus();

                    Console.WriteLine("--------------------------------------------------");

                    Console.WriteLine($"Welcome to the city of Textica, {Character.CharacterName}! What do you want to do, or where do you want to go?");

                    Response = Console.ReadLine();
                    Console.Beep(800, 100);

                    switch (Response)
                    {
                        case "city watch":
                        case "watch":
                            Console.Clear();
                            new CityWatch();
                            break;
                        case "mayor office":
                        case "mayor":
                            Console.Clear();
                            new MayorOffice();
                            break;
                        case "merchant":
                            Console.Clear();
                            new Merchant();
                            break;
                        case "forest":
                            Console.Clear();
                            new Forest();
                            break;
                        case "inventory":
                            Inventory.InventoryCheck();
                            break;
                        case "help":
                            Console.WriteLine("If you want to go somewhere or do something, type that in lowercase and nothing else. Consider the tavern, merchant, city watch, or your inventory.");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("That doesn't seem to work!");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
public class CityWatch
{
    private string Response { get; set; }
    public CityWatch()
    {
        Character.CharacterLevelAndExperience();
        Character.CharacterStatus();

        Console.WriteLine("You enter the city watch building and see a watchman in chainmail, armed with a sword on his hip. He turns to look at you.");

        Thread.Sleep(2000);

        Console.WriteLine("Watchman: You don't seem to be from around here. What do you want?");

        Thread.Sleep(2000); 

        Console.WriteLine("1 - Do you have any quests for me?");
        Console.WriteLine("2 - I'll be leaving.");

        Response = Console.ReadLine();
        Console.Beep(800, 100);

        if (Response == "1")
        {
            Console.WriteLine("Watchman: We do in fact have something for you.");
            Thread.Sleep(2000);
            Console.WriteLine("Watchman: There have been reports of goblins in the forest outside town attacking travelers. The city watch is understaffed, so we're looking for anyone who's willing to help.");
            Thread.Sleep(2000);
            Console.WriteLine("Watchman: Is that something you'd be interested in? We're offering 500 G if you manage to kill five goblins and give me their heads.");

            Console.WriteLine("1 - I'm interested.");
            Console.WriteLine("2 - No thanks.");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "1")
            {
                Console.WriteLine("Glad to have ye around. Get back to me with those golbin heads when you can.");

                Thread.Sleep(2000);

                Console.WriteLine("Press any key to continue.");

                Console.ReadKey(true);

                Thread.Sleep(2000);

                Console.Clear();

                TownHub.ForestAccess = true;
                
                new TownHub();

            }
            else Console.WriteLine("That's too bad. I'll see ya around, I guess."); Thread.Sleep(2000); Console.Clear(); new TownHub();
        }
        if (Response == "2") Console.Clear(); new TownHub();
    }
}
public class Merchant
{
    private string Response { get; set; }
    public Merchant()
    {
        while (true)
        {
            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("Merchant: Greetings, adventurer! Looking to buy some of my wares?");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "yes")
            {
                while (true)
                {
                    Console.WriteLine($"Here are my wares:");

                    Console.WriteLine("Bow - 10 G");
                    Console.WriteLine("HealthPotion - 15 G");
                    Console.WriteLine("LeatherArmor - 25 G");
                    Console.WriteLine("ChainmailArmor - 30 G");
                    Console.WriteLine("Type an item's name for more information.");

                    Response = Console.ReadLine();

                    if (Response == "bow" || Response == "Bow")
                    {
                        Weapon bow = new Bow();

                        Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        if (Response == "yes" && Character.GoldAmount >= 10)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new Bow());
                            Character.GoldAmount = Character.GoldAmount - 10;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "yes" && Character.GoldAmount < 10)
                        {
                            Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "leatherarmor" || Response == "LeatherArmor")
                    {
                        Armor leatherArmor = new LeatherArmor();

                        Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        foreach (Inventory inventoryItem in Inventory.InventoryList)
                        {
                            if (Response == "yes" && Character.GoldAmount >= 25 && inventoryItem != new LeatherArmor())
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(new LeatherArmor());
                                Character.GoldAmount = Character.GoldAmount - 25;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount >= 25 && inventoryItem == new LeatherArmor())
                            {
                                Console.WriteLine("You already have leather armor!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 25)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            break;
                        }
                        if (Response == "no") continue;
                        break;
                    }
                    if (Response == "healthpotion" || Response == "HealthPotion")
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        if (Response == "yes" && Character.GoldAmount >= 15)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new HealthPotion());
                            Character.GoldAmount = Character.GoldAmount - 15;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "yes" && Character.GoldAmount < 15)
                        {
                            Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "ChainmailArmor" || Response == "chainmailarmor")
                    {
                        Armor chainmailArmor = new ChainmailArmor();

                        Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();
                        if (Response == "yes" && Character.GoldAmount >= 30)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new ChainmailArmor());
                            Character.GoldAmount = Character.GoldAmount - 30;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "yes" && Character.GoldAmount < 30)
                        {
                            Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                }
            }
            if (Response == "no")
            {
                Console.WriteLine("Come back if you ever want to buy anything!"); Console.ReadKey(true); Console.Clear(); new TownHub();
            }
        }
    }
}
public class Forest
{
   private string Response { get; set; }
   public Forest()
   {
        Character character = new Character();

        while (true) {

            Character.CharacterLevelAndExperience();

            Console.WriteLine("--------------------------------------------------");

            Character.CharacterStatus();

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("You see yourself before a dense forest teeming with life. Where do you want to go, or what do you want to do?");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "goblin huts" || Response == "huts")
            {
                Console.Clear();
                new Combat();

            }
            if (Response == "look" || Response == "look around")
            {
                Console.WriteLine("You see what appear to be goblin huts far off in the distance. This is where the goblins have likely set up camp.");
                Console.ReadKey(true);
                Console.Clear();
                continue;
            }
            if (Response == "inventory")
            {
                Inventory.InventoryCheck();
                continue;
            }
            else Console.Clear(); new TownHub();
        }
   }
}
public class MayorOffice
{

}