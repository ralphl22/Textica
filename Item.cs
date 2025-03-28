﻿// Contains items useable by the player character
public class Item;
public class Weapon : Item
{
    public float WeaponDamage { get; private set; }
    public Weapon(float weaponDamage, int weaponCost)
    {
        WeaponDamage = weaponDamage;
    }
}
public class Sword : Weapon
{
    public Sword() : base(10, 10) { }
}
public class Bow : Weapon
{
    public Bow() : base(5, 5) { }
}
public class Armor : Item
{
    public int ArmorPoints { get; set; }
    public int ArmorCost { get; set; }
    public Armor(int armorPoints)
    {
        ArmorPoints = armorPoints;
    }
}
public class LeatherArmor : Armor
{
    public LeatherArmor() : base(5) { }
}
public class ChainmailArmor : Armor
{
    public ChainmailArmor() : base(10) { }

}
public class HealthPotion : Item
{
    public HealthPotion() { }
}
public class GoblinHead : Item
{
    public static int Amount { get; set; }
}