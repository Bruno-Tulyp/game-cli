abstract class SpecialAbilityBase : ISpecialAbility
{
    public abstract int Cooldown { get; }
    public int RemainingCooldown { get; private set; }
    public abstract string Name { get; }
    public abstract string Description { get; }

    public void ReduceCooldown()
    {
        if (RemainingCooldown > 0)
        {
            RemainingCooldown--;
        }
    }

    public bool CanUse()
    {
        return RemainingCooldown == 0;
    }

    public void Use(Character caster, Character target)
    {
        if (!CanUse())
        {
            Console.WriteLine($"{Name} est en cooldown pour {RemainingCooldown} tour(s).");

            return;
        }

        ApplyEffect(caster, target);

        RemainingCooldown = Cooldown;
    }

    protected abstract void ApplyEffect(Character caster, Character target);
}
