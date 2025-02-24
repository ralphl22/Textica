// Handles combat mechanics in the game
public class Combat
{
    public int Round { get; set; }
    public string Response { get; set; }
    public Combat()
    {
        Round = 1;

        Character character = new Character();

        character.CharacterName = "Testman"; character.CharacterClass = "Fighter"; character.CharacterHealthPoints = 15; character.CharacterArmorPoints = 10; character.CharacterSpeedPoints = 3; TownHub.ForestAccess = true;

        Monster goblinFighter = new GoblinFighter();

        Monster goblinArcher = new GoblinArcher();

        Random random = new Random();

        goblinFighter.MonsterHealthPoints = 0;

        character.CharacterDamage = random.Next(1, 11);

        character.CharacterAccurarcy = random.Next(51);

        goblinFighter.MonsterDamage = random.Next(1, 11);

        goblinFighter.MonsterAccurarcy = random.Next(51);

        while (true)
        {
            if (Round == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You encounter a {Console.ForegroundColor = ConsoleColor.Green} {goblinFighter.MonsterClass}!");
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
                Thread.Sleep(2000);

                Character.CurrentExperiencePoints = Character.CurrentExperiencePoints + 5;

                new Character();

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

            if (goblinFighter.MonsterSpeedPoints > character.CharacterSpeedPoints)
            {

                while (Round == 1)
                {
                    Console.WriteLine($"{goblinFighter.MonsterClass} goes first!");
                    Thread.Sleep(2000);
                    break;
                }


                if (goblinFighter.MonsterAccurarcy >= 30)
                {
                    Console.Beep(800, 100);
                    Console.Beep(1000, 100);
                    Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG!");
                    Round++;
                    continue;
                }
                else
                {
                    Console.Beep(300, 100);
                    Console.Beep(200, 100);
                    Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");
                    Round++;
                    continue;
                }
            }
            else
            {
                if (Round == 1)
                {
                    Console.WriteLine("You go first!");
                    Thread.Sleep(2000);
                }

                Console.WriteLine("What do you want do do?");
                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Defend");
                Console.WriteLine("3 - Flee");

                Response = Console.ReadLine();

                switch (Response)
                {
                    case "1":
                        if (character.CharacterAccurarcy >= 30)
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
                                    continue;
                                }

                                if (goblinFighter.MonsterAccurarcy >= 30)
                                {
                                    Thread.Sleep(2000);

                                    Console.Beep(800, 100);
                                    Console.Beep(1000, 100);
                                    Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG!");

                                    character.CharacterArmorPoints = character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                                    if (character.CharacterArmorPoints <= 0)
                                    {
                                        character.CharacterArmorPoints = 0;

                                        if (character.CharacterHealthPoints > 0)
                                        {
                                            character.CharacterHealthPoints = character.CharacterHealthPoints - goblinFighter.MonsterDamage;
                                            Round++;
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                        if (character.CharacterHealthPoints <= 0)
                                        {
                                            Round++;
                                            Thread.Sleep(2000);
                                            continue;
                                        }

                                    }

                                    Thread.Sleep(2000);

                                    Console.Beep(300, 100);
                                    Console.Beep(200, 100);
                                    Console.WriteLine($"The {goblinFighter.MonsterClass} hits your armor! Your armor was reduced to {character.CharacterArmorPoints}!");
                                    Thread.Sleep(2000);
                                    continue;
                                }
                                else
                                {
                                    Thread.Sleep(2000);

                                    Console.Beep(300, 100);
                                    Console.Beep(200, 100);
                                    Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");

                                    Round++;

                                    Thread.Sleep(2000);

                                    continue;
                                }
                            }
                            else
                            {
                                Console.Beep(800, 100);

                                Console.Beep(1000, 100);

                                Console.WriteLine($"You hit the {goblinFighter.MonsterClass} for {character.CharacterDamage} DMG!");

                                goblinFighter.MonsterHealthPoints = goblinFighter.MonsterHealthPoints - character.CharacterDamage;

                                if (goblinFighter.MonsterHealthPoints <= 0)
                                {
                                    continue;
                                }

                                if (goblinFighter.MonsterAccurarcy >= 30)
                                {
                                    Thread.Sleep(2000);

                                    Console.Beep(800, 100);
                                    Console.Beep(1000, 100);
                                    Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG!");

                                    character.CharacterArmorPoints = character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                                    if (character.CharacterArmorPoints <= 0)
                                    {
                                        character.CharacterArmorPoints = 0;

                                        if (character.CharacterHealthPoints > 0)
                                        {
                                            character.CharacterHealthPoints = character.CharacterHealthPoints - goblinFighter.MonsterDamage;
                                            Round++;
                                            Thread.Sleep(2000);
                                            continue;

                                        }
                                        if (character.CharacterHealthPoints <= 0)
                                        {
                                            Round++;
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                    }
                                    Round++;
                                    Thread.Sleep(2000);
                                    Console.Beep(300, 100);
                                    Console.Beep(200, 100);
                                    Console.WriteLine($"The {goblinFighter.MonsterClass} hits your armor! Your armor was reduced to {character.CharacterArmorPoints}!");
                                    Thread.Sleep(2000);
                                    continue;
                                }
                                else
                                {
                                    Thread.Sleep(2000);
                                    Console.Beep(300, 100);
                                    Console.Beep(200, 100);
                                    Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");
                                    Round++;
                                    Thread.Sleep(2000);
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 100);

                            Console.WriteLine("You miss your attack!");

                            if (goblinFighter.MonsterAccurarcy >= 30)
                            {
                                Thread.Sleep(2000);

                                Console.Beep(800, 100);
                                Console.Beep(1000, 100);
                                Console.WriteLine($"{goblinFighter.MonsterClass} attacks with its sword, doing {goblinFighter.MonsterDamage} DMG!");

                                character.CharacterArmorPoints = character.CharacterArmorPoints - goblinFighter.MonsterDamage;

                                if (character.CharacterArmorPoints <= 0)
                                {
                                    character.CharacterArmorPoints = 0;

                                    if (character.CharacterHealthPoints > 0)
                                    {
                                        character.CharacterHealthPoints = character.CharacterHealthPoints - goblinFighter.MonsterDamage;
                                        Round++;
                                        continue;
                                    }
                                    if (character.CharacterHealthPoints <= 0)
                                    {
                                        Round++;
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                }
                                Round++;
                                Thread.Sleep(2000);
                                Console.WriteLine($"The {goblinFighter.MonsterClass} hits your armor! Your armor was reduced to {character.CharacterArmorPoints}!");
                                Thread.Sleep(2000);
                                continue;
                            }
                            else
                            {
                                Thread.Sleep(2000);

                                Console.Beep(300, 100);
                                Console.Beep(200, 100);
                                Console.WriteLine($"{goblinFighter.MonsterClass} misses its attack!");

                                Round++;

                                Thread.Sleep(2000);

                                continue;
                            }
                        }
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