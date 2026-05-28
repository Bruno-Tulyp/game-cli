class MagicianAbility : SpecialAbilityBase
{
    private const double DamageMultiplier = 0.5;
    public override int Cooldown => 3;
    public override string Name => "Éclair";
    public override string Description => $"Foudroie l'ennemi et lui fait perdre {DamageMultiplier * 100}% de ses points de vie actuels, avec un cooldown de {Cooldown} tours";

    protected override void ApplyEffect(Character caster, Character target)
    {
        int damage = (int)(target.HealthPoints * DamageMultiplier);

        Console.WriteLine($"{caster.Name} utilise '{Name}' sur {target.Name}, infligeant {damage} dégâts.");

        target.TakeDamage(damage, caster);
    }
}
