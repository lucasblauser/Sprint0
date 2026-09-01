using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

public class PlatformPlayer : IPlayer
{
    public Vector2 position { get; private set; }
    public AnimatedSprite sprite { get; private set; }
    public Animation[] animations { get; private set; }
    public IController controller { get; private set; }
    public float movementSpeed { get; private set; }

    public PlatformPlayer(IController controller, Vector2 startPosition, AnimatedSprite sprite, Animation[] animations, float movementSpeed)
    {
        this.controller = controller;
        this.position = startPosition;
        this.sprite = sprite;
        this.animations = animations;
        this.movementSpeed = movementSpeed;
    }

    public void Update()
    {
         Vector2 direction = controller.movementDirection;
        float positionSpeed = movementSpeed;
        Animation idleRight = animations[0];
        Animation idleLeft = animations[1];
        Animation walkRight = animations[2];
        Animation walkLeft = animations[3];

        if(controller.isRunning)
        {
            positionSpeed *= 1.5f;
            sprite.animationSpeed = 1.5f;
        }
        else
        {
            sprite.animationSpeed = 1.0f;
        }
        this.position += direction * positionSpeed;

        if(direction.X > 0 && sprite.Animation != walkRight)
        {
            sprite.Animation = walkRight;
        }
        else if(direction.X < 0 && sprite.Animation != walkLeft)
        {
            sprite.Animation = walkLeft;
        }
        else if (direction.X == 0 && sprite.Animation == walkRight)
        {
            sprite.Animation = idleRight;
        }
        else if (direction.X == 0 && sprite.Animation == walkLeft)
        {
            sprite.Animation = idleLeft;
        }
    }
    
}