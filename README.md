# GDIM32-Final
## Check-In
### Group Devlog
During the development of our game, we utilized raycasting. When implementing the interaction mechanism of shooting by left-clicking the mouse to create damage with enemy, we considered how to accurately locate the target of the shot. Therefore, we used a raycasting ray with its origin at the muzzle: _shootRaycastOrigin = _shootpoint.position; Shootpoint is an empty GameObject placed in front of the pistol model. 

We also set the direction to be forward: Vector3 shootDirection = _shootpoint.forward; _range represents the effective range of the pistol we designed. We then use the code Physics.Raycast(_shootRaycastOrigin, shootDirection, out hit, _range) to retrieve hit. 

the GameObject that the raycast hits (RaycastHit hit;). We can get the name and tag of the GameObject via hit.transform.gameObject.name or hit.transform.gameObject.tag.


### Team Member Ruichen Ma

In this project, I was responsible for developing the player movement and shooting-related mechanics. I downloaded 3D models and animations of arms and pistols from the Unity Asset Store online. In the code, I implemented player movement, shooting, and reloading functionalities.

For the shooting mechanic, I used raycasting. I set a gameobject in front of muzzle as the origin of the ray and cast a straight line forward with the code Physics.Raycast(_shootRaycastOrigin, shootDirection, out hit, _range). This allowed me to retrieve information about the object hit by the ray through the hit variable. Additionally, while casting the ray, I instantiated a bullet prefab using the code Instantiate(_BulletsPrefab, _Bulletshootpoint.transform.position, _Bulletshootpoint.transform.rotation * Quaternion.Euler(0, 180, 0)), and made it move forward with the following logic: Vector3 moveDirection = -_bulletTransform.forward.normalized; _bulletTransform.position += moveDirection * speed * Time.deltaTime; which implemented the VFX of shooting.

For player movement, I implemented player movement using Vector; Vector3 Dir = (_playerTransform.forward * verticalInput + _playerTransform.right * horizontalInput).normalized;.

Since our game is a first-person shooter, I captured the X and Y axis data of the mouse. I mapped this data to in-game camera rotation with the code: xRotation -= mouseY; playerBody.Rotate(Vector3.up * mouseX); transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); Meanwhile, I used Mathf.Clamp to limit the range of the player's vertical camera rotation (up and down).

Finally, when the ray hit an enemy, I sent an event to trigger the enemy's health reduction interaction and the UI display interaction for hit feedback.

I believe our proposal has helped us clearly allocate our different tasks. Meanwhile, since the expected outcomes were clearly defined in the proposal, it has also reduced communication overhead during development.
### Team Member Name 2
Put your individual check-in Devlog here.
### Team Member Eric Wei
In the Final Check-In assignment, we split the taks for each one, I mainly foucus on the sound system, part of the player movement, and the lighting setup in the Check-In. I implemented the SFX system in Unity. I created the SFX class and connected it to the GameController using events such as OnShoot, OnEnemyHit, and OnEnemyDead. The Script uses AudioSource and multiple AudioClip variables includes shootSound, hitSound, enemyDeadSound, backgroundSounds. to provide audio feedback for shooting, hitting enemies, enemy death, and background music. This supports the audio feedback system described in our proposal. I also worked on some part of the player movement. I helped implement the WASD movement logic inside the Player class using input detection in Update() and moving the player with Transform position changes. This connects to the Controller part of our Model View Controller architecture described in the proposal. In addition, I set up the lighting in the scene. For example, I used a point light to create localized lighting and improve the target and the visibility in the environment. This supports the forest environment described in our proposal. Overall, my work is focusing on the audio, some player control, and scene lighting, which are essential parts of gameplay clarity and immersion at this stage of development.


## Final Submission
### Group Devlog

#### 1. Singleton
We set up `GameController` as a **Singleton**. We ensure that only one instance of `GameController.Instance` exists using the following code in `Awake()`method in the `GameController` script:

```csharp
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
```

In this case, I can put all the scripts that I need to use into the `GameController`, When I need to use Varible form those script in other script, I can use it by useing the Singleton. In this way, I don't have to redefine and assign all script I need to use in every single script. Therefore, my script can become easy to read.

for example:  

In the `GameController`

```csharp
public Weapon Weapon;
```
In the `DialogueLogic`

```csharp
GameController.Instance.Weapon._clipNUM
```





#### 2. MVC
In our game, we use **events** in three different scripts: `QuestUI`, `Enemy`, and `Pickup`.

##### 1 QuestUI Script  

When I generate a new prefab which have `QuestUI` script and this prefab destroyed after completing a quest, it sends an event that includes information of this GameObject. This allows me to retrieve the `RectTransform` of this GameObject in the `QuestManager` script and create new list all existing quests.  

In the `QuestUI`

```csharp
QuestDestroy?.Invoke(this);
```

In the `QuestManager`

```csharp

QuestUI.QuestDestroy += OnQuestDestroy;
public void OnQuestDestroy(QuestUI questUI)
{
    RectTransform DestrouRt = questUI.GetComponent<RectTransform>();
    _activeQuests.Remove(DestrouRt);
    __finishQuestNUM += 1;
    float currentY = 0;
    foreach (RectTransform questRt in _activeQuests)
    {
        questRt.anchoredPosition = new Vector2(0, currentY);
        currentY -= questRt.rect.height + space;
    }

}
```

##### 2 Pickup Script
When the player presses the F key to pick up an item, it sends an event containing the information of the GameObject which player pick up. This allow me to retrieve tag name of this GameObject in the `Weapon` script. And distinguish which GameObject player pick up.


In the `pickup`

```csharp
OnPickup?.Invoke(this);
```  
In the `Weapon`

```csharp
pickup.OnPickup += Gunpickup; 
pickup.OnPickup += Magpickup;
  private void Gunpickup(pickup pickupItem)
  {
      if(pickupItem.tag == "Gun")
      {
          //Debug.Log("pickupGun");
          _ispickUp = true;
      }
  }

  private void Magpickup(pickup pickupItem)
  {
      if( pickupItem.tag == "Mag")
      {
          _clipNUM += 1;
      }
  }
```


##### 3 Enemy Script
When an enemy is destroyed because its HP equal or lower than 0, this GameObject will send an event with the infomation of this GameObeject. This all me to retrieve the tag name of this GameObject in the  `QuestUI` script to verify if the destroyed enemy is the target enemy.  

In the `Enemy`

```csharp
enemyDeath?.Invoke(this); 
```  

In the `QuestUI`

```csharp
Enemy.enemyDeath += OnEnemyDeath;

void OnEnemyDeath(Enemy enemy)
{
    Debug.Log(enemy.tag);
    if(enemy.tag == _targetName)
    {
        _currentNumber += 1;
        _currentNum.text = _currentNumber.ToString(); 
    }
}
```


#### 3. FSM (Finite State Machine)
In the `Weapon` script, I use an `enum` to define and separate the weapon states in two different state. When the player has not picked up the gun, the `weaponState` is set to `None`, and the gun GameObject is set to `SetActive(false)`. When the player picks up the gun, the `weaponState` becomes `Pickup`, allowing the player to execute methods such as `FireWeapon()`, `Reload()`, and others.

```csharp
private enum WeaponsState
{
    None,
    Pickup
}
```



### Team Member Name 1
Put your individual final Devlog here.
### Team Member Name 2
Put your individual final Devlog here.
### Team Member Eric Wei
At the final stage of the project, I contributed to several important parts of the game development in Unity. I worked on the lighting setup and environment design in the scene to improve the overall visual atmosphere of the game. By adjusting Unity's lighting settings and background objects in the scene, I helped make the environment feel more polished and visually cohesive for the player. I also implemented sound effects in the game using Unity's AudioSource and AudioClip components. These audio events are connected to gameplay interactions so that sounds are triggered when players perform certain actions in the game. This helps provide feedback to the player and improves the overall immersion of the gameplay experience. In addition, I helped optimize the scene by adjusting environment objects and fixing technical issues that appeared during development. I also debugged problems to ensure that lighting, audio systems, and scene elements function correctly together inside the Unity scene. Debugging and testing were important parts of my contribution because they helped prevent technical problems from affecting other parts of the project. Throughout the development process, I maintained active communication with my teammates. I regularly shared progress updates, discussed implementation decisions, and collaborated with the team to solve problems. Overall, my work helped improve the game's visual presentation, audio feedback, performance, and overall player experience.



## Open-Source Assets


[3D model of hand and gun & animation & bullet 3D model](https://assetstore.unity.com/packages/3d/props/weapons/glassofcoins-low-poly-fps-pack-196540)
[BGM morning](https://www.youtube.com/watch?v=KIh8PEwFCtg)
[Shooting & reloading SFX](https://assetstore.unity.com/packages/templates/systems/multiplayer-fps-template-259143)
[map objects](https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v2-0-86679)
[signal 3D model of pistal](https://ng1994.itch.io/cyberpunk-gun-model-futuristic-weapon-for-3d-projects)
[NPC 3D Model](https://assetstore.unity.com/packages/3d/characters/humanoids/npc-character-proto-series-132051)

