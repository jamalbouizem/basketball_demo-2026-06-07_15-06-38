# Documentation du Projet : Basket

Ce document fait office de guide technique pour le prototype du jeu de Basket demandé dans le cadre du test technique. Il regroupe les informations d'installation, de build, les choix techniques ainsi que les pistes d'amélioration.

## 📊 Informations Générales
* **Temps de développement :** Environ 3 heures
* **Moteur utilisé :** Unity 6 (Version spécifique : `6000.4.10f1` / Unity 6.4)

---

## 🚀 Comment Lancer l'Exécutable
L'exécutable Windows est pré-compilé et disponible à la racine du dossier partagé ou dans le ZIP.
1. Ouvrez le dossier `Build_Windows`.
2. Lancez le fichier `.exe` du projet.
3. Le jeu démarre immédiatement (un timer d'une minute se lance).

---

## 🛠️ Comment Générer l'Exécutable (Build) depuis Unity
Pour ouvrir le projet et générer une nouvelle version de l'exécutable, suivez ces étapes :

1. **Import du projet :**
   * Ouvrez **Unity Hub** (version compatible avec Unity 6).
   * Cliquez sur **Add** > **Add project from disk** et sélectionnez le dossier racine (contenant les dossiers `Assets`, `Packages`, `ProjectSettings`).
2. **Ouverture de la scène :**
   * Dans l'onglet *Project* d'Unity, allez dans `Assets/Scenes/` et ouvrez la scène principale du jeu.
3. **Configuration du Build :**
   * Allez dans le menu supérieur : **File** > **Build Profiles** (ou *Build Settings* selon vos raccourcis).
   * Assurez-vous que la plateforme sélectionnée est **Windows**.
   * Vérifiez que la scène actuelle est bien cochée dans la liste *Scenes in Build*.
4. **Compilation :**
   * Cliquez sur le bouton **Build**.
   * Choisissez ou créez un dossier de destination (ex: `Build_Windows`) et validez. L'exécutable y sera généré en quelques instants.

---

## 📐 Choix Techniques & Implémentation

Le prototype a été développé en environ 3 heures en s'appuyant sur les bases d'un preset Platformer 2D afin d'aller au plus vite vers l'essentiel : la boucle de gameplay (Core Gameplay Loop).

* **Structure de la scène :** Les tiles ont été éditées pour se limiter à un morceau de plateforme épuré, sans ennemis ni éléments perturbateurs.
* **Mécanique de tir :** Le script de contrôle du joueur a été modifié. La logique de saut a été remplacée par une fonction de tir instanciant un prefab de ballon doté de composants physiques (`Rigidbody2D`). La force de projection est appliquée via la méthode `AddForce`.
* **Détection du score :** Le panier est équipé d'un `BoxCollider2D` paramétré en mode *Trigger*. 
* **Calcul du score & UI :** Une couche d'interface graphique (UI) gère le décompte du temps (Timer de 1 minute) et l'affichage du score en temps réel. Le score est incrémenté dynamiquement selon la formule suivante : 
  $$\text{Score} += 1 + \text{Distance au panier}$$
* **Écran de Game Over :** Un écran de fin de partie affichant le score final est entièrement intégré. Actuellement, pour fluidifier l'expérience sans surcharger l'UI, le joueur est automatiquement redirigé vers la scène de jeu après quelques secondes d'attente sur cet écran.

---

## 💡 Pistes d'Amélioration & Évolution du Gameplay

Voici les axes techniques et de game design identifiés pour perfectionner le titre :

### 1. Amélioration de la physique du Panier (Priorité Technique)
* **Problématique actuelle :** Le déclenchement du score par un unique gros trigger au milieu du panier est permissif et peut valider des tirs venant du bas ou des côtés.
* **Solution envisagée :** Implémenter deux `EdgeCollider2D` très fins et physiques sur les rebords gauche et droit du cercle pour simuler les rebonds réalistes du ballon sur l'arceau. Pour la validation du panier, placer un trigger horizontal au centre, couplé à une vérification de la vélocité verticale du ballon ($V_y < 0$). Cela garantira qu'un panier n'est accordé que si le ballon traverse le filet du haut vers le bas.

### 2. Évolutions de la Mécanique de Gameplay
* **Jauge de puissance :** Remplacer le tir direct par un système de *Click-and-Drag* (visée à la souris ou au stick) affichant une parabole de prédiction texturée ou une jauge de force, offrant plus de contrôle et de skill au joueur.
* **Dynamisme du terrain :** Pour valoriser le calcul de score lié à la distance, modifier aléatoirement la position du joueur (ou du panier) après chaque tir réussi. Cela forcerait le joueur à réadapter sa force et sa trajectoire à chaque panier.

### 3. Graphismes, Effets et Jus de Jeu (Juiciness)
* **Feedbacks Visuels :** Ajouter un système de particules de traînée (*Trail Renderer*) derrière le ballon lors d'un tir puissant, et un effet d'étincelles ou de confettis lors d'un panier réussi (notamment un bonus pour un "swish" sans toucher l'arceau).
* **Animations :** Intégrer un shader de déformation de filet ou une courte animation de "vague" sur le filet du panier au moment où le trigger est traversé.
* **Ergonomie UI :** Remplacer la redirection automatique de l'écran Game Over par un bouton physique "Recommencer" et un bouton "Retour au Menu Principal", ainsi qu'un tableau local des 5 meilleurs scores (*Highscores*) pour stimuler la rejouabilité.
