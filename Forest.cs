// Allows the user to interact with and take quests from NPCs in the city
public class Forest
{
    private string Response { get; set; }
    private int X { get; set; }
    private int Y { get; set; }
    private bool AreCoordinatesInitialized {  get; set; }  
    public Forest()
    {
        Character character = new Character();

        while (true)
        {
            if (AreCoordinatesInitialized == false)
            {
                X = 500; Y = -500;
                AreCoordinatesInitialized = true;
            }
   
            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"You see yourself before a lush, dense forest. What do you want to do? Your current position is ({X}, {Y}).");

            if (AreCoordinatesInitialized == true && X > 500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                X = 500;
                Thread.Sleep(3000);
                Console.Clear();
                continue;
            }
            if (AreCoordinatesInitialized == true && Y < -500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                Y = -500;
                Thread.Sleep(3000);
                Console.Clear();
                continue;
            }
            if (AreCoordinatesInitialized == true && X > 500 && Y < -500)
            {
                Console.WriteLine("You can't go any further! Try again!");
                X = 500; Y = -500;
                Console.ReadKey(true);
                Console.Clear();
                continue;
            }
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
                        if (Response == "y") 
                        {
                            Console.Clear();
                            new Combat(); 
                        }
                        if (Response == "n") break;
                        else continue;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing you can see here other than endless forest and greenery.");
                    Console.ReadKey(true);                
                }
            }
            if (Response == "move up") Y = Y + 100;
            if (Response == "move down") Y = Y - 100;
            if (Response == "move left") X = X - 100;
            if (Response == "move right") X = X + 100;
            if (Response == "go to")
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
                Inventory.InventoryCheck();
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