# Monopoly_2019
Projet de Design Pattern

Contributors:
-AUBRY Corentin
-DUVERGER Leopold
-GOLDSCHIELD Jérémy

PATTERN USE :
-- MVC
-- Observer
-- Factory
-- Singleton

Explaination of the pattern MVC :

We use the model View Controller for the projet. With this we can easily display the information and the board. The controller manage the game and each time it's necessary call the view (the method of the view ) to diplay usefull information for the player.


Explaination of the pattern Observer :

There are 2 observers in the project : one for the player and another for the dices.
For the player: The observer notify each time the value of the position or money are modified.
For the dice: The observer notify each time the value of the dices change ( each time rolling dices ).

We use this observer to easily display the modification of money or position of a player and the value of the dice.
That way it's not necessary when some methods change this value, to create something to do the display.
We are sure that the player is notify of the modification.


Explaination of the pattern Singleton :

There are 2 singleton in the project : one for the dices in the SingletonDice class and one for the board in the Board class.
We use them to make sure that there is a single instance for the board and the dices.

To do so, we use a method that checks if there is an instance of the dices or board created. If there is none, it creates an instace of the object by calling its constructor. Else it returns the existing one.
This method is called when we instanciate the dices int the Board class and when we instanciate the board int the Game class.
