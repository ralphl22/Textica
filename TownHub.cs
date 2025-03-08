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
            character.AutoCharacterCreation();
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