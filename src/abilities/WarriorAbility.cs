class WarriorAbility : SpecialAbilityBase
{
    private const double DamageMultiplier = 1.5;
    public override int Cooldown => 2;
    public override string Name => "Frappe lourde";
    public override string Description => $"Inflige une attaque puissante qui fait {DamageMultiplier * 100}% de votre puissance d'attaque, avec un cooldown de {Cooldown} tours";
    
    protected override void ApplyEffect(Character caster, Character target)
    {
        int damage = (int)(caster.AttackPower * DamageMultiplier);

        Console.WriteLine($"{caster.Name} utilise '{Name}' sur {target.Name}, infligeant {damage} dégâts.");

        target.TakeDamage(damage, caster);
    }
}
