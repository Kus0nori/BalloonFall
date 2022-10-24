# BalloonFall

### Features:
<ul>
<li>Multi-thread texture generation
<li>Downloading sprites using asset bundles
<li>Spawning objects with random properties
<li>iOS, Android and Windows build possibility
</ul>

### Build:
Before building it is advised to delete "Asset bundles" folder, to decrease application weight. Also internet connection is required on first launch.

### Gameplay:
A circle of random size and color appears from above at a random time in a random place.
The circle should appear outside the visibility zone, but fit in the screen in width.
It moves down at a constant speed, which depends on its size - the smaller, the faster.
When pressed, the circle disappears, and adds points to the player - the smaller the circle, the more points.
If it disappears from the visibility zone, remove the circle without giving points.
There is no logical ending to the game, that is, the circles fall endlessly.
 
The game interface consists of: 
<ul>
<li>Background
<li>Start button - starts a new game.
<li>Stop button - stops the game.
<li>Points counter and timer (starts from zero at start) in the lower left corner.
</ul>

Every 1000 points, the game moves to a new level. 
During the transition display a message is shown on the screen with the level number, 
the speed and number of circles are increased, their color and background (now there will be several of them) is changed.
Game backgrounds are placed in AssetBundles on my github and loaded during game initialization using the WWW class.
 
The color of the circles will now be set by the textures that are generated at the start of the game, as well 
as when changing levels. The size and color of the texture are subject to generation. Valid extensions are 32x32, 64x64, 128x128 and 256x256. 
Textures with larger expansion are assigned to larger circles and vice versa.
