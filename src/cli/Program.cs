using game_cli.src.enums;

ConsoleGameHelper.DisplayGameInfo();

string heroName = ConsoleGameHelper.ReadHeroName();
HeroType selectedHeroType = ConsoleGameHelper.ReadHeroType();

Hero player = HeroFactory.CreateHero(selectedHeroType, heroName);
Enemy enemy = EnemyFactory.CreateEnemy(EnemyType.Goblin);

ConsoleGameHelper.DisplayGameSummary(player, enemy);

BattleAction selectedAction = ConsoleGameHelper.ReadBattleAction();

Dictionary<BattleAction, Action> actions = new()
{
    [BattleAction.Attack] = () =>
        enemy.TakeDamage(player.AttackPower, player),
    [BattleAction.UseSpecialAbility] = () =>
        player.SpecialAbility.Use(player, enemy),
    [BattleAction.Quit] = () =>
        Console.WriteLine("Vous avez quitté la partie.")
};

if (actions.TryGetValue(selectedAction, out var action))
{
    action();
}
