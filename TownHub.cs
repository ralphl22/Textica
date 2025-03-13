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

        if (Character.IsCharacterCreated == false)
        {
            character.CharacterCreation();
            Character.IsCharacterCreated = true;
        }
        else while (Character.CharacterName == null)
        {
            character.AutoCharacterCreation();
            Character.IsCharacterCreated = true;
        }

       // ForestAccess = true;

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

                Console.WriteLine("----------------------------------------------");

                Character.CharacterLevelAndExperience();
                Character.CharacterStatus();

                Console.WriteLine("----------------------------------------------");

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
                    Console.WriteLine("----------------------------------------------");

                    Character.CharacterLevelAndExperience();
                    Character.CharacterStatus();

                    Console.WriteLine("----------------------------------------------");

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
    public static bool IsGoblinQuestAccepted { get; set; }
    public static bool IsGoblinQuestCompleted { get; set; }
    public CityWatch()
    {
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount == 0 || GoblinHead.Amount > 0 && GoblinHead.Amount < 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Watchman Karl: Welcome back, adventurer. I see that you have {GoblinHead.Amount} goblin heads.");

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.WriteLine("Watchman Karl: That's not enough for the reward. Come back when you have at least 5 goblin heads.");

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.Clear();

            new TownHub();
        }
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount == 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Watchman Karl: Welcome back, adventurer. I see that you have 5 goblin heads.");

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.WriteLine("Watchman Karl: Here is your 250 G reward. Keep up the good work.");

            Character.GoldAmount = Character.GoldAmount + 250;

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.Clear();

            new TownHub();
        }
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount > 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Character.GoldAmount = Character.GoldAmount + GoblinHead.Amount * 50;

            Console.WriteLine($"Watchman Karl: Welcome back, adventurer. I see that you have {GoblinHead.Amount} goblin heads, which is more than I asked for. Adding up the 50 goblin bonus per head, you have {Character.GoldAmount} G as your reward.");

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            new TownHub();
        }
        Console.WriteLine("----------------------------------------------");

        Character.CharacterLevelAndExperience();
        Character.CharacterStatus();

        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("You see a watchman in chainmail, armed with a sword on his hip. He turns to look at you.");

        Console.ReadKey(true);

        while (true)
        {
            Console.WriteLine("Watchman Karl: You don't seem to be from around here. What do you want?");
            
            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "quest")
            {
                Console.WriteLine("Watchman Karl: We do in fact have something for you.");
                Console.ReadKey(true);
                Console.Beep(800, 100);
                Console.WriteLine("Watchman karl: There have been reports of goblins in the forest outside town attacking travelers. We're looking for anyone who's willing to help.");
                Console.ReadKey(true);
                Console.Beep(800, 100);

                while (true)
                {
                    Console.WriteLine("Watchman Karl: Is that something you'd be interested in? We're offering 250 G if you manage to get five goblin heads.");

                    Response = Console.ReadLine();
                    Console.Beep(800, 100);

                    if (Response == "yes")
                    {
                        Console.WriteLine("Watchman Karl: Glad to have you around. Get back to me with those golbin heads when you can.");

                        Console.ReadKey(true);
                        Console.Beep(800, 100);

                        Console.Clear();

                        IsGoblinQuestAccepted = true;

                        TownHub.ForestAccess = true;

                        new TownHub();

                    }
                    if (Response == "no")
                    {
                        Console.WriteLine("That's too bad. I'll see ya around, I guess.");

                        Console.ReadKey(true);
                        Console.Beep(800, 100);

                        Console.Clear();

                        new TownHub();
                    }
                }
            }
            if (Response == "leave")
            {
                Console.Clear();

                new TownHub();
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

        while (true) 
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("You see yourself before a lush, dense forest. Where do you want to go, or what do you want to do?");

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
                Console.Beep(800, 100);
                Console.Clear();
                continue;
            }
            if (Response == "inventory")
            {
                Inventory.InventoryCheck();
                continue;
            }
            if (Response == "leave")
            {
                Console.Clear(); 
                
                new TownHub(); 
            }

            Console.Clear();
        }
   }
}