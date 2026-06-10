using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Spike : GameObject
    {
        private const float Speed = 0.5f;
        private readonly Sprite _sprite = new Sprite();

        public Spike(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/spike.png");
            _sprite.Position = pos;

            AssignTag("spike");
            SetCollisionCheckEnabled(true);
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("ship"))
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives(); // Damage the player

                MakeDead(); // Remove spike after hit
            }
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.Y > Game.RenderWindow.Size.Y)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(
                    pos.X,
                    pos.Y + Speed * msElapsed
                );
            }
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
    }
}