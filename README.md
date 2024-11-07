# Triangle_Scalene

Dans ce jeu, les cartes sont réparties en classes. [Famille_Royale, Chevalier, Assassin, Paysan]
- La plus forte remporte le pli.

**A la fin de la partie, on compte le nombre de cartes de chacun, celui qui en a le plus l'emporte !**

 1. Les joueurs choississent une carte parmis leur carte disponible et la confronte à la carte adverse dans *la zone de divulgation* puis sont retournée en meme temps.
 2. Lors d'une confrontation, *En cas d'égalité* on met les deux cartes de coté et le gagnant suivant les récupère.

Entre les **10** cartes remise à chaques joueurs et la carte *BONUS* placée sur le tapis, le jeu compte ***21 cartes*** en tout et pour tout.

Les Sets sont donnés au hazard en début de partie.
SetA appelée "la main forte"
SetB appelée "la main faible"

**Puissance des Cartes :** 
*Au sein de la Famille Royale:*
    prince <-- roi  
    Roi <-- Reine
    reine <-- Prince

    Famille royale <-- Assassin
    Assassin <-- Chevalier
    Chevalier <-- Famille Royale

    Paysans <-- Famille royale
    Paysans <-- Chevalier
    Paysans /--\ Paysans
    Paysans /--\ Assassin

    Les paysans peuvent prendre avantage dans le combat selon leurs effets !
    (À savoir que les effets ne peuvent être activés que dans une égalité de cartes, sauf exception de Hero Invincible et Cheval de Troie)

**Effets de Carte**
    Croissance Explosive = Accroît le nombre de Carte Gagnées
    Grande Revolution = Récupère la carte Bonus
    Cheval de Troie = Récupère la moitié des cartes gagnées de l'adversaire
    Exil = Exil une carte de la main de l'adversaire
    Réinitialisation = Prend les cartes gagnée de l'adversaire et le remets dans les mains correspondantes
    Hero invincible = Peut vaincre toutes les cartes
    Roi = Si contre Prince, gagne.
    Reine = Si contre Roi, gagne.
    Prince = Si contre Reine, gagne.

# Jeu en C# - Instructions de lancement

## Prérequis

Avant de lancer le jeu, vous devez avoir installé le SDK .NET sur votre machine.

### 1. Installer le SDK .NET

Si vous n'avez pas encore installé le SDK .NET, vous pouvez le faire avec la commande suivante :

```bash
sudo apt install dotnet-sdk-8.0

```
vous pouvez installer la dernière version de .NET disponible sur le site officiel de Microsoft : https://dotnet.microsoft.com/download/dotnet-core/8.0

### 2. Vérifier la version de .NET

Après l'installation, vérifiez que la version de .NET est correcte en exécutant la commande suivante

```bash
dotnet --version
```
*Vous devriez voir quelque chose comme 8.0.110.*

### 3. Vérifier la version dans le fichier card_app.csproj

Ouvrez le fichier card_app.csproj et assurez-vous que la version de .NET est correcte. Si votre version de .NET est différente, modifiez la ligne suivante :

```bash
    <TargetFramework>net8.0</TargetFramework>
```

## Lancer le jeu

### Étape 1 : Assurez-vous que vous êtes dans le bon répertoire

Naviguez dans le terminal vers le dossier où se trouve votre fichier `.csproj` (pour un projet) ou `.sln` (pour une solution). Vous pouvez utiliser la commande suivante pour vous déplacer dans le répertoire :

### Étape 2 : Compiler le projet

Si vous n'avez pas encore compilé votre projet, vous devez le faire avant de pouvoir l'exécuter. Utilisez la commande suivante pour compiler votre projet :

```bash
dotnet build
```

### Étape 3 : Lancer le projet

Une fois le projet compilé avec succès, vous pouvez le lancer avec la commande suivante :

```bash
dotnet run
```

Cela démarrera votre jeu. Profitez-en !

