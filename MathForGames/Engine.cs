﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _buffer;

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Called start for the entire application
            Start();

            //Loop until the application is told close
            while (!_applicationShouldClose)
            {
                Update();
                Draw();
                Thread.Sleep(50);
            }

            //Call end for the entire application
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            Scene scene = new Scene();
            Actor actor = new Actor('P', new MathLibrary.Vector2 { X = 0, Y = 0 }, "Actor1", ConsoleColor.Yellow);
            Actor actor2 = new Actor('A', new MathLibrary.Vector2 { X = 10, Y = 10 }, "Actor2", ConsoleColor.Green);
            Player player = new Player('@', 5, 5, 1, "Player", ConsoleColor.DarkMagenta);
            UIText healthText = new UIText(20, 4, "Health", ConsoleColor.Cyan, 50, 10, "This is a test. \n All the text inside if this box is not important at all.");

            scene.AddUIElement(healthText);
            scene.AddActor(actor);
            scene.AddActor(actor2);
            scene.AddActor(player);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();

            Console.CursorVisible = false;
        }
        
        /// <summary>
        /// Called everytime the gane loops
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
            _scenes[_currentSceneIndex].UpdateUI();

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            //Clears the stuff that was on the screen in the last frame
            _buffer = new Icon[Console.WindowWidth - 1, Console.WindowHeight - 1];

            //Reset the cursor position to the top so the previous screen is drawn over
            Console.SetCursorPosition(0, 0);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

            //Iterate through buffer
            for (int y = 0; y < _buffer.GetLength(1); y++)
            {
                for (int x = 0; x < _buffer.GetLength(0); x++)
                {
                    if (_buffer[x, y].Symbol == '\0')
                    {
                        _buffer[x, y].Symbol = ' ';
                    }

                    //Set console text color to be color of item at buffer
                    Console.ForegroundColor = _buffer[x, y].Color;
                    //Print the symbol of the item in the buffer
                    Console.Write(_buffer[x, y].Symbol);
                }

                //Skip a line once the end of a row had been reached
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Called when the application ends
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
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
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {
            //If there is no key being pressed...
            if (!Console.KeyAvailable)
                //...return
                return 0;

            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Adds the icon to the buffer to print to the screen in the next draw call.
        /// Prints the icon at the given position in the buffer.
        /// </summary>
        /// <param name="icon">The icon to draw</param>
        /// <param name="position">The position of the icon in the buffer</param>
        /// <returns>False if the position is outside the bounds of the buffer</returns>
        public static bool Render(Icon icon, Vector2 position)
        {
            //If the position is out of bounds...
            if (position.X < 0 || position.X >= _buffer.GetLength(0) || position.Y < 0 || position.Y >= _buffer.GetLength(1))
                //...return false
                return false;

            //Set the buffer at the index of the given postition to be the icon
            _buffer[(int)position.X, (int)position.Y] = icon;
            return true;
        }

        /// <summary>
        /// Ends the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
