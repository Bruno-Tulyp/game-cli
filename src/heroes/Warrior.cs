class Warrior(string name) : Hero(name, 90, 10)
{
    public override string ClassName => "Guerrier";
    public override ISpecialAbility SpecialAbility { get; } = new WarriorAbility();
}
