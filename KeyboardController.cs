using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

public class KeyboardController : IController
{
    public Vector2 movementDirection { get; private set; }
    public bool isRunning { get; private set; }
    public void Update()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            direction.Y -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            direction.Y += 1;
        }

        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            direction.X -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            direction.X += 1;
        }

        movementDirection = direction;
        isRunning = keyboardState.IsKeyDown(Keys.Space);
    }
}