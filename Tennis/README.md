# 🎾 Kata de Code – Tennis scoreboard

## 🎯 Objectif

Implémenter un **système de gestion du score d’une compétition de tennis**, capable de :

* calculer le score d’un match à partir d’un **point marqué par un joueur sur un court** via l'écoute d'une requête HTTP
* agréger les scores de **plusieurs matchs joués simultanément**
* exposer un **tableau de scores global**

---
## 📚 Contexte fonctionnel

Un match de tennis oppose **deux joueurs** et plusieurs matchs peuvent se dérouler dans une même competition. Plusieurs compétitions peuvent être géré en même temps par le système.

### Règles de scoring

* Un jeu se déroule avec les points : `0 → 15 → 30 → 40`
* À `40-40`, on parle de **deuce**
* Après un deuce :

  * un joueur peut prendre l’**avantage**
  * s’il marque à nouveau, il **gagne le jeu**
  * s’il perd le point, retour à **deuce**
* Un **set** est gagné par un joueur lorsqu’il remporte **6 jeux** avec **au moins 2 jeux d’écart**
* Un **match** est gagné par le premier joueur remportant **2 sets**

---
## 📥 Entrée attendue

Le service à implémenter reçoit :
* Un call http via le contrat suivant lors d'un gain de point
```http
POST /competitions/{competitionId}/courts/{courtId}/matches/{matchId}/points
Content-Type: application/json

{
  "playerId": "PLAYER_A"
}
```
* Représente le **point marqué par un joueur**
* Déclenche le calcul du score
* Retourne un affichage complet mis à jour
---
## 📤 Sortie attendue

Le système doit exposer un **tableau de scores de la compétition** au format HTML via un call http avec le contrat suivant:
```http
PUT /competitions/{competitionId}
Content-Type: application/json

{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 40 – 30 Player B</p>
                    <p>Sets : 1 – 0</p>
                </div>

                <div class="court">
                    <h2>Court 2</h2>
                    <p>Player C ADV – 40 Player D</p>
                    <p>Sets : 0 – 0</p>
                </div>
                </div>"
}
```
⚠️Des endpoints supplémentaires peuvent être discutés/implémentés

## 🧪 Exemples de scénarios

### Jeu simple

```
A marque 4 points d’affilée
→ A gagne le jeu

{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 0 - 0 Player B</p>
                    <p>Game : 1 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
```

### Jeu multiple

```
A marque 4 points d’affilée
→ A gagne le jeu
A2 et B2 sont en train de jouer
-> un match avait été lancé

{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 0 - 0 Player B</p>
                    <p>Game : 1 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                <div class="court">
                    <h2>Court 2</h2>
                    <p>Player A2 0 - 0 Player B2</p>
                    <p>Game : 0 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
```

### Deuce et avantage

```
A : 40
B : 40
A marque → avantage A
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A ADV - 40 Player B</p>
                    <p>Game : 0 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
B marque → deuce
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 40 - 40 Player B</p>
                    <p>Game : 0 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
A marque → avantage A
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A ADV - 40 Player B</p>
                    <p>Game : 0 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
A marque → A gagne le jeu
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 0 - 0 Player B</p>
                    <p>Game : 1 - 0</p>
                    <p>Sets : 0 – 0</p>
                </div>

                </div>"
}
```

### Gain de set

```
A gagne 6 jeux
B en gagne 4
→ A gagne le set
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A 0 - 0 Player B</p>
                    <p>Game : 0 - 0</p>
                    <p>Sets : 1 – 0</p>
                </div>

                </div>"
}
```

### Gain de match

```
A gagne 6 jeux et 1 set
B gagne 4 jeux et 0 set
→ A gagne le set
{
  "display":   "<div class="competition">
                <h1>Roland-Garros</h1>

                <div class="court">
                    <h2>Court 1</h2>
                    <p>Player A WIN vs Player B</p>
                    <p>Game : 6 - 1</p>
                    <p>Sets : 2 – 0</p>
                </div>

                </div>"
}
```