// Handles combat mechanics in the game
public class Combat
{
    public int Round { get; set; }
    public string Response { get; set; }
    public bool MonsterInitiative { get; set; }
    public bool CharacterInitiative { get; set; }
    public Combat()
    {
        Round = 1;

        Character character = new Character();

        character.CharacterName = "Testman"; character.CharacterClass = "Fighter"; character.CharacterHealthPoints = 15; character.CharacterArmorPoints = 10; character.CharacterSpeedPoints = 3; TownHub.ForestAccess = true;

        Monster goblinFighter = new GoblinFighter();

        Monster goblinArcher = new GoblinArcher();

        Random random = new Random();

        // goblinFighter.MonsterHealthPoints = 0;

        // goblinFighter.MonsterSpeedPoints = 10;

        character.CharacterDamage = random.Next(1, 11);

        character.CharacterAccurarcy = random.Next(31);

        goblinFighter.MonsterDamage = random.Next(1, 11);

        goblinFighter.MonsterAccurarcy = random.Next(31);

        while (true)
        {
            if (Round == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Beep(300, 200);
                Console.Beep(450, 200);
                Console.Beep(300, 200);
                Thread.Sleep(2000);
                Console.WriteLine($"You encounter a {Console.ForegroundColor = ConsoleColor.Green} {goblinFighter.MonsterClass}!");
                Thread.Sleep(2000);
                Console.ResetColor();
            }

            Thread.Sleep(1000);

            Console.Clear();

            if (goblinFighter.MonsterHealthPoints <= 0) goblinFighter.MonsterHealthPoints = 0;

            Console.WriteLine($"Round: {Round}");

            Console.WriteLine("-----------------------------------------------------------------------");

            goblinFighter.MonsterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            character.CharacterClassColorCheck();
            character.CharacterLevelAndExperience();
            character.CharacterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            if (goblinFighter.MonsterHealthPoints <= 0)
            {
                Character.CurrentExperiencePoints = Character.CurrentExperiencePoints + 5;

                Thread.Sleep(2000);

                Console.WriteLine($"{goblinFighter.MonsterClass} is dead!");

                Thread.Sleep(2000);

                Console.WriteLine($"You gained {Character.CurrentExperiencePoints} EXP!");

                Thread.Sleep(2000);

                Console.WriteLine("Press any key to continue.");

                Console.ReadKey(true);

                Console.Clear();

                new Forest();
            }
            if (character.CharacterHealthPoints <= 0)
            {
                Thread.Sleep(2000);

                Console.WriteLine("You are dead!");

                Thread.Sleep(2000);

                Console.WriteLine("Press any key to try again!");

                Console.ReadKey(true);

                Console.Clear();

                new Forest();
            }

            CharacterCombat();
            Round++;

            void CharacterCombat()
            {
                while (character.CharacterSpeedPoints > goblinFighter.MonsterSpeedPoints || MonsterInitiative == true) 
                {
                    if (CharacterInitiative == false)
                    {
                        Thread.Sleep(2000);
                        Console.WriteLine("You go first!");
                        Thread.Sleep(2000);
                        CharacterInitiative = true;
                    }

                    Console.WriteLine("What do you want do do?");
                    Console.WriteLine("1 - Attack");
                    Console.WriteLine("2 - Defend");
                    Console.WriteLine("3 - Flee");

                    Response = Console.ReadLine();

                    if (Response == "1")
                    {
                        if (character.CharacterAccurarcy > 10)
                        {
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

                                if (goblinFighter.MonsterHealthPoints <= 0)
                                {
                                    Thread.Sleep(2000);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                Console.Beep(800, 100);
                                Console.Beep(1000, 100);

                                Console.WriteLine($"You hit the {goblinFighter.MonsterClass} for {character.CharacterDamage} DMG!");

                                goblinFighter.MonsterHealthPoints = goblinFighter.MonsterHealthPoints - character.CharacterDamage;

                                if (goblinFighter.MonsterHealthPoints <= 0)
                                {
                                    Thread.Sleep(2000);
                                    break;
                                }
                                break;
                            }
                        }
                        else
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 100);

                            Console.WriteLine("You miss your attack!");

                            Thread.Sleep(2000);

                            break;
                        }
                    }
                    if (Response == "2")
                    {
                        Console.Beep(400, 150);
                        Console.Beep(350, 150);
                        Console.WriteLine("You tense yourself in anticipation of an attack! DMG is reduced by half for 1 round!");
                        break;
                    }
                    if (Response == "3")
                    {
                        Console.Beep(800, 100);
                        Console.Beep(600, 100);

                        Console.Clear();

                        new Forest();
                    }
                }
                if (goblinFighter.MonsterSpeedPoints > character.CharacterSpeedPoints || CharacterInitiative == true)
                {
                    MonsterCombat();
                }
            }
            void MonsterCombat()
            {
                while (goblinFighter.MonsterSpeedPoints > character.CharacterSpeedPoints || CharacterInitiative == true)
                {
                    if (CharacterInitiative == false)
                    {
                        Console.WriteLine($"{goblinFighter.MonsterClass} goes first!");
                        MonsterInitiative = true;
                        Thread.Sleep(2000);
                    }
                    if (goblinFighter.MonsterHealthPoints <= 0)
                    {
                        break;
                    }
                    if (goblinFighter.MonsterAccurarcy > 10)
                    {
                        Thread.Sleep(2000);

                        if (goblinFighter.MonsterDamage >= 7)
                        {
                            Console.Beep(1000, 100);
                            Console.Beep(1200, 100);
                            Console.Beep(1400, 150);

                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("CRITICAL HIT!");

                            Thread.Sleep(2000);

                            Console.ResetColor();

                            if (Response == "2") goblinFighter.MonsterDamage = goblinFighter.MonsterDamage / 2; Response = null;
                            
                            character.CharacterArmorPoints = character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                            Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG! Your armor was reduced to {character.CharacterArmorPoints}!");
                        }
                        else
                        {
                            Thread.Sleep(2000);

                            Console.Beep(800, 100);
                            Console.Beep(1000, 100);

                            if (Response == "2") goblinFighter.MonsterDamage = goblinFighter.MonsterDamage / 2; Response = null;

                            character.CharacterArmorPoints = character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                            Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG! Your armor was reduced to {character.CharacterArmorPoints}!");
                        }
                        if (character.CharacterArmorPoints <= 0)
                        {
                            character.CharacterArmorPoints = 0;

                            if (character.CharacterHealthPoints > 0)
                            {
                                character.CharacterHealthPoints = character.CharacterHealthPoints - goblinFighter.MonsterDamage;

                                Console.WriteLine($"The {goblinFighter.MonsterClass} hits through your armor! You receive {goblinFighter.MonsterDamage}!");

                                Thread.Sleep(2000);
                                break;
                            }
                            if (character.CharacterHealthPoints <= 0)
                            {
                                Thread.Sleep(2000);
                                character.CharacterHealthPoints = 0;
                                break;
                            }
                        }
                        Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(2000);

                        Console.Beep(300, 100);
                        Console.Beep(200, 100);
                        Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");

                        Thread.Sleep(2000);

                        break;
                    }
                }
            }
        }
    }
}