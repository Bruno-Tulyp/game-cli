using game_cli.src.enums;

static class ConsoleGameHelper
{
    public static void DisplayGameInfo()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         Bienvenue dans game-cli        ");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Un petit jeu de combat tour par tour en C#.");
        Console.WriteLine("Choisissez un héros, puis sélectionnez vos actions pendant le combat.");
        Console.WriteLine();
    }

    public static string ReadHeroName()
    {
        while (true)
        {
            Console.Write("Entrez le nom de votre héros : ");

            string? name = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine();

                return name;
            }

            Console.WriteLine("Le nom du héros ne peut pas être vide.");
            Console.WriteLine();
        }
    }

    public static HeroType ReadHeroType()
    {
        Console.WriteLine("Choisissez la classe de votre héros :");
        Console.WriteLine();

        foreach (HeroType heroType in Enum.GetValues<HeroType>())
        {
            Console.WriteLine($"{(int)heroType}. {GetHeroTypeLabel(heroType)}");
        }

        Console.WriteLine();

        return ReadEnumChoice<HeroType>(
            "Entrez le numéro correspondant à la classe choisie : ",
            GetHeroTypeLabel,
            "Veuillez entrer un numéro valide correspondant à une classe de héros.");
    }

    public static BattleAction ReadBattleAction()
    {
        Console.WriteLine("Actions disponibles :");
        Console.WriteLine();

        foreach (BattleAction action in Enum.GetValues<BattleAction>())
        {
            Console.WriteLine($"{(int)action}. {GetBattleActionLabel(action)}");
        }

        Console.WriteLine();

        return ReadEnumChoice<BattleAction>(
            "Choisissez votre action : ",
            GetBattleActionLabel,
            "Veuillez entrer un numéro valide correspondant à une action.");
    }

    public static void DisplayCharacterInfo(Character character)
    {
        Console.WriteLine($"- Nom : {character.Name}");
        Console.WriteLine($"- Points de vie: {character.HealthPoints}");
        Console.WriteLine($"- Puissance d'attaque: {character.AttackPower}");
    }

    public static void DisplayHeroInfo(Hero hero)
    {
        Console.WriteLine("Héros sélectionné :");
        Console.WriteLine();
        Console.WriteLine($"- Classe : {hero.ClassName}");
        
        DisplayCharacterInfo(hero);

        Console.WriteLine($"- Compétence spéciale : {hero.SpecialAbility.Name} ({hero.SpecialAbility.Description})");
        Console.WriteLine();
    }

    public static void DisplayEnemyInfo(Enemy enemy)
    {
        Console.WriteLine("Ennemi rencontré :");
        Console.WriteLine();

        DisplayCharacterInfo(enemy);

        Console.WriteLine();
    }

    public static void DisplayGameSummary(Hero hero, Enemy enemy)
    {
        DisplayHeroInfo(hero);
        DisplayEnemyInfo(enemy);

        Console.WriteLine("Le combat commence !");
        Console.WriteLine();
    }

    private static TEnum ReadEnumChoice<TEnum>(string prompt, Func<TEnum, string> getLabel, string invalidMessage)
        where TEnum : struct, Enum
    {
        while (true)
        {
            Console.Write(prompt);

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && Enum.IsDefined(typeof(TEnum), value))
            {
                Console.WriteLine();

                return (TEnum)(object)value;
            }

            Console.WriteLine(invalidMessage);
            Console.WriteLine();
        }
    }

    private static string GetLabel<TEnum>(Dictionary<TEnum, string> labelDictionary, TEnum value)
        where TEnum : struct, Enum
    {
        return labelDictionary.TryGetValue(value, out string? label) ? label : value.ToString();
    }

    private static string GetHeroTypeLabel(HeroType heroType)
    {
        Dictionary<HeroType, string> heroTypeLabels = new()
        {
            { HeroType.Warrior, "Guerrier" },
            { HeroType.Magician, "Magicien" },
            { HeroType.Thief, "Voleur" }
        };

        return GetLabel(heroTypeLabels, heroType);
    }

    private static string GetBattleActionLabel(BattleAction action)
    {
        Dictionary<BattleAction, string> battleActionLabels = new()
        {
            { BattleAction.Attack, "Attaquer" },
            { BattleAction.UseSpecialAbility, "Utiliser la compétence spéciale" },
            { BattleAction.Quit, "Quitter" }
        };

        return GetLabel(battleActionLabels, action);
    }
}
