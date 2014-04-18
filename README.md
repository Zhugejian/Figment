#Figment
###_by Phoenix Studios_


Alexander Atanassov  
Margo Sikes  
Jabari Weathers  
Eric Zhu  

===


For Windows, run Prototype_1.exe to play!

For Macs, run Prototype_1(Mac).app to play!


Instructions:
- Move the player with "WASD"
- Melee attack with "E"
- Drop respawn point with "F"
- If the player has a respawn point, they will return there upon dying
- To win, find and open(attack) the repressed memory, which looks like a stationary respawn point


===

Change log:


4/18/14
- art/environments:
  - changed forest door sprite image
  - adjusted sprite layering (so transparent forest walls will no longer be visible through any forest doors)
- experimental combat mechanics and animations (all in Room2)
  - attacks push the target, the force is variable
  - sifter attack delay to coincide with animation (still needs polish)
  - sifter can attack while moving without breaking the animation (still needs polish)
  - sifter reaction animation to being hit
  - sifter death animation upon being killed
  - enemies attack animation only plays when they've successfully hit the player


4/16/14
- added new scene: Room4
- enemies can now only damage the player (friendly-fire removed)
- added one track of background music
- the respawn point can now be in any room
  - press "F" to drop the respawn point at the player's location
  - unrestricted usage for now
- changed format of all sprites from Truecolor to either 16 bits or Compressed to stay under Git's 100MB file limit
- added repressed memory/victory condition
- added victory screen


4/14/14
- most environmental art (walls, doors, trees) now implemented as sprites
- room point lights have been removed
  - instead the room's ground is self-illuminating
- player animation mirrors appropriately when pressing the movement keys separately
  - fixed idle and attack animations to come
- player is followed by an animated orb
- player health is indicated by a green bar above the character
  - the bar shrinks in width when health lowers
  - when player health = 0, the bar will no longer be visible
- can quit the game through Game Over menu


4/9/14
- art and animations:
  - isometric design: 2D art in 3D environment
  - implemented environmental art
  - implemented chest animations
  - partially implemented player and enemy sprites
  - placeholder healthbar, yet to be implemented
- combat:
  - certain gameObjects are Damageable: player and enemies
  - combat is all melee, with direction-sensitive cone hit-boxes 
  - friendly fire possible for additional realism
  - semblance of enemy AI:
    - enemies follow the player
    - smaller enemies will try to hold the player down for the larger enemies
  - enemies and players have health
- death:
  - enemies destroyed upon losing all health
  - respawn point for player:
    - opening a chest will allow a player to respawn at that location upon death
    - will remember the respawn point even upon exiting that room
    - will reset the chest and respawn point after respawning
  - player sent to Game Over screen if killed without a respawn point


4/2/14
- added instructions
- very basic enemy AI
  - follows player
- very basic destroy enemy mechanic
  - reduce health on click
  - when health reaches zero, disappears
- sprite sheets for an enemy and chest done, yet to be implemented though


3/26/14
- added menu screen
- added "health" counter to enemies (each enemy takes three clicks to kill)
- enemies blink red when hit
- palm trees and more!


3/12/14
- everything
- executable file ("DemoVersion_3_12_14.exe") is our game so far