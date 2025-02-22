// Handles combat mechanics in the game
public class Combat
{
    public int Round { get; set; }
    public string Response { get; set; }
    public Combat()
    {
        while (true)
        {
            Character character = new Character();

            character.CharacterName = "Testman"; character.CharacterClass = "Fighter"; character.CharacterHealthPoints = 15; character.CharacterArmorPoints = 10; character.CharacterSpeedPoints = 3; TownHub.ForestAccess = true;

            Monster goblinFighter = new GoblinFighter();

            Monster goblinArcher = new GoblinArcher();

            Console.ForegroundColor = ConsoleColor.Green;

            Random random = new Random();

            while (Round == 0)
            {
                Console.WriteLine($"You encounter a {Console.ForegroundColor = ConsoleColor.Green} {goblinFighter.MonsterClass}!");
                break;
            }
            Console.ResetColor();

            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine($"Round: {Round}");

            Console.WriteLine("-----------------------------------------------------------------------");

            goblinFighter.MonsterSpeedPoints = random.Next(1, 7);

            goblinFighter.MonsterStatus();
            
            Console.WriteLine("-----------------------------------------------------------------------");

            character.CharacterClassColorCheck();
            character.CharacterLevelAndExperience();    
            character.CharacterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            if (goblinFighter.MonsterSpeedPoints > character.CharacterSpeedPoints)
            {
                goblinFighter.MonsterDamage = random.Next(1, 6);

                Thread.Sleep(2000);

                while (Round == 0)
                {
                    Console.WriteLine($"{goblinFighter.MonsterClass} goes first!");
                    Thread.Sleep(2000);
                    break;
                }

                goblinFighter.MonsterAccurarcy = random.Next(101);

                if (goblinFighter.MonsterAccurarcy > 50)
                {

                    Console.Beep(800, 100);
                    Console.Beep(1000, 100);
                    Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG!");
                    Round++;
                }
                else
                {
                    Console.Beep(300, 100);
                    Console.Beep(200, 100);
                    Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");
                    Round++;
                    continue;
                }

                if (Round < 10)
                {
                    continue;
                }
                break;
            }
            else
            {
                Thread.Sleep(2000);
                
                while (Round == 0)
                {
                    Console.WriteLine("You go first!");
                    break;
                }

                Console.WriteLine("What do you want do do?");

                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Defend");
                Console.WriteLine("3 - Flee");

                Response = Console.ReadLine();

                switch (Response)
                {
                    case "1":
                        //character.CharacterDamage = random.Next(1, 11);

                        character.CharacterDamage = 5;

                        goblinFighter.MonsterHealthPoints = 5;

                        if (goblinFighter.MonsterHealthPoints <= 0) Console.Beep(800, 100); Console.Beep(1000, 100); Console.WriteLine($"You hit the {goblinFighter.MonsterClass} for {character.CharacterDamage} DMG!"); Console.WriteLine($"{goblinFighter.MonsterClass} is dead!"); Thread.Sleep(2000); Console.Clear(); new Forest();

                        if (character.CharacterDamage >= 7)
                        {
                            Console.Beep(1000, 100);
                            Console.Beep(1200, 100);
                            Console.Beep(1400, 150);

                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("CRITICAL HIT!");

                            Thread.Sleep(2000);

                            Console.ResetColor();

                            Console.WriteLine($"You hit the {goblinFighter.MonsterClass} for {character.CharacterDamage} DMG!");

                            goblinFighter.MonsterHealthPoints = goblinFighter.MonsterHealthPoints - character.CharacterDamage;
                        }
                        else Console.Beep(800, 100); Console.WriteLine($"You hit the {goblinFighter.MonsterClass} for {character.CharacterDamage} DMG!");
                        break;
                    case "2":

                    break;
                    case "3":


                    break;
                }
            }
            break;
        }
    }
}