using game_cli.src.enums;

class EnemyFactory
{
    private static readonly Dictionary<EnemyType, Func<Enemy>> Enemies = new()
    {
        {EnemyType.Goblin, () => new Goblin()},
        {EnemyType.Orc, () => new Orc()},
        {EnemyType.Troll, () => new Troll()}
    };

    public static Enemy CreateEnemy(EnemyType enemyType)
    {
        if (!Enemies.TryGetValue(enemyType, out var createEnemy))
        {
            throw new ArgumentException("Invalid enemy type");
        }

        return createEnemy();
    }
}
