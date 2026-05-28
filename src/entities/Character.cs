class Character(string name, int healthPoints, int attackPower)
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

        Console.WriteLine($"{Name} takes {damage} damage from {attacker.Name} and has {HealthPoints} HP left.");
    }

    public void Heal(int healAmount)
    {
        HealthPoints += healAmount;

        if (HealthPoints > MaxHealthPoints)
        {
            HealthPoints = MaxHealthPoints;
        }

        Console.WriteLine($"{Name} heals for {healAmount} and has {HealthPoints} HP now.");
    }
}
