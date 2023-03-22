# **XOX50 -  Final Project - Murat Beder**

Introduction

\* My name is Murat Beder and this is my final project for CS50G Introduction to game develepment course.

\* Checkout the video : https://youtu.be/o7dpI8Us4Gg

**The Goal**

\* Our aim in every level is same as xox game we all know. Match 3 same letters vertically diagonally or horizontally.

\* When you finish each chapter, you move on to the next chapter and you have to pass all chapters in one sitting to win the game.

\* Each level has time and magazine limitations. You need to create the desired pattern with the balls you have before the time runs out. If you fail (in this version of the game) you can try again. If we want to complicate the game, we can force it to start over when we fail.

**How To Play**

\* You can see the projectile by pressing and holding any point of the screen. By looking at this projectile, you throw a ball to the desired area by using the slingshot and pull-and-drop mechanics.

\* Thrown balls apply rotational force to blocks on the XOX board ahead. The blocks stand with the X or O face up. (I'll explain how it works later).

\* Match 3 same letters vertically, diagonally or horizontally.

**How Did I Do It**

\* At first, I thought this game would be more suitable for mobile platforms (mobile phones), so I adjusted the screen size and control mechanics accordingly.

\* I first started the game by making a simple start scene. (and named it Main Menu). I designed a simple login interface to this scene.

![](RackMultipart20230219-1-7tsh86_html_7287df9ec09d3a58.png) ![](RackMultipart20230219-1-7tsh86_html_9177b642860770fa.png)

\* Then the first thing I had to do was create a xox board of 9 blocks.I created 9 blocks, I added rigidbody and box collider to all these blocks. I then combined them into a gameobject child. Later, I added Hinge Joint (connected body to Game Table(parent)) to these blocks one by one. Thus, all these blocks are interlocked to each other in the area of the parent (Game Table). I made a few tweaks from the inspector (gravity, angular drag etc.) to prefab this whole table and make it more playable.

![](RackMultipart20230219-1-7tsh86_html_bdf1d285ccbd7cd4.png) ![](RackMultipart20230219-1-7tsh86_html_2282e1aa6131a80.png)

\* What I've done so far hasn't been enough. Because when these blocks rotate, I wanted them to stand with any surface facing straight up so that it would be easier for the player to see and play the game. Under the GameBoxes script, I calculated the correct times for the rotating blocks to stop, and when they fell to certain speeds, I found the nearest vertical point to the ground and made them stop there.

**-\> GameBoxes.cs**

\* After dozens of problems and debugging I was able to get this XOX board the way I wanted it. Next was to create an external factor that would rotate the blocks on this board.

\* For this, I aimed to create an object that would stand in front of the camera and throw a ball as a result of user inputs.

\* I decided that the most suitable mechanic for this kind of game was the slingshot and I decided to put a joystick on the screen. When the joystick is pulled back, the slingshot will be pulled more forcefully, and when the joystick approaches the middle, it will be pulled more forcefully. Pulling it to the right would make it go left, and pulling it to the left would make it go right. Thus, the player would be able to throw all the blocks the player wanted after a short practice.

\* I downloaded the joystick package from Unity's asset store and used it ready.

\* Then I created a script called Cannon and wrote a code that throws balls according to the joystick movements. (I originally planned that the thrown ball would come out of a cannon, but then I changed my mind).

**-\> Cannon.cs**

**\*** Every time the player changes the input (moving his hand on the screen), a physics simulation I found on the internet runs and calculates where the ball will go. It prints it on the screen. When the user removes his hand from the screen, the ball coming out of the slingshot is thrown. The ball goes where it is indicated. You can see all these in **Cannon.cs and Projection.cs** script files.

\* Now I could influence the game table and rotate the blocks with the player input. All I had to do was check if I had won the game. I did this in the GameManager.cs file.

\* I could win the game now, but there was no reason to lose. The ball was unlimited and there was no time limit. I've set a Bullet limit and a time limit to add a losing mechanic. I showed them on Canvas as Remaining Bar and Time Bar. ![](RackMultipart20230219-1-7tsh86_html_aceb8c779d7f72f9.png)

\* You can examine the code of these counters in the **RemainingThrowBar.cs** and **Timer.cs** files. I created very simple counters.

\* After all this was over, I took care of screen transitions such as winning, losing, going to the next level, returning to the main menu. I handled these with the PauseMenu.cs script under the canvas object in each scene and the MainMenu.cs scripts only in the first scene.

![](RackMultipart20230219-1-7tsh86_html_29cca8660dbc2af4.png) ![](RackMultipart20230219-1-7tsh86_html_f91d5f6f4623cfaa.png)

\* Finally, I designed levels in 6 different environments and made the game ready as a draft. The number of rounds and time is the same in all levels, but different challenges can be added to the game and these times can be changed from section to section.

And here you can find everything I told in video.

\* [https://youtu.be/o7dpI8Us4Gg](https://youtu.be/o7dpI8Us4Gg)

Murat Beder 

edX : muratizm

Github : muratizm


Ankara, Turkey
