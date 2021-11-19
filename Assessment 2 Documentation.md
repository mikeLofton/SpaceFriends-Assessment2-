**Michael Lofton**

s218033 

Math For Games

SpaceFriends-Assessment2-

# I. Requirements
    
 1. **Description of Problem**

    **Name:** SpaceFriends-Assessment2-

    **Problem Statement:** 

    Submit executable for Graphical Test Application that makes use of your maths classes to implement the following.

    **Problem Specifications:**
    
    * Example of matrix hierarchy to manipulate visible elements.
    * Example of game objects moving using velocity and acceleration with vectors.
    * Example of simple collision detection.  

 2. **Input Information:**
    * WASD - Moves the player.
    * The four Arrow Keys - shoots a bullet in the corresponding direction.
    * Numpad 1 - decreases the player's size.
    * Numpad 2 - increases the player's size.
 3. **Output Information:**
    * The game will affect sprites and movements based on the player's input.
 4. **User Interface Information:**
    * The UI displays a win/lose message depending on if the player defeats all enemies or dies.

# II. Design
 1. *System Architecture*
 
    The Engine class handles the initialization of game scenes and actors. The Scene class stores all the actors within the scene and handles the addition and removal of actors from a given scene. The Actor class is used to create all objects within a scene as well as child objects to a parent actor. The Collider class tracks what owner actor has each collider type and checks for collison. The CircleCollider and AABBCollider classes inherit from Collider. The Sprite class draws texture and visuals for the game. The Baby, Bullet, Enemy, GameManager, Player, and UIText classes all inherit from Actor. The player can move in any direction and fire bullets. The baby will mimic the player's movements and fire their own bullets. Enemies wil attempt to collide with the player and babies. Bullets will remove enemies from the scene on collision. The game manager keeps track of the win/lose conditions and display text accordingly.
 2. *Object Information*
    * **File Name:** Program.cs
        * **Class Name:** Program
        * Name: Main(string[] args)
            * Description: Runs the Engine.
            * Visibility: public
            * Type: static void
    * **File Name:** Engine.cs
        * **Class Name:** Engine
        * Name: _applicationShouldClose(static bool)
            * Description: Used to end the game.
            * Visibility: private
        * Name: _currentSceneIndex(static int)
            * Description: Keeps track of the games' current scene.
            * Visibility: private
        * Name: _scenes(Scene[])
            * Description: The array of game scenes
            * Visibility: private
        * Name: _stopwatch(Stopwatch)
            * Description: Counts the game time
            * Visibility: private
        * Name: Run()
            * Description: Starts the game loop
            * Visibility: public
            * Type: void
        * Name: Start()
            * Description: Initializes the games starting values
            * Visibility: private
            * Type: void
        * Name: Update(float deltaTime)
            * Description: Called everytime the game loops
            * Visibility: private
            * Type: void
        * Name: Draw()
            * Description: Updates the visuals everytime the game loops
            * Visibility: private
            * Type: void
        * Name: End()
            * Description: Called when the game ends
            * Visibility: private
            * Type: void
        * Name: AddScene(Scene scene)
            * Description: Adds a scene to the _scenes array
            * Visibility: public
            * Type: int
        * Name: CloseApplication()
            * Description: Ends the application
            * Visibility: public
            * Type: static void
        * Name: InitializeSceneObjects()
            * Description: Initializes the scenes and actors
            * Visibility: private
            * Type: void
    * **File Name:** Scene.cs
        * **Class Name:** Scene
        * Name: _actors(Actor[])
            * Description: Array that contains all actors in the scene
            * Visibility: private
        * Name: _UIElements(Actor[])
            * Description: Array that contains all UI actors in the scene
            * Visibility: private
        * Name: Scene()
            * Description: Scene Constructor
            * Visibility: public
        * Name: Start()
            * Description: Calls start for all actors in the actors array
            * Visibility: public
            * Type: virtual void
        * Name: Update(float deltaTime)
            * Description: Calls update for every actor in the scene. Calls start for actors that haven't been called yet.
            * Visibility: public
            * Type: virtual void
        * Name: UpdateUI(float deltaTime)
            * Description: Calls update for every UI element in the scene. Calls start for UI elements that haven't been called yet.
            * Visibility: public
            * Type: virtual void
        * Name: Draw()
            * Description: Calls draw for every actor in the array.
            * Visibility: public
            * Type: virtual void
        * Name: DrawUI()
            * Description: Calls draw for every UI element in the array
            * Visibility: public
            * Type: virtual void
        * Name: End()
            * Description: Calls end for every actor in the array
            * Visibility: public
            * Type: virtual void
        * Name: AddActor(Actor actor)
            * Description: Adds an actor to the scene.
            * Visibility: public
            * Type: virtual void
        * Name: RemoveActor(Actor actor)
            * Description: Removes an actor from the scene.
            * Visibility: public
            * Type: virtual bool
        * Name: AddUIElement(Actor UI)
            * Description: Adds UI element to the scene.
            * Visibility: public
            * Type: virtual void
        * Name: RemoveUIElement(Actor UI)
            * Description: Removes UI element from the scene.
            * Visibility: public
            * Type: virtual bool
    * **File Name:** Sprite.cs
        * **Class Name:** Sprite
        * Name: _texture(Texture2D)
            * Description: A 2D texture
            * Visibility: private
        * Name: Width(int)
            * Description: The width of the texture.
            * Visibility: public
        * Name: Height(int)
            * Description: The height of the texture.
            * Visibility: public
        * Name: Sprite()
            * Description: Sprite Constructor. Takes in the file path of the image to use as the texture.
            * Visibility: public
        * Name: Draw(Matrix3 transform)
            * Description: Draws the sprite using the rotation, translation, and scale of the given transform.
            * Visibility: public
            * Type: void
    * **File Name:** Actor.cs
        * **Class Name:** Actor
        * Name: _name(string)
            * Description: The actor's name.
            * Visibility: private
        * Name: _started(bool)
            * Description: Determines whether the actor's start function has been called.
            * Visibility: private
        * Name: _forward(Vector2)
            * Description: The actor's forward vector2.
            * Visibility: private
        * Name: _collider(Collider)
            * Description: The actor's collider.
            * Visibility: private
        * Name: _globalTransform(Matrix3)
            * Description: The global transform identity matrix.
            * Visibility: private
        * Name: _localTransform(Matrix3)
            * Description: The local transform identity matrix.
            * Visibility: private
        * Name: _translation(Matrix3)
            * Description: The translation identity matrix.
            * Visibility: private
        * Name: _rotation(Matrix3)
            * Description: The rotation identity matrix.
            * Visibility: private
        * Name: _scale(Matrix3)
            * Description: The scale identity matrix.
            * Visibility: private
        * Name: _children(Actor[])
            * Description: The array of child actors.
            * Visibility: private
        * Name: _parent(Actor)
            * Description: The parent actor.
            * Visibility: private
        * Name: _sprite(Sprite)
            * Description: The actor's sprite.
            * Visibility: private
        * Name: Started(bool)
            * Description: Returns true if the start functions have been called for this actor.
            * Visibility: public
        * Name: LocalPosition(Vector2)
            * Description: Gets the T column of the Matrix3. Sets translation to value's X and value's Y.
            * Visibility: public
        * Name: WorldPosition(Vector2)
            * Description: Gets the global transform's T column. Translates the actor.
            * Visibility: public
        * Name: GlobalTransform(Matrix3)
            * Description: The global transform matrix.
            * Visibility: public
        * Name: LocalTransform(Matrix3)
            * Description: The local transform matrix.
            * Visibility: public
        * Name: Parent(Actor)
            * Description: The parent actor.
            * Visibility: public
        * Name: Children(Actor[])
            * Description: The array of children.
            * Visibility: public
        * Name: Size(Vector2)
            * Description: Gets a scale vector2. Sets scal to value X and value Y.
            * Visibility: public
        * Name: Forward(Vecotr2)
            * Description: Has LookAt fuction face a point. 
            * Visibility: public
        * Name: Sprite(Sprite)
            * Description: The sprite attached to the actor.
            * Visibility: public
        * Name: Collider(Collider)
            * Description: The collider attached to the actor.
            * Visibility: public
        * Name: Actor()
            * Description: Actor Constructor. Takes in the actor's x position, y position, the actor's name, and the actor's sprite path.
            * Visibility: public
        * Name: Actor()
            * Description: Actor Constructor. Takes in the actor's position, the actor's name, and the actor's sprite path.
            * Visibility: public
        * Name: UpdateTransforms()
            * Description: Update the global and local transforms everytime the game loops.
            * Visibility: public
            * Type: void
        * Name: AddChild(Actor child)
            * Description: Adds actors to the children array. Childs an actor to a parent.
            * Visibility: public
            * Type: void
        * Name: RemoveChild(Actor child)
            * Description: Removes actor from the children array. Removes child from parent actor.
            * Visibility: public
            * Type: bool
        * Name: Start()
            * Description: Start for each actor
            * Visibility: public
            * Type: virtual void
        * Name: Update(float deltaTime)
            * Description: Called everytime the game loops.
            * Visibility: public
            * Type: virtual void
        * Name: Draw()
            * Description: Draws the actor sprites.
            * Visibility: public
            * Type: virtual void
        * Name: End()
            * Description: End for each actor
            * Visibility: public
            * Type: virtual void
        * Name: OnCollision(Actor actor)
            * Description: What occurs on the collision between this actor and another.
            * Visibility: public
            * Type: virtual void
        * Name: CheckForCollision(Actor other)
            * Description: Checks if this actor collided with another actor.
            * Visibility: public
            * Type: virtual bool
        * Name: SetTranslation(float translationX, float translationY)
            * Description: Sets position of the actor.
            * Visibility: public
            * Type: void
        * Name: Translate(float translationX, translationY)
            * Description: Applies the given values to the current translation.
            * Visibility: public
            * Type: void
        * Name: SetRotation(float radians)
            * Description: Set the rotation of the actor.
            * Visibility: public
            * Type: void
        * Name: Rotate(float radians)
            * Description: Adds a rotation to the current transform's rotation.
            * Visibility: public
            * Type: void
        * Name: SetScale(float x, float y)
            * Description: Sets the scale of the actor.
            * Visibility: public
            * Type: void
        * Name: Scale(float x, float y)
            * Description: Scales the actor by the given x and y.
            * Visibility: public
            * Type: void
        * Name: LookAt(Vector2 position)
            * Description: Rotates the actor to face the given position.
            * Visibility: public
            * Type: void
    * **File Name:** Player.cs
        * **Class Name:** Player : Actor
        * Name: _speed(float)
            * Description: The player's movement speed.
            * Visibility: private
        * Name: _velocity(Vector2)
            * Description: The player's velocity.
            * Visibility: private
        * Name: _scene(Scene)
            * Description: The scene to spawn the bullet in.
            * Visibility: private
        * Name: _cooldownTime(float)
            * Description: How many seconds the player has to wait before firing another bullet.
            * Visibility: private
        * Name: _sinceLastShot(float)
            * Description: How many seconds have passed since the last time the player fired a bullet.
            * Visibility: private
        * Name: Speed(float)
            * Description: Gets the player's speed. Sets speed to value.
            * Visibility: public
        * Name: Velocity(Vector2)
            * Description: Gets the player velocity. Sets velocity to value.
            * Visibility: public
        * Name: Player()
            * Description: Player Constructor. Takes in the player's x position, y position, speed, current scene, name, and sprite file path.
            * Visibility: public
        * Name: Update(float deltaTime)
            * Description: Called everytime the game loops. Used for player movement, shot direction, and clamping them on the screen.
            * Visibility: public
            * Type: override void
        * Name: OnCollision(Actor actor)
            * Description: Collision between the player and another actor. Removes player from the scene on collision with an enemy.
            * Visibility: public
            * Type: override void
        * Name: Draw()
            * Description: Draws the actors.
            * Visibility: public
            * Type: override void
    * **File Name:** Enemy.cs
        * **Class Name:** Enemy : Actor
        * Name: _speed(float)
            * Description: The enemy's movement speed.
            * Visibility: private
        * Name: _velocity(Vector2)
            * Description: The enemy's velocity.
            * Visibility: private
        * Name: _enemyType(float)
            * Description: The enemy's type.
            * Visibility: private
        * Name: _target(Actor)
            * Description: The enemy's target.
            * Visibility: private
        * Name: _scene(Scene)
            * Description: The scene the enemy is in. 
            * Visibility: private
        * Name: Speed(float)
            * Description: Gets the enemy's speed. Sets the speed to value.
            * Visibility: public
        * Name: Velocity(Vector2)
            * Description: Gets the enemy's velocity. Sets velocity to value. 
            * Visibility: public
        * Name: Enemy()
            * Description: Enemy Constructor. Takes in the enemy's position, speed, type, target, current scene, name, and file path.
            * Visibility: public
        * Name: Update(float deltaTime)
            * Description: Called everytime the game loops. Used for enemy movement and rotation.
            * Visibility: public
            * Type: override void
        * Name: OnCollision(Actor actor)
            * Description: Collision between enemy and another actor. On collision with a baby remove the baby from the scene.
            * Visibility: public
            * Type: override void
        * Name: Draw()
            * Description: Draws the enemy sprites.
            * Visibility: public
            * Type: override void
    * **File Name:** Baby.cs
        * **Class Name:** Baby : Actor
        * Name: _scene(Scene)
            * Description: The scene the baby is in.
            * Visibility: private       
        * Name: _cooldownTime(float)
            * Description: How many seconds the baby has to wait before firing another bullet.
            * Visibility: private
        * Name: _sinceLastShot(float)
            * Description: How many seconds have passed since the last time the baby fired a bullet.
            * Visibility: private
        * Name: Baby()
            * Description: Baby Constructor. Takes in the baby's position, current scene, name, and file path.
            * Visibility: public
        * Name: Update(float deltaTime)
            * Description: Allows baby to shoot bulllets.
            * Visibility: public
            * Type: override void
        * Name: OnCollision(Actor actor)
            * Description: Collision between baby and another actor.
            * Visibility: public
            * Type: override void
        * Name: Draw()
            * Description: Draws the baby sprites.
            * Visibility: public
            * Type: override void
    * **File Name:** Bullet.cs
        * **Class Name:** Bullet : Actor
        * Name: _speed(float)
            * Description: The bullet's movement speed.
            * Visibility: private
        * Name: _velocity(Vector2)
            * Description: The bullet's velocity.
            * Visibility: private
        * Name: _xDirection(int)
            * Description: The bullet's direction on the x axis.
            * Visibility: private
        * Name: _yDirection(int)
            * Description: The bullet's direction on the y axis.
            * Visibility:
        * Name: _scene(Scene)
            * Description: The scene to spawn the bullet in.
            * Visibility: private
        * Name: _existanceTime(float)
            * Description: How many seconds the bullet can exist.
            * Visibility: private
        * Name: _sinceExisting(float)
            * Description: How many seconds have passed since bullet was added to the scene.
            * Visibility: private
        * Name: Speed(float)
            * Description: Gets the bullet's speed. Sets speed to value.
            * Visibility: public
        * Name: Velocity(Vector2)
            * Description: Gets the bullet's velocity. Sets velocity to value.
            * Visibility: public
        * Name: Bullet()
            * Description: Bullet Constructor. Takes in the bullet's position, speed, x and y bullet direction, current scene, name, and sprite file path.
            * Visibility: public
        * Name: Update(float deltaTime)
            * Description: Called everytime the game loops. Used for bullet movement. Revomes bullet from scene 10 seconds after it's added.
            * Visibility: public
            * Type: override void
        * Name: OnCollision(Actor actor)
            * Description: Collision between the bullet and another actor. Removes enemies from the scene on collision.
            * Visibility: public
            * Type: override void
        * Name: Draw()
            * Description: Draws the bullet sprites.
            * Visibility: public
            * Type: override void
    * **File Name:** UIText.cs
        * **Class Name:** UIText : Actor
        * Name: Text(string)
            * Description: The text to display.
            * Visibility: public
        * Name: Width(int)
            * Description: The textbox width.
            * Visibility: public
        * Name: Height(int)
            * Description: The textbox height.
            * Visibility: public
        * Name: FontSize(int)
            * Description: The text font size.
            * Visibility: public
        * Name: Font(Font)
            * Description: The text's font.
            * Visibility: public
        * Name: FontColor(Color)
            * Description: The text's color.
            * Visibility: public
        * Name: UIText()
            * Description: Takes in the textbox position, name, font color, width, height, and text.
            * Visibility: public
        * Name: Draw()
            * Description: Draws the textbox.
            * Visibility: public
            * Type: override void
    * **File Name:** GameManager.cs
        * **Class Name:** GameManager : Actor
        * Name: _scene(Scene)
            * Description: The scene the game manager is in.
            * Visibility: private
        * Name: EnemyCount(static int)
            * Description: The number of enemy's in the scene.
            * Visibility: public
        * Name: PlayerIsDead(static bool)
            * Description: Whether the player is dead or not.
            * Visibility: public 
        * Name: winText(UIText)
            * Description: The game win message.
            * Visibility: private
        * Name: loseText(UIText)
            * Description: The game lose text. 
            * Visibility: private
        * Name: GameManager()
            * Description: GameManager constructor. Takes in position, current scene, name, and sprite path.
            * Visibility: public
        * Name: Update(float deltaTime)
            * Description: Displays win text if enemy count is zero. Displays lose text if player dies.
            * Visibility: public
            * Type: override void
    * **File Name:** Collider.cs
        * **Class Name:** Collider
        * Name: ColliderType(enum)
            * Description: The types of colliders.
            * Visibility: public
        * Name: _owner(Actor)
            * Description: The actor that owns a collider
            * Visibility: private
        * Name: _colliderType(ColliderType)
            * Description: The type of collider an actor has.
            * Visibility: private
        * Name: Owner(Actor)
            * Description: Gets the owner. Sets owner to value.
            * Visibility: public
        * Name: ColliderType(ColliderType)
            * Description: Gets the collider type.
            * Visibility: public
        * Name: Collider()
            * Description: Collider constructor. Takes in the owner actor and the type of coller the actor owns.
            * Visibility: public
        * Name: CheckCollision(Actor other)
            * Description: Checks for collision with another actor.
            * Visibility: public
            * Type: bool
        * Name: CheckCollisionCircle(CircleCollider other)
            * Description: Checks for collision with circle collider. Meant to be overriden by other collider classes.
            * Visibility: public
            * Type: virtual bool
        * Name: CheckCollisionAABB(AABBCollider other)
            * Description: Checks for collision with AABBCollider. Meant to be overriden by other collider classes.
            * Visibility: public
            * Type: virtual bool
    * **File Name:** CircleCollider.cs
        * **Class Name:** CircleCollider : Collider
        * Name: _collisionRadius(float)
            * Description: The circle collider's collision radius.
            * Visibility: private
        * Name: CollisionRadius(float)
            * Description: Gets the collision radius. Sets it to value.
            * Visibility: public
        * Name: CircleCollider()
            * Description: CircleCollider constructor. Takes in the collision radius and the collider's owner.
            * Visibility: public
        * Name: CheckCollisionCircle(CircleCollider other)
            * Description: Checks for collision with other's circle collider.
            * Visibility: public
            * Type: ooverride bool
        * Name: CheckCollisionAABB(AABBColider other)
            * Description: Checks for collision with other's AABBCollider.
            * Visibility: public
            * Type: override bool
    * **File Name:** AABBCollider.cs
        * **Class Name:** AABBCollider : Collider
        * Name: _width(float)
            * Description: The collider's width.
            * Visibility: private
        * Name: _height(float)
            * Description: The collider's height.
            * Visibility: private
        * Name: Width(float)
            * Description: Gets the width. Sets it to value.
            * Visibility: public
        * Name: Height(float)
            * Description: Gets the height. Sets it to value.
            * Visibility: public
        * Name: Left(float)
            * Description: The farthest left x position of the collider.
            * Visibility: public
        * Name: Right(float)
            * Description: The farthest right x position of the collider.
            * Visibility: public
        * Name: Top(float)
            * Description: The farthest y position upwards of the collider.
            * Visibility: public
        * Name: Bottom(float)
            * Description: The farthest y position downwards of the colider
            * Visibility: public
        * Name: AABB()
            * Description: AABB constructor. Takes in the collider's width, height, and owner.
            * Visibility: public
        * Name: CheckCollisionAABB(AABBCollider other)
            * Description: Checks for collision between two AABB colliders.
            * Visibility: public
            * Type: override bool
        * Name: CheckCollisionCircle(CircleCollider other)
            * Description: Checks for collision with other's circle collider.
            * Visibility: public
            * Type: ooverride bool
    * **File Name:** Vector2.cs
        * **Struct Name:** Vector2
        * Name: X(float)
            * Description: The Vector2 X value.
            * Visibility: public
        * Name: Y(float)
            * Description: The Vector2 Y value.
            * Visibility: public 
        * Name: Vector2() 
            * Description: Vector2 Constructor. Takes in an X and Y value.
            * Visibility: public 
        * Name: Magnitude(float)
            * Description: Gets the lenght of the vector.
            * Visibility: public
        * Name: Normalized(Vector2) 
            * Description: Gets the normalized version of this vector without changing it.
            * Visibility: public
        * Name: Normalize()
            * Description: Changes this vector to have a magnitude that is equal to one. Returns the result of the normalization.
            * Visibility: public
        * Name: DotProduct(Vector2 lhs, Vector2 rhs)
            * Description: Returns the dot product of the first vector on to the second.
            * Visibility: public
            * Type: static float    
        * Name: Distance(Vector2 lhs, Vector2 rhs)
            * Description: Finds the distance from the first vector to the second.
            * Visibility: public
            * Type: static float 
        * Name: +(Vector2 lhs, Vector2 rhs)
            * Description: Adds the x value of the second vector to the first, and adds the y value of the second vector to the first.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: -(Vector2 lhs, Vector2 rhs)
            * Description: Subtracts the x value of the second vector to the first, and subtracts the y value of the second vector to the first.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: *(Vector2 lhs, float rhs)
            * Description: Multiplies the vectors x and y values by the scalar.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: /(Vector2 lhs, float rhs)
            * Description: Divides the vector's x and y values by the scalar.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: ==(Vector2 lhs, Vector2 rhs)
            * Description: Compares the x and y values of two vectors. Returns true if the x and y values of both vectors match.
            * Visibility: public
            * Type: static bool operator
        * Name: !=(Vector2 lhs, Vector2 rhs)
            * Description: Compares the x and y values of two vectors. True if the x values of both vectors don't match and the y values don't match. 
            * Visibility: public 
            * Type: static bool operator
    * **File Name:** Matrix3.cs
        * **Struct Name:** Matrix3
        * Name: Matrix3()
            * Description: Takes in the rows and columns of the matrix3.
            * Visibility: public
        * Name: Identity(static Matrix3)
            * Description: Creates ans Identity Matrix3.
            * Visibility: public
        * Name: CreateRotation(float radians)
            * Description: Creates a new matrix that has been rotated by the given value in radians.
            * Visibility: public 
            * Type: static Matrix3
        * Name: CreateTranslation(float x, float y)
            * Description: Creates a new matrix that has been translated by the given x and y value.
            * Visibility: public
            * Type: static Matrix3
         * Name: CreateTranslation(Vector2 position)
            * Description: Creates a new matrix that has been translated by the given Vector2.
            * Visibility: public
            * Type: static Matrix3
         * Name: CreateScale(float x, float y)
            * Description: Creates a new matrix that has been scaled by the given value.
            * Visibility: public
            * Type: static Matrix3
         * Name: +(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 addition.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: -(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 subtraction.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: *(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 multiplication.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: *(Matrix3 lhs, Vector3 rhs)
            * Description: Overload for multiplying a matrix3 with a vector3.
            * Visibility: public
            * Type: static Matrix3 operator