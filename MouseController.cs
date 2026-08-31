using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

public class MouseController : IController
{
    public Vector2 movementDirection { get; private set; }
    public bool isRunning { get; private set; }
    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        Vector2 direction = Vector2.Zero;

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            direction.X -= 1;
        }
        if (mouseState.RightButton == ButtonState.Pressed)
        {
            direction.X += 1;
        }

        movementDirection = direction;
        isRunning = mouseState.MiddleButton == ButtonState.Pressed;
    }
}