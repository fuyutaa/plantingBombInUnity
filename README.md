# plantingBombInUnity
 Scripts and instructions to set up fast a plantable bomb that reacts with CompareTag()

 The systme founded in this repo is a for a bomb that we have in our inventory, place it and wait for it to detonate and destroy a destructible wall. 

This is used as the intro of levels in my mobile game "A Ninja Job" if you're interested in examples of applications.

------------------------
MANUAL
------------------------

1) Creating the explosion effect ( do not place in a gameObject)
    In the scene :
    1. RIGHT_CLICK -) Effects -) Particle System
    2. Particle System component parameters :
        - Clicking on the name Explosion :
            - Duration : 2
            - Looping : Unchecked
            - Start Lifetime : 0.75
            - Start Speed : 30
            - Start Size : Random Between two constants (0.25 / 1)
            - Start Rotation : Random Between two constants (0 / 360)
        - Emission :
            - Rate Over Time : 1
            - Create new Burst (Count = 50, no other modifs to the params)
        - Shape :
            - Shape : Circle
            - Radius : 0.5
        - (Activate) Limit Velocity over lifetime :
            - Speed : 3
            - Dampen : 0.5
        - (Activate) Add a gradient of colors over Lifetime
            - Yellowish to Orangish
        - Renderer : 
            - Material : Square
        - (Activate) Size Over Lifetime :
            - Size : from top to bottom (preset)

2) Adding the C4 to your game
    1. Create an empty in the scene named >"C4"
    2. Add to it a CircleCollider with IsTrigger checked
    3. Add to it a script named >"C4Manager" and use the code founded in this repo.
    4. Place it somewhere in the scene where we don't see it. We'll make clones of it.
    5. Add references in the inspector

3) Setting up the explosion function in your inventory script
    If you don't have already an inventory in your game, I did a github repo about setting up one (inventoryInUnity)

    1. Add the Inventory.cs parts to your inventory system. 
    2. Add references in the inspector

4) Creating the destroyableWall 
    1. Make destroyed the walls you want to be able to destroy in your map, so you can add a clean wall over it that will be the one we'll deleted, revealing the destroyed original wall.
    2. Add your destroyableWall to the scene
    3. Add to it a BoxCollider2D *WITHOUT* IsTrigger checked.
    4. Add to it a CircleCollider2D *WITH* IsTrigger checked. This will be the area we'll be able to place the C4 in it.
    5. Create and add the tag "destroyableWall"



------------------------
CREDITS :
The "how to make" explosion effect tutorial by Single Sapling Games on youtube : https://youtu.be/ig-0oJgy7NI
------------------------

