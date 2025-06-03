# AugMonia – Jeu en Réalité Augmentée

Bienvenue dans **AugMonia**, un jeu en réalité augmentée où vous devez affronter des araignées virtuelles à l'aide de votre téléphone Samsung !

## Description

Dans ce jeu, vous incarnez un chasseur de monstres. Votre mission : **tuer toutes les araignées générées via le scan d'une carte**. Pour y parvenir, vous devrez :

1. Lancer un dé.
2. Scanner une carte spéciale.
3. Affronter le bon nombre d'araignées.
4. Les vaincre en tapant sur votre écran pour lancer des boules explosives.

Le jeu utilise **Unity** (version 3.37) et nécessite un téléphone **Samsung** de **10e à 15e génération**.

---

## Prérequis

Avant de commencer, assurez-vous d’avoir :

* L'appplication **Unity** avec la bonne version : 3.37
* Un **téléphone Samsung** (de génération 10 à 15).
* Un **ordinateur avec ADB** (Android Debug Bridge) installé pour vérifier la connexion.
* Un câble USB pour connecter le téléphone à l’ordinateur.
* Le fichier **`augMonia`** situé dans le dossier **apk_build** (fourni sur le dépôt GitHub).

---

## 🔧 Installation

1. **Connectez votre téléphone à l’ordinateur.**

2. Vérifiez qu’il est bien détecté avec la commande suivante :

   ```bash
   adb devices
   ```

   Si votre appareil apparaît dans la liste, tout est bon.

3. Installez l’APK sur votre téléphone :

   ```bash
   adb install augMonia.apk
   ```

---

## Comment jouer

Une fois le jeu lancé, suivez ces étapes :

### 1. Interface de démarrage

* Appuyez sur **"Démarrer le jeu"**.

### 2. Définir un plan

* Suivez les instructions à l'écran pour définir une **zone de jeu** dans votre environnement réel.

### 3. Lancer le dé

* Un dé virtuel apparaît. Lancez-le.
* La valeur obtenue est enregistrée dans le **canvas** du jeu situé en haut à gauche de l'écran.

### 4. Scanner une carte

* Scannez une **carte spéciale (image cible fournie dans le rapport)**.
* Le jeu génère **autant de monstres (araignées)** que le nombre obtenu sur le dé.

### 5. Tuer les araignées

* Tapez rapidement sur votre écran : cela lance des **boules explosives**.
* Quand une boule touche une araignée, elle meurt.
* Continuez jusqu’à ce **qu’il n’en reste plus aucune**.

### 🏆 Victoire !

* Vous avez tué toutes les araignées ? Bravo, **vous avez gagné !**

---

## Développement

* Le jeu a été développé avec **Unity 3.37**.
* Le projet complet est disponible sur **GitHub** : \[Lien du dépôt ici].

