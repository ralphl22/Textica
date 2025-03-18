// Handles combat mechanics in the game
public class Combat
{
    private int Round { get; set; }
    private string Response { get; set; }
    private bool MonsterInitiative { get; set; }
    private bool CharacterInitiative { get; set; }
    private int MonsterChance { get; set; }
    public static bool IsInCombat { get; set; }
    private int TiebreakerNumber { get; set; }
    private int FleeChance { get; set; }
    public Combat()
    {
        if (Round == 0) Round = 1;

        Random random = new Random();

        Character character = new Character() { CharacterDamage = random.Next(1, 11), CharacterAccurarcy = random.Next(31) };

        Monster defaultMonster = new DefaultMonster();

        MonsterChance = random.Next(0, 101);

        if (MonsterChance > 50)
        {
            defaultMonster = new GoblinFighter();
        }
        else defaultMonster = new GoblinArcher();

        defaultMonster.MonsterDamage = random.Next(1, 11);

        defaultMonster.MonsterAccurarcy = random.Next(31);

        while (true)
        {
            if (Round == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You encounter a {Console.ForegroundColor = ConsoleColor.Green} {defaultMonster.MonsterClass}!");
                Console.Beep(300, 200);
                Console.Beep(450, 200);
                Console.Beep(300, 200);
                Thread.Sleep(2000);
                Console.ResetColor();
            }

            Console.Clear();

            IsInCombat = true;

            if (defaultMonster.MonsterHealthPoints <= 0) defaultMonster.MonsterHealthPoints = 0;
            if (Character.CharacterHealthPoints <= 0) Character.CharacterHealthPoints = 0;

            Console.WriteLine($"Round: {Round}");

            Console.WriteLine("-----------------------------------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            defaultMonster.MonsterStatus();

            Console.WriteLine("-----------------------------------------------------------------------");

            if (defaultMonster.MonsterHealthPoints <= 0)
            {
                IsInCombat = false; 

                Thread.Sleep(2000);

                Console.WriteLine($"{defaultMonster.MonsterClass} is dead!");

                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine($"You gained 10 EXP!");

                Character.CurrentExperiencePoints = Character.CurrentExperiencePoints + 10;

                Inventory.InventoryList.Add(Inventory.GoblinHead);

                GoblinHead.Amount = GoblinHead.Amount + 1;

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
                while (Character.CharacterSpeedPoints > defaultMonster.MonsterSpeedPoints || MonsterInitiative == true || Character.CharacterSpeedPoints == defaultMonster.MonsterSpeedPoints) 
                {
                    if (Character.CharacterSpeedPoints == defaultMonster.MonsterSpeedPoints && Round == 1)
                    {
                        TiebreakerNumber = random.Next(1, 101);

                        if (TiebreakerNumber > 50)
                        {
                            // Character goes first
                            Console.WriteLine($"TiebreakerNumber is {TiebreakerNumber}. You go first!");
                        }
                        else
                        {
                            // Monster goes first
                            Console.WriteLine($"TiebreakerNumber is {TiebreakerNumber}. {defaultMonster.MonsterClass} goes first!");
                            break;

                        }
                    }
                    if (CharacterInitiative == false && MonsterInitiative == false)
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

                                Console.WriteLine($"You hit the {defaultMonster.MonsterClass} for {character.CharacterDamage} DMG!");

                                defaultMonster.MonsterHealthPoints = defaultMonster.MonsterHealthPoints - character.CharacterDamage;

                                if (defaultMonster.MonsterHealthPoints <= 0)
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

                                Console.WriteLine($"You hit the {defaultMonster.MonsterClass} for {character.CharacterDamage} DMG!");

                                defaultMonster.MonsterHealthPoints = defaultMonster.MonsterHealthPoints - character.CharacterDamage;

                                if (defaultMonster.MonsterHealthPoints <= 0)
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
                    if (Response == "inventory")
                    {
                        Inventory.InventoryCheck();
                        continue;
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
                        FleeChance = random.Next(1, 101);

                        if (FleeChance > 50)
                        {
                            Console.Beep(800, 100);
                            Console.Beep(600, 100);

                            Console.WriteLine("You succesfully fled the battle!");

                            Thread.Sleep(2000);

                            Console.Clear();

                            new Forest();
                        }
                        else Console.WriteLine("Your flee attempt was unsuccesful!");
                        continue;
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
                                Console.WriteLine("You stab yourself with your weapon, dealing critical damage!");
                                Character.CharacterHealthPoints = 0;
                                break;
                            }
                            else break;
                        }
                        if (Character.CharacterHealthPoints == 0) break;
                        continue;
                    }
                    if (Response == "kiss" || Response == "hug" || Response == "cuddle" || Response == "tickle")
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
                if (defaultMonster.MonsterSpeedPoints > Character.CharacterSpeedPoints || CharacterInitiative == true && Character.CharacterHealthPoints > 0 || defaultMonster.MonsterSpeedPoints == Character.CharacterSpeedPoints)
                {
                    MonsterCombat();
                }
            }
            void MonsterCombat()
            {
                while (defaultMonster.MonsterSpeedPoints > Character.CharacterSpeedPoints || CharacterInitiative == true || MonsterInitiative == false)
                {
                    if (CharacterInitiative == false)
                    {
                        Console.WriteLine($"{defaultMonster.MonsterClass} goes first!");
                        MonsterInitiative = true;
                        Thread.Sleep(2000);
                    }
                    if (defaultMonster.MonsterHealthPoints <= 0)
                    {
                        break;
                    }
                    if (defaultMonster.MonsterAccurarcy > 10)
                    {
                        Thread.Sleep(2000);

                        if (defaultMonster.MonsterDamage >= 7)
                        {
                            Console.Beep(1000, 100);
                            Console.Beep(1200, 100);
                            Console.Beep(1400, 150);

                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("CRITICAL HIT!");

                            Thread.Sleep(2000);

                            Console.ResetColor();

                            if (Response == "2")
                            {
                                defaultMonster.MonsterDamage = defaultMonster.MonsterDamage / 2; 

                                Response = null;
                            }
                            
                            Character.CharacterArmorPoints = Character.CharacterArmorPoints - defaultMonster.MonsterDamage;

                            if (defaultMonster == new GoblinFighter()) Console.WriteLine($"{defaultMonster.MonsterClass} attacks with its sword, doing {defaultMonster.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                            if (defaultMonster == new GoblinArcher()) Console.WriteLine($"{defaultMonster.MonsterClass} attacks with its bow, doing {defaultMonster.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                        }
                        else
                        {
                            Thread.Sleep(2000);

                            Console.Beep(800, 100);
                            Console.Beep(1000, 100);

                            if (Response == "2")
                            {
                                defaultMonster.MonsterDamage = defaultMonster.MonsterDamage / 2; 

                                Response = null;
                            }

                            Character.CharacterArmorPoints = Character.CharacterArmorPoints - defaultMonster.MonsterDamage;

                            if (defaultMonster == new GoblinFighter()) Console.WriteLine($"{defaultMonster.MonsterClass} attacks with its sword, doing {defaultMonster.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                            if (defaultMonster == new GoblinArcher()) Console.WriteLine($"{defaultMonster.MonsterClass} attacks with its bow, doing {defaultMonster.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                        }
                        if (Character.CharacterArmorPoints <= 0)
                        {
                            Character.CharacterArmorPoints = 0;

                            if (Character.CharacterHealthPoints > 0)
                            {
                                Character.CharacterHealthPoints = Character.CharacterHealthPoints - defaultMonster.MonsterDamage;

                                Console.WriteLine($"The {defaultMonster.MonsterClass} hits through your armor! You receive {defaultMonster.MonsterDamage} DMG!");

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
                        Console.WriteLine($"{defaultMonster.MonsterClass} misses its attack!");

                        Thread.Sleep(2000);

                        break;
                    }
                }
            }
        }
    }
}