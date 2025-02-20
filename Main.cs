// Entry point to get the whole game running
Main main = new Main();

public class Main
{
     public Main()
     {
        // mainMenu instance commented out to save time on debugging, and because the MainMenu class is fine as is.

        //new MainMenu();

        new Character();
        new TownHub();
     }
}
