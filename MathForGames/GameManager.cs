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
        UIText winText = new UIText(800, 450, "WinText", Color.WHITE, 300, 300, 40, "YOU WIN!");
        UIText loseText = new UIText(800, 450, "LoseText", Color.WHITE, 300, 300, 40, "YOU LOSE!");

        public GameManager(float x, float y, Scene currentScene, string name = "Manager", string path = "") : 
            base(x, y, name, path)
        {
            _scene = currentScene;
        }

        public override void Update(float deltaTime)
        {
            if (EnemyCount <= 0)
                _scene.AddUIElement(winText);

            if (PlayerIsDead)
                _scene.AddUIElement(loseText);

            base.Update(deltaTime);
        }
    }
}
