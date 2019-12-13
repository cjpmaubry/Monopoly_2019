
# Monopoly_2019
### Design Pattern Project

Contributors:
- AUBRY Corentin
- DUVERGER Leopold
- GOLDSCHILD Jérémy

## PATTERNS USED 
- MVC
- Observer
- Factory
- Singleton

### Explaination of the pattern MVC :

We use the model View Controller for the projet. With this we can easily display the information and the board. The controller manage the game and each time it's necessary call the view (the method of the view ) to diplay usefull information for the player.


### Explaination of the pattern Observer :

There are 2 observers in the project : one for the player and another for the dices.
For the player: The observer notify each time the value of the position or money are modified.
For the dice: The observer notify each time the value of the dices change ( each time rolling dices ).

We use this observer to easily display the modification of money or position of a player and the value of the dice.
That way it's not necessary when some methods change this value, to create something to do the display.
We are sure that the player is notify of the modification.


### Explaination of the pattern Singleton :

There are 2 singleton in the project : one for the dices in the SingletonDice class and one for the board in the Board class.
We use them to make sure that there is a single instance for the board and the dices.

To do so, we use a method that checks if there is an instance of the dices or board created. If there is none, it creates an instace of the object by calling its constructor. Else it returns the existing one.
This method is called when we instanciate the dices int the Board class and when we instanciate the board int the Game class.

## Use of GitHub

We collaborated on this project through GitHub. To do so, we used the GitHub fuctionality on Visual Studio and the GitHub website.

Each time someone needed to implement a new functionality, we created a new branch from master. If someone else needed to work on something different at the same time, we then created a new branch from the first branch. Once those implementations were done, we merged together these branches than we merged the branch into master.

## Rules of the game 

In our version of the Monopoly, the game can have from two to four players.
Each player is given a name, 500M of money and starts on the Go box.
Each turn, a player rolls two dices and moves forward by a number of boxes equal to the sum of the dices.
If the dices roll the same value (double), the player plays again.

If a player lands on a property box, if the box isn't owned, he can choose to buy the property. If the property is owned, he can choose to buy it or not if he has enough money. If the box is already owned, he has to pay a rent to the player that owns the car.

If he lands on the Go To Jail box, the player is sent to Jail.
To escape Jail, the player has to throw the dices and get a double. He can also escape if he fails to get a double three times in a row. In both cases, he moves forward by the sum of the dices.
The jail box can also be visited if the player lands on this box after having rolled the dices.
If the player gets three double in a row, he is sent to Jail.

If the player lands on a box Luck or Community Chest, he draws a card and is required to follow the instructions written on it (Pay money, Receive money, Go to jail, Nothing happens).

If the player lands on a Tax box, he has to pay the amount of the tax.

If the player lands on the Free Park box, he receives the money payed by the players to the taxes, luck cards or community chest cards.

Every time a player passes by the box Go, he receives 20M. If he directly lands on it, he receives double the amount.

The game ends when there is only one player that still has money left.


