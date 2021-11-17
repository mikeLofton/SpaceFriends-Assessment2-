using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Called start for the entire application
            Start();

            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loop until the application is told close
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                //Get how much time has passed since the application started
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set delta time to be the difference in time from the last time to the current time
                deltaTime = currentTime - lastTime;

                //Update the application
                Update(deltaTime);
                //Draw all items
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currentTime;
            }

            //Call end for the entire application
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            _stopwatch.Start();

            //Create a window using Raylib
            Raylib.InitWindow(1600, 900, "ShooterTurtle");
            Raylib.SetTargetFPS(60);

            InitializeSceneObjects();                              
        }
        
        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Called when the application ends
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a scene to the engine's scene array
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index where the new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Creates a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy all values from old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //Return the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Ends the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }

        private void InitializeSceneObjects()
        {
            Scene scene = new Scene();

            Player player = new Player(800, 450, 100, scene, "Turtle", "Images/Turtle.png");
            player.SetScale(50, 50);
            AABBCollider playerBoxCollider = new AABBCollider(50, 50, player);
            player.Collider = playerBoxCollider;

            Baby baby1 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby1.SetScale(0.7f, 0.7f);
            baby1.SetTranslation(-1, 0);
            AABBCollider baby1BoxCollider = new AABBCollider(30, 30, baby1);
            baby1.Collider = baby1BoxCollider;

            Baby baby2 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby2.SetScale(0.7f, 0.7f);
            baby2.SetTranslation(-1, 1);
            AABBCollider baby2BoxCollider = new AABBCollider(30, 30, baby2);
            baby2.Collider = baby2BoxCollider;

            Baby baby3 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby3.SetScale(0.7f, 0.7f);
            baby3.SetTranslation(0, 1);
            AABBCollider baby3BoxCollider = new AABBCollider(30, 30, baby3);
            baby3.Collider = baby3BoxCollider;

            Baby baby4 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby4.SetScale(0.7f, 0.7f);
            baby4.SetTranslation(1, 1);
            AABBCollider baby4BoxCollider = new AABBCollider(30, 30, baby4);
            baby4.Collider = baby4BoxCollider;

            Baby baby5 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby5.SetScale(0.7f, 0.7f);
            baby5.SetTranslation(1, 0);
            AABBCollider baby5BoxCollider = new AABBCollider(30, 30, baby5);
            baby5.Collider = baby5BoxCollider;

            Baby baby6 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby6.SetScale(0.7f, 0.7f);
            baby6.SetTranslation(1, -1);
            AABBCollider baby6BoxCollider = new AABBCollider(30, 30, baby6);
            baby6.Collider = baby6BoxCollider;

            Baby baby7 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby7.SetScale(0.7f, 0.7f);
            baby7.SetTranslation(0, -1);
            AABBCollider baby7BoxCollider = new AABBCollider(30, 30, baby7);
            baby7.Collider = baby7BoxCollider;

            Baby baby8 = new Baby(1, 1, scene, "Baby", "Images/Baby.png");
            baby8.SetScale(0.7f, 0.7f);
            baby8.SetTranslation(-1, -1);
            AABBCollider baby8BoxCollider = new AABBCollider(30, 30, baby8);
            baby8.Collider = baby8BoxCollider;

            Enemy enemy1 = new Enemy(60, 60, 70, 1, player, scene, "Shark1", "Images/Shark.png");
            enemy1.SetScale(105, 50);
            CircleCollider enemy1CircleCollider = new CircleCollider(45, enemy1);
            enemy1.Collider = enemy1CircleCollider;

            Enemy enemy3 = new Enemy(300, 50, 70, 1, player, scene, "Shark1", "Images/Shark.png");
            enemy3.SetScale(105, 50);
            CircleCollider enemy3CircleCollider = new CircleCollider(45, enemy3);
            enemy3.Collider = enemy3CircleCollider;

            Enemy enemy5 = new Enemy(50, 250, 70, 1, player, scene, "Shark1", "Images/Shark.png");
            enemy5.SetScale(105, 50);
            CircleCollider enemy5CircleCollider = new CircleCollider(45, enemy5);
            enemy5.Collider = enemy5CircleCollider;

            Enemy enemy7 = new Enemy(50, 600, 70, 1, player, scene, "Shark1", "Images/Shark.png");
            enemy7.SetScale(105, 50);
            CircleCollider enemy7CircleCollider = new CircleCollider(45, enemy7);
            enemy7.Collider = enemy7CircleCollider;

            Enemy enemy2 = new Enemy(1500, 850, 50, 2, player, scene, "Clam1", "Images/clam.png");
            enemy2.SetScale(50, 50);
            CircleCollider enemy2CircleCollider = new CircleCollider(45, enemy2);
            enemy2.Collider = enemy2CircleCollider;

            Enemy enemy4 = new Enemy(1500, 550, 50, 2, player, scene, "Clam1", "Images/clam.png");
            enemy4.SetScale(50, 50);
            CircleCollider enemy4CircleCollider = new CircleCollider(45, enemy4);
            enemy4.Collider = enemy4CircleCollider;

            Enemy enemy6 = new Enemy(900, 850, 50, 2, player, scene, "Clam1", "Images/clam.png");
            enemy6.SetScale(50, 50);
            CircleCollider enemy6CircleCollider = new CircleCollider(45, enemy6);
            enemy6.Collider = enemy6CircleCollider;

            Enemy enemy8 = new Enemy(1500, 250, 50, 2, player, scene, "Clam1", "Images/clam.png");
            enemy8.SetScale(50, 50);
            CircleCollider enemy8CircleCollider = new CircleCollider(45, enemy8);
            enemy8.Collider = enemy8CircleCollider;

            GameManager gameManager = new GameManager(1, 1, scene);
            GameManager.EnemyCount = 8;
            GameManager.PlayerIsDead = false;

            //Add all children to player
            player.AddChild(baby1);
            player.AddChild(baby2);
            player.AddChild(baby3);
            player.AddChild(baby4);
            player.AddChild(baby5);
            player.AddChild(baby6);
            player.AddChild(baby7);
            player.AddChild(baby8);

            //Add player to scene
            scene.AddActor(player);

            //Add Babies to scene
            scene.AddActor(baby1);
            scene.AddActor(baby2);
            scene.AddActor(baby3);
            scene.AddActor(baby4);
            scene.AddActor(baby5);
            scene.AddActor(baby6);
            scene.AddActor(baby7);
            scene.AddActor(baby8);

            //Add the game manager
            scene.AddActor(gameManager);

            //Add sharks to scene
            scene.AddActor(enemy1);
            scene.AddActor(enemy3);
            scene.AddActor(enemy5);
            scene.AddActor(enemy7);

            //Add clams to scene
            scene.AddActor(enemy2);
            scene.AddActor(enemy4);
            scene.AddActor(enemy6);
            scene.AddActor(enemy8);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();
        }
    }
}
