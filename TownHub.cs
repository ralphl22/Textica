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
