
# Monopoly_2019
### School Project : Design Pattern Lessons


                                    /\/\   ___  _ __   ___  _ __   ___ | |_   _
                                   /    \ / _ \| '_ \ / _ \| '_ \ / _ \| | | | |
                                  / /\/\ \ (_) | | | | (_) | |_) | (_) | | |_| |
                                  \/    \/\___/|_| |_|\___/| .__/ \___/|_|\__, |
                                                           |_|            |___/


Contributors:
- AUBRY Corentin
- DUVERGER Leopold
- GOLDSCHILD Jérémy

### Introduction
This project wad made in order to apply the principles seen during the course on Git and Design Patterns.
The main goal was to create a very simplified Monopoly Game with only :
- dice mechanic
- movable players
- jail and gotojail mechanic
HOWEVER, we went a little further and tried to make a complete fully playable Monopoly Game.
In this version, we have succesfully implemented :
- all the original boxes on a Monopoly Game Board
- money and the ability to buy and own propreties
- luck and community cards (not all of them, only 4 different cards in each)
- propreties, railroads, utilities
- free parking and go
We are only missing the possibility to buy houses, hyhypothec a proprety or trad with other players

## Rules of the game 

In our version of the Monopoly, the game can have from two to four players.
Each player is given a name, 500M of money and starts on the Go box.
Each turn, a player rolls two dices and moves forward by a number of boxes equal to the sum of the dices.
If the two dices roll the same value (double), the player plays again.
If the player gets three double in a row, he is sent to Jail.

When a player lands on a property box, if the box isn't owned, he can choose to buy the property. 
If the property is owned, he can choose to buy it or not. 
If the box is already owned, he has to pay a rent to the player that owns it.

When he lands on the Go To Jail box, the player is sent to Jail.
To escape Jail, the player has to throw the dices and get a double. He can also escape if he fails to get a double three turns in a row, but will haev tp pay 50 M. 
The jail box can also be visited if the player lands on this box after having rolled the dices.

All of the following are automatic and don't require any input from the player :
If the player lands on a box Luck or Community Chest, he draws a card and is required to follow the instructions written on it (Pay money, Receive money, Go to jail, Nothing happens, Go to Go).

If the player lands on a Tax box, he has to pay the amount of the tax.

If the player lands on the Free Park box, he receives the money payed by the players to the taxes, luck cards or community chest cards.

Every time a player passes by the box Go, he receives 20M. If he directly lands on it, he receives double the amount.

End of the game:
When a player is out of money, he is removed from the game and his propreties are unowned.
The game ends when there is only ONE player that still has money left.

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

## Display of the game

When the game is launched, you first have to enter the number of players and their names then the board is displayed.
For each turn, we indicate which player has to play and that he has to press any key to roll the dices. Then the results of the dices are displayed and the board with the new position of the player. Then depending on the box he lands on a display will be made asking for the player for an interaction.
To display the board in the console, we made a method that first display the top row of the board, then the columns and finally the bottom row.
Each box is displayed with three rows.
The board is displayed row by row.

Depending of the category of the box, the background in the console for each box will have a different color:

- Start / Free Park = Green
- Mediterranean Avenue / Baltic avenue = Blue
- Oriental Avenue / Vermont Avenue / Connecticut Avenue = Cyan
- St. Charles Palace / States avenue / Virginia avenue = Magenta
- St James Place / Tennessee Avenue / New York Avenue = Dark Yellow
- Kentucky Avenue / Indiana Avenue / Illinois Avenue = Dark Red
- Atlantic Avenue / Ventnor Avenue / Marvin Gardens = Yellow
- Pacific Avenue / North Carolina Avenue / Pennsylvania Avenue = Dark Green
- Park Place / Board Walk = Dark Blue
- Chance / Community Chest = Dark Magenta
- Tax = Dark Grey
- Jail / Go To Jail = Red
- Railroad / Companies = White

If there are two players, the first one will be displayed on the top row of the box where he is positioned and the second one on the middle row.
If there is a third player, he will be displayed o the bottom row.
If there is a fourth player, he will be displayed on the bottom row too.

All of the display is also managed through the MVC and Observer patterns as explained above.

###Example (without color) of the display of the board with 2 players

+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||        |
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||        |
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||        |
+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------+                                                                                          +--------+
|        |                                                                                          |        |
|        |                                                                                          |        |
|        |                                                                                          |        |
+--------+                                                                                          +--------+
+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||   1    |
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||   2    |
|        ||        ||        ||        ||        ||        ||        ||        ||        ||        ||        |
+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+
