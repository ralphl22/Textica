// Area where the player can buy and sell items from the merchant
public class Merchant
{
    private string Response { get; set; }
    // Contains the items that the merchant has in stock - it will automatically update as the merchant gains or loses items
    private static List<Item> MerchantList = new List<Item>() { Inventory.Bow, Inventory.Sword, Inventory.HealthPotion, Inventory.HealthPotion, Inventory.HealthPotion, Inventory.HealthPotion, Inventory.HealthPotion, Inventory.LeatherArmor, Inventory.ChainmailArmor };
    public Merchant()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------------");

            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Merchant Alicia: Greetings, adventurer! Looking to buy some of my wares, or are you looking to sell?");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "buy")
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("----------------------------------------------");

                    Character.CharacterLevelAndExperience();
                    Character.CharacterStatus();

                    Console.WriteLine("----------------------------------------------");

                    Console.WriteLine($"Merchant Alicia: Here are my wares:");

                    foreach (Item merchantItem in MerchantList)
                    {
                        if (merchantItem == Inventory.Bow) Console.WriteLine($"{merchantItem} - 15 G");
                        else if (merchantItem == Inventory.Sword) Console.WriteLine($"{merchantItem} - 15 G");
                        else if (merchantItem == Inventory.HealthPotion) Console.WriteLine($"{merchantItem} - 10 G");
                        else if (merchantItem == Inventory.LeatherArmor) Console.WriteLine($"{merchantItem} - 20 G");
                        else if (merchantItem == Inventory.ChainmailArmor) Console.WriteLine($"{merchantItem} - 30 G");
                        else Console.WriteLine($"{merchantItem} - ??? G");
                    }
                    Console.WriteLine("Type an item's name for more information, or type 'exit' to exit.");

                    Response = Console.ReadLine();

                    if (Response == "bow" && MerchantList.Contains(Inventory.Bow) || Response == "Bow" && MerchantList.Contains(Inventory.Bow))
                    {
                        Weapon bow = new Bow();

                        Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Purchase item?");

                            Response = Console.ReadLine();

                            if (Response == "yes" && Character.GoldAmount >= 15)
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(Inventory.Bow);
                                MerchantList.Remove(Inventory.Bow);
                                Character.GoldAmount = Character.GoldAmount - 15;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 15)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "sword" && MerchantList.Contains(Inventory.Sword) || Response == "Sword" && MerchantList.Contains(Inventory.Sword))
                    {
                        Weapon sword = new Sword();

                        Console.WriteLine($"Common bow used by hunters. Deals {sword.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Purchase item?");

                            Response = Console.ReadLine();

                            if (Response == "yes" && Character.GoldAmount >= 15)
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(Inventory.Sword);
                                MerchantList.Remove(Inventory.Sword);
                                Character.GoldAmount = Character.GoldAmount - 15;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 15)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "leatherarmor" && MerchantList.Contains(Inventory.LeatherArmor) || Response == "LeatherArmor" && MerchantList.Contains(Inventory.LeatherArmor))
                    {
                        Armor leatherArmor = new LeatherArmor();

                        Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Purchase item?");

                            Response = Console.ReadLine();

                            foreach (Item inventoryItem in Inventory.InventoryList)
                            {
                                if (Response == "yes" && Character.GoldAmount >= 20 && inventoryItem != Inventory.LeatherArmor)
                                {
                                    Console.WriteLine("Item purchased!");
                                    Inventory.InventoryList.Add(Inventory.LeatherArmor);
                                    MerchantList.Remove(Inventory.LeatherArmor);
                                    Character.GoldAmount = Character.GoldAmount - 20;
                                    Inventory.InventoryMenu();
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    break;
                                }
                                if (Response == "yes" && Character.GoldAmount >= 20 && inventoryItem == Inventory.LeatherArmor)
                                {
                                    Console.WriteLine("You already have leather armor!");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    continue;
                                }
                                if (Response == "yes" && Character.GoldAmount < 20)
                                {
                                    Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    continue;
                                }
                                if (Response == "no") break;
                                else continue;
                            }
                            break;
                        }
                        continue;
                    }
                    if (Response == "healthpotion" && MerchantList.Contains(Inventory.HealthPotion) || Response == "HealthPotion" && MerchantList.Contains(Inventory.HealthPotion))
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Purchase item?");

                            Response = Console.ReadLine();

                            if (Response == "yes" && Character.GoldAmount >= 10)
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(Inventory.HealthPotion);
                                MerchantList.Remove(Inventory.HealthPotion);   
                                Character.GoldAmount = Character.GoldAmount - 10;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 10)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "ChainmailArmor" && MerchantList.Contains(Inventory.ChainmailArmor) || Response == "chainmailarmor" && MerchantList.Contains(Inventory.ChainmailArmor))
                    {
                        Armor chainmailArmor = new ChainmailArmor();

                        Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Purchase item?");

                            Response = Console.ReadLine();
                            if (Response == "yes" && Character.GoldAmount >= 30)
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(Inventory.ChainmailArmor);
                                MerchantList.Remove(Inventory.ChainmailArmor);
                                Character.GoldAmount = Character.GoldAmount - 30;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 30)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "exit")
                    {
                        Console.Beep(800, 100); 

                        Response = null;

                        break;
                    }
                    if (Response == "inventory")
                    {
                        Inventory.InventoryMenu();

                        continue;
                    }
                }
            }
            if (Response == "sell")
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine($"Inventory ({Inventory.InventoryList.Count} Items):");

                    foreach (Item inventoryItem in Inventory.InventoryList)
                    {
                        if (inventoryItem == Inventory.Bow) Console.WriteLine($"{inventoryItem} - 15 G");
                        else if (inventoryItem == Inventory.Sword) Console.WriteLine($"{inventoryItem} - 15 G");
                        else if (inventoryItem == Inventory.HealthPotion) Console.WriteLine($"{inventoryItem} - 10 G");
                        else if (inventoryItem == Inventory.LeatherArmor) Console.WriteLine($"{inventoryItem} - 20 G");
                        else if (inventoryItem == Inventory.ChainmailArmor) Console.WriteLine($"{inventoryItem} - 30 G");
                        else Console.WriteLine($"{inventoryItem}");
                    }
                    Console.WriteLine("Type the name of the item to sell, or type exit to exit the sell menu.");

                    Response = Console.ReadLine();

                    if (Response == "bow" || Response == "Bow")
                    {
                        Weapon bow = new Bow();

                        Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Sell item for 15 G?");

                            Response = Console.ReadLine();
                            if (Response == "yes")
                            {
                                Console.WriteLine("Item sold for 15 G!");
                                Inventory.InventoryList.Remove(Inventory.ChainmailArmor);
                                Character.GoldAmount = Character.GoldAmount + 15;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "sword" || Response == "Sword")
                    {
                        Weapon sword = new Sword();

                        Console.WriteLine($"A common sword. Deals {sword.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Sell item for 15 G?");

                            Response = Console.ReadLine();
                            if (Response == "yes")
                            {
                                Console.WriteLine("Item sold for 15 G!");
                                Inventory.InventoryList.Remove(Inventory.Sword);
                                Character.GoldAmount = Character.GoldAmount + 15;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "leatherarmor" || Response == "LeatherArmor")
                    {
                        Armor leatherArmor = new LeatherArmor();

                        Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Sell item for 20 G?");

                            Response = Console.ReadLine();
                            if (Response == "yes")
                            {
                                Console.WriteLine("Item sold for 20 G!");
                                Inventory.InventoryList.Remove(Inventory.LeatherArmor);
                                Character.GoldAmount = Character.GoldAmount + 20;
                                Inventory.IsInInventory();
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "healthpotion" || Response == "HealthPotion")
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Sell item for 10 G?");

                            Response = Console.ReadLine();
                            if (Response == "yes")
                            {
                                Console.WriteLine("Item sold for 10 G!");
                                Inventory.InventoryList.Remove(Inventory.HealthPotion);
                                Character.GoldAmount = Character.GoldAmount + 10;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "ChainmailArmor" || Response == "chainmailarmor")
                    {
                        Armor chainmailArmor = new ChainmailArmor();

                        Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        while (true)
                        {
                            Console.WriteLine($"Sell item for 30 G?");

                            Response = Console.ReadLine();
                            if (Response == "yes")
                            {
                                Console.WriteLine("Item sold for 30 G!");
                                Inventory.InventoryList.Remove(Inventory.ChainmailArmor);
                                Inventory.IsInInventory();
                                Character.GoldAmount = Character.GoldAmount + 30;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "no") break;
                            else continue;
                        }
                        continue;
                    }
                    if (Response == "inventory")
                    {
                        Inventory.InventoryMenu();

                        continue;
                    }
                    if (Response == "exit")
                    {
                        Console.Beep(800, 100); 

                        Console.Clear();

                        Response = null;

                        break;
                    }
                }
            }
            if (Response == "exit")
            {
                Console.Clear(); 

                new TownHub();
            }
            if (Response == "inventory")
            {
                Inventory.InventoryMenu();

                continue;
            }
        }
    }
}