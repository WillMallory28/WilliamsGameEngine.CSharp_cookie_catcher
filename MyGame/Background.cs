using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class Background : GameObject
    {
        private const float ScrollSpeed = 0.05f; // Slow scrolling speed
        private readonly Sprite _sprite = new Sprite();
        private float _scrollOffset = 0f;

        public Background()
        {
            _sprite.Texture = Game.GetTexture("Resources/background.png");
            _sprite.Position = new Vector2f(0, 0);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            
            // Update scroll offset
            _scrollOffset += ScrollSpeed * msElapsed;
            
            // Wrap around to create seamless scrolling
            float textureWidth = _sprite.Texture.Size.X;
            if (_scrollOffset > textureWidth)
            {
                _scrollOffset -= textureWidth;
            }
            
            // Update sprite position for scrolling effect
            _sprite.Position = new Vector2f(-_scrollOffset, 0);
        }

        public override void Draw()
        {
            // Draw the main background sprite
            Game.RenderWindow.Draw(_sprite);
            
            // Draw a second copy right after for seamless scrolling
            Sprite secondBg = new Sprite(_sprite);
            secondBg.Position = new Vector2f(_sprite.Texture.Size.X - _scrollOffset, 0);
            Game.RenderWindow.Draw(secondBg);
        }
    }
}
