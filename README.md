# envgraphique-eval2-simulateurATM
Projet d'ecole. Application WPF MVVM full stack.

Packages: 
EntityFramework.6.2.0,
EntityFramework.6.4.4,
Microsoft.Bcl.AsyncInterfaces.5.0.0,
Microsoft.Extensions.DependencyInjection.5.0.2,
Microsoft.Extensions.DependencyInjection.Abstractions.5.0.0
System.Runtime.CompilerServices.Unsafe.4.5.3
System.Threading.Tasks.Extensions.4.5.4
WPFCustomControl (Autheur Maxime Cesare-Zurek)

## Installation
Ouvrir Microsoft SQL Server Management Studio, restaurer la base de donnees a partir de /Database.Backup/ATM.bak. (Nom de la base de donnés: ATM)
Ouvrir la  solution avec visual studio (EnvGraphique.Evaluation2.ATM.sln).
Installer les packages requis.
Lancer l'application

## Comptes enregistrés dans la base de données

Client :	
	Username: maxzurek	Password: 1234
Admin:		
	Username: admin		Password: 1234

## Fonctionalités système

Appuyez sur le bouton Déconnection pour fermer la session

## Fonctionalités client

```
Accueil:	Affichage des soldes de tout les comptes du client. Appuyer sur "Afficher Transactions" pour voir la liste de toutes les transactions du compte ciblé.
Retrait: 	Sélectionnez le compte source, entrez le montant et appuyer sur "Valider".
Dépôt: 	 	Sélectionnez le compte cible, entrez le montant et appuyer sur "Valider".
Virement: 	Sélectionnez le compte source, sélectionnez le compte cible, entrez le montant et appuyer sur "Valider".
Paiement:	Sélectionnez le compte source, entrez le numéro de facture (numéro fictif puisqu'il ny a pas de facture enregistrées, pas de validation), 
          	entrez le montant et appuyer sur "Valider".
```

## Fonctionalités administrateur

```
Gestion:
	Bloquer utilisateur:				Sélectionnez l utilisateur a bloquer et appuyez sur "Bloquer".
	Débloquer utilisateur:				Sélectionnez l utilisateur a debloquer et appuyez sur "Debloquer".
	Ajouter argent papier:				Entrez le montant a ajouter au guichet et appuyez sur "Valider".
	Montant disponnible:				Affichage du montant disponnible dans le guichet pour les retraits.
	Payer intérêts des comptes épargnes:		Appuyer sur le boutton pour éffectuer l'opération. 
	Augmenter les soldes des marges de crédit:	Appuyer sur le boutton pour éffectuer l'opération.

Créer utilisateur:	Entrez les informations requises et appuyer sur enregistrer.
Créer compte:		Choisisez le l'utilisateur à qui le compte appartiendra, choisisez le type de compte, entrez les informations requises et appuyer sur "Enregistrer". 
			(Le montant de retrait maximal, le taux d'intérêt et les frais de paiement facture sont les valeurs par défaut utilisées pour effectuer les 					calculs dans l'énnoncé)
Transactions:		Affichage de la liste des transactions de tout les comptes enregistrés dans la base de données. 
			Il est possible de filtrer les transactions par : Id; Type de transaction; Montant; Date; Id compte cible et Id compte source.
Prélèvements:		Sélectionnez un compte hypothéquecaire enregistré dans le système comme compte source, entrez le montant à prélever et appuyez sur "Valider".
```
## License
[MIT](https://choosealicense.com/licenses/mit/)
