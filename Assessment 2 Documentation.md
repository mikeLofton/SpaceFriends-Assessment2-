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
    