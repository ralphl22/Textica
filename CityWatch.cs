// Allows the user to interact with and take quests from NPCs in the city
public class CityWatch
{
    private string Response { get; set; }
    public static bool IsGoblinQuestAccepted { get; set; }
    public static bool IsGoblinQuestCompleted { get; set; }
    public CityWatch()
    {
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount == 0 || IsGoblinQuestAccepted == true && GoblinHead.Amount > 0 && GoblinHead.Amount < 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Watchman Karl: Welcome back, adventurer. I see that you have {GoblinHead.Amount} goblin heads.");

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.WriteLine("Watchman Karl: That's not enough for the reward. Come back when you have at least 5 goblin heads.");

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.Clear();

            new TownHub();
        }
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount == 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Watchman Karl: Welcome back, adventurer. I see that you have 5 goblin heads.");

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.WriteLine("Watchman Karl: Here is your 250 G reward. Keep up the good work!");

            Character.GoldAmount = Character.GoldAmount + 250;

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            Console.Clear();

            new TownHub();
        }
        if (IsGoblinQuestAccepted == true && GoblinHead.Amount > 5)
        {
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Character.GoldAmount = Character.GoldAmount + GoblinHead.Amount * 50;

            Console.WriteLine($"Watchman Karl: Welcome back, adventurer. I see that you have {GoblinHead.Amount} goblin heads, which is more than I asked for. Adding up the 50 goblin bonus per head, you have {Character.GoldAmount} G as your reward!");

            IsGoblinQuestCompleted = true;

            Console.ReadKey(true);
            Console.Beep(800, 100);

            new TownHub();
        }
        Console.WriteLine("----------------------------------------------");

        Character.CharacterLevelAndExperience();
        Character.CharacterStatus();

        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("You see a watchman in chainmail, armed with a sword on his hip. He turns to look at you.");

        Console.ReadKey(true);

        while (true)
        {
            Console.WriteLine("Watchman Karl: You don't seem to be from around here. What do you want?");
            
            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "quest")
            {
                Console.WriteLine("Watchman Karl: We do in fact have something for you.");
                Console.ReadKey(true);
                Console.Beep(800, 100);
                Console.WriteLine("Watchman karl: There have been reports of goblins in the forest outside town attacking travelers. We're looking for anyone who's willing to help.");
                Console.ReadKey(true);
                Console.Beep(800, 100);

                while (true)
                {
                    Console.WriteLine("Watchman Karl: Is that something you'd be interested in? We're offering 250 G if you manage to get five goblin heads.");

                    Response = Console.ReadLine();
                    Console.Beep(800, 100);

                    if (Response == "yes")
                    {
                        Console.WriteLine("Watchman Karl: A scout told us that the coordinates of the goblin camp are (300, 300). Good luck.");

                        Console.ReadKey(true);
                        Console.Beep(800, 100);

                        Console.Clear();

                        IsGoblinQuestAccepted = true;

                        TownHub.ForestAccess = true;

                        new TownHub();

                    }
                    if (Response == "no")
                    {
                        Console.WriteLine("That's too bad. I'll see ya around, I guess.");

                        Console.ReadKey(true);
                        Console.Beep(800, 100);

                        Console.Clear();

                        new TownHub();
                    }
                }
            }
            if (Response == "exit")
            {
                Console.Clear();

                new TownHub();
            }
        }
    }
}
