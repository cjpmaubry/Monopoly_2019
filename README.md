# Monopoly_2019
Projet de Design Pattern

Contributors:
-AUBRY Corentin
-DUVERGER Leopold
-GOLDSCHIELD Jérémy

PATTERN USE :
--> MVC
--> Observer
--> Factory
--> Singleton

Explaination of the pattern Observer :

They are 2 observers in the projet : one for the player and another for the dice.
For the player: The observer notify each time the value of the position or money are modify.
For the dice: The observer notify each time the value of the dice change ( each time rolling dice ).

We use this observer to easily display the modification of money or position of a player and the value of the dice.
That way it's not necessary when some methods change this value, to create something to do the display.
We are sure that the player is notify of the modification.
