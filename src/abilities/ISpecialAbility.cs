interface ISpecialAbility
{
    int Cooldown { get; }
    int RemainingCooldown { get; set; }
    string Name { get; }
    string Description { get; }

    bool CanUse();
    void Use(Character caster, Character target);
}