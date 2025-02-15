// Serves as the main menu of the game - user can press any key to continue to character creation 
public class MainMenu 
{
    public MainMenu()
    {
        
        Console.Title = "Legend of Textica";

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("LEGEND OF TEXTICA");
        Console.WriteLine();
        Console.Write("PRESS ANY KEY TO CONTINUE");

        Console.ReadKey(true);

        Console.Beep(800, 100);

        Console.ForegroundColor= ConsoleColor.White;

        Console.Clear();
    }
}
