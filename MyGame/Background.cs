using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class Background : GameObject
    {
        private const float ScrollSpeed = 0.0f; //changed to 0 to stop the backround from scrolling
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
            
            // makes the backround scroll independent of the frame rate
            _scrollOffset += ScrollSpeed * msElapsed;
            
            // wraps the backround so seemless
            float textureWidth = _sprite.Texture.Size.X;
            if (_scrollOffset > textureWidth)
            {
                _scrollOffset -= textureWidth;
            }
            
            _sprite.Position = new Vector2f(-_scrollOffset, 0);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
            
            // creates the second backround to make seemless
            Sprite secondBg = new Sprite(_sprite);
            secondBg.Position = new Vector2f(_sprite.Texture.Size.X - _scrollOffset, 0);
            Game.RenderWindow.Draw(secondBg);
        }
    }
}
