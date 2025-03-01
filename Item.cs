// Contains items useable by the player character
public class Item : Inventory
{

}
public class Weapon : Item
{
    public float WeaponDamage { get; set; }

    public Weapon(float weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }
}
public class Sword : Weapon
{
    public Sword() : base(10)
    {

    }
}
public class Bow : Weapon
{
    public Bow() : base(5)
    {

    }
}
public class Armor : Item
{

}
public class ChainMailArmor : Armor
{
    public ChainMailArmor()
    {
        Character.CharacterArmorPoints = 10;
    }
}
public class LeatherArmor : Armor
{
    public LeatherArmor()
    {
        Character.CharacterArmorPoints = 5;
    }
}
public class HealthPotion : Item
{

}