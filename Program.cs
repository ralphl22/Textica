﻿//IntroText introText = new ();
Character character = new ();
TownHub townHub = new ();
            
class IntroText 
{
    public IntroText()
    {
        Console.Title = "Legend of Textica";

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("LEGEND OF TEXTICA");
        Console.WriteLine();
        Console.Write("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey(true);
        Console.Beep(800, 100);
        Console.ForegroundColor= ConsoleColor.White;
        Console.Clear();
    }
}

class Character
{
   private protected string _characterName;
   private protected string _characterClass;
   private protected string _response;
   private protected float _healthPoints;
   private protected float _armorPoints;
   private protected float _speedPoints;
    private protected void CharacterStatus()
    {
        if (_characterClass == "Fighter")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

        }
        if (_characterClass == "Rogue")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

        }
        if (_characterClass == "Grammaturge")
        {
            Console.ForegroundColor = ConsoleColor.Blue;

        }
        Console.WriteLine($"{_characterName} the {_characterClass}");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {_healthPoints}/{_healthPoints} ");

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write($"AP: {_armorPoints}/{_armorPoints} ");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($"SPD: {_speedPoints}");

        Console.ForegroundColor = ConsoleColor.White;
    }


   public void CharacterCreation()
   {
        do
        {

            Console.Write("What is thy name, adventurer? ");
            _characterName = Console.ReadLine();
            Console.Beep(800, 100);
            Console.Write("Are thy sure this is the name thy choseth? (Y or N): ");
            _response = Console.ReadLine();
            Console.Beep(800, 100);

            if (_response == "N" || _response == "n")
            {
                continue;
            }

            do
            {
                Console.WriteLine("Choose thy class, adventurer: ");
                Console.WriteLine("1 - Fighter");
                Console.WriteLine("2 - Rogue");
                Console.WriteLine("3 - Grammaturge");
                _response = Console.ReadLine();
                Console.Beep(800, 100);


                if (_response == "1")
                {
                    _healthPoints = 15;
                    _armorPoints = 10;
                    _speedPoints = 3;
                    _characterClass = "Fighter";

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine("The Fighter");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints}/{_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints}/{_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}"); 

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The fighter is the most basic of the classes. Armed with sword, shield, and plate armor, it is a balanced class that can take on any foe. Highest constitution of the classes.");
                }
                if (_response == "2")
                {
                    _healthPoints = 10;
                    _armorPoints = 5;
                    _speedPoints = 10;
                    _characterClass = "Rogue";

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.WriteLine("The Rogue");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints}/{_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints}/{_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The rogue uses stealth and tricky to misdirect and evade foes. Weaker in consitution with lesser armor compared to a fighter, but stronger than a mage, and quicker than both.");
                }
                if (_response == "3")
                {
                    _healthPoints = 5;
                    _armorPoints = 3;
                    _speedPoints = 5;
                    _characterClass = "Grammaturge";

                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("The Grammaturge");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"HP: {_healthPoints}/{_healthPoints} ");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"AP: {_armorPoints}/{_armorPoints} ");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"SPD: {_speedPoints}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("The grammaturge is a master of grammaturgy: using words as a medium for magick powers. Though weaker and slower than the fighter and rogue, the grammaturge makes up for it with both offensive and defensive healing magicks, assuming you find the right words!");
                }

                Console.Write("Are thy sure this is the class thy choseth? (Y or N): ");
                _response = Console.ReadLine();
                Console.Beep(800, 100);

                if (_response == "N" || _response == "n")
                {
                    continue;
                }

                Console.WriteLine($"Welcome to the lands of Textica, {_characterName} the {_characterClass}!");

            } while (_characterClass == null || _characterName == null);

        } while (_characterClass == null || _characterName == null);
        
    }    

}

class TownHub : Character
{
    public TownHub()
    {
        CharacterCreation();
        CharacterStatus();
        Console.WriteLine($"Welcome to the city of Textica, {_characterName}! Where do you want to go?");
        Console.WriteLine("1 - Tavern");
        Console.WriteLine("2 - City Watch");
        Console.WriteLine("3 - Mayor's Office");
        Console.WriteLine("4 - Merchant");
        _response = Console.ReadLine();

    }
}