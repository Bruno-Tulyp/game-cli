interface ISpecialAbility
{
    int Cooldown { get; }
    int RemainingCooldown { get; }
    string Name { get; }
    string Description { get; }

    void ReduceCooldown();
    bool CanUse();
    void Use(Character caster, Character target);
}
