﻿// Responsible for managing the player character
public class Character
{
    public static string CharacterName { get; set; }
    public float CharacterDamage { get; set; }
    public int CharacterAccuracy { get; set; }
    private string Response { get; set; }
    public static int CharacterLevel { private get; set; }
    public static int CurrentExperiencePoints { get; set; }
    public static int ExperiencePointsToLevelUp { private get; set; }
    public static float CharacterHealthPoints { get; set; }
    public static float MaxHealthPoints { get; set; }
    public static float CharacterArmorPoints { get; set; }
    public static float CharacterSpeedPoints { get; set; }
    public static int GoldAmount { get; set; }
    public bool IsCharacterCreated { get; set; }
    // Allows the player to choose their name and character class
    public void  CharacterCreation()
    {
        while (true) 
        {
            Console.Write("What is thy name, adventurer? ");

            CharacterName = Console.ReadLine();
            Console.Beep(800, 100);

            if (string.IsNullOrWhiteSpace(CharacterName))
            {
                continue;
            }

            while (true)
            {
                Console.Write("Are thy sure this is the name thy choseth? (y or n): ");

                Response = Console.ReadLine();
                Console.Beep(800, 100);

                if (string.IsNullOrWhiteSpace(Response))
                {
                    continue;
                }
                else if (Response == "y" || Response == "Y")
                {
                    Console.Write($"Welcome to the lands of Textica, {CharacterName}!");

                    GoldAmount = 50;

                    new Inventory();

                    Console.ReadKey(true);

                    Console.Clear();

                    break;
                }
            }
            break;
        }
    }
    // Automatically creates a character for testing purposes
    public void AutoCharacterCreation()
    {
        CharacterName = "John the Adventurer";

        CharacterHealthPoints = 10;

        MaxHealthPoints = 10;

        GoldAmount = 50;

        CharacterSpeedPoints = 3;

        new Inventory();
    }
    // Handles current character level and EXP gain
    public static void CharacterLevelAndExperience()
    {
        if (CharacterLevel == 5)
        {
            CurrentExperiencePoints = 0;
            ExperiencePointsToLevelUp = 0;
        }
        // Initial character level
        if (CharacterLevel == 0) CharacterLevel = 1;

        // Intial EXP required to level up
        if (ExperiencePointsToLevelUp == 0) ExperiencePointsToLevelUp = 200;

        // EXP required to level up based on what the user's current EXP is: current EXP is the default value of 0 intially 
        switch (CurrentExperiencePoints)
        {
            // 200 EXP for level 2, 300 EXP for level 3, 400 EXP for level 4, 500 EXP for level 5
            case 200:
                CharacterLevel = 2;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to Lvl {CharacterLevel}!");
                ExperiencePointsToLevelUp = 300;
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case 300:
                CharacterLevel = 3;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to Lvl {CharacterLevel}!");
                ExperiencePointsToLevelUp = 400;
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case 400:
                CharacterLevel = 4;
                CurrentExperiencePoints = 0;
                Console.WriteLine($"You leveled up to Lvl {CharacterLevel}!");
                ExperiencePointsToLevelUp = 500;
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case 500:
                CharacterLevel = 5;
                CurrentExperiencePoints = 0;
                ExperiencePointsToLevelUp = 0;
                Console.WriteLine($"You leveled up to Lvl {CharacterLevel}!");
                Thread.Sleep(2000);
                Console.Clear();
                break;
        }
    }
    // Displays the character's status: name, class, HP, AP, and SPD
    public static void CharacterStatus()
    {
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine($"{CharacterName}");

        Console.Write($"Lvl {CharacterLevel} ");

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.Write($"EXP: {CurrentExperiencePoints}/{ExperiencePointsToLevelUp} ");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {CharacterHealthPoints} / {MaxHealthPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write($"AP: {CharacterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Write($"SPD: {CharacterSpeedPoints}");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($" {GoldAmount} G");

        Console.ResetColor();

        Console.WriteLine("----------------------------------------------");
    }
}