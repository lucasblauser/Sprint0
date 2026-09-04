using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

public class Mario : I2DPlatformPlayer
{
    public Vector2 position { get; private set; }
    public ISprite sprite { get; private set; }
    public IController controller { get; private set; }
    public float movementSpeed { get; private set; }

    public Mario(IController controller, Vector2 startPosition, TextureAtlas atlas)
    {
        this.controller = controller;
        this.position = startPosition;

        AnimatedSprite animatedSprite = atlas.CreateAnimatedSprite("mario-idle-right");
        animatedSprite.CenterOrigin();
        animatedSprite.Scale *= 4.0f;

        this.sprite = new PlayerSprite(animatedSprite, new Animation[4]);

        this.sprite.animations[0] = atlas.GetAnimation("mario-idle-right");
        this.sprite.animations[1] = atlas.GetAnimation("mario-idle-left");
        this.sprite.animations[2] = atlas.GetAnimation("mario-walk-right");
        this.sprite.animations[3] = atlas.GetAnimation("mario-walk-left");

        this.movementSpeed = 300.0f; // pixels / second
    }

    public void Update(GameTime gameTime)
    {
        controller.Update();

         Vector2 direction = controller.movementDirection;
        float positionSpeed = movementSpeed;
        Animation idleRight = sprite.animations[0];
        Animation idleLeft = sprite.animations[1];
        Animation walkRight = sprite.animations[2];
        Animation walkLeft = sprite.animations[3];

        if(controller.isRunning)
        {
            positionSpeed *= 1.5f;
            sprite.SetAnimationSpeedMultiplier(2.0f);
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