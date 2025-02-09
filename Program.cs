
while (true)
{
    IntroText introText = new IntroText();
    CharacterCreation characterCreation = new CharacterCreation();
    break;
}
        
            
class IntroText 
{
    public IntroText()
    {
        Console.Title = "Legend of Textica";

        Console.WriteLine("LEGEND OF TEXTICA");
        Console.WriteLine();
        Console.Write("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey(true);
        Console.Beep(800, 100);
        Console.Clear();
    }
}

class CharacterCreation
{
   private protected string _characterName;
   private protected string _characterClass;
   private protected string _response;

   public CharacterCreation()
   {
        do
        {

            Console.Write("What is thy name, adventurer? ");
            _characterName = Console.ReadLine();
            Console.Beep(800, 100);
            Console.Write("Are thy sure this is the name thy choseth? (Y or N): ");
            _response = Console.ReadLine();
            Console.Beep(800, 100);

            if (_response != "Y")
            {
                continue;
            }

            while (true)
            {
                Console.WriteLine("Choose thy class, adventurer: ");
                Console.WriteLine("1 - Fighter");
                Console.WriteLine("2 - Rogue");
                Console.WriteLine("3 - Grammaturge");
                _response = Console.ReadLine();
                Console.Beep(800, 100);


                if (_response == "1")
                {
                    Console.WriteLine("HP: 20/20");
                    Console.WriteLine("The fighter is the most basic of the classes. Armed with sword, shield, and plate armor, it is a balanced class that can take on any foe. Highest constitution of the classes.");
                    _characterClass = "Fighter";
                }
                if (_response == "2")
                {
                    Console.WriteLine("HP: 15/15");
                    Console.WriteLine("The rogue uses stealth and tricky to misdirect and evade foes. Weaker in consitution with no defense compared to a fighter, but stronger than a mage, and quicker than both.");
                    _characterClass = "Rogue";
                }
                if (_response == "3")
                {
                    Console.WriteLine("HP: 10/10");
                    Console.WriteLine("The grammaturge is a master of grammaturgy: using words as a medium for magick powers. Though weaker and slower than the fighter and rogue, the grammaturge makes up for it with both offensive and defensive healing magicks, assuming you find the right words!");
                    _characterClass = "Grammaturge";
                }

                Console.Write("Are thy sure this is the class thy choseth? (Y or N): ");
                _response = Console.ReadLine();
                Console.Beep(800, 100);

                if (_response != "Y")
                {
                    continue;
                }
                Console.WriteLine($"Welcome to the lands of Textica, {_characterName} the {_characterClass}!");
                break;
            }

        } while (_characterClass == null || _characterName == null);
   }    
}

class TownHub : CharacterCreation
{
    



}