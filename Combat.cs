// Handles combat mechanics in the game
public class Combat
{
    private int Round { get; set; }
    private string Response { get; set; }
    private bool MonsterInitiative { get; set; }
    private bool CharacterInitiative { get; set; }
    public Combat()
    {
        Round = 1;

        Character character = new Character();

        Monster goblinFighter = new GoblinFighter();

        Monster goblinArcher = new GoblinArcher();

        Random random = new Random();

        character.CharacterDamage = random.Next(1, 11);

        character.CharacterAccurarcy = random.Next(31);

        goblinFighter.MonsterDamage = random.Next(1, 11);

        goblinFighter.MonsterAccurarcy = random.Next(31);

        while (true)
        {
            /*
            if (Round == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
               // Console.Beep(300, 200);
                //Console.Beep(450, 200);
                //Console.Beep(300, 200);
                Thread.Sleep(2000);
                Console.WriteLine($"You encounter a {Console.ForegroundColor = ConsoleColor.Green} {goblinFighter.MonsterClass}!");
                Thread.Sleep(2000);
                Console.ResetColor();
            }*/

            Thread.Sleep(1000);

            Console.Clear();

            if (goblinFighter.MonsterHealthPoints <= 0) goblinFighter.MonsterHealthPoints = 0;

            Console.WriteLine($"Round: {Round}");

            Console.WriteLine("-----------------------------------------------------------------------");

            goblinFighter.MonsterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            if (goblinFighter.MonsterHealthPoints <= 0)
            {
                Character.CurrentExperiencePoints = Character.CurrentExperiencePoints + 5;

                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine($"{goblinFighter.MonsterClass} is dead!");

                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine($"You gained {Character.CurrentExperiencePoints} EXP!");

                Console.ResetColor();

                Thread.Sleep(2000);

                Console.WriteLine("Press any key to continue.");

                Console.ReadKey(true);

                Console.Clear();

                new Forest();
            }
            if (Character.CharacterHealthPoints <= 0)
            {
                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine("You are dead!");

                Console.ResetColor();

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
                while (Character.CharacterSpeedPoints > goblinFighter.MonsterSpeedPoints || MonsterInitiative == true) 
                {
                    if (CharacterInitiative == false)
                    {
                        Console.WriteLine("You go first!");
                        Thread.Sleep(2000);
                        CharacterInitiative = true;
                    }

                    Console.WriteLine("What do you want do do?");

                    Response = Console.ReadLine();

                    if (Response == "attack")
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
                    if (Response == "defend")
                    {
                        Console.Beep(400, 150);
                        Console.Beep(350, 150);
                        Console.WriteLine("You tense yourself in anticipation of an attack! DMG is reduced by half for 1 round!");
                        break;
                    }
                    if (Response == "flee")
                    {
                        Console.Beep(800, 100);
                        Console.Beep(600, 100);

                        Console.Clear();

                        new Forest();
                    }
                    if (Response == "live")
                    {
                        while (true)
                        {
                            Console.WriteLine("You're already alive!");
                            Thread.Sleep(2000);
                            break;
                        }
                        continue;
                    }
                    if (Response == "die")
                    {
                        while (true)
                        {
                            Console.WriteLine("Are you sure you want to die (y or n)?");

                            Response = Console.ReadLine();
                            if (Response == "Y" || Response == "y")
                            {
                                Console.Beep(1000, 100);
                                Console.Beep(1200, 100);
                                Console.Beep(1400, 150);
                                Console.WriteLine("You stab yourself with your sword, dealing critical damage!");
                                Character.CharacterHealthPoints = 0;
                                break;
                 
                            }
                            else break;
                        }
                        if (Character.CharacterHealthPoints == 0) break;
                        continue;
                    }
                    if (Response == "kiss" || Response == "hug" || Response == "cuddle")
                    {
                        while (true)
                        {
                            Console.WriteLine("You want to do what?!");
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("That doesn't seem to work!");
                            Thread.Sleep(2000);
                            break;

                        }
                    }
                }
                if (goblinFighter.MonsterSpeedPoints > Character.CharacterSpeedPoints || CharacterInitiative == true && Character.CharacterHealthPoints > 0)
                {
                    MonsterCombat();
                }
            }
            void MonsterCombat()
            {
                while (goblinFighter.MonsterSpeedPoints > Character.CharacterSpeedPoints || CharacterInitiative == true)
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
                            
                            Character.CharacterArmorPoints = Character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                            Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints}!");
                        }
                        else
                        {
                            Thread.Sleep(2000);

                            Console.Beep(800, 100);
                            Console.Beep(1000, 100);

                            if (Response == "2") goblinFighter.MonsterDamage = goblinFighter.MonsterDamage / 2; Response = null;

                            Character.CharacterArmorPoints = Character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                            Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints}!");
                        }
                        if (Character.CharacterArmorPoints <= 0)
                        {
                            Character.CharacterArmorPoints = 0;

                            if (Character.CharacterHealthPoints > 0)
                            {
                                Character.CharacterHealthPoints = Character.CharacterHealthPoints - goblinFighter.MonsterDamage;

                                Console.WriteLine($"The {goblinFighter.MonsterClass} hits through your armor! You receive {goblinFighter.MonsterDamage}!");

                                Thread.Sleep(2000);
                                break;
                            }
                            if (Character.CharacterHealthPoints <= 0)
                            {
                                Thread.Sleep(2000);
                                Character.CharacterHealthPoints = 0;
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