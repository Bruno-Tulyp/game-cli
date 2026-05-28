class ThiefAbility : SpecialAbilityBase
{
    private const double CriticalChance = 0.3;
    private const int DamageMultiplier = 2;
    public override int Cooldown => 2;
    public override string Name => "Coup critique";
    public override string Description => $"Inflige une attaque rapide qui a {CriticalChance * 100}% de chances de faire {DamageMultiplier} fois votre puissance d'attaque, avec un cooldown de {Cooldown} tours";

    protected override void ApplyEffect(Character caster, Character target)
    {
        Random rand = new();
        bool isCritical = rand.NextDouble() < CriticalChance;
        int damage = isCritical ? caster.AttackPower * DamageMultiplier : caster.AttackPower;

        Console.WriteLine($"{caster.Name} utilise '{Name}' sur {target.Name}, infligeant {(isCritical ? "un coup critique" : "une attaque normale")} de {damage} dégâts.");

        target.TakeDamage(damage, caster);
    }
}
