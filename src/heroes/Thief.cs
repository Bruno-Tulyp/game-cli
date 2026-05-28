class Thief(string name) : Hero(name, 90, 14)
{
    public override string ClassName => "Voleur";
    public override ISpecialAbility SpecialAbility { get; } = new ThiefAbility();
}
