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
            <a href="..\pages\accueil.html">Stranded In Space</a>
        </div>
        <ul class="links">
            <li>
                <a href="#">Le jeu</a>
                <!--on voudra rajouter un menu deroulant, avec possibilité d'accéder a différentes parties de la page en cliquant sur le lien-->
            </li>
            <li>
                <a href="#">L'histoire du groupe</a> 
                <!--on voudra rajouter un menu deroulant, avec possibilité d'accéder a différentes parties de la page en cliquant sur le lien-->
            </li>
            <li>
                <a href="#">Highscores</a>
                <!--ici on laissera le lien tel quel pour accéder directement aux meilleurs scores des joueurs-->
            </li>
        </ul>
        <img src="..\images\popcorn2.png" class="pop">
    </nav>
    </br></br></br></br></br>
    <p>
        <?php 
            session_start();
            //accès a la base de données
            $BDD = array();
            $BDD['host'] = "localhost";
            $BDD['user'] = "root";
            $BDD['pass'] = "";
            $BDD['db'] = "joueurs";
            $mysqli = mysqli_connect($BDD['host'], $BDD['user'], $BDD['pass'], $BDD['db']);
            if(isset($_POST['connexion'])) { // si le bouton connexion est appuyé
                $Pseudo = htmlentities($_POST['pseudo'], ENT_QUOTES, "ISO-8859-1"); // le htmlentities() passera les guillemets en entités HTML, ce qui empêchera les injections SQL
                $MotDePasse = htmlentities($_POST['mdp'], ENT_QUOTES, "ISO-8859-1");
                //on se connecte à la base de données:
                $mysqli = mysqli_connect("localhost", "pseudo", "mdp", "joueurs");
                //on vérifie que la connexion s'effectue correctement:
                if(!$mysqli){
                    echo "Erreur de connexion à la base de données.";
                } else {
                    // on fait maintenant la requête dans la base de données pour rechercher si ces données existe et correspondent:
                    $Requete = mysqli_query($mysqli,"SELECT * FROM membres WHERE pseudo = '".$Pseudo."' AND mdp = '".md5($MotDePasse)."'");
                    // si il y a un résultat, mysqli_num_rows() nous donnera alors 1
                    // si mysqli_num_rows() retourne 0 c'est qu'il a trouvé aucun résultat
                    if(mysqli_num_rows($Requete) == 0) {
                        echo "Ce compte n'a pas l'air d'exister pour le moment, pas de chance";
                    } else {
                        // on ouvre la session avec $_SESSION:
                        $_SESSION['pseudo'] = $Pseudo;
                        header("Location: ../pages/accueil.html"); // Redirection du navigateur
                        exit;
                    }
                }
            }
        ?>
        <form action="connexion.php" method="post">
            Pseudo: <input type="text" name="pseudo" value="" required/>
            <br />
            Mot de passe: <input type="password" name="mdp" value="" required/>
            <br />
            <input type="submit" name="connexion" value="Connexion" />
        </form>
    </p>
</body>
</html>