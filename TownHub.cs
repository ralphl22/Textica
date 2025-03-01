// Allows the user to interact with and take quests from NPCs in the city
public class TownHub
{
    public static bool ForestAccess { get; set; }
    private string Response { get; set; }
    private int MessageCount { get; set; }
    public TownHub()
    {
        Character character = new Character();

        Character.IsCharacterCreated = true;

        List<Inventory> inventory = new List<Inventory>() { new Sword(), new LeatherArmor() };

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
                if (MessageCount == 0)
                {
                    Console.Beep(800, 100);

                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("New area unlocked!");

                    Console.ResetColor();

                    Thread.Sleep(2000);

                    Console.Clear();

                    MessageCount++;
                }

                character.CharacterLevelAndExperience();
                character.CharacterStatus();

                Console.WriteLine($"Welcome to the city of Textica, {Character.CharacterName}! What do you want to do, or where do you want to go?");

                Response = Console.ReadLine();
                Console.Beep(800, 100);

                switch (Response)
                {
                    case "tavern":
                        Console.Clear();
                        new Tavern();
                        break;
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
                    case "king castle":
                        Console.Clear();
                        new KingCastle();
                        break;
                    case "forest":
                        Console.Clear();
                        new Forest();
                        break;
                    case "inventory":
                        Console.WriteLine($"Inventory ({inventory.Count} Items):");

                        foreach (Item inventoryItem in inventory)
                        {
                            Console.WriteLine($"{inventoryItem}");
                        }
                        Console.ReadKey(true);
                        Console.Clear();
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
                    character.CharacterLevelAndExperience();
                    character.CharacterStatus();

                    Console.WriteLine($"Welcome to the city of Textica, {Character.CharacterName}! What do you want to do, or where do you want to go?");

                    Response = Console.ReadLine();
                    Console.Beep(800, 100);

                    switch (Response)
                    {
                        case "tavern":
                            Console.Clear();
                            new Tavern();
                            break;
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
                        case "king castle":
                            Console.Clear();
                            new KingCastle();
                            break;
                        case "forest":
                            Console.Clear();
                            new Forest();
                            break;
                        case "inventory":
                            Console.WriteLine($"Inventory ({inventory.Count} Items):");

                            foreach (Item inventoryItem in inventory)
                            {
                                Console.WriteLine($"{inventoryItem}");
                            }
                            Console.ReadKey(true);
                            Console.Clear();
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
public class Tavern
{
    private protected string Response { get; set; }
    public Tavern()
    {
        Console.WriteLine("You enter the tavern. You see people of all different races and cultures scattered about.");
        Thread.Sleep(2000);
        Console.WriteLine("You approach the tavernkeeper, and he eyes you curiously.");
        Thread.Sleep(2000);
        Console.WriteLine("Tavernkeeper: Greetings, adventurer. Welcome to my humble tavern. What brings you here?");
        Thread.Sleep(2000);

        while (true)
        {
            Console.WriteLine("1 - I'm here looking for information.");
            Console.WriteLine("2 - Got anything for me to drink?");
            Console.WriteLine("3 - Any quests for me to partake in?");
            Console.WriteLine("4 - I'll be leaving.");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "1")
            {
                Console.WriteLine("Tavernkeeper: Information, eh? Word is that a bunch of monsters have been terroizing travelers in the forest outside town. The city watch is looking for anyone interested in dealing with 'em. Anything else?");
            }
            if (Response == "2")
            {
                Console.WriteLine("Tavernkeeper: No, I've got nothing for you.");
            }
            if (Response == "3")
            {
                Console.WriteLine("Tavernkeeper: No, I've got nothing for you.");
            }
            if (Response == "4")
            {
                Console.Clear();
                new TownHub();
            }
        }
    }
}
public class CityWatch
{
    private string Response { get; set; }

    public CityWatch()
    {
        Console.WriteLine("You enter the city watch building and see a watchman in leather armor and armed with a sword on his hip. He turns to look at you.");
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
    public Merchant()
    {

    }
}
public class Forest
{
   private string Response { get; set; }
   public Forest()
   {
        Character character = new Character();

        character.CharacterLevelAndExperience();

        Console.WriteLine("--------------------------------------------------");

        character.CharacterClassColorCheck();
        character.CharacterStatus();

        Console.WriteLine("--------------------------------------------------");


        Console.WriteLine("You see yourself before a dense forest teeming with life. Where do you want to go?");

        Console.WriteLine("1 - Goblin Tribe Huts");

        Console.WriteLine("2 - I'll be leaving.");

        Response = Console.ReadLine();
        //Response = "1";
        Console.Beep(800, 100);

        if (Response == "1")
        {
            Console.Clear();
            new Combat();

        }
        else new TownHub();
   }
}
public class MayorOffice
{

}
public class KingCastle
{

}