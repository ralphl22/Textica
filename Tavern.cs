// Entry point to get the whole game running
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
