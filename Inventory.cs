// Responsible for displaying and managing player's inventory
public class Inventory
{
    public static Item LeatherArmor { get; set; }
    public static Item Sword { get; set; }
    public static Item HealthPotion { get; set; }
    public static Item Bow { get; set; }
    public static Item ChainmailArmor { get; set; }
    public static Item GoblinHead { get; set; }
    public static bool IsEquipped { get; set; }
    public static int ItemsInitializedNumber { get; set; }
    public static List<Item> InventoryList { get; set; }
    public static string Response { get; set; } 
    public Inventory()
    {
        LeatherArmor = new LeatherArmor();

        Sword = new Sword();

        HealthPotion = new HealthPotion();

        Bow = new Bow();

        ChainmailArmor = new ChainmailArmor();

        GoblinHead = new GoblinHead();

        InventoryList = new List<Item>() { Sword, LeatherArmor, HealthPotion, HealthPotion, HealthPotion };

        foreach (Item inventoryItem in InventoryList)
        {
            if (inventoryItem == LeatherArmor) Console.WriteLine($"{inventoryItem} (Equipped)");
            else if (inventoryItem == Sword) Console.WriteLine($"{inventoryItem} (Equipped)");
        }

    }
    public static void InventoryCheck()
    {
        string response;

        while (true)
        {
            if (Combat.IsInCombat == true)
            {
                Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

                foreach (Item inventoryItem in InventoryList)
                {
                    if (IsEquipped == false)
                    {
                        Console.WriteLine($"{inventoryItem}");
                    }
                    else if (IsEquipped == true)
                    {
                        Console.WriteLine($"{inventoryItem} (Equipped)");
                    }
                    else Console.WriteLine($"{inventoryItem}");
                }
                Console.WriteLine("Type the name of the item for more information, or type exit to exit the inventory.");

                response = Console.ReadLine();

                if (response == "exit" || response == "Exit")
                {
                    break;
                }
                if (response == "healthpotion" || response == "HealthPotion")
                {
                    while (true)
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP.");

                        response = Console.ReadLine();

                        if (response == "use" || response == "Use")
                        {
                            Console.WriteLine("Use health potion?");

                            response = Console.ReadLine();

                            if (response == "yes")
                            {
                                Console.WriteLine("Health potion used! You restore 5 HP!");
                                Character.CharacterHealthPoints = Character.CharacterHealthPoints + 5;
                                break;
                            }
                            if (response == "no")
                            {
                                break;
                            }
                        }
                        else continue;
                    }
                }
                else
                {
                    Console.WriteLine("That item can't be used or interacted with in combat!");
                    continue;
                }
            }
            Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

            foreach (Item inventoryItem in InventoryList)
            {
               if (ItemsInitializedNumber == 0 && inventoryItem == LeatherArmor || ItemsInitializedNumber == 0 && inventoryItem == Sword)
               {
                    Console.WriteLine($"{inventoryItem} (Equipped)");
               }
                else if (IsEquipped == false)
                {
                    if (inventoryItem == Bow && Response == "bow" || inventoryItem == Bow && Response == "Bow")
                    {
                        Console.WriteLine($"{Bow}");
                    }
                    else if (inventoryItem == Sword && Response == "sword" || inventoryItem == Sword && Response == "Sword")
                    {
                        Console.WriteLine($"{Sword}");
                    }
                    else if (inventoryItem == LeatherArmor && Response == "leatherarmor" || inventoryItem == LeatherArmor && Response == "LeatherArmor")
                    {
                        Console.WriteLine($"{LeatherArmor}");
                    }
                    else if (inventoryItem == ChainmailArmor && Response == "chainmailarmor" || inventoryItem == ChainmailArmor && Response == "ChainmailArmor")
                    {
                        Console.WriteLine($"{ChainmailArmor}");
                    }
                    else Console.WriteLine($"{inventoryItem}");

                }
                else if (IsEquipped == true)
                {
                    if (inventoryItem == Bow)
                    {
                        if (Response == "bow" || inventoryItem == Bow && Response == "Bow")
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                    }
                    else if (inventoryItem == Sword)
                    {
                        if (inventoryItem == Bow && Response == "sword" || Response == "Sword")
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                    }
                    else if (inventoryItem == LeatherArmor)
                    {
                        if (inventoryItem == Bow && Response == "leatherarmor" || Response == "LeatherArmor")
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                    }
                    else if (inventoryItem == ChainmailArmor)
                    {
                        if (Response == "chainmailarmor" || inventoryItem == Bow && Response == "ChainmailArmor")
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                    }
                    else Console.WriteLine($"{inventoryItem}");
                }
                else Console.WriteLine($"{inventoryItem}");
            }
            ItemsInitializedNumber++;

            Console.WriteLine("Type the name of the item for more information, or type 'exit' to exit the inventory.");

            response = Console.ReadLine();
            Console.Beep(800, 100);

            if (response == "equip")
            {
                Console.WriteLine("Which item do you want to equip?");

                response = Console.ReadLine();

                Response = response;
                IsEquipped = true;
                continue;
            }
            if (response == "unequip")
            {
                Console.WriteLine("Which item do you want to unequip?");
                response = Console.ReadLine();
                Response = response;
                IsEquipped = false;
                continue;
            }
            if (response == "exit")
            {
                Console.Clear();
                break;
            }
            if (response == "bow" || response == "Bow")
            {
                Weapon bow = new Bow();

                Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG.");
            }
            if (response == "sword" || response == "Sword")
            {
                Weapon sword = new Sword();

                Console.WriteLine($"A common sword. Deals {sword.WeaponDamage} DMG.");
            }
            if (response == "leatherarmor" || response == "LeatherArmor")
            {
                Armor leatherArmor = new LeatherArmor();

                Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");
            }
            if (response == "ChainmailArmor" || response == "chainmailarmor")
            {
                Armor chainmailArmor = new ChainmailArmor();

                Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP.");
            }
            if (response == "healthpotion" || response == "HealthPotion")
            {
                Console.WriteLine("A red health potion. Heals 5 HP.");
            }
        }
    }
}

