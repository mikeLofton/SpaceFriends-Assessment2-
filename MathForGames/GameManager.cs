using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class GameManager : Actor
    {
        public static int EnemyCount;

        public GameManager(float x, float y, string name = "GameManager", string path = "") : 
            base(x, y, name, path)
        {

        }
    }
}
