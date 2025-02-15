// Allows the user to interact with and take quests from NPCs in the city
public class TownHub : Character
{
    public TownHub()
    {
        // CharacterCreation();

        // Fields are already initialized for testing purposes

        _characterName = "Testman"; _characterClass = "Fighter"; _healthPoints = 15; _armorPoints = 10; _speedPoints = 5;

        CharacterClassColorCheck();
        CharacterLevelAndExperience();
        CharacterStatus();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"Welcome to the city of Textica, {_characterName}! Where do you want to go?");
        Console.WriteLine("1 - Tavern");
        Console.WriteLine("2 - City Watch");
        Console.WriteLine("3 - Mayor's Office");
        Console.WriteLine("4 - Merchant");
        Console.WriteLine("5 - King's Castle");

        _response = Console.ReadLine();

        switch (_response)
        {
            case "1":
                new Tavern();
                break;
            case "2":
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

public class Tavern
{
    string _response;

    public Tavern()
    {
        Console.WriteLine("You enter the tavern. You see people of all different races and cultures scattered about, playing games, talking to each other, and dancing.");
        Console.WriteLine("You approach the tavernkeeper, and he eyes you curiously.");

        Console.WriteLine("Tavekeeper: Greetings, adventurer. Welcome to my humble tavern. What brings you here?");

        while (true)
        {

            Console.WriteLine("1 - I'm here looking for information.");
            Console.WriteLine("2 - Got anything for me to drink?");
            Console.WriteLine("3 - Any quests for me to partake in?");
            Console.WriteLine("4 - I'll be leaving.");

            _response = Console.ReadLine();

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

class CityWatch
{

}
class MayorOffice
{

}
class Merchant
{

}
class KingCastle
{

}
