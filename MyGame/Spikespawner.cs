using GameEngine;
using SFML.System;

namespace MyGame
{
    class SpikeSpawner : GameObject
    {
        private const int SpawnDelay = 2250;
        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;

            if (_timer <= 0)
            {
                _timer = SpawnDelay;

                Vector2u size = Game.RenderWindow.Size;

                float spikeX = Game.Random.Next() % size.X;
                float spikeY = -100;

                Spike spike = new Spike(new Vector2f(spikeX, spikeY));
                Game.CurrentScene.AddGameObject(spike);
            }
        }
    }
}