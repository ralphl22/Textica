// Responsible for displaying and managing player's inventory
public class Inventory
{
    public static List<Item> InventoryList { get; set; }
    public static Item LeatherArmor { get; set; }
    public static Item Sword { get; set; }
    public static Item HealthPotion { get; set; }
    public static Item Bow { get; set; }
    public static Item ChainmailArmor { get; set; }
    public static Item GoblinHead { get; set; }
    public static bool IsItemEquipped { get; set; } 
    public static bool IsLeatherArmorEquipped { get; set; }
    public static bool IsSwordEquipped { get; set; }
    public static bool IsBowEquipped { get; set; }
    public static bool IsChainmailArmorEquipped { get; set; }
    
    public Inventory()
    {
        // Intializes inventory items and creates the player's inventory
        IsLeatherArmorEquipped = true;

        IsSwordEquipped = true;

        Bow = new Bow();

        Sword = new Sword();

        HealthPotion = new HealthPotion();

        LeatherArmor = new LeatherArmor();

        ChainmailArmor = new ChainmailArmor();

        GoblinHead = new GoblinHead();

        InventoryList = new List<Item>() { Sword, LeatherArmor, HealthPotion, HealthPotion, HealthPotion, ChainmailArmor };

        // Calls the method which determines if the relevant armor items are in the players inventory. If they are, the player gets the AP for that specific armor; if they are not, the player's AP is 0.
        IsInInventory();
    }
    // Displays the contents of the player's inventory, and the amount of items in it. Allows the player to equip and unequip items, see item descriptions, and exit the menu.
    public static void InventoryMenu()
    {
        string response;

        while (true)
        {
            // If player is in combat, they will be able to use everything in their inventory except for unequipping or equipping items, and can only use certain items
            if (Combat.IsInCombat == true)
            {
                Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

                foreach (Item inventoryItem in InventoryList)
                {
                    if (inventoryItem == LeatherArmor)
                    {
                        if (IsLeatherArmorEquipped == true)
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                        else if (IsLeatherArmorEquipped == false)
                        {
                            Console.WriteLine($"{inventoryItem}");
                        }
                        else Console.WriteLine($"{inventoryItem}");
                    }
                    else if (inventoryItem == Sword)
                    {
                        if (IsSwordEquipped == true) Console.WriteLine($"{inventoryItem} (Equipped)");
                        else Console.WriteLine($"{inventoryItem}");
                    }
                    else if (IsItemEquipped == false)
                    {
                        if (inventoryItem == Bow && IsBowEquipped == false) Console.WriteLine($"{inventoryItem}");

                        else if (inventoryItem == ChainmailArmor && IsChainmailArmorEquipped == false)
                        {
                            Console.WriteLine($"{inventoryItem}");

                        }
                        else Console.WriteLine($"{inventoryItem}");
                    }
                    else if (IsItemEquipped == true)
                    {
                        if (inventoryItem == Bow && IsBowEquipped == true) Console.WriteLine($"{inventoryItem} (Equipped)");
                        else if (inventoryItem == ChainmailArmor && IsChainmailArmorEquipped == true)
                        {
                            Console.WriteLine($"{inventoryItem} (Equipped)");
                        }
                        else Console.WriteLine($"{inventoryItem}");
                    }
                }
                Console.WriteLine("What do you want to do with your inventory?");

                response = Console.ReadLine();

                if (response == "help" || response == "Help") Console.WriteLine("Type 'use' to use item, or type 'exit' to exit inventory.");
                if (response == "exit" || response == "Exit") break;
                if (response == "use" || response == "Use")
                {
                    while (true)
                    {
                        Console.WriteLine("What item do you want to use?");

                        response = Console.ReadLine();

                        if (response == "healthpotion" || response == "HealthPotion")
                        {
                            while (true)
                            {
                                Console.WriteLine("Use health potion?");

                                response = Console.ReadLine();

                                if (response == "yes")
                                {
                                    Console.WriteLine("Health potion used! You restore 5 HP!");
                                    Character.CharacterHealthPoints += 5;
                                    break;
                                }
                                if (response == "no")
                                {
                                    break;
                                }
                                else continue;
                            }
                        }
                        else continue;
                    }
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
                                Character.CharacterHealthPoints += 5;
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
                    Console.WriteLine("That doesn't seem to work!");
                    continue;
                }
            }
            // Default behavior of inventory while not in combat: see item count, equip/unquip item, get item description, and exit inventory
            Console.Clear();

            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Inventory ({InventoryList.Count} Items):");

            foreach (Item inventoryItem in InventoryList)
            {
                if (inventoryItem == LeatherArmor)
                {
                    if (IsLeatherArmorEquipped == true)
                    {
                        Console.WriteLine($"{inventoryItem} (Equipped)");
                    }
                    else if (IsLeatherArmorEquipped == false)
                    {
                        Console.WriteLine($"{inventoryItem}");
                    }
                    else Console.WriteLine($"{inventoryItem}");
                }
                else if (inventoryItem == Sword)
                {
                    if (IsSwordEquipped == true) Console.WriteLine($"{inventoryItem} (Equipped)");
                    else Console.WriteLine($"{inventoryItem}");
                }
                else if (IsItemEquipped == false)
                {
                    if (inventoryItem == Bow && IsBowEquipped == false) Console.WriteLine($"{inventoryItem}");

                    else if (inventoryItem == ChainmailArmor && IsChainmailArmorEquipped == false) 
                    {
                        Console.WriteLine($"{inventoryItem}");

                    }
                    else Console.WriteLine($"{inventoryItem}");
                }
                else if (IsItemEquipped == true)
                {
                    if (inventoryItem == Bow && IsBowEquipped == true) Console.WriteLine($"{inventoryItem} (Equipped)");
                    else if (inventoryItem == ChainmailArmor && IsChainmailArmorEquipped == true)
                    {
                        Console.WriteLine($"{inventoryItem} (Equipped)");
                    }
                    else Console.WriteLine($"{inventoryItem}");
                }
            }
            Console.WriteLine("What do you want to do with your inventory?");

            response = Console.ReadLine();
            Console.Beep(800, 100);

            if (response == "help" || response == "Help") Console.WriteLine("Type item name for more information; type 'equip' or 'unequip' to equip and unequip item; or type 'exit' to exit inventory.");
            if (response == "equip")
            {
                while (true)
                {
                    Console.WriteLine("Which item do you want to equip?");

                    response = Console.ReadLine();

                    if (response == "bow" || response == "Bow")
                    {
                        if (IsBowEquipped == true)
                        {
                            Console.WriteLine("Bow is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsBowEquipped = true;
                    }
                    else if (response == "sword" || response == "Sword")
                    {
                        if (IsSwordEquipped == true)
                        {
                            Console.WriteLine("Sword is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsSwordEquipped = true;
                    }
                    else if (response == "leatherarmor" || response == "LeatherArmor")
                    {
                        if (IsChainmailArmorEquipped == true)
                        {
                            Console.WriteLine("ChainmailArmor is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        if (IsLeatherArmorEquipped == true)
                        {
                            Console.WriteLine("LeatherArmor is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsLeatherArmorEquipped = true;
                        Character.CharacterArmorPoints = 5;
                    }
                    else if (response == "ChainmailArmor" || response == "chainmailarmor")
                    {
                        if (IsLeatherArmorEquipped == true)
                        {
                            Console.WriteLine("LeatherArmor is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        if (IsChainmailArmorEquipped == true)
                        {
                            Console.WriteLine("ChainmailArmor is already equipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsChainmailArmorEquipped = true;
                        Character.CharacterArmorPoints = 10;
                    }
                    else if (response == "exit" || response == "Exit") break;
                    else continue;
                    break;
                }
                if (response == "exit" || response == "Exit") continue;
                IsItemEquipped = true;
                continue;
            }
            if (response == "unequip")
            {
                while (true)
                {
                    Console.WriteLine("Which item do you want to unequip?");
                    response = Console.ReadLine();

                    if (response == "bow" || response == "Bow")
                    {
                        if (IsBowEquipped == false)
                        {
                            Console.WriteLine("Bow is already unequipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsBowEquipped = false;
                    }
                    else if (response == "sword" || response == "Sword")
                    {
                        if (IsSwordEquipped == false)
                        {
                            Console.WriteLine("Sword is already unequipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsSwordEquipped = false;
                    }
                    else if (response == "leatherarmor" || response == "LeatherArmor")
                    {
                        if (IsLeatherArmorEquipped == false)
                        {
                            Console.WriteLine("LeatherArmor is already unequipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsLeatherArmorEquipped = false;
                        Character.CharacterArmorPoints = 0;
                    }
                    else if (response == "ChainmailArmor" || response == "chainmailarmor")
                    {
                        if (IsChainmailArmorEquipped == false)
                        {
                            Console.WriteLine("ChainmailArmor is already unequipped!");
                            Console.ReadKey(true);
                            continue;
                        }
                        IsChainmailArmorEquipped = false;
                        Character.CharacterArmorPoints = 0;
                    }
                    else if (response == "exit" || response == "Exit") break;
                    else continue;
                    break;
                }
                if (response == "exit" || response == "Exit") continue;
                IsItemEquipped = false;
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
            Console.ReadKey(true);
        }
    }
    public static void IsInInventory()
    {
        if (InventoryList.Contains(LeatherArmor))
        {
            Character.CharacterArmorPoints = 5;
        }
        else if (InventoryList.Contains(ChainmailArmor))
        {
            Character.CharacterArmorPoints = 10;
        }
        else Character.CharacterArmorPoints = 0;
    }
}

