// Allows the user to buy and sell items from the merchant
public class Merchant
{
    private string Response { get; set; }
    public Merchant()
    {
        while (true)
        {
            Character.CharacterLevelAndExperience();
            Character.CharacterStatus();

            Console.WriteLine("Merchant: Greetings, adventurer! Looking to buy some of my wares, or are you looking to sell?");

            Response = Console.ReadLine();
            Console.Beep(800, 100);

            if (Response == "buy")
            {
                while (true)
                {
                    Console.WriteLine($"Here are my wares:");

                    Console.WriteLine("Bow - 5 G");
                    Console.WriteLine("Sword - 10 G");
                    Console.WriteLine("HealthPotion - 15 G");
                    Console.WriteLine("LeatherArmor - 25 G");
                    Console.WriteLine("ChainmailArmor - 30 G");
                    Console.WriteLine("Type an item's name for more information, or type exit to exit.");

                    Response = Console.ReadLine();

                    if (Response == "bow" || Response == "Bow")
                    {
                        Weapon bow = new Bow();

                        Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        if (Response == "yes" && Character.GoldAmount >= 5)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new Bow());
                            Character.GoldAmount = Character.GoldAmount - 5;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "yes" && Character.GoldAmount < 5)
                        {
                            Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "sword" || Response == "Sword")
                    {
                        Weapon sword = new Sword();

                        Console.WriteLine($"Common bow used by hunters. Deals {sword.WeaponDamage} DMG.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        if (Response == "yes" && Character.GoldAmount >= 10)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new Bow());
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
                        if (Response == "no") continue;
                    }
                    if (Response == "leatherarmor" || Response == "LeatherArmor")
                    {
                        Armor leatherArmor = new LeatherArmor();

                        Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        foreach (Inventory inventoryItem in Inventory.InventoryList)
                        {
                            if (Response == "yes" && Character.GoldAmount >= 25 && inventoryItem != new LeatherArmor())
                            {
                                Console.WriteLine("Item purchased!");
                                Inventory.InventoryList.Add(new LeatherArmor());
                                Character.GoldAmount = Character.GoldAmount - 25;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount >= 25 && inventoryItem == new LeatherArmor())
                            {
                                Console.WriteLine("You already have leather armor!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            if (Response == "yes" && Character.GoldAmount < 25)
                            {
                                Console.WriteLine($"Not enough gold! You have {Character.GoldAmount} G!");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            break;
                        }
                        if (Response == "no") continue;
                        break;
                    }
                    if (Response == "healthpotion" || Response == "HealthPotion")
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();

                        if (Response == "yes" && Character.GoldAmount >= 15)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new HealthPotion());
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
                        if (Response == "no") continue;
                    }
                    if (Response == "ChainmailArmor" || Response == "chainmailarmor")
                    {
                        Armor chainmailArmor = new ChainmailArmor();

                        Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Purchase item?");

                        Response = Console.ReadLine();
                        if (Response == "yes" && Character.GoldAmount >= 30)
                        {
                            Console.WriteLine("Item purchased!");
                            Inventory.InventoryList.Add(new ChainmailArmor());
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
                        if (Response == "no") continue;
                    }
                    if (Response == "exit") Console.Beep(800, 100); Console.Clear(); break;
                }
            }
            if (Response == "sell")
            {
                while (true)
                {
                    Console.WriteLine($"Inventory ({Inventory.InventoryList.Count} Items):");

                    foreach (Item inventoryItem in Inventory.InventoryList)
                    {
                        Console.WriteLine($"{inventoryItem}");
                    }

                    Console.WriteLine("Type the name of the item to sell it, or type exit to exit the sell menu.");

                    Response = Console.ReadLine();

                    if (Response == "bow" || Response == "Bow")
                    {
                        Weapon bow = new Bow();

                        Console.WriteLine($"Common bow used by hunters. Deals {bow.WeaponDamage} DMG. Sells for 5 G.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Sell item?");

                        Response = Console.ReadLine();

                        if (Response == "yes")
                        {
                            Console.WriteLine("Item sold for 5 G!");
                            Inventory.InventoryList.Remove(new Bow());
                            Character.GoldAmount = Character.GoldAmount + 5;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "sword" || Response == "Sword")
                    {
                        Weapon sword = new Sword();

                        Console.WriteLine($"A common sword. Deals {sword.WeaponDamage} DMG. Sells for 10 G.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Sell item?");

                        Response = Console.ReadLine();

                        if (Response == "yes")
                        {
                            Console.WriteLine("Item sold for 10 G!");
                            Inventory.InventoryList.Remove(new Sword());
                            Character.GoldAmount = Character.GoldAmount + 10;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "leatherarmor" || Response == "LeatherArmor")
                    {
                        Armor leatherArmor = new LeatherArmor();

                        Console.WriteLine($"Typical leather armor that offers full body protection. It provides {leatherArmor.ArmorPoints} AP. Sells for 25 G.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Sell item for 25 G?");

                        Response = Console.ReadLine();

                        foreach (Inventory inventoryItem in Inventory.InventoryList)
                        {
                            if (Response == "yes" && Character.GoldAmount >= 25 && inventoryItem != new LeatherArmor())
                            {
                                Console.WriteLine("Item sold for 25 G!");
                                Inventory.InventoryList.Remove(new LeatherArmor());
                                Character.GoldAmount = Character.GoldAmount + 25;
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }
                            break;
                        }
                        if (Response == "no") continue;
                        break;
                    }
                    if (Response == "healthpotion" || Response == "HealthPotion")
                    {
                        Console.WriteLine("A red health potion. Heals 5 HP. Sells for 15 G.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Sell item for 15 G?");

                        Response = Console.ReadLine();

                        if (Response == "yes")
                        {
                            Console.WriteLine("Item sold for 15 G!");
                            Inventory.InventoryList.Remove(new HealthPotion());
                            Character.GoldAmount = Character.GoldAmount + 15;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "ChainmailArmor" || Response == "chainmailarmor")
                    {
                        Armor chainmailArmor = new ChainmailArmor();

                        Console.WriteLine($"Armor made of interlocking metal rings that provides excellent protection against blows. It provides {chainmailArmor.ArmorPoints} AP. Sells for 30 G.");

                        Console.ReadKey(true);

                        Console.WriteLine($"Sell item for 30 G?");

                        Response = Console.ReadLine();
                        if (Response == "yes")
                        {
                            Console.WriteLine("Item sold for 30 G!");
                            Inventory.InventoryList.Remove(new ChainmailArmor());
                            Character.GoldAmount = Character.GoldAmount + 30;
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        }
                        if (Response == "no") continue;
                    }
                    if (Response == "exit") Console.Beep(800, 100); Console.Clear();  break;
                }
            }
            if (Response == "leave")
            {
                Console.ReadKey(true); Console.Clear(); new TownHub();

            }
        }
    }
}
