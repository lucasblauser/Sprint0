using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
public interface ISprite
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch, Vector2 position);
    void SetAnimation(Animation animation);
    void SetAnimationSpeedMultiplier(float speed);

    AnimatedSprite animatedSprite { get; }
    Animation[] animations { get; }
}