using GameEngine;
using SFML.System;

namespace MyGame
{
    public class GameScene : Scene
    {
        private int _score = 0;
        private int _lives = 3;

        public int GetScore()
        {
            return _score;
        }

        public int GetLives()
        {
            return _lives;
        }

        public void IncreaseScore()
        {
            _score++;
        }
        public void DecreaseLives()
        {
            --_lives;
            if (_lives == 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
        public GameScene()
        {
            // Add background first so it renders behind everything
            Background background = new Background();
            AddGameObject(background);
            
            Ship ship = new Ship();
            AddGameObject(ship);
            MeteorSpawner meteor = new MeteorSpawner();
            AddGameObject(meteor);
            SpikeSpawner spike = new SpikeSpawner();
            AddGameObject(spike);
            
            
            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
        }
    }
}