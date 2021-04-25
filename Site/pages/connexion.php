<html lang="fr">
<head>
    <link href="..\pages_css\accueil.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />
    <title>Stranded In Space</title>
</head>
<body>
    <nav class="menu" style="height: 90px;">
        <img src="..\images\popcorn1.png" class="pop">
        <div class="logo">
            <a href="../index.html">Stranded In Space</a>
        </div>
        <ul class="links">
            <li>
                <a href="lejeu.html">Le jeu</a>
            </li>
            <li>
                <a href="#">L'histoire du groupe</a> 
            </li>
            <li>
                <a href="#">Highscores</a>
            </li>
        </ul>
        <img src="..\images\popcorn2.png" class="pop">
    </nav>
    </br></br>
    <p class="text">
        Connexion :
    </p>
    </br></br>
    <p class="text">
        <form action="connexion.php" method="post">
            Pseudo: <input type="text" name="pseudo" value="" required/>
            <br />
            Mot de passe: <input type="password" name="mdp" value="" required/>
            <br />
            <br />
            <input type="submit" name="connexion" value="Connexion" />
        </form>
    </p>
    <p>
        <a href="inscription.php">Pas encore inscrit ?</a>
    </p>
</body>
</html>