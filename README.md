#Figment
###_by Phoenix Studios_


Alexander Atanassov  
Margo Sikes  
Jabari Weathers  
Eric Zhu  

===

For Windows, run DemoVersion_4_14_14.exe to play!
For Macs, run DemoVersion_4_14_14.app to play!

Instructions:
- Move the player with "WASD"
- Melee attack with "E"
- Open chests with "F"
- An opened chest is a respawn point in the event of player death
- There is no victory in this game
- You may try to kill enemies, but they will always return
- Death is your only escape

===

Change log:


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