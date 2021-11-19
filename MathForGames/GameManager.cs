using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class GameManager : Actor
    {
        private Scene _scene;
        public static int EnemyCount;
        public static bool PlayerIsDead;
        private UIText winText = new UIText(800, 450, "WinText", Color.WHITE, 300, 300, 40, "YOU WIN!");
        private UIText loseText = new UIText(800, 450, "LoseText", Color.WHITE, 300, 300, 40, "YOU LOSE!");

        /// <param name="x">The x position on the world</param>
        /// <param name="y">The y position in the world</param>
        /// <param name="currentScene">The current scene the manager is in</param>
        /// <param name="name">The game manager's name</param>
        /// <param name="path">The sprite path</param>
        public GameManager(float x, float y, Scene currentScene, string name = "Manager", string path = "") : 
            base(x, y, name, path)
        {
            _scene = currentScene;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //If the enemy count is less than or equal to zero
            if (EnemyCount <= 0)
                //Display win text
                _scene.AddUIElement(winText);

            // If the player is dead
            if (PlayerIsDead)
                //DIsplay loss text
                _scene.AddUIElement(loseText);

            base.Update(deltaTime);
        }
    }
}
