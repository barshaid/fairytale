Fairytale
Basic 2D sidescroller, levels are randomly generated from premade bitmaps with only one being the boss map. each segment can also be by using different variations of the same asset.
each tilemap is made out of a 32x32 pixel picture containing colored pixel which correspond to a color in the colorkey map included. essentialy the animator can creator more variations of the prefab(per game plot, i.e. icy ground, broken magma filled cave walls, different monster variations, etc) and create unqiue levels without the need to program them. 

GameObject levelGeneator runs creates an array in the requested size of segments of numbers between 0 and number of bitmap set minus one(boss bitmap), after a sequance was created it begins by first placing ground prefabs, then moves to background prefabs and lastly npc and collectibles. at this point the map is scanned to provide A* pathfinding with an obsticle map 

the player can float on water and jump out of it

entereing the caves darken the surrounding

platform can be jumped to from below

npcs-
fairy - flying mob, flocks the player when in range
fish - aquatic mob, same
both are spawned to be 0.5 to 1 of their prefab size and have power and speed accordingly

unicorn boss - shoots spheres, is stationary, starts a short text dialog scene, upon death drops big crystal and ends level

consumables
orbs - used for hp and powerups (explained in tutorial)
small crystals - highscore points

