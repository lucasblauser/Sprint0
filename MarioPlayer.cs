using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

public class MarioPlayer : I2DPlatformPlayer
{
    public Vector2 position { get; private set; }
    public ISprite sprite { get; private set; }
    public IController controller { get; private set; }
    public float movementSpeed { get; private set; }

    public MarioPlayer(IController controller, Vector2 startPosition, ISprite sprite, float movementSpeed)
    {
        this.controller = controller;
        this.position = startPosition;
        this.sprite = sprite;
        this.movementSpeed = movementSpeed;
    }

    public void Update(GameTime gameTime)
    {
         Vector2 direction = controller.movementDirection;
        float positionSpeed = movementSpeed;
        Animation idleRight = sprite.animations[0];
        Animation idleLeft = sprite.animations[1];
        Animation walkRight = sprite.animations[2];
        Animation walkLeft = sprite.animations[3];

        if(controller.isRunning)
        {
            positionSpeed *= 1.5f;
            sprite.SetAnimationSpeedMultiplier(1.5f);
        }
        else
        {
            sprite.SetAnimationSpeedMultiplier(1.0f);
        }

        this.position += direction * positionSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(direction.X > 0 && sprite.animatedSprite.Animation != walkRight)
        {
            sprite.SetAnimation(walkRight);
        }
        else if(direction.X < 0 && sprite.animatedSprite.Animation != walkLeft)
        {
            sprite.SetAnimation(walkLeft);
        }
        else if (direction.X == 0 && sprite.animatedSprite.Animation == walkRight)
        {
            sprite.SetAnimation(idleRight);
        }
        else if (direction.X == 0 && sprite.animatedSprite.Animation == walkLeft)
        {
            sprite.SetAnimation(idleLeft);
        }

        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, position);
    }
}