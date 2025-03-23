// Responsible for hostile NPC monsters
public class Monster
{
    public string MonsterClass { get; set; }
    public float MonsterHealthPoints { get; set; }
    public float MonsterArmorPoints { get; set; }
    public float MonsterSpeedPoints { get; set; }
    public float MonsterDamage { get; set; }
    public float MonsterAccurarcy { get; set; }
    public Monster(string monsterClass, float monsterHealthPoints, float monsterArmorPoints, float monsterSpeedPoints)
    {
        MonsterClass = monsterClass;

        MonsterHealthPoints = monsterHealthPoints;

        MonsterArmorPoints = monsterArmorPoints;

        MonsterSpeedPoints = monsterSpeedPoints;
    }
    public void MonsterStatus()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"{MonsterClass}");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"HP: {MonsterHealthPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write($"AP: {MonsterArmorPoints} ");

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine($"SPD: {MonsterSpeedPoints} ");

        Console.ResetColor();
    }
}
public class DefaultMonster : Monster
{
    public DefaultMonster() : base("Default Monster", 0, 0, 0)
    {

    }
}
public class GoblinFighter : Monster
{
    public GoblinFighter() : base("Goblin Fighter", 10, 0, 3)
    {

    }
}
public class GoblinArcher : Monster
{
    public GoblinArcher() : base("Goblin Archer", 5, 0, 4)
    {

    }
}
