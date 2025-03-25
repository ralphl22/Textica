// Hub area where the player can enter into other areas
public class TownHub
{
    public static bool ForestAccess { get; set; }
    private string Response { get; set; }
    private int MessageCount { get; set; }
    public TownHub()
    {
        Character character = new Character();

        character.IsCharacterCreated = true;

        if (character.IsCharacterCreated == false)
        {
            character.CharacterCreation();
            character.IsCharacterCreated = true;
        }
        if (Character.CharacterName == null && character.IsCharacterCreated == true) 
        {
            character.AutoCharacterCreation();
        }
       
        ForestAccess = true;    

        while (true)
        {
            // Initial access to forest not granted until player accepts a quest in the city watch area
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

                Character.CharacterLevelAndExperience();
                Character.CharacterStatus();

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
                        Inventory.InventoryMenu();
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
                            Inventory.InventoryMenu();
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