# BookStoreAPI

BookStoreAPI est une API de gestion de livres pour une librairie. Elle permet de créer, lire, mettre à jour et supprimer des livres de la base de données.

## Installation

1. Clonez ce dépôt sur votre machine locale.
2. Assurez-vous d'avoir .NET Core SDK installé.
3. Ouvrez une fenêtre de terminal et naviguez jusqu'au répertoire du projet.
4. Exécutez la commande `dotnet restore` pour restaurer les dépendances du projet.
5. Exécutez la commande `dotnet run` pour démarrer l'API.

## Utilisation

Une fois l'API en cours d'exécution, vous pouvez accéder aux endpoints suivants :

- GET /api/books : Récupère tous les livres de la librairie.
- GET /api/books/{id} : Récupère un livre spécifique en fonction de son identifiant.
- POST /api/books : Crée un nouveau livre dans la librairie.
- PUT /api/books/{id} : Met à jour les propriétés d'un livre existant.
- DELETE /api/books/{id} : Supprime un livre existant de la librairie.
- etc ...

Consultez la documentation complète de l'API pour plus de détails sur chaque endpoint et les réponses attendues.

## Auteurs

- Tom Desvignes
