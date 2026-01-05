# 🧙‍♂️ Kata de Code – Harry Potter & Livres d’Occasion

## 🎯 Objectif

Implémenter un service capable de **calculer le prix total d’un panier de livres Harry Potter**, en tenant compte :

* de **réductions** appliquées sur des lots de tomes différents
* de **prix variables**, récupérés depuis une **API externe de livres d’occasion**

L’objectif n’est pas uniquement d’obtenir le bon résultat, mais de proposer un **code clair, testable et bien structuré**.

---

## 📚 Contexte fonctionnel

La saga **Harry Potter** comporte **7 tomes**.

En français:

1. Harry Potter à l’école des sorciers
2. La chambre des secrets
3. Le prisonnier d’Azkaban
4. La coupe de feu
5. L’ordre du Phénix
6. Le prince de sang-mêlé
7. Les reliques de la mort

Un client peut acheter **plusieurs exemplaires de chaque tome**.

⚠️ Harry Potter à l’école des sorciers et Harry potter and the philosopher's stone sont tous deux des tome 1.

Deux exemplaires du **même tome** ne sont **jamais considérés comme différents** pour l’application des réductions.

---

## 💸 Règles de réduction

Les réductions s’appliquent sur des **lots de tomes distincts**.

| Nombre de tomes distincts | Réduction |
| ------------------------- | --------- |
| 2                         | 5 %       |
| 3                         | 10 %      |
| 4                         | 20 %      |
| 5                         | 25 %      |
| 6                         | 30 %      |
| 7                         | 35 %      |

La réduction s’applique sur la **somme réelle des prix** des tomes du lot.

---

## 🌍 API Externe – Livres d’occasion

Une API externe fournit l’accès à un catalogue générique de livres d’occasion.

### 📘 Spécification OpenAPI

```yaml
paths:
  /books/{isbn}:
    get:
      summary: Récupérer un livre d’occasion par ISBN
      parameters:
        - name: isbn
          in: path
          required: true
          schema:
            type: string
      responses:
        '200':
          description: Livre trouvé
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Book'
        '404':
          description: Livre non trouvé

  /books:
    get:
      summary: Rechercher des livres d’occasion
      parameters:
        - name: title
          in: query
          schema:
            type: string
        - name: author
          in: query
          schema:
            type: string
        - name: language
          in: query
          schema:
            type: string
        - name: maxPrice
          in: query
          schema:
            type: number
      responses:
        '200':
          description: Résultat paginé
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Books'

components:
  schemas:
    Book:
      type: object
      properties:
        isbn:
          type: string
        title:
          type: string
        authors:
          type: array
          items:
            type: string
        language:
          type: string
        publicationDate:
          type: string
          format: date
        price:
          type: number

    Books:
      type: array
      items:
        $ref: '#/components/schemas/Book'
```

---

## 📥 Entrée attendue

Le service à implémenter reçoit :

* une **liste de numéros de tome** (valeurs de 1 à 7), représentant les livres ajoutés au panier

Exemple :

```
[1, 1, 2, 3, 5]
```

---

## 📤 Sortie attendue

* le **prix total du panier**

Exemple :

```
42.30
```

---

## 🧪 Exemples de cas de test

### Cas simple

```
Entrée : [1]
Sortie : prix du Tome 1
```

---

### Deux tomes différents

```
Entrée : [1, 2]
Sortie : (prix1 + prix2) - 5 %
```

---

### Doublons

```
Entrée : [1, 1, 2]
Sortie : (prix1 + prix2) - 5 % + prix1
```

---

### Cas complexe

```
Entrée : [1,1,2,2,3,3,4,5]
Résultat attendu :
- regroupement optimal des tomes
```
