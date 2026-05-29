using game_cli.src.enums;

Console.WriteLine("Jeu CLI - Sélection du héros\n");

foreach (var heroType in Enum.GetValues<HeroType>())
{
    Console.WriteLine($"{(int)heroType}. {heroType}");
}

bool validInput = false;

Hero player;

while (!validInput)
{
    Console.Write("\nEntrez le numéro correspondant au type de héros: ");

    string? input = Console.ReadLine();

    if (int.TryParse(input, out int heroTypeNumber) && Enum.IsDefined(typeof(HeroType), heroTypeNumber))
    {
        HeroType selectedHeroType = (HeroType)heroTypeNumber;

        Console.WriteLine($"Vous avez sélectionné: {selectedHeroType}\n");

        player = HeroFactory.CreateHero(selectedHeroType, "Player");        
        Enemy enemy = EnemyFactory.CreateEnemy(EnemyType.Goblin);

        player.SpecialAbility.Use(player, enemy);

        validInput = true;
    }
    else
    {
        Console.WriteLine("Entrée non valide. Veuillez entrer un numéro valide correspondant à un type de héros.");
    }
}
