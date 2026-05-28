abstract class Character(string name, int healthPoints, int attackPower)
{
    public string Name { get; } = name;
    public int HealthPoints { get; set; } = healthPoints;
    private int MaxHealthPoints { get; } = healthPoints;
    private int MinHealthPoints { get; } = 0;
    public int AttackPower { get; } = attackPower;

    public bool IsAlive()
    {
        return HealthPoints > MinHealthPoints;
    }

    public void TakeDamage(int damage, Character attacker)
    {
        HealthPoints -= damage;

        if (HealthPoints < MinHealthPoints)
        {
            HealthPoints = MinHealthPoints;
        }

        Console.WriteLine($"{Name} subit {damage} dégâts de {attacker.Name} et a {HealthPoints} PV restants.");
    }

    public void Heal(int healAmount)
    {
        HealthPoints += healAmount;

        if (HealthPoints > MaxHealthPoints)
        {
            HealthPoints = MaxHealthPoints;
        }

        Console.WriteLine($"{Name} se soigne de {healAmount} et a {HealthPoints} PV maintenant.");
    }
}
