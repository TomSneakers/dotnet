## Documentation sur le projet API

L'API BookStore permet de gérer les livres d'une librairie en fournissant des fonctionnalités pour créer, lire, mettre à jour et supprimer des livres.

## Endpoints

### GET /api/books

Récupère tous les livres de la librairie.

#### Réponse

- Code de statut : 200 OK
- Corps de la réponse : Un tableau JSON contenant tous les livres de la librairie.

Exemple de réponse :

```json
[
  {
    "id": 1,
    "title": "Harry Potter and the Philosopher's Stone",
    "author": "J.K. Rowling",
    "publisher": "Bloomsbury Publishing"
  },
  {
    "id": 2,
    "title": "To Kill a Mockingbird",
    "author": "Harper Lee",
    "publisher": "J. B. Lippincott & Co."
  },
  ...
]
```

### GET /api/books/{id}

Récupère un livre spécifique en fonction de son identifiant.

#### Paramètres de l'URL

id (obligatoire) : L'identifiant du livre à récupérer.

#### Réponse

- Code de statut : 200 OK si le livre est trouvé, 404 Not Found sinon.
- Corps de la réponse : Un objet JSON représentant le livre trouvé.

### POST /api/books

Crée un nouveau livre dans la librairie.

#### Corps de la requête

Un objet JSON représentant le livre à créer.

- title (obligatoire) : Le titre du livre.
- author (optionnel) : L'auteur du livre.
- publisher (optionnel) : L'éditeur du livre.

#### Exemple de corps de la requête

```json
{
  "title": "Harry Potter and the Philosopher's Stone",
  "author": "J.K. Rowling",
  "publisher": "Bloomsbury Publishing"
}
```

#### Réponse

- Code de statut : 201 Created si le livre est créé avec succès.
- En-tête de réponse : L'en-tête Location contient l'URL du livre créé.
- Corps de la réponse : Un objet JSON représentant le livre créé.

#### Exemple de réponse

```json
{
  "id": 1,
  "title": "Harry Potter and the Philosopher's Stone",
  "author": "J.K. Rowling",
  "publisher": "Bloomsbury Publishing"
}
```

### PUT /api/books/{id}

Met à jour les propriétés d'un livre existant.

#### Paramètres de l'URL

id (obligatoire) : L'identifiant du livre à mettre à jour.

#### Corps de la requête

Un objet JSON représentant les nouvelles valeurs des propriétés du livre :

- title (optionnel) : Le nouveau titre du livre.
- author (optionnel) : Le nouvel auteur du livre.
- publisher (optionnel) : Le nouvel éditeur du livre.

#### Exemple de corps de la requête

```json
{
  "title": "Harry Potter and the Philosopher's Stone",
  "author": "J.K. Rowling",
  "publisher": "Bloomsbury Publishing"
}
```

#### Réponse

- Code de statut : 200 OK si le livre est mis à jour avec succès, 404 Not Found sinon.
- Corps de la réponse : Un objet JSON représentant le livre mis à jour.

#### Exemple de réponse

```json
{
  "id": 1,
  "title": "Harry Potter and the Philosopher's Stone",
  "author": "J.K. Rowling",
  "publisher": "Bloomsbury Publishing"
}
```

### DELETE /api/books/{id}

Supprime un livre existant de la librairie.

#### Paramètres de l'URL

id (obligatoire) : L'identifiant du livre à supprimer.

#### Réponse

- Code de statut : 204 No Content si le livre est supprimé avec succès, 404 Not Found sinon.

### Gestion des erreurs

En cas d'erreur, l'API renverra une réponse avec un code de statut approprié et un message d'erreur dans le corps de la réponse.

#### Exemple de réponse en cas d'erreur

```json
{
  "message": "Le livre demandé n'a pas été trouvé."
}
```

Ceci conclut la documentation de l'API BookStore. N'hésitez pas à vous référer à cette documentation pour utiliser correctement l'API et effectuer les opérations nécessaires sur les livres de la librairie. Si vous avez des questions supplémentaires, n'hésitez pas à les poser.
