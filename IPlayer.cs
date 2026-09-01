using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
public interface IPlayer
{
    void Update(GameTime gameTime);

    IController controller { get; }
    Vector2 position { get; }
    AnimatedSprite sprite { get; }
    Animation[] animations { get; }
    float movementSpeed { get; }
}