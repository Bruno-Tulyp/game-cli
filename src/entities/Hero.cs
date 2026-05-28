abstract class Hero(string name, int healthPoints, int attackPower) : Character(name, healthPoints, attackPower)
{
    public abstract string ClassName { get; }
    public abstract ISpecialAbility SpecialAbility { get; }
}
