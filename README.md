#Figment
###_by Phoenix Studios_


Alexander Atanassov  
Margo Sikes  
Jabari Weathers  
Eric Zhu  

===

Run DemoVersion_4_9_14.exe to play!


Move the player with "WASD"

Melee attack with "E"

Open chests with "F"

===

Change log:

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