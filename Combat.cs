// Handles combat mechanics in the game
public class Combat
{
    private int Round { get; set; }
    private string Response { get; set; }
    private bool MonsterInitiative { get; set; }
    private bool CharacterInitiative { get; set; }
    private int MonsterChance { get; set; }
    private Monster MonsterChoice { get; set; } 
    private Monster GoblinFighter { get; set; }
    private Monster GoblinArcher { get; set; }
    public static bool IsInCombat { get; private set; }
    private int TiebreakerNumber { get; set; }
    private int FleeChance { get; set; }
    public Combat()
    {                                                                           
        if (Round == 0) Round = 1;

        Random random = new Random();

        Character character = new Character();

        character.CharacterDamage = random.Next(1, 11);

        if (Response == "monsterdefend")
        {
            character.CharacterDamage /= 2;
        }

        character.CharacterAccuracy = random.Next(101);

        MonsterChance = random.Next(101);

        GoblinFighter = new GoblinFighter();

        GoblinArcher = new GoblinArcher();

        if (MonsterChance > 50)
        {
            MonsterChoice = GoblinFighter;
        }
        else MonsterChoice = GoblinArcher;

        MonsterChoice.MonsterDamage = random.Next(1, 11);

        MonsterChoice.MonsterAccuracy = random.Next(101);

        while (true)
        {
            // Message telling the player what monster they have encountered
            /*
            if (Round == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You encounter a {MonsterChoice.MonsterClass}!");
                Console.Beep(300, 200);
                Console.Beep(450, 200);
                Console.Beep(300, 200);
                Thread.Sleep(2000);
                Console.ResetColor();
            }*/

            Console.Clear();

            IsInCombat = true;

            // Makes it so character or monster HP stays at 0 if an attack makes HP less than 0
            if (MonsterChoice.MonsterHealthPoints <= 0) MonsterChoice.MonsterHealthPoints = 0;
            if (Character.CharacterHealthPoints <= 0) Character.CharacterHealthPoints = 0;

            Console.WriteLine($"Round: {Round}");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            MonsterChoice.MonsterStatus();

            // Checks to see if monster HP is less or equal to 0: if so, displays that monster is dead, adds EXP, and goblin head to player's inventory, and to the amount
            if (MonsterChoice.MonsterHealthPoints <= 0)
            {
                IsInCombat = false; 

                Thread.Sleep(2000);

                Console.WriteLine($"{MonsterChoice.MonsterClass} is dead!");

                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine($"You gained 10 EXP!");

                Character.CurrentExperiencePoints += 10;

                Thread.Sleep(2000);

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("You got 1 GoblinHead!");

                Inventory.InventoryList.Add(Inventory.GoblinHead);

                GoblinHead.Amount += 1;

                Thread.Sleep(2000);

                Console.ResetColor();

                Console.WriteLine("Press any key to continue.");

                Console.ReadKey(true);

                Console.Clear();

                new Forest();
            }

            // Checks to see if player HP is less or equal to 0; if so, player is considered dead, and prompts the player to try again and go back to the area from the begining
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
                while (Character.CharacterSpeedPoints > MonsterChoice.MonsterSpeedPoints || MonsterInitiative == true || Character.CharacterSpeedPoints == MonsterChoice.MonsterSpeedPoints) 
                {
                    if (Character.CharacterSpeedPoints == MonsterChoice.MonsterSpeedPoints && Round == 1)
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
                            Console.WriteLine($"TiebreakerNumber is {TiebreakerNumber}. {MonsterChoice.MonsterClass} goes first!");
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
                        if (character.CharacterAccuracy > 10)
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

                                Console.WriteLine($"You hit the {MonsterChoice.MonsterClass} for {character.CharacterDamage} DMG!");

                                MonsterChoice.MonsterHealthPoints = MonsterChoice.MonsterHealthPoints - character.CharacterDamage;

                                if (MonsterChoice.MonsterHealthPoints <= 0)
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

                                Console.WriteLine($"You hit the {MonsterChoice.MonsterClass} for {character.CharacterDamage} DMG!");

                                MonsterChoice.MonsterHealthPoints = MonsterChoice.MonsterHealthPoints - character.CharacterDamage;

                                if (MonsterChoice.MonsterHealthPoints <= 0)
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
                        Inventory.InventoryMenu();
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
                            if (Response == "N" || Response == "n") break;
                            else continue;
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
                            continue;

                        }
                    }
                }
                if (MonsterChoice.MonsterSpeedPoints > Character.CharacterSpeedPoints || CharacterInitiative == true && Character.CharacterHealthPoints > 0 || MonsterChoice.MonsterSpeedPoints == Character.CharacterSpeedPoints)
                {
                    if (MonsterChoice == GoblinFighter)
                    {
                        GoblinFighterCombat goblinFighterCombat = new GoblinFighterCombat();    

                        goblinFighterCombat.MonsterCombat(random, this, character, MonsterChoice);
                    }
                    if (MonsterChoice == GoblinArcher) 
                    {
                        GoblinArcherCombat goblinArcherCombat = new GoblinArcherCombat();

                        goblinArcherCombat.MonsterCombat(random, this, character, MonsterChoice); 
                    }
                }
            }
        }
    }
    // Interface accounts for different monsters with their own movesets
    private interface IMonsterCombat
    {
        void MonsterCombat(Random random, Combat combat, Character character, Monster monsterChoice);
    }
    private class GoblinFighterCombat : IMonsterCombat
    {
        // Goblin Fighter moveset
        public void MonsterCombat(Random random, Combat combat, Character character, Monster monsterChoice)
        {
            combat.MonsterChance = random.Next(101);

            while (monsterChoice.MonsterSpeedPoints > Character.CharacterSpeedPoints || combat.CharacterInitiative == true || combat.MonsterInitiative == false)
            {
                if (combat.MonsterInitiative == false && combat.CharacterInitiative == false)
                {
                    Console.WriteLine($"{monsterChoice.MonsterClass} goes first!");
                    combat.MonsterInitiative = true;
                    Thread.Sleep(2000);
                }
                if (monsterChoice.MonsterHealthPoints <= 0)
                {
                    break;
                }
                if (monsterChoice.MonsterAccuracy > 50)
                {
                    Thread.Sleep(2000);

                    if (monsterChoice.MonsterDamage >= 7)
                    {
                        Console.Beep(1000, 100);
                        Console.Beep(1200, 100);
                        Console.Beep(1400, 150);

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("CRITICAL HIT!");

                        Thread.Sleep(2000);

                        Console.ResetColor();

                        if (combat.Response == "defend")
                        {
                            monsterChoice.MonsterDamage /= 2;
                        }

                        Character.CharacterArmorPoints = Character.CharacterArmorPoints - monsterChoice.MonsterDamage;

                        Console.WriteLine($"{monsterChoice.MonsterClass} attacks with its sword, dealing {monsterChoice.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                    }
                    else
                    {
                        Thread.Sleep(2000);

                        Console.Beep(800, 100);
                        Console.Beep(1000, 100);

                        if (combat.Response == "defend")
                        {
                            monsterChoice.MonsterDamage = monsterChoice.MonsterDamage / 2;
                        }

                        Character.CharacterArmorPoints = Character.CharacterArmorPoints - monsterChoice.MonsterDamage;

                        Console.WriteLine($"{monsterChoice.MonsterClass} attacks with its sword, dealing {monsterChoice.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                    }
                    if (Character.CharacterArmorPoints <= 0)
                    {
                        Character.CharacterArmorPoints = 0;

                        if (Character.CharacterHealthPoints > 0)
                        {
                            Character.CharacterHealthPoints = Character.CharacterHealthPoints - monsterChoice.MonsterDamage;

                            Console.WriteLine($"The {monsterChoice.MonsterClass} hits through your armor! You receive {monsterChoice.MonsterDamage} DMG!");

                            Thread.Sleep(2000);
                            break;
                        }
                        if (Character.CharacterHealthPoints <= 0)
                        {
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                    break;
                }
                else if (combat.MonsterChance > 50)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"The {monsterChoice.MonsterClass} raises its wooden shield! DMG reduced by half for 1 round!");
                    Thread.Sleep(2000);
                    combat.Response = "monsterdefend";
                    break;
                }
                else if (combat.MonsterChance <= 10)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"The {monsterChoice.MonsterClass} skips its turn!");
                    Thread.Sleep(2000);
                    break;

                }
                else
                {
                    Thread.Sleep(2000);

                    Console.Beep(300, 100);
                    Console.Beep(200, 100);
                    Console.WriteLine($"{monsterChoice.MonsterClass} misses its attack!");

                    Thread.Sleep(2000);

                    break;
                }
            }
        }
    }
    private class GoblinArcherCombat : IMonsterCombat
    {

        // Goblin Archer moveset
        public void MonsterCombat(Random random, Combat combat, Character character, Monster monsterChoice)
        {
            combat.MonsterChance = random.Next(101);

            while (monsterChoice.MonsterSpeedPoints > Character.CharacterSpeedPoints || combat.CharacterInitiative == true || combat.MonsterInitiative == false)
            {
                if (combat.MonsterInitiative == false && combat.CharacterInitiative == false)
                {
                    Console.WriteLine($"{monsterChoice.MonsterClass} goes first!");
                    combat.MonsterInitiative = true;
                    Thread.Sleep(2000);
                }
                if (monsterChoice.MonsterHealthPoints <= 0)
                {
                    break;
                }
                if (monsterChoice.MonsterAccuracy > 50)
                {
                    Thread.Sleep(2000);

                    if (monsterChoice.MonsterDamage >= 7)
                    {
                        Console.Beep(1000, 100);
                        Console.Beep(1200, 100);
                        Console.Beep(1400, 150);

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("CRITICAL HIT!");

                        Thread.Sleep(2000);

                        Console.ResetColor();

                        if (combat.Response == "defend")
                        {
                            monsterChoice.MonsterDamage /= 2;
                        }

                        Character.CharacterArmorPoints = Character.CharacterArmorPoints - monsterChoice.MonsterDamage;

                        Console.WriteLine($"{monsterChoice.MonsterClass} attacks with its bow, dealing {monsterChoice.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                    }
                    else
                    {
                        Thread.Sleep(2000);

                        Console.Beep(800, 100);
                        Console.Beep(1000, 100);

                        if (combat.Response == "defend")
                        {
                            monsterChoice.MonsterDamage = monsterChoice.MonsterDamage / 2;
                        }

                        Character.CharacterArmorPoints = Character.CharacterArmorPoints - monsterChoice.MonsterDamage;

                        Console.WriteLine($"{monsterChoice.MonsterClass} attacks with its bow, dealing {monsterChoice.MonsterDamage} DMG! Your armor was reduced to {Character.CharacterArmorPoints} AP!");
                    }
                    if (Character.CharacterArmorPoints <= 0)
                    {
                        Character.CharacterArmorPoints = 0;

                        if (Character.CharacterHealthPoints > 0)
                        {
                            Character.CharacterHealthPoints = Character.CharacterHealthPoints - monsterChoice.MonsterDamage;

                            Console.WriteLine($"The {monsterChoice.MonsterClass} hits through your armor! You receive {monsterChoice.MonsterDamage} DMG!");

                            Thread.Sleep(2000);
                            break;
                        }
                        if (Character.CharacterHealthPoints <= 0)
                        {
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                    break;
                }
                else if (combat.MonsterChance > 50)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"The {monsterChoice.MonsterClass} increases its footwork in anticipation of an attack! DMG reduced by half for 1 round!");
                    Thread.Sleep(2000);
                    combat.Response = "monsterdefend";
                    break;
                }
                else if (combat.MonsterChance <= 10)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"The {monsterChoice.MonsterClass} skips its turn!");
                    Thread.Sleep(2000);
                    break;

                }
                else
                {
                    Thread.Sleep(2000);

                    Console.Beep(300, 100);
                    Console.Beep(200, 100);
                    Console.WriteLine($"{monsterChoice.MonsterClass} misses its attack!");

                    Thread.Sleep(2000);

                    break;
                }
            }
        }
    }
}
