# game-cli

Petit jeu en ligne de commande écrit en C# / .NET. Ce README distingue ce que le jeu est censé devenir de ce qui est déjà présent dans le code.

## Prérequis

- .NET SDK 10.0 ou compatible avec la cible `net10.0`
- Un terminal ouvert à la racine du projet

## Lancer le projet

Depuis la racine du dépôt, exécutez :

```bash
dotnet restore
dotnet run
```

Pour vérifier que tout compile avant de lancer le jeu :

```bash
dotnet build
```

## Ce que le jeu est censé être

Le projet vise un jeu de combat tour par tour.

1. Le joueur saisit son nom.
2. Le joueur choisit une classe de héros.
3. Le combat démarre contre un ennemi.
4. Les affrontements se déroulent round par round jusqu'à la victoire ou la défaite.
5. Les compétences spéciales et les cooldowns donnent une identité forte à chaque classe.

## Ce qui est déjà implémenté

Aujourd'hui, le programme console fait encore une version très réduite de ce flux.

1. L'application affiche la liste des classes de héros disponibles.
2. L'utilisateur choisit un nom et son héros par numéro.
3. Un héros est instancié via [HeroFactory](src/factories/HeroFactory.cs).
4. Un ennemi Goblin est instancié via [EnemyFactory](src/factories/EnemyFactory.cs).
5. L'utilisateur choisit parmi une action disponible et l'exécute

Ce qui manque encore pour correspondre à la vision cible :

- une vraie boucle de combat round par round
- l'alternance des actions entre héros et ennemi
- la gestion complète de la victoire et de la défaite
- le choix de l'ennemi au lieu d'un Goblin imposé

## Patterns de conception utilisés

### Factory

Le projet utilise le pattern Factory pour centraliser la création des objets de jeu. Au lieu d'instancier les classes directement dans le flux principal, la logique de création est regroupée dans des factories dédiées.

Ce que cela apporte :

- évite de disperser les `new` dans le code d'exécution
- simplifie l'ajout de nouveaux héros ou ennemis
- isole la logique de création du reste du jeu

Classes concernées :

- [HeroFactory](src/factories/HeroFactory.cs)
- [EnemyFactory](src/factories/EnemyFactory.cs)
- [Hero](src/entities/Hero.cs)
- [Enemy](src/entities/Enemy.cs)
- [Warrior](src/heroes/Warrior.cs)
- [Magician](src/heroes/Magician.cs)
- [Thief](src/heroes/Thief.cs)
- [Goblin](src/enemies/Goblin.cs)
- [Orc](src/enemies/Orc.cs)
- [Troll](src/enemies/Troll.cs)

### Template Method

Le pattern Template Method est présent dans la gestion des compétences spéciales. La classe abstraite définit l'algorithme commun de l'utilisation d'une compétence, puis délègue l'effet concret à une méthode abstraite implémentée par chaque compétence.

Ce que cela apporte :

- garantit un comportement commun pour toutes les compétences
- évite de dupliquer la logique de cooldown et de validation
- permet de spécialiser uniquement la partie variable de l'attaque

Classes concernées :

- [SpecialAbilityBase](src/abilities/SpecialAbilityBase.cs)
- [ISpecialAbility](src/abilities/ISpecialAbility.cs)
- [MagicianAbility](src/abilities/MagicianAbility.cs)
- [WarriorAbility](src/abilities/WarriorAbility.cs)
- [ThiefAbility](src/abilities/ThiefAbility.cs)

### Strategy

Les compétences spéciales sont également exposées comme des objets `ISpecialAbility` attachés aux héros. Chaque héros possède une instance concrète d'`ISpecialAbility` (par ex. `WarriorAbility`, `MagicianAbility`, `ThiefAbility`) ; l'utilisation d'une interface distincte permet d'échanger ou de tester des comportements sans modifier la hiérarchie des héros — c'est l'esprit du pattern Strategy.

Ce que cela apporte :

- sépare l'algorithme de la compétence de la classe `Hero`
- facilite les tests unitaires et le remplacement des compétences à l'exécution
- rend le comportement spécial interchangeable sans toucher à la hiérarchie de classes

Classes concernées :

- [ISpecialAbility](src/abilities/ISpecialAbility.cs)
- [SpecialAbilityBase](src/abilities/SpecialAbilityBase.cs)
- [MagicianAbility](src/abilities/MagicianAbility.cs)
- [WarriorAbility](src/abilities/WarriorAbility.cs)
- [ThiefAbility](src/abilities/ThiefAbility.cs)
- [Hero](src/entities/Hero.cs)

## Structure du projet

- [src/cli/Program.cs](src/cli/Program.cs) : point d'entrée de l'application
- [src/entities](src/entities) : hiérarchie des entités du jeu
- [src/heroes](src/heroes) : classes concrètes de héros
- [src/enemies](src/enemies) : classes concrètes d'ennemis
- [src/factories](src/factories) : usines de création des objets de jeu
- [src/abilities](src/abilities) : compétences spéciales des héros
- [src/enums](src/enums) : types disponibles pour le menu et les factories

## Remarque

Le projet utilise aussi l'héritage et le polymorphisme de façon importante, mais les deux patterns les plus clairement matérialisés par l'architecture actuelle sont la Factory et le Template Method.
