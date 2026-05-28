class Hero(string name, int healthPoints, int attackPower, IHeroClass heroClass) : Character(name, healthPoints, attackPower)
{
    public IHeroClass HeroClass { get; } = heroClass;
}
