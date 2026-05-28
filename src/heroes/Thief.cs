class Thief(string name) : Hero(name, 70, 20)
{
    public override string ClassName => "Voleur";
    public override ISpecialAbility SpecialAbility { get; } = new ThiefAbility();
}
