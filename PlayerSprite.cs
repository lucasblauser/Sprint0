using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
public class PlayerSprite : ISprite
{
    public AnimatedSprite animatedSprite { get; private set;}
    public Animation[] animations { get; private set; }

    public PlayerSprite(AnimatedSprite sprite, Animation[] animations)
    {
        this.animatedSprite = sprite;
        this.animations = animations;
    }
    public void Update(GameTime gameTime)
    {
        animatedSprite.Update(gameTime);
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        animatedSprite.Draw(spriteBatch, position);
    }
    public void SetAnimation(Animation animation)
    {
        animatedSprite.Animation = animation;
    }
    public void SetAnimationSpeedMultiplier(float speed)
    {
        animatedSprite.animationSpeed = speed;
    }
}