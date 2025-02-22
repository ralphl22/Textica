// Allows the user to interact with and take quests from NPCs in the city
public class TownHub
{
    public static bool ForestAccess { get; set; }

    public TownHub()
    {
        Character character = new Character();

        character.IsCharacterCreated = true;

        if (character.IsCharacterCreated == false)
        {
            character.CharacterCreation();
        }

        // Fields are already initialized for testing purposes

        character.CharacterName = "Testman";  character.CharacterClass = "Fighter"; character.CharacterHealthPoints = 15; character.CharacterArmorPoints = 10; character.CharacterSpeedPoints = 5; ForestAccess = true;

        // Intial access to forest not granted until player accepts a quest in the city watch area

        if (ForestAccess == true)
        {
            /*
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("New area unlocked!");

            Console.ResetColor();

            Thread.Sleep(2000);

            Console.Clear();*/

            character.CharacterClassColorCheck();
            character.CharacterLevelAndExperience();
            character.CharacterStatus();

            Console.ResetColor();

            Console.WriteLine($"Welcome to the city of Textica, {character.CharacterName}! Where do you want to go?");
            Console.WriteLine("1 - Tavern");
            Console.WriteLine("2 - City Watch");
            Console.WriteLine("3 - Mayor's Office (Not available)");
            Console.WriteLine("4 - Merchant (Not available)");
            Console.WriteLine("5 - King's Castle (Not available)");
            Console.WriteLine("6 -  Forest");

            character.Response = "6";
            Console.Beep(800, 100);

            switch (character.Response)
            {
                case "1":
                    Console.Clear();
                    new Tavern();
                    break;
                case "2":
                    Console.Clear();
                    new CityWatch();
                    break;
                case "3":
                    Console.Clear();
                    new MayorOffice();
                    break;
                case "4":
                    Console.Clear();
                    new Merchant();
                    break;
                case "5":
                    Console.Clear();
                    new KingCastle();
                    break;
                case "6":
                    Console.Clear();
                    new Forest();
                    break;
                default:
                    Console.WriteLine("Input does not appear to be working!");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"Welcome to the city of Textica, {character.CharacterName}! Where do you want to go?");
            Console.WriteLine("1 - Tavern");
            Console.WriteLine("2 - City Watch");
            Console.WriteLine("3 - Mayor's Office (Not available)");
            Console.WriteLine("4 - Merchant (Not available)");
            Console.WriteLine("5 - King's Castle (Not available)");

            character.Response = Console.ReadLine();
            Console.Beep(800, 100);

            switch (character.Response)
            {
                case "1":
                    Console.Clear();
                    new Tavern();
                    break;
                case "2":
                    Console.Clear();
                    new CityWatch();
                    break;
                case "3":
                    new MayorOffice();
                    break;
                case "4":
                    new Merchant();
                    break;
                case "5":
                    new KingCastle();
                    break;
                default:
                    Console.WriteLine("Input does not appear to be working!");
                    break;
            }
        }
    }
}
public class Tavern
{
    private protected string _response;
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

            _response = Console.ReadLine();
            Console.Beep(800, 100);

            if (_response == "1")
            {
                Console.WriteLine("Tavernkeeper: Information, eh? Word is that a bunch of monsters have been terroizing travelers in the forest outside town. The city watch is looking for anyone interested in dealing with 'em. Anything else?");
            }
            if (_response == "2")
            {
                Console.WriteLine("Tavernkeeper: No, I've got nothing for you.");
            }
            if (_response == "3")
            {
                Console.WriteLine("Tavernkeeper: No, I've got nothing for you.");
            }
            if (_response == "4")
            {
                Console.Clear();
                new TownHub();
            }
        }
    }
}
public class CityWatch
{
    private protected string _response;

    public CityWatch()
    {
        Console.WriteLine("You enter the city watch building and see a watchman in leather armor and armed with a sword on his hip. He turns to look at you.");
        Thread.Sleep(2000);
        Console.WriteLine("Watchman: You don't seem to be from around here. What do you want?");
        Thread.Sleep(2000); 

        Console.WriteLine("1 - Do you have any quests for me?");
        Console.WriteLine("2 - I'll be leaving.");

        _response = Console.ReadLine();
        Console.Beep(800, 100);

        if (_response == "1")
        {
            Console.WriteLine("Watchman: We do in fact have something for you.");
            Thread.Sleep(2000);
            Console.WriteLine("Watchman: There have been reports of goblins in the forest outside town attacking travelers. The city watch is understaffed, so we're looking for anyone who's willing to help.");
            Thread.Sleep(2000);
            Console.WriteLine("Watchman: Is that something you'd be interested in? We're offering 500 G if you manage to kill five goblins and give me their heads.");

            Console.WriteLine("1 - I'm interested.");
            Console.WriteLine("2 - No thanks.");

            _response = Console.ReadLine();
            Console.Beep(800, 100);

            if (_response == "1")
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
        if (_response == "2") Console.Clear(); new TownHub();
    }
}
class Forest
{
    public string _response; 

   public Forest()
   {
        Console.WriteLine("You see yourself before a dense forest teeming with life. Where do you want to go?");

        Console.WriteLine("1 - Goblin Tribe Huts");
        Console.WriteLine("2 - I'll be leaving.");

        _response = Console.ReadLine();

        if (_response == "1")
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
public class Merchant
{

}
public class KingCastle
{

}
