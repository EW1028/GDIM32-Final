# GDIM32-Final
## Check-In
### Group Devlog
During the development of our game, we utilized raycasting. When implementing the interaction mechanism of shooting by left-clicking the mouse to create damage with enemy, we considered how to accurately locate the target of the shot. Therefore, we used a raycasting ray with its origin at the muzzle: _shootRaycastOrigin = _shootpoint.position; Shootpoint is an empty GameObject placed in front of the pistol model. 

We also set the direction to be forward: Vector3 shootDirection = _shootpoint.forward; _range represents the effective range of the pistol we designed. We then use the code Physics.Raycast(_shootRaycastOrigin, shootDirection, out hit, _range) to retrieve hit. 

the GameObject that the raycast hits (RaycastHit hit;). We can get the name and tag of the GameObject via hit.transform.gameObject.name or hit.transform.gameObject.tag.


### Team Member Name 1
Put your individual check-in Devlog here.
### Team Member Name 2
Put your individual check-in Devlog here.
### Team Member Eric Wei
In the Final Check-In assignment, we split the taks for each one, I mainly foucus on the sound system, part of the player movement, and the lighting setup in the Check-In. I implemented the SFX system in Unity. I created the SFX class and connected it to the GameController using events such as OnShoot, OnEnemyHit, and OnEnemyDead. The Script uses AudioSource and multiple AudioClip variables includes shootSound, hitSound, enemyDeadSound, backgroundSounds. to provide audio feedback for shooting, hitting enemies, enemy death, and background music. This supports the audio feedback system described in our proposal. I also worked on some part of the player movement. I helped implement the WASD movement logic inside the Player class using input detection in Update() and moving the player with Transform position changes. This connects to the Controller part of our Model View Controller architecture described in the proposal. In addition, I set up the lighting in the scene. For example, I used a point light to create localized lighting and improve the target and the visibility in the environment. This supports the forest environment described in our proposal. Overall, my work is focusing on the audio, some player control, and scene lighting, which are essential parts of gameplay clarity and immersion at this stage of development.


## Final Submission
### Group Devlog
Put your group Devlog here.


### Team Member Name 1
Put your individual final Devlog here.
### Team Member Name 2
Put your individual final Devlog here.
### Team Member Eric Wei
Put your individual final Devlog here.

## Open-Source Assets


[3D model of hand and gun & animation & bullet 3D model](https://assetstore.unity.com/packages/3d/props/weapons/glassofcoins-low-poly-fps-pack-196540)
[BGM morning](https://www.youtube.com/watch?v=KIh8PEwFCtg)
[Shooting & reloading SFX](https://assetstore.unity.com/packages/templates/systems/multiplayer-fps-template-259143)

