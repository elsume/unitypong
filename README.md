# unitypong
rize gdm project

## description
this project is an attempt at creating atari's pong game using the unity 2d engine. through this project, i hope to learn c# coding and be able to apply it in this game project.

## status log
**01/25/26**

first day working on the project. overall time spent during this session ~4 hours. the main game objects (paddles, walls, and ball) have been made, as well as the scoring ui. the movement script for the paddles work, allowing them to move up and down, albeit in sync. the walls all have colliders on them, so the ball does not escape the border set up by them. the ball's movement script has been made, yet there is an issue with how its velocity behaves, creating unsatisfactory results when trying to code its bouncing behavior. not enough time before the deadline to fix this issue.

**02/01/26**

second day working on the project. first decided to redo the whole game just to check if there would still be issues on the newer attempt. ball movement still was not working as wanted so i just decided to hardcode a constant velocity for the ball. ball now bounces as expected. now, i can continue with week 2's assignment. using classes and inheritance, a script made for paddle movement can now be implemented in two places with two different inputs. the game can now have two players bounce the ball with w/s and up/down controls. it seems last implementation to really make the game complete would be the scoring system once a ball leaves the horizontal bounds.

**02/01/26**

third day of working on the project. converted paddleController into an abstract class and created an abstract method to ensure correct input is being received. next created an ICollidable interface to deal with collision behaviors of all collidable objects in the game. had to move around code for the ball's bouncing mechanic so that it will act as the OnHit method's implementation. Lastly added NetworkedObject abstract class with its two methods to prepare for next week's assignment.


## instructions
* clone the repository:

` git clone https://github.com/elsume/unitypong.git`
* launch unity hub
* click "Add" and select the cloned repository folder
* open with Unity 2022.3.62f3 LTS
* open the main scene
* navigate to Assets/Scenes/MainScene.unity
* click the play button in unity to start the game
