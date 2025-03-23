// Area where the player can explore the forest using X and Y coordinates, and engage in combat encounters
public class Forest
{
    private string Response { get; set; }
    private int X { get; set; }
    private int Y { get; set; }
    private bool AreCoordinatesInitialized { get; set; }  
    public Forest()
    {
        while (true)
        {
            if (AreCoordinatesInitialized == false)
            {
                // Starting coordinates of player: they start in quadrant I in a Cartesian plane
                X = 500; Y = 500;
                AreCoordinatesInitialized = true;
            }
   
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"You see yourself before a lush, dense forest. What do you want to do? Your current position is ({X}, {Y}).");

            // Defines the boundaries of the forest: the player cannot go any further than these numbers
            if (X > 500 && Y > 500 || X < -500 && Y < -500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                X = 500;
                Y = 500;
                Console.ReadKey(true);
                Console.Clear();
                continue;
            }
            if (X > 500 || X < -500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                X = 500;
                Thread.Sleep(3000);
                Console.Clear();
                continue;
            }
            if (Y > 500 || Y < -500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                Y = 500;
                Thread.Sleep(3000);
                Console.Clear();
                continue;
            }

            // Looking around at specific coordinates gives specific dialogue; player can change their position in the forest, use their inventory, or exit the forest.
            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "look around" || Response == "look")
            {
                if (X == 300 && Y == 300)
                {
                    Console.WriteLine("You see what appears to be a goblin camp off in the distance.");
                    Console.ReadKey(true);

                    while (true)
                    {
                        Console.WriteLine("Enter goblin camp?");

                        Response = Console.ReadLine();
                        Console.Beep(800, 100);

                        if (Response == "y" || Response == "yes") 
                        {
                            Console.Clear();
                            new Combat(); 
                        }
                        if (Response == "n" || Response == "no") break;
                        else continue;
                    }
                }
                else if (X == 500 && Y == 500)
                {
                    Console.WriteLine("You are at the forest entrance. You see nothing here other than endless forest and greenery.");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("You see nothing here other than endless forest and greenery.");
                    Console.ReadKey(true);
                }
            }
            if (Response == "move up" || Response == "up") Y += 100;
            if (Response == "move down" || Response == "down") Y -= 100;
            if (Response == "move left" || Response == "left") X -= 100;
            if (Response == "move right" || Response == "right") X += 100;
            if (Response == "go to" || Response == "goto")
            {
                Console.Write("X coordinate: ");
                Response = Console.ReadLine();
                X = Convert.ToInt32(Response);
                Console.Write("Y coordinate: ");
                Response = Console.ReadLine();
                Y = Convert.ToInt32(Response);
            }
            if (Response == "inventory")
            {
                Inventory.InventoryMenu();
                continue;
            }
            if (Response == "exit")
            {
                Console.Clear();

                new TownHub();
            }
            Console.Clear();
        }
    }
}