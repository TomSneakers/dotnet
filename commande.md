# All commande for .net

## Commande pour prérequis

```bash
dotnet --version //verifie la version
dotnet --list-sdks //liste les sdk installés
```

## Commande pour voir tout les templates

Liste tout les templates

```bash
dotnet new list
```

## Commande pour créer un projet en console

Créer un projet en console

```bash
dotnet new console --use-program-main -o consoleProject

```

## Commande pour lancer le projet

Lance le projet

```bash
dotnet run
```

## Commande CLI

```bash
dotnet new // Initialise un projet
dotnet restore // Restaure les dépendances et les outils d un projet

dotnet build // Compile un projet et toutes ses dépendances

dotnet run // Compile et exécute un projet

dotnet test // Execute les tests d un projet

dotnet publish // Publie un projet pour un déploiement en production

dotnet pack // Crée un paquet NuGet
```

## Commande pour installer un package

```bash
dotnet add package <nom du package>
```

## Commande pour trouver un template

```bash
dotnet new list | grep <nom du template>
```