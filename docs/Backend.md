# Documentation

Le backend est subdivisé en 4 parties principales : Domaine, Infrastructure, Application et Api. Le Domaine contient les entités de la base de données (Modèles). L'infrastructure contient la base de données et les répertoires. L'Application contient les services et la logique pour interagir avec la base de données. L'API contient les contrôleurs et la logique pour interagir avec l'utilisateur.

> Lors de cet entretien, vous n'aurez pas à toucher à la partie Infrastructure et devrez vous concentrer sur les parties Application et Api.

Veuillez noter que cette structure est une "Clean Architecture" très simplifiée. Dans une application réelle, nous aurions plus d'abstractions et une plus grande séparation des préoccupations.

## L'application

L'application est subdivisée en 3 parties principales : Livres, Membres et Prêts. Chaque partie contient une commande et un dossier de modèles. Le dossier de commandes contient les commandes pouvant être exécutées sur l'entité comme récupérer une liste, mettre à jour ou créer. Le dossier "Models" contient les DTOs renvoyés par les commandes.

Une commande se compose d'une classe `IRequest` qui contient les paramètres de la requête et d'une classe `IRequestHandler` qui contient la logique pour exécuter la commande.

## L'API

L'API se compose uniquement de contrôleurs. Chaque contrôleur contient la logique pour interagir avec l'utilisateur et la logique pour exécuter les commandes. Chacun des points de terminaison des contrôleurs est documenté à l'aide de Swagger et peut également être trouvé ci-dessous.

### Endpoints

#### Books

<details><summary><code>GET</code><code><b> /api/books</b></code> <code><i> : Return all books.</i></code></summary></details>
<details><summary><code>POST</code><code><b> /api/books</b></code> <code><i>(Create a new book)</i></code></summary></details>
<details><summary><code>PUT</code><code><b> /api/books/{id}</b></code> <code><i>(Update a given book)</i></code></summary></details>
<details><summary><code>DELETE</code><code><b> /api/books/{id}</b></code> <code><i>(Delete a given book)</i></code></summary></details>

#### Members

<details><summary><code>GET</code><code><b> /api/members</b></code> <code><i>(Return all members)</i></code></summary></details>
<details><summary><code>POST</code><code><b> /api/members</b></code> <code><i>(Adds a new member)</i></code></summary></details>
<details><summary><code>PUT</code><code><b> /api/members/{id}</b></code> <code><i>(Update a given member)</i></code></summary></details>

#### Loans

<details><summary><code>GET</code><code><b> /api/loans</b></code> <code><i>(Return all loans)</i></code></summary></details>
<details><summary><code>POST</code><code><b> /api/loans</b></code> <code><i>(Issue a new loan)</i></code></summary></details>
<details><summary><code>PUT</code><code><b> /api/loans/{id}</b></code> <code><i>(Update a given loan)</i></code></summary></details>
