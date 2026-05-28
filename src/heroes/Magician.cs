class Magician(string name) : Hero(name, 80, 15)
{
    public override string ClassName => "Magicien";
    public override ISpecialAbility SpecialAbility { get; } = new MagicianAbility();
}
