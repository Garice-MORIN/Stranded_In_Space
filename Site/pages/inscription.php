<html lang="fr">
<head>
    <link href="..\pages_css\accueil.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />
    <title>Stranded In Space</title>
</head>
<body>
    <nav class="menu" style="height: 90px;">
        <img src="..\image\popcorn1.png" class="pop">
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
        <img src="..\image\popcorn2.png" class="pop">
    </nav>
    <p>
        <?php

            //connexion à la base de données:
        $BDD = array();
        $BDD['host'] = "localhost";
        $BDD['user'] = "root";
        $BDD['pass'] = "";
        $BDD['db'] = "joueurs";
        $mysqli = mysqli_connect($BDD['host'], $BDD['user'], $BDD['pass'], $BDD['db']);
        if(!$mysqli) {
            echo "Connexion non établie.";
            exit;
        }
            //la table est créée avec les paramètres suivants:
            //champ "id": en auto increment pour un id unique, peux vous servir pour une identification future
            //champ "pseudo": en varchar de 0 à 25 caractères
            //champ "mdp": en char fixe de 32 caractères, soit la longueur de la fonction md5()
            //fin création automatique
        //par défaut, on affiche le formulaire (quand il validera le formulaire sans erreur avec l'inscription validée, on l'affichera plus)
        $AfficherFormulaire=1;
        //traitement du formulaire:
        if(isset($_POST['pseudo'],$_POST['mdp'])){//l'utilisateur à cliqué sur "S'inscrire", on demande donc si les champs sont défini avec "isset"
            if(empty($_POST['pseudo'])){//le champ pseudo est vide, on arrête l'exécution du script et on affiche un message d'erreur
                echo "Le champ Pseudo est vide.";
            } elseif(!preg_match("#^[a-z,0-9]+$#",$_POST['pseudo'])){//le champ pseudo est renseigné mais ne convient pas au format qu'on souhaite qu'il soit
                //soit: que des lettres minuscule + des chiffres (je préfère personnellement enregistrer le pseudo de mes membres en minuscule afin de ne pas avoir deux pseudo identique mais différents comme par exemple: Admin et admin)
                echo "Le Pseudo doit être renseigné en lettres minuscules sans accents, sans caractères spéciaux.";
            } elseif(strlen($_POST['pseudo'])>25){//le pseudo est trop long, il dépasse 25 caractères
                echo "Le pseudo est trop long, il dépasse 25 caractères.";
            } elseif(empty($_POST['mdp'])){//le champ mot de passe est vide
                echo "Le champ Mot de passe est vide.";
            } elseif(mysqli_num_rows(mysqli_query($mysqli,"SELECT * FROM membres WHERE pseudo='".$_POST['pseudo']."'"))==1){//on vérifie que ce pseudo n'est pas déjà utilisé par un autre membre
                echo "Ce pseudo est déjà utilisé.";
            } else {
                //toutes les vérifications sont faites, on passe à l'enregistrement dans la base de données:
                if(!mysqli_query($mysqli,"INSERT INTO membres SET pseudo='".$_POST['pseudo']."', mdp='".md5($_POST['mdp'])."'")){//on crypte le mot de passe avec la fonction propre à PHP: md5()
                    echo "Une erreur s'est produite: ".mysqli_error($mysqli);
                } else {
                    echo "Vous vous êtes inscrit avec succès!";
                    //on affiche plus le formulaire
                    $AfficherFormulaire=0;
                    echo "Vous pouvez retourner sur la page d'accueil maintenant!";
                }
            }
        }
        if($AfficherFormulaire==1){
            ?>
            <!-- 
            La balise <form> sert à dire que c'est un formulaire
            on lui demande de faire fonctionner la page inscription.php une fois le bouton "S'inscrire" cliqué
            on lui dit également que c'est un formulaire de type "POST"

            Les balises <input> sont les champs de formulaire
            type="text" sera du texte
            type="password" sera des petits points noir (texte caché)
            type="submit" sera un bouton pour valider le formulaire
            name="nom de l'input" sert à le reconnaitre une fois le bouton submit cliqué
             -->
            <br />
            <form method="post" action="inscription.php">
                Pseudo (a-z0-9) : <input type="text" name="pseudo">
                <br />
                Mot de passe : <input type="password" name="mdp">
                <br />
                <input type="submit" value="S'inscrire">
            </form>
            <p>
                Déjà inscrit? Connectez-vous en cliquant <a href="../pages/connexion.php">ici.</a>
            </p>
            <?php } ?>
    </p>
</body>
</html>