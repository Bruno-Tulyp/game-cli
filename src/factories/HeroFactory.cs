using game_cli.src.enums;

class HeroFactory
{
    private static readonly Dictionary<HeroType, Func<string, Hero>> Heroes = new()
    {
        {HeroType.Warrior, (name) => new Warrior(name)},
        {HeroType.Magician, (name) => new Magician(name)},
        {HeroType.Thief, (name) => new Thief(name)}
    };
    
    public static Hero CreateHero(HeroType heroType, string name)
    {
        if (!Heroes.TryGetValue(heroType, out var createHero))
        {
            throw new ArgumentException("Invalid hero type");
        }

        return createHero(name);
    }
}
