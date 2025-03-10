﻿// Contains items useable by the player character
public class Item : Inventory
{

}
public class Weapon : Item
{
    public float WeaponDamage { get; set; }
    public int WeaponCost { get; set; }
    public Weapon(float weaponDamage, int weaponCost)
    {
        WeaponDamage = weaponDamage;
    }
}
public class Sword : Weapon
{
    public Sword() : base(10, 10)
    {

    }
}
public class Bow : Weapon
{
    public Bow() : base(5, 5)
    {

    }
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
public class ChainmailArmor : Armor
{
    public ChainmailArmor() : base(10)
    {
        Character.CharacterArmorPoints = 10;
    }
}
public class LeatherArmor : Armor
{
    public LeatherArmor() : base(5)
    {
        Character.CharacterArmorPoints = 5;
    }
}
public class HealthPotion : Item
{
    public HealthPotion()
    {

    }
}