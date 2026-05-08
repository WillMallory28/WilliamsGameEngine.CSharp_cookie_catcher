using GameEngine;
using SFML.System;

namespace MyGame
{
    public class GameScene : Scene
    {
        private int _score = 0;

        public int GetScore()
        {
            return _score;
        }

        public void IncreaseScore()
        {
            _score++;
        }
        public GameScene()
        {
            Ship ship = new Ship();
            AddGameObject(ship);
            MeteorSpawner meteor = new MeteorSpawner();
            AddGameObject(meteor);
            
            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
        }
    }
}