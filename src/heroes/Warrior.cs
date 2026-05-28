class Warrior(string name) : Hero(name, 120, 18)
{
    public override string ClassName => "Guerrier";
    public override ISpecialAbility SpecialAbility { get; } = new WarriorAbility();
}
