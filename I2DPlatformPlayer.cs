using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
public interface I2DPlatformPlayer
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);

    IController controller { get; }
    Vector2 position { get; }
    ISprite sprite { get; }
    float movementSpeed { get; }
}